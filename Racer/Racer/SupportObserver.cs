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

        public SupportObserver(string to, string header="", string footer="", bool quotes=false) : base(to, header, footer, quotes)
        {
        }

        public override void Update(ISubject subject)
        {
            base.Update(subject);
            Racer racer = subject as Racer;
            Email(subjectString, racer.ToString() + " at: " + racer.LastSeen.ToString());
        }
    }
}
