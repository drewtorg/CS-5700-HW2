using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{

    public class EmailObserver : RacerObserver
    {
        public string SendTo { get; set; }
        private Sender sender;

        public EmailObserver(string to, string header = "", string footer = "", bool quotes = false)
        {
            SendTo = to;

            if(quotes)
                sender = new HeaderSender(header, new FooterSender(footer, new QuoteSender()));
            else
                sender = new HeaderSender(header, new FooterSender(footer));

        }

        public void Email(string subject, string message)
        {
            sender.Send(SendTo, subject, message);
        }

    }
}
