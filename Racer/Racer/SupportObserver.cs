using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class SupportObserver : EmailObserver
    {
        private const string subjectString = "Racer Update";
        private const string messageHeader = "Here is an update for each of your racers:\n";

        public SupportObserver(string to, string header="", string footer="", bool quotes=false) : base(to, header, footer, quotes)
        {
        }

        protected override void EmailCallback(object state)
        {
            if (Racers.Count > 0)
            {
                string message = CreateRacersMessage(messageHeader);
                Email(subjectString, message);
            }
        }
    }
}
