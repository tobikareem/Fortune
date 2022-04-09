
namespace Shared.Interfaces.Services
{
    public interface IServiceCalls
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject">confirm email</param>
        /// <param name="body">confirmation link</param>
        void SendMessage(string from, string to, string subject, string body);


        Task GetGoggleAnalytics();
    }
}
