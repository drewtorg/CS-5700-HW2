using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class SupportObsever : RacerObserver
    {
        public override void Update(Racer racer)
        {
            //TODO: Replace console output lines with email code
            Console.WriteLine(racer.ToString() + " at: " + racer.LastSeen.ToString());
        }
    }
}
