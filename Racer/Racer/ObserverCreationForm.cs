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
    public enum ObserverType { Support, CheatingDetector, BigScreen };

    public partial class ObserverCreationForm : Form
    {
        public ObserverCreationForm()
        {
            InitializeComponent();
        }

        public string ObserverTitle
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        public string To
        {
            get { return toTextBox.Text; }
            set { toTextBox.Text = value; }
        }

        public string Header
        {
            get { return headerTextBox.Text; }
            set { headerTextBox.Text = value; }
        }

        public string Footer
        {
            get { return footerTextBox.Text; }
            set { footerTextBox.Text = value; }
        }

        public ObserverType Type
        {
            get { return (supportTypeRadioButton.Checked)   ?   ObserverType.Support :
                         (cheatingTypeRadioButton.Checked)  ?   ObserverType.CheatingDetector :
                                                                ObserverType.BigScreen; }
        }


        private void creationButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void allRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                RadioButton rb = sender as RadioButton;
                if (rb == bigScreenTypeRadioButton)
                {
                    To = "";
                    Header = "";
                    Footer = "";

                    toTextBox.Enabled = false;
                    headerTextBox.Enabled = false;
                    footerTextBox.Enabled = false;
                }
                else
                {
                    toTextBox.Enabled = true;
                    headerTextBox.Enabled = true;
                    footerTextBox.Enabled = true;
                }
            }
        }
    }
}
