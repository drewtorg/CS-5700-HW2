using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Racer
{
    public static class Runner
    {
        public static void Main(string[] args)
        {
            RaceManager manager = new RaceManager();
            SupportObsever obs = new SupportObsever();
            List<int> bibs = manager.Racers.Keys.ToList();
            obs.Subscribe(manager.Racers[bibs[1]]);

            //CheatingDetector detector = new CheatingDetector(manager.Groups);

            manager.AddObserver(obs);

            obs.Subscribe(manager.Racers[bibs[0]]);

            //manager.AddObserver(detector);

            manager.Start();

            obs.Subscribe(manager.Racers[bibs[3]]);


            while (true)
            {
                Thread.Sleep(100);
            }

        }
    }
}
