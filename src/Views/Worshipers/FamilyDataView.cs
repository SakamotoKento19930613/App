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
    public partial class FamilyDataView : Form
    {
        public FamilyDataView()
        {
            InitializeComponent();
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastNameKana { get; set; }
        public string FirstNameKana { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Pref { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Prayer { get; set; }
        public int FirstfruitsFeeVal { get; set; }
        public int NotiffcationMethod { get; set; }
        public string Note { get; set; }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
