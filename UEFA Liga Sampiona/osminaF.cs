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
    public partial class osminaF : Form
    {
        public osminaF(List<Timovi> GRUPA_1, List<Timovi> GRUPA_2, List<Timovi> GRUPA_3, List<Timovi> GRUPA_4, List<Timovi> GRUPA_5, List<Timovi> GRUPA_6, List<Timovi> GRUPA_7, List<Timovi> GRUPA_8)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FvF(GRUPA_1, 60, 80);
            FvF(GRUPA_2, 542, 80);
            FvF(GRUPA_3, 1024, 80);
            FvF(GRUPA_4, 1506, 80);
            FvF(GRUPA_5, 60, 560);
            FvF(GRUPA_6, 542, 560);
            FvF(GRUPA_7, 1024, 560);
            FvF(GRUPA_8, 1506, 560);
        }
        void FvF (List<Timovi> tim, int x, int y)
        {
            Button[] rez = new Button[6];
            Label[] Timovi = new Label[6];
            int i;
            for (i = 0; i < 6; i++)
            {
                Timovi[i] = new Label();
                Timovi[i].Location = new Point(x, y);
                Timovi[i].BackColor = Color.Transparent;
                Timovi[i].ForeColor = Color.White;
                this.Controls.Add(Timovi[i]);
                rez[i] = new Button();
                rez[i].Location = new Point(x - 40, y);
                rez[i].Size = new Size(40, 20);
                this.Controls.Add(rez[i]);
                rez[i].Text = "Add";

                y += 35;
            }

            Timovi[0].Text = $"{tim[0].Naziv} vs. {tim[1].Naziv}";
            Timovi[1].Text = $"{tim[0].Naziv} vs. {tim[2].Naziv}";
            Timovi[2].Text = $"{tim[0].Naziv} vs. {tim[3].Naziv}";
            Timovi[3].Text = $"{tim[1].Naziv} vs. {tim[2].Naziv}";
            Timovi[4].Text = $"{tim[1].Naziv} vs. {tim[3].Naziv}";
            Timovi[5].Text = $"{tim[2].Naziv} vs. {tim[3].Naziv}";
            //pokuso sam da dodam to string() i nece, da znas za sutra
        }

        private void osminaF_Paint(object sender, PaintEventArgs e)
        {
            //grup 1
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 10, 20, 452, 450);
            //grup 2
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 492, 20, 452, 450);
            //grup 3
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 974, 20, 452, 450);
            //grup 4
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1456, 20, 452, 450);
            //grup 5
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 10, 500, 452, 450);
            //grup 6
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 492, 500, 452, 450);
            //grup 7
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 974, 500, 452, 450);
            //grup 8
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1456, 500, 452, 450);
        }
    }
}
