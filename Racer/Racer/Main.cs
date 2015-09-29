using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Racer
{
    public static class Runner
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RaceManager manager = new RaceManager();
            SupportObserver obs = new SupportObserver("emailme@dot.com");
            //CheatingDetector detector = new CheatingDetector(manager.Groups);
            BigScreenForm bigScreen = new BigScreenForm(manager);
            List<int> bibs = manager.Racers.Keys.ToList();
            obs.Subscribe(manager.Racers[bibs[1]]);


            manager.AddObserver(obs);

            obs.Subscribe(manager.Racers[bibs[0]]);

            //manager.AddObserver(detector);

            manager.Start();

            obs.Subscribe(manager.Racers[bibs[3]]);


            Application.Run(new BigScreenForm(manager));
        }
    }
}
