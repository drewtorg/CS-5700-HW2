using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    class RaceGroup : Subject
    {
        public string Label { get; private set; }
        public Dictionary<int, Racer> Racers { get; private set; }
        public HashSet<int> NumberBlock { get; private set; }
        public DateTime StartTime { get; private set; }

        public RaceGroup(string label, int numberBlockMin, int numberBlockMax, DateTime startTime)
        {
            Label = label;
            StartTime = startTime;
            NumberBlock = new HashSet<int>();

            for (; numberBlockMin <= numberBlockMax; ++numberBlockMin)
                NumberBlock.Add(numberBlockMin);
        }
    }
}
