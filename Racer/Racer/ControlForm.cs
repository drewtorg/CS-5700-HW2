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
        private RaceManager manager;
        private RacerObserver selectedObserver = null;

        public ControlForm()
        {
            InitializeComponent();
            
            manager = new RaceManager();
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
                observerLabel.Text = "No obverser selected";

            foreach (RacerTracker tracker in manager.Racers.Values)
            {
                Racer r = tracker.Racer;
                ListViewItem item = new ListViewItem(new string[] { (r.FirstName + r.LastName), r.Bib.ToString(), r.GroupID.ToString() });
                item.Tag = tracker;
                if (selectedObserver != null && tracker.Observers.Contains(selectedObserver))
                    subscribedView.Items.Add(item);
                else
                    racerView.Items.Add(item);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
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
                    RacerTracker subject = item.Tag as RacerTracker;
                    selectedObserver.Subscribe(subject);
                    manager.AddObserver(selectedObserver);
                }
                refreshRacerLists();
            }
        }

        private void unsubscribeButton_Click(object sender, EventArgs e)
        {
            if (selectedObserver != null)
            {
                foreach (ListViewItem item in racerView.SelectedItems)
                {
                    RacerTracker subject = item.Tag as RacerTracker;
                    selectedObserver.Unsubscribe();
                    manager.RemoveObserver(selectedObserver);
                }
                refreshRacerLists();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ObserverCreationForm modalDialogForm = new ObserverCreationForm();
            modalDialogForm.Text = "New Observer";
            modalDialogForm.ObserverTitle = string.Format("Observer #{0}", manager.Observers.Count + 1);
            if (modalDialogForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RacerObserver observer;

                if (modalDialogForm.Type == ObserverCreationForm.ObserverType.Support)
                    observer = new SupportObserver(modalDialogForm.To, modalDialogForm.Header, modalDialogForm.Footer);

                else if (modalDialogForm.Type == ObserverCreationForm.ObserverType.CheatingDetector)
                    observer = new CheatingDetector(modalDialogForm.To, modalDialogForm.Header, modalDialogForm.Footer);

                else
                    observer = new BigScreenObserver(new BigScreenForm());

                observer.Title = modalDialogForm.ObserverTitle;
                manager.Observers.Add(observer);

                selectedObserver = null;
                observerView.SelectedIndices.Clear();
                refreshObserverView();
                refreshRacerLists();
            }
        }
    }
}
