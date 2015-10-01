using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Racer
{
    public class EmailSender : Sender
    {
        private const string username = "donotreply@contest.com";

        public EmailSender()
        {
        }

        virtual public void Send(string to, string subject, string message)
        {
            MailMessage mail = new MailMessage(to, username);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);

            //Console.WriteLine("To: {0}\nFrom: {1}\nSubject:{2}\n{3}", to, username, subject, message);
        }

        virtual public string AppendMessage(string message)
        {
            return message;
        }
    }
}
