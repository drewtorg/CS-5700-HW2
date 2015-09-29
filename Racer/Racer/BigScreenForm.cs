using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racer
{
    public partial class BigScreenForm : Form
    {
        private object myLock = new object();
        private Dictionary<int, Racer> Racers = new Dictionary<int, Racer>();
        private Timer refreshTester = new Timer();
        private bool repaintNeeded = false;

        public int RefreshFrequency { get; set; }

        public BigScreenForm()
        {
            InitializeComponent();
            RefreshFrequency = 50;
        }

        public void Update(Racer r)
        {
            if (r != null)
            {
                lock (myLock)
                {
                    if (!Racers.ContainsKey(r.Bib))
                        Racers.Add(r.Bib, r);
                    else
                        Racers[r.Bib] = r;
                }
                repaintNeeded = true;
            }
        }

        private void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0)
                RefreshFrequency = 50;

            refreshTester.Interval = RefreshFrequency;
            refreshTester.Tick += refreshTimer_Tick;
            refreshTester.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (repaintNeeded)
            {
                lock (myLock)
                {
                    RefreshDisplay();
                    repaintNeeded = false;
                }
            }
        }

        private void RefreshDisplay()
        {
            racerView.Items.Clear();
            foreach (Racer racer in Racers.Values)
            {
                ListViewItem item = new ListViewItem(new string[]
                                                {
                                                    racer.FirstName,
                                                    racer.LastName,
                                                    racer.Bib.ToString(),
                                                    racer.GroupID.ToString(),
                                                    racer.Location.ToString(),
                                                    racer.LastSeen.ToLongTimeString()
                                                });
                racerView.Items.Add(item);
            }
        }

        private void BigScreenForm_Load(object sender, EventArgs e)
        {
            StartRefreshTimer();
        }
    }
}
