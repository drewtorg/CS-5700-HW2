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
        public int ID { get; private set; }
        public Dictionary<int, RacerTracker> Racers { get; private set; }
        public int BlockMin { get; private set; }
        public int BlockMax { get; private set; }
        public DateTime StartTime { get; private set; }

        public RaceGroup(int id, string label, int numberBlockMin, int numberBlockMax, DateTime startTime)
        {
            ID = id;
            Label = label;
            StartTime = startTime;
            BlockMin = numberBlockMin;
            BlockMax = numberBlockMax;
            Racers = new Dictionary<int, RacerTracker>();
        }

        public void AddRacer(RacerTracker r)
        {
            if (BlockMin <= r.Racer.Bib && r.Racer.Bib <= BlockMax)
                Racers.Add(r.Racer.Bib, r);
            else
                throw new ArgumentOutOfRangeException("Racer bib number out of range");
        }
    }
}
