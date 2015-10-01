using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Racer
{
    public static class RacerSimulator
    {
        [STAThread]
        public static void Main(string[] args)
        {
            QuoteSender sender = new QuoteSender(new HeaderSender("Heeelllo"));
            sender.Send("Drew", "Goodbye", "nope");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new ControlForm());
        }
    }
}
