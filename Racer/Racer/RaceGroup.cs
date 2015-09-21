using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class RaceGroup
    {
        public string Label { get; private set; }
        public Dictionary<int, Racer> Racers { get; private set; }
        public HashSet<int> NumberBlock { get; private set; }
        public DateTime StartTime { get; private set; }

        private Random random;

        public RaceGroup(string label, int numberBlockMin, int numberBlockMax, DateTime startTime)
        {
            Label = label;
            StartTime = startTime;
            NumberBlock = new HashSet<int>();
            random = new Random();

            for (; numberBlockMin <= numberBlockMax; ++numberBlockMin)
                NumberBlock.Add(numberBlockMin);
        }

        public void AddRacer(Racer r)
        {
            int assignedNumber = (random.Next(NumberBlock.Min(), NumberBlock.Max()));
            NumberBlock.Remove(assignedNumber);
            r.Bib = assignedNumber;
            Racers.Add(assignedNumber, r);
        }
    }
}
