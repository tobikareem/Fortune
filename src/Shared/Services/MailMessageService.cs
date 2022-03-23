using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using Shared.Interfaces.Services;

namespace Shared.Services
{
    public class MailMessageService : IMailMessage
    {

        public MailMessageService()
        {
        }

        public void SendMessage(string from, string to, string subject, string body)
        {

            var message = new MailMessage(from, to, subject, body)
            {
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8
            };

            message.IsBodyHtml = true;


            var client = new SmtpClient("smtpout.secureserver.net");
            client.Port = 80;
            client.Credentials = new System.Net.NetworkCredential("", "");

            client.SendCompleted += (s, e) =>
            {
                // Get the unique identifier for this asynchronous operation.
                var token = e.UserState as string;

                if (e.Cancelled)
                {
                    Console.WriteLine("[{0}] Send canceled.", token);
                }
                if (e.Error != null)
                {
                    Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
                }
                else
                {
                    Console.WriteLine("Message sent.");
                }
            };

            string userState = "Test Message";

            client.SendAsync(message, userState);

            message.Dispose();
        }

    }
}
