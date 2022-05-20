using System.Globalization;
using System.Text.RegularExpressions;
using Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace Web.Extensions
{
    public static class Utility
    {
        public static string GetImageSrc(this string imageItem, byte[]? profileImageByte)
        {
            var imageData = string.Empty;
            if (profileImageByte != null)
            {
                imageData = Convert.ToBase64String(profileImageByte);
            }

            imageItem = $"data:image/png;base64,{imageData}";

            return string.IsNullOrWhiteSpace(imageData) ? string.Empty : imageItem;
        }

        public static string GetPlainTextFromHtml(string htmlText)
        {
            const string pattern = @"<(.|\n)*?>";
            var regex = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlText = regex.Replace(htmlText, string.Empty);
            htmlText = Regex.Replace(htmlText, pattern, string.Empty);
            htmlText = Regex.Replace(htmlText, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlText = Regex.Replace(htmlText, @"&nbsp;", " ", RegexOptions.IgnoreCase);
            htmlText = htmlText.Replace( @"&nbsp;;", string.Empty);
            
            return htmlText;
        }

        public static async Task AddAccessAndRefreshTokens(UserManager<ApplicationUser> userManager, ExternalLoginInfo info, ApplicationUser user)
        {
            var newAccessToken = info.AuthenticationTokens.FirstOrDefault((x => x.Name == "access_token"))?.Value;
            var newRefreshToken = info.AuthenticationTokens.FirstOrDefault(x => x.Name == "refresh_token")?.Value;
            var newExpiresIn = info.AuthenticationTokens.FirstOrDefault(x => x.Name == "expires_in")?.Value;


            if (!string.IsNullOrWhiteSpace(newAccessToken))
            {
                await userManager.SetAuthenticationTokenAsync(user, info.ProviderDisplayName, "access_token", newAccessToken);
            }

            if (!string.IsNullOrWhiteSpace(newRefreshToken))
            {
                await userManager.SetAuthenticationTokenAsync(user, info.ProviderDisplayName, "refresh_token", newRefreshToken);
            }

            if (!string.IsNullOrWhiteSpace(newExpiresIn))
            {
                var expiryTime = DateTime.Now.AddSeconds(Convert.ToInt32(newExpiresIn));
                await userManager.SetAuthenticationTokenAsync(user, info.ProviderDisplayName, "expires_in", expiryTime.ToString(CultureInfo.CurrentCulture));
            }
        }
    }
}
