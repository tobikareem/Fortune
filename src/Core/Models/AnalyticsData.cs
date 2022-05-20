

namespace Core.Models
{
    public class AnalyticsData
    {
        public string Browser { get; set; }
        public string OperatingSystem { get; set; }
        public string MobileDeviceInfo { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int UserCount { get; set; }
        public int SessionCount { get; set; }
    }
}
