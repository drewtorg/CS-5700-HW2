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
        private Timer refreshTester = new Timer();
        private bool repaintNeeded = false;

        public RacerObserver Observer { get; set; }

        public int RefreshFrequency { get; set; }

        public BigScreenForm()
        {
            InitializeComponent();
            RefreshFrequency = 50;
        }

        public void Update(Racer r)
        {
            if (r != null)
                repaintNeeded = true;
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
            if (repaintNeeded || Observer.Racers.Count == 0)
            {
                lock (Observer.Lock)
                {
                    RefreshDisplay();
                    repaintNeeded = false;
                }
            }
        }

        private void RefreshDisplay()
        {
            racerView.Items.Clear();
            foreach (Racer racer in Observer.Racers.Values)
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
