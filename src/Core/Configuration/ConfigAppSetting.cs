
using Newtonsoft.Json;

namespace Core.Configuration
{
    public class ConfigAppSetting
    {
        public const string FacebookSignInOptions = "Authentications:FacebookSignIn";
        public const string TwitterSignInOptions = "Authentications:TwitterSignIn";
        public const string GoogleDriveApiOptions = "Authentications:GoogleDriveApi";
        public const string GoogleAnalyticsOptions = "Authentications:GoogleAnalytics";
        public const string ConnectionStringsOptions = "ConnectionStrings";
        public const string EmailPropOptions = "EmailProp";
        public const string SinglePropertyOptions = "SingleProperty";
        public const string SpotifyOptions = "Authentications:Spotify";
        public const string InstagramOptions = "Authentications:Instagram";

        [JsonProperty("SingleProperty")]
        public SingleProperty SingleProperty { get; set; }

        [JsonProperty("ConnectionStrings")]
        public ConnectionStrings ConnectionStrings { get; set; }

        [JsonProperty("EmailProp")]
        public EmailProp EmailProp { get; set; }

        [JsonProperty("Authentications")]
        public Authentications Authentications { get; set; }

        [JsonProperty("AppEndPoint")]
        public string AppEndPoint { get; set; }
        
        [JsonProperty("ProductionLabelFilter")]
        public string ProductionLabelFilter { get; set; }
    }

    public class SingleProperty
    {
        [JsonProperty("Sentinel")]
        public double Sentinel { get; set; }
        
        [JsonProperty("ASPNETCORE_ENVIRONMENT")]
        public string Aspnetcoreenvironment { get; set; }        
        
        [JsonProperty("DbContext")]
        public string DbContext { get; set; }

        [JsonProperty("ProductionLabelFilter")]
        public string ProductionLabelFilter { get; set; }

        [JsonProperty("ProjectName")]
        public string ProjectName { get; set; }

        [JsonProperty("MyGoogleEmail")]
        public string MyGoogleEmail { get; set; }

        [JsonProperty("AppEndPoint")]
        public string AppEndPoint { get; set; }
    }
    
    public class ConnectionStrings
    {
        [JsonProperty("DefaultConnection")]
        public string DefaultConnection { get; set; }

        [JsonProperty("AppConfiguration")]
        public string AppConfiguration { get; set; }

        [JsonProperty("ProductionConnection")]
        public string ProductionConnection { get; set; }
    }

    public class EmailProp
    {
        [JsonProperty("FromEmail")]
        public string FromEmail { get; set; }

        [JsonProperty("MyEmailName")]
        public string MyEmailName { get; set; }

        [JsonProperty("EmailSubject")]
        public string EmailSubject { get; set; }

        [JsonProperty("SendGridApiKey")]
        public string SendGridApiKey { get; set; }
    }

    public class GoogleAnalytics
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("projectid")]
        public string Projectid { get; set; }

        [JsonProperty("privatekeyid")]
        public string Privatekeyid { get; set; }

        [JsonProperty("privatekey")]
        public string Privatekey { get; set; }

        [JsonProperty("clientemail")]
        public string Clientemail { get; set; }

        [JsonProperty("clientid")]
        public string Clientid { get; set; }

        [JsonProperty("authuri")]
        public string Authuri { get; set; }

        [JsonProperty("tokenuri")]
        public string Tokenuri { get; set; }

        [JsonProperty("authproviderx509certurl")]
        public string Authproviderx509Certurl { get; set; }

        [JsonProperty("clientx509certurl")]
        public string Clientx509Certurl { get; set; }
    }

    public class GoogleDriveApi
    {
        [JsonProperty("tokentype")]
        public string Tokentype { get; set; }

        [JsonProperty("expiresin")]
        public int Expiresin { get; set; }

        [JsonProperty("refreshtoken")]
        public string Refreshtoken { get; set; }

        [JsonProperty("oauthclientId")]
        public string OauthclientId { get; set; }

        [JsonProperty("oauthclientsecret")]
        public string Oauthclientsecret { get; set; }

        [JsonProperty("apikey")]
        public string Apikey { get; set; }

        [JsonProperty("googledrivescope")]
        public string Googledrivescope { get; set; }

        [JsonProperty("googledriveTokenRequestUrl")]
        public string GoogledriveTokenRequestUrl { get; set; }
    }

    public class FacebookSignIn
    {
        [JsonProperty("facebookappid")]
        public string Facebookappid { get; set; }

        [JsonProperty("facebookappsecret")]
        public string Facebookappsecret { get; set; }
    }

    public class TwitterSignIn
    {
        [JsonProperty("twitterconsumerkey")]
        public string Twitterconsumerkey { get; set; }

        [JsonProperty("twitterconsumersecret")]
        public string Twitterconsumersecret { get; set; }
        
        [JsonProperty("twitterbearer")]
        public string TwitterBearer { get; set; }

        [JsonProperty("twitteraccesstoken")] 
        public string TwitterAccessToken { get; set; }

        [JsonProperty("twitteraccesstokensecret")]
        public string TwitterAccessTokenSecret { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public class Spotify : AppClientInfo
    {
        public string SpotifyCode { get; set; }
    }

    public class Instagram : AppClientInfo
    {
        public string AuthorizeUri { get; set; }
    }

    public class Authentications
    {
        [JsonProperty("GoogleAnalytics")]
        public GoogleAnalytics GoogleAnalytics { get; set; }

        [JsonProperty("GoogleDriveApi")]
        public GoogleDriveApi GoogleDriveApi { get; set; }

        [JsonProperty("FacebookSignIn")]
        public FacebookSignIn FacebookSignIn { get; set; }

        [JsonProperty("TwitterSignIn")]
        public TwitterSignIn TwitterSignIn { get; set; }
    }


    public class AppClientInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string Scope { get; set; }
    }
}
