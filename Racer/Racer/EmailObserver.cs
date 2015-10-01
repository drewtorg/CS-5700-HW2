using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Racer
{

    public class EmailObserver : RacerObserver
    {
        public string SendTo { get; set; }
        private ISender sender;

        protected Timer timer;
        private const int INTERVAL = 5;

        public EmailObserver(string to, string header = "", string footer = "", bool quotes = false)
        {
            SendTo = to;

            if(quotes)
                sender = new HeaderSender(header, new FooterSender(footer, new QuoteSender()));
            else
                sender = new HeaderSender(header, new FooterSender(footer));

            timer = new Timer(new TimerCallback(EmailCallback), null,TimeSpan.FromMinutes(INTERVAL), TimeSpan.FromMinutes(INTERVAL));
        }

        protected string CreateRacersMessage(string header)
        {
            string message = header;
            foreach (var racer in Racers.Values)
            {
                message += (racer.ToString() + '\n');
            }
            return message;
        }

        protected virtual void EmailCallback(object state)
        {
            Email("Hello", "Goodbye");
        }
        
        public void Email(string subject, string message)
        {
            sender.Send(SendTo, subject, message);
        }

    }
}
