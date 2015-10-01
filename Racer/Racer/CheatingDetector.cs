using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class CheatingDetector : EmailObserver
    {
        private Dictionary<int, Racer> currentPositions;
        private Dictionary<int, Racer> lastPositions;

        private Dictionary<int, Racer> cheaters;

        private const string subjectString = "Cheaters Detected!";
        private const string messageHeader = "Here is an update of each cheater:\n";
        private const int TIME_BUFFER = 3;

        public CheatingDetector(string to, string header = "", string footer = "", bool quotes=false) : base(to, header, footer, quotes)
        {
            currentPositions = new Dictionary<int, Racer>();
            lastPositions = new Dictionary<int, Racer>();
            cheaters = new Dictionary<int, Racer>();
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

        protected override void EmailCallback(object state)
        {
            if (cheaters.Count > 0)
            {
                string message = CreateRacersMessage(messageHeader);
                Email(subjectString, message);
            }
        }

        private void DetectCheating(Racer racer)
        {
            foreach (Racer other in currentPositions.Values)
            {
                Racer prevRacer, prevOther;

                if (lastPositions.TryGetValue(other.Bib, out prevOther) && lastPositions.TryGetValue(racer.Bib, out prevRacer))
                    if (AreCheating(racer, other, prevRacer, prevOther))
                    {
                        lock(Lock)
                        {
                            cheaters.Add(racer.Bib, racer);
                            cheaters.Add(other.Bib, other);
                        }
                    }
            }
        }

        public bool AreCheating(Racer racer, Racer other, Racer prevRacer, Racer prevOther)
        {
            return (other.GroupID != racer.GroupID && other.Location == racer.Location && prevOther.Location == prevRacer.Location && Math.Abs((other.LastSeen - racer.LastSeen).Seconds) < TIME_BUFFER && Math.Abs((prevOther.LastSeen - prevRacer.LastSeen).Seconds) < TIME_BUFFER);
        }
    }
}
