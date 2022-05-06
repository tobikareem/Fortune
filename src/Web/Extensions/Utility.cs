using System.Text.RegularExpressions;

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
    }
}
