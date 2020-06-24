using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace UEFA_Liga_Sampiona
{
    public partial class Form1 : Form
    {
        List<Timovi> zreb = new List<Timovi>();

        List<Timovi> A = new List<Timovi>();
        List<Timovi> B = new List<Timovi>();
        List<Timovi> C = new List<Timovi>();
        List<Timovi> D = new List<Timovi>();

        public Form1()
        {
            InitializeComponent();

            this.Text = "UEFA Champions League";
            WindowState = FormWindowState.Maximized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (UEFAEntities ctx = new UEFAEntities())
            {
                zreb = ctx.Timovis.OrderByDescending(tim => tim.Koeficijent).ToList();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player p = new player();
            p.ShowDialog();
        }

        private void drawTeamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrangeTeams();

            Raspored raspored = new Raspored(A, B, C, D);

            raspored.Show();
        }

        private void ArrangeTeams()
        {
            foreach(Timovi tim in zreb)
            {
                if(A.Count() < 8)
                {
                    A.Add(tim);
                }
                else if(B.Count() < 8)
                {
                    B.Add(tim);
                }
                else if(C.Count() < 8)
                {
                    C.Add(tim);
                }
                else
                {
                    D.Add(tim);
                }
            }
        }
    }
}
