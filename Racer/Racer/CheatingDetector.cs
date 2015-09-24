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

        private const int TIME_BUFFER = 3;

        public CheatingDetector(Dictionary<int, RaceGroup> groups)
        {
            currentPositions = new Dictionary<int, Racer>();
            lastPositions = new Dictionary<int, Racer>();

            foreach (var group in groups.Values)
                Subscribe(group);
        }

        public override void Update(Racer racer)
        {
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
                {
                    if (other.GroupID != racer.GroupID && other.Location == racer.Location && prevOther.Location == prevRacer.Location && Math.Abs((other.LastSeen - racer.LastSeen).Seconds) < TIME_BUFFER && Math.Abs((prevOther.LastSeen - prevRacer.LastSeen).Seconds) < TIME_BUFFER)
                    {
                        //TODO: email judges that these racers are cheating
                        Console.WriteLine(other.ToString() + " and " + racer.ToString() + " are cheating!!");
                    }
                }
           }
        }
    }
}
