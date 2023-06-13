using Core.Configuration;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.Repository
{
    public interface IHttpRepository
    {
        Task<string> GetGoogleDriveAccessToken();
        Task<TweetData?> GetMyTweetsAsync();
        Task<AccessBearerToken> GetSpotifyAccessTokenAsync(string refreshToken);
    }
}
