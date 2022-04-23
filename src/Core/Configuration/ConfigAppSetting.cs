
using Newtonsoft.Json;

namespace Core.Configuration
{
    public class ConfigAppSetting
    {
        public const string AzureAppConfigConnString = "APP_CONFIG_CONNECTION_STRING";
        public const string ProductionLabelFilter = "Production";
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public EmailProp EmailProp { get; set; }
        public string AppEndPoint { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }

        public ConfigAppSetting()
        {
            EmailProp = new EmailProp();
            Logging = new Logging();
            ConnectionStrings = new ConnectionStrings();
        }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        public string MicrosoftAspNetCore { get; set; }

    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }

        public Logging()
        {
            LogLevel = new LogLevel();
        }
    }

    public class EmailProp
    {
        public string FromEmail { get; set; }
        public string EmailSubject { get; set; }

        public string MyEmailName { get; set; }
        public string SendGridApiKey { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string AppConfiguration { get; set; }
    }

    public class GoggleAnalytics
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("projectid")]
        public string ProjectId { get; set; }

        [JsonProperty("private_key_id")]
        public string PrivateKeyId { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        [JsonProperty("client_email")]
        public string ClientEmail { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("auth_uri")]
        public string AuthUri { get; set; }

        [JsonProperty("token_uri")]
        public string TokenUri { get; set; }

        [JsonProperty("auth_provider_x509_cert_url")]
        public string AuthProviderX509CertUrl { get; set; }

        [JsonProperty("client_x509_cert_url")]
        public string ClientX509CertUrl { get; set; }
    }
    


}
