using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class EmailDecorator : EmailSender
    {
        public EmailSender Next { get; set; }

        public EmailDecorator(EmailSender next = null) : base()
        {
            Next = next;
        }

        override public void Send(string to, string subject, string message)
        {
            base.Send(to, subject, AppendMessage(message));
        }

        override public string AppendMessage(string message)
        {
            if (Next != null)
                return message + Next.AppendMessage(message);
            return message;
        }

    }
}
