<#
.SYNOPSIS
    Sync the Web project's User Secrets into the Azure App Service application
    settings, converting colon-nested keys to the double-underscore (__) form
    that .NET Core maps back to ':' at runtime.

.DESCRIPTION
    User Secrets are the source of truth for local development. Production has
    no User Secrets, so the same values must live as App Service application
    settings. .NET maps a DOUBLE underscore '__' in an env var / app setting
    name to the ':' configuration separator, so:

        User Secret  : Authentications:FacebookSignIn:facebookappid
        App Setting  : Authentications__FacebookSignIn__facebookappid
        Code reads   : config["Authentications:FacebookSignIn:facebookappid"]

    A SINGLE underscore is NOT a separator, which is why the previous
    single-underscore app settings never resolved and the app failed to start
    with "Facebook credentials are missing from configuration".

    Run this whenever you add or change a secret locally:
        - reads secrets.json directly (robust for multi-line values such as the
          Google service-account private key),
        - flattens nested JSON to colon keys,
        - skips dev-only / misplaced keys (see -ExcludeKeys),
        - SNAPSHOTS the current App Service settings first via
          Backup-AzureAppSettings.ps1 (rollback point; skip with -SkipBackup),
        - writes the '__' app settings to the App Service (idempotent; existing
          keys are updated, new ones added).

    The connection-string distinction you asked for: ConnectionStrings:DefaultConnection
    (the LocalDB dev connection) is EXCLUDED by default - production resolves the
    database from ConnectionStrings:ProductionConnection instead.

.PARAMETER WhatIf
    Preview the keys that would be written without changing anything in Azure.

.PARAMETER PruneLegacyUnderscore
    Also DELETE the old single-underscore variants (e.g. Authentications_FacebookSignIn_facebookappid)
    of every key this script manages. Off by default. Preview first with -WhatIf.

.EXAMPLE
    ./Sync-UserSecretsToAzure.ps1 -WhatIf
    ./Sync-UserSecretsToAzure.ps1
    ./Sync-UserSecretsToAzure.ps1 -PruneLegacyUnderscore

.NOTES
    Requires the Azure CLI (az) signed in to the tenant that owns the subscription:
        az login --tenant c8882291-ad5a-41a3-b8a6-413a0ba91b2c
#>
[CmdletBinding()]
param(
    [string]   $ResourceGroup = "FortuneWeb",
    [string]   $AppName       = "tobikareem",
    [string]   $Subscription  = "5a44eaa5-b35c-4847-8a7b-3c044351c78e",
    # If empty, the UserSecretsId is read from src/Web/Web.csproj.
    [string]   $UserSecretsId = "",
    # Colon keys (exact or prefix) that must NOT be pushed to production:
    #   ConnectionStrings:DefaultConnection -> LocalDB, dev only (prod uses ProductionConnection)
    #   Authentications:Logging             -> misplaced logging config; the app reads root "Logging"
    [string[]] $ExcludeKeys   = @("ConnectionStrings:DefaultConnection", "Authentications:Logging"),
    [switch]   $PruneLegacyUnderscore,
    # Skip the automatic pre-write backup (not recommended).
    [switch]   $SkipBackup,
    [switch]   $WhatIf
)

$ErrorActionPreference = "Stop"
$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot   = Resolve-Path (Join-Path $scriptRoot "..\..")

# --- Resolve the UserSecretsId from the Web project if not supplied ---------
if (-not $UserSecretsId) {
    $csproj = Join-Path $repoRoot "src\Web\Web.csproj"
    if (-not (Test-Path $csproj)) { throw "Cannot find $csproj to read UserSecretsId. Pass -UserSecretsId explicitly." }
    $match = Select-String -Path $csproj -Pattern '<UserSecretsId>(.*?)</UserSecretsId>' | Select-Object -First 1
    if (-not $match) { throw "No <UserSecretsId> in Web.csproj. Pass -UserSecretsId explicitly." }
    $UserSecretsId = $match.Matches[0].Groups[1].Value.Trim()
}

$secretsPath = Join-Path $env:APPDATA "Microsoft\UserSecrets\$UserSecretsId\secrets.json"
if (-not (Test-Path $secretsPath)) { throw "secrets.json not found at $secretsPath" }
Write-Host "User Secrets : $secretsPath" -ForegroundColor Cyan
Write-Host "Target       : $AppName ($ResourceGroup)`n" -ForegroundColor Cyan

