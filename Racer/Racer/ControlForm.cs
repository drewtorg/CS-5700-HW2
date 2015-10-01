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
    public partial class ControlForm : Form
    {
        private const string groupFile = @"../../../SensorSimulator/bin/Debug/Group.csv";
        private const string racerFile = @"../../../SensorSimulator/bin/Debug/Racers.csv";
        private const string sensorFile = @"../../../SensorSimulator/bin/Debug/Sensor.csv";

        private RaceManager manager;
        private RacerObserver selectedObserver = null;

        public ControlForm()
        {
            InitializeComponent();
            
            manager = new RaceManager(groupFile, racerFile, sensorFile);
            manager.Start();
        }

        private void refreshObserverView()
        {
            observerView.Items.Clear();
            foreach (RacerObserver observer in manager.Observers)
            {
                ListViewItem item = new ListViewItem(observer.Title);
                observerView.Items.Add(item);
            }
        }

        private void refreshRacerLists()
        {
            subscribedView.Items.Clear();
            racerView.Items.Clear();

            if (selectedObserver != null)
                observerLabel.Text = "Subjects of " + selectedObserver.Title;
            else
                observerLabel.Text = "No observer selected";

            foreach (Racer r in manager.Racers.Values)
            {
                ListViewItem item = new ListViewItem(new string[] { (r.FirstName + r.LastName), r.Bib.ToString(), r.GroupID.ToString() });
                item.Tag = r;
                if (selectedObserver != null && r.Observers.Contains(selectedObserver))
                    subscribedView.Items.Add(item);
                else
                    racerView.Items.Add(item);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            manager.Stop();
            Close();
        }

        private void observerView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (observerView.SelectedIndices.Count == 1)
            {
                selectedObserver = manager.Observers[observerView.SelectedIndices[0]];
                unsubscribeButton.Enabled = true;
                subscribeButton.Enabled = true;
            }
            else
            {
                selectedObserver = null;
                unsubscribeButton.Enabled = true;
                subscribeButton.Enabled = true;
            }

            refreshRacerLists();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            refreshObserverView();
            refreshRacerLists();
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            if (selectedObserver != null)
            {
                foreach (ListViewItem item in racerView.SelectedItems)
                {
                    Racer subject = item.Tag as Racer;
                    subject.Subscribe(selectedObserver);
                }
                refreshRacerLists();
            }
        }

        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            if (selectedObserver != null)
            {
                foreach (ListViewItem item in subscribedView.SelectedItems)
                {
                    Racer subject = item.Tag as Racer;
                    subject.Unsubscribe(selectedObserver);
                }
                refreshRacerLists();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ObserverCreationForm modalDialogForm = new ObserverCreationForm();
            modalDialogForm.Text = "New Observer";
            modalDialogForm.ObserverTitle = string.Format("Observer #{0}", manager.Observers.Count + 1);
            if (modalDialogForm.ShowDialog() == DialogResult.OK)
            {
                RacerObserver observer;

                if (modalDialogForm.Type == ObserverType.Support)
                    observer = new SupportObserver(modalDialogForm.To, modalDialogForm.Header, modalDialogForm.Footer, modalDialogForm.Quotes);

                else if (modalDialogForm.Type == ObserverType.CheatingDetector)
                    observer = new CheatingDetector(modalDialogForm.To, modalDialogForm.Header, modalDialogForm.Footer, modalDialogForm.Quotes);

                else
                    observer = new BigScreenObserver(new BigScreenForm());

                observer.Title = modalDialogForm.ObserverTitle;
                manager.AddObserver(observer);

                selectedObserver = null;
                observerView.SelectedIndices.Clear();
                refreshObserverView();
                refreshRacerLists();
            }
        }
    }
}
