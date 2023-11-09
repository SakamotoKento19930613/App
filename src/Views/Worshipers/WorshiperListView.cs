using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorTrackSystem.src.Views.Worshipers
{
    public partial class WorshiperListView : Form
    {
        public WorshiperListView()
        {
            InitializeComponent();
        }

        private void BtnMenuView_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddWorshipView_Click(object sender, EventArgs e)
        {
            AddWorshipView addWorshipView = new AddWorshipView();
            addWorshipView.Show();
        }
    }
}
