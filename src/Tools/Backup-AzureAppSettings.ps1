<#
.SYNOPSIS
    Snapshot the current Azure App Service application settings to a timestamped,
    gitignored JSON file so the previous state can be restored after a change.

.DESCRIPTION
    Dumps the live App Service application settings (names + values) via the
    Azure CLI to:

        src/Tools/azure-appsettings-backup-<app>-<timestamp>.json

    The file contains live secrets and is gitignored (see .gitignore). The dump
    uses the same array shape that 'az ... appsettings set --settings @file'
    accepts, so a rollback is a single command (printed at the end).

    Run this BEFORE Sync-UserSecretsToAzure.ps1 (or any other settings change).

.EXAMPLE
    ./Backup-AzureAppSettings.ps1
    # ...later, to roll back:
    az webapp config appsettings set -n tobikareem -g FortuneWeb `
        --subscription <sub> --settings "@<backup-file>"

.NOTES
    Requires the Azure CLI (az) signed in to the owning tenant:
        az login --tenant c8882291-ad5a-41a3-b8a6-413a0ba91b2c
#>
[CmdletBinding()]
param(
    [string] $ResourceGroup = "FortuneWeb",
    [string] $AppName       = "tobikareem",
    [string] $Subscription  = "5a44eaa5-b35c-4847-8a7b-3c044351c78e",
    # Where to write the backup; defaults to this script's folder (src/Tools).
    [string] $OutDir        = (Split-Path -Parent $MyInvocation.MyCommand.Path)
)

$ErrorActionPreference = "Stop"

$timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
$outFile   = Join-Path $OutDir "azure-appsettings-backup-$AppName-$timestamp.json"

Write-Host "Backing up app settings for '$AppName' ($ResourceGroup)..." -ForegroundColor Cyan
$json = az webapp config appsettings list -n $AppName -g $ResourceGroup --subscription $Subscription
if ($LASTEXITCODE -ne 0) { throw "az webapp config appsettings list failed (exit $LASTEXITCODE)." }

# Validate it parsed and count entries before writing.
$parsed = $json | ConvertFrom-Json
$json | Set-Content -Path $outFile -Encoding utf8

Write-Host "Saved $($parsed.Count) settings to:" -ForegroundColor Green
Write-Host "  $outFile"
Write-Host "`nThis file is gitignored. To roll back to this snapshot:" -ForegroundColor Yellow
Write-Host "  az webapp config appsettings set -n $AppName -g $ResourceGroup --subscription $Subscription --settings `"@$outFile`""
