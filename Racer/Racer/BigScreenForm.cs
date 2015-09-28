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
        private BigScreenObserver observer;
        private RaceManager manager;

        public BigScreenForm(RaceManager manager)
        {
            InitializeComponent();
            observer = new BigScreenObserver();
            this.manager = manager;
        }
    }
}
