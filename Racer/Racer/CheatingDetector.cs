using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class CheatingDetector : RacerObserver
    {
        private Dictionary<int, Racer> currentPositions;
        private Dictionary<int, Racer> lastPositions;

        public string SendTo { get; set; }
        private Sender sender;

        private const int TIME_BUFFER = 3;

        public CheatingDetector(string to, string header = "", string footer = "")
        {
            SendTo = to;
            currentPositions = new Dictionary<int, Racer>();
            lastPositions = new Dictionary<int, Racer>();
            sender = new HeaderSender(header, new FooterSender(footer));
        }

        public override void Update(ISubject subject)
        {
            base.Update(subject);
            Racer racer = subject as Racer;

            if (!currentPositions.ContainsKey(racer.Bib))
                currentPositions.Add(racer.Bib, racer);
            else
            {
                lastPositions[racer.Bib] = currentPositions[racer.Bib];
                currentPositions[racer.Bib] = racer;
                DetectCheating(racer);
            }
        }

        private void DetectCheating(Racer racer)
        {
            foreach (Racer other in currentPositions.Values)
            {
                Racer prevRacer, prevOther;

                if (lastPositions.TryGetValue(other.Bib, out prevOther) && lastPositions.TryGetValue(racer.Bib, out prevRacer))
                    if (AreCheating(racer, other, prevRacer, prevOther))
                        sender.Send(SendTo, "Cheaters detected!", other.ToString() + " and " + racer.ToString() + " are cheating!!");
           }
        }

        private bool AreCheating(Racer racer, Racer other, Racer prevRacer, Racer prevOther)
        {
            return (other.GroupID != racer.GroupID && other.Location == racer.Location && prevOther.Location == prevRacer.Location && Math.Abs((other.LastSeen - racer.LastSeen).Seconds) < TIME_BUFFER && Math.Abs((prevOther.LastSeen - prevRacer.LastSeen).Seconds) < TIME_BUFFER);
        }
    }
}