# --- Flatten nested JSON into colon-delimited keys --------------------------
function ConvertTo-FlatConfig {
    param([Parameter(Mandatory)] $Node, [string] $Prefix = "")
    $out = [ordered]@{}
    foreach ($p in $Node.PSObject.Properties) {
        $key = if ($Prefix) { "$Prefix`:$($p.Name)" } else { $p.Name }
        if ($p.Value -is [System.Management.Automation.PSCustomObject]) {
            (ConvertTo-FlatConfig -Node $p.Value -Prefix $key).GetEnumerator() | ForEach-Object { $out[$_.Key] = $_.Value }
        }
        else {
            $out[$key] = "$($p.Value)"   # coerce to string (App Settings are strings)
        }
    }
    $out
}

$secrets = Get-Content -Raw -Path $secretsPath | ConvertFrom-Json
$flat    = ConvertTo-FlatConfig -Node $secrets

# --- Apply exclusions + warn on empties -------------------------------------
$settings = [ordered]@{}
foreach ($kv in $flat.GetEnumerator()) {
    $excluded = $ExcludeKeys | Where-Object { $kv.Key -eq $_ -or $kv.Key.StartsWith("$_`:") -or $kv.Key.StartsWith("$_") }
    if ($excluded) { Write-Host ("  skip  {0}" -f $kv.Key) -ForegroundColor DarkGray; continue }
    if ([string]::IsNullOrWhiteSpace($kv.Value)) { Write-Warning "Empty value for '$($kv.Key)' - review before relying on it in prod." }
    $appKey = $kv.Key -replace ':', '__'
    $settings[$appKey] = $kv.Value
}

Write-Host "`n$($settings.Count) setting(s) to write (as __ keys):" -ForegroundColor Green
$settings.Keys | ForEach-Object { Write-Host "  $_" }

if ($WhatIf) {
    Write-Host "`n-WhatIf: no changes made.`n" -ForegroundColor Yellow
    if ($PruneLegacyUnderscore) { Write-Host "(Would also prune single-underscore legacy keys for the same names.)" -ForegroundColor Yellow }
    return
}

# --- Safety: snapshot current settings before writing (rollback point) ------
if (-not $SkipBackup) {
    $backupScript = Join-Path $scriptRoot "Backup-AzureAppSettings.ps1"
    if (Test-Path $backupScript) {
        Write-Host "`nTaking a backup before writing..." -ForegroundColor Cyan
        & $backupScript -ResourceGroup $ResourceGroup -AppName $AppName -Subscription $Subscription -OutDir $scriptRoot
    }
    else {
        Write-Warning "Backup-AzureAppSettings.ps1 not found next to this script; proceeding WITHOUT a backup. Pass -SkipBackup to silence this."
    }
}

# --- Write to Azure (JSON file avoids quoting issues with multi-line values) -
$payload  = $settings.GetEnumerator() | ForEach-Object { [pscustomobject]@{ name = $_.Key; value = $_.Value; slotSetting = $false } }
$tmp      = Join-Path ([System.IO.Path]::GetTempPath()) ("appsettings_{0}.json" -f $UserSecretsId)
$payload | ConvertTo-Json -Depth 10 | Set-Content -Path $tmp -Encoding utf8
try {
    Write-Host "`nWriting settings to Azure..." -ForegroundColor Cyan
    az webapp config appsettings set -n $AppName -g $ResourceGroup --subscription $Subscription --settings "@$tmp" | Out-Null
    if ($LASTEXITCODE -ne 0) { throw "az webapp config appsettings set failed (exit $LASTEXITCODE)." }
    Write-Host "Done. $($settings.Count) settings synced." -ForegroundColor Green
}
finally {
    Remove-Item $tmp -ErrorAction SilentlyContinue
}

# --- Optional: remove the old single-underscore variants ---------------------
if ($PruneLegacyUnderscore) {
    Write-Host "`nPruning legacy single-underscore keys..." -ForegroundColor Cyan
    $legacyNames = $settings.Keys | ForEach-Object { $_ -replace '__', '_' }   # __ -> _ gives the old name
    $existing    = az webapp config appsettings list -n $AppName -g $ResourceGroup --subscription $Subscription | ConvertFrom-Json
    $toDelete    = $existing | Where-Object { $legacyNames -contains $_.name -and $_.name -notin $settings.Keys }
    if (-not $toDelete) { Write-Host "  Nothing to prune." -ForegroundColor DarkGray }
    foreach ($d in $toDelete) {
        Write-Host "  delete $($d.name)" -ForegroundColor DarkYellow
        az webapp config appsettings delete -n $AppName -g $ResourceGroup --subscription $Subscription --setting-names $d.name | Out-Null
    }
}
