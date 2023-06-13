using Core.Models;
using Data.Entity;
using SendGrid;
using SpotifyAPI.Web;
using File = Google.Apis.Drive.v3.Data.File;

namespace Shared.Interfaces.Services
{
    public interface IExternalApiCalls
    {
        Task<Response> SendGridEmail(string toEmail, string subject, string plainTextContent, string recipientName = "",
            string htmlContent = "");

        Task<TweetData> GetAllMyTweetsAsync();

        Task<List<AnalyticsData>> GetGoogleAnalyticsAsync();
        Task<List<File>> GetAllGoogleDrivePhotosAsync();

        Task<string> UploadFileToGoogleDriveAsync(Stream file, string fileName, string fileMime, string folder,
            string fileDescription);

        Task<string> CreateFolderOnGoogleDriveAsync(string parent, string folderName);

        Task DeleteFileOnGoogleDriveAsync(string fileId);

        Task<SpotifyClient> SpotifyClientBuilderAsync(ApplicationUser user);
    }
}
