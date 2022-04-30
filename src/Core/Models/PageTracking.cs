
namespace Core.Models
{
    public class PageTracking
    {
        private string _endPoint;
        public string EndPoint
        {
            get => _endPoint;
            set => _endPoint = value.Length > 100 ? value[..100] : value;
        }

        public string Method { get; set; }

        public double Duration { get; set; }

        public string Error { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Message
        {
            get
            {
                var message = $"... Duration:  {Duration}. ${(string.IsNullOrWhiteSpace(Error) ? "" : $"Error: {Error}")} - Requested Endpoint: {EndPoint} - Method: {Method} - CreatedAt: {CreatedAt :yyyy-M-d dddd hh:mm}";

                return message;
            }
        }
    }
}
