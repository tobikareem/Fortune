
namespace Core.Configuration
{
    public class ConfigAppSetting
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public EmailProp EmailProp { get; set; }

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
        public string MyEmail { get; set; }
        public string Subject { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    
}
