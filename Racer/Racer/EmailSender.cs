using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Racer
{
    public class EmailSender : Sender
    {
        private const string username = "your_email@gmail.com";
        private const string password = "your_email@gmail.com";
        private const string host = "smtp.gmail.com";
        private const int port = 587;

        public EmailSender()
        {
        }

        virtual public void Send(string to, string subject, string message)
        {
            SmtpClient client = new SmtpClient(host, port);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(username, password);

            MailMessage mail = new MailMessage(to, username);
            mail.Subject = subject;
            mail.Body = message;

            client.Send(mail);

            //Use this to test without actually sending emails
            //Console.WriteLine("To: {0}\nFrom: {1}\nSubject:{2}\n{3}", to, username, subject, message);
        }

        virtual public string AppendMessage(string message)
        {
            return message;
        }
    }
}
