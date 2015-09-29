using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class SupportObserver : RacerObserver
    {
        private Sender sender;
        
        public string SendTo { get; set; }

        public SupportObserver(string to, string header="", string footer="")
        {
            SendTo = to;
            sender = new HeaderSender(header, new FooterSender(footer));
        }

        public override void Update(Racer racer)
        {
            sender.Send(SendTo, "Racer Update", racer.ToString() + " at: " + racer.LastSeen.ToString());
        }
    }
}
