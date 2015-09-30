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
        public Dictionary<int, Racer> Racers { get; private set; }
        public int BlockMin { get; private set; }
        public int BlockMax { get; private set; }
        public DateTime StartTime { get; private set; }

        private const int MAX_RACERS = 100;

        public RaceGroup(int id, string label, int numberBlockMin, int numberBlockMax, DateTime startTime)
        {
            ID = id;
            Label = label;
            StartTime = startTime;
            BlockMin = numberBlockMin;
            BlockMax = numberBlockMax;
            Racers = new Dictionary<int, Racer>();
        }

        public void AddRacer(Racer r)
        {
            if (r != null && Racers.Count < MAX_RACERS && BlockMin <= r.Bib && r.Bib <= BlockMax && !Racers.ContainsKey(r.Bib) && r.GroupID == ID)
                Racers.Add(r.Bib, r);
        }
    }
}
