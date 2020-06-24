using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UEFA_Liga_Sampiona
{
    public partial class Raspored : Form
    {
        public Raspored(List<Timovi> A, List<Timovi> B, List<Timovi> C, List<Timovi> D)
        {
            InitializeComponent();

            foreach(Timovi a in A)
            {
                MessageBox.Show(a.ToString());
            }
        }

        private void Raspored_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
