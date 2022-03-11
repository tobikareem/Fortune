
namespace Core.Interfaces.Services
{
    public interface IMailMessage
    {
        void SendMessage(string from, string to, string subject, string body);
    }
}
