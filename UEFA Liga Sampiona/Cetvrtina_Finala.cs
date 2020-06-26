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
    public partial class Cetvrtina_Finala : Form
    {
        List<Timovi> pp;
        List<Timovi> dp;

        List<Timovi> GRUPA_1 = new List<Timovi>();
        List<Timovi> GRUPA_2 = new List<Timovi>();
        List<Timovi> GRUPA_3 = new List<Timovi>();
        List<Timovi> GRUPA_4 = new List<Timovi>();
        public Cetvrtina_Finala(List <Timovi> tim, List <Timovi> tim2)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            pp = tim;
            dp = tim2;

            //Gprvo plasirani
            Label PK = new Label();
            PK.Location = new Point(480, 60);
            PK.BackColor = Color.Transparent;
            PK.ForeColor = Color.White;
            PK.Text = "PRVO PLASIRANI";
            this.Controls.Add(PK);

            //drugo plasirani
            Label DP = new Label();
            DP.Location = new Point(1380, 60);
            DP.BackColor = Color.Transparent;
            DP.ForeColor = Color.White;
            DP.Text = "DRUGO PLASIRANI";
            DP.Size = new Size(200, 20);
            this.Controls.Add(DP);

            CreateTeamLabels(100, 100, pp);
            CreateTeamLabels(1000, 100, dp);
        }

        private void Cetvrtina_Finala_Paint(object sender, PaintEventArgs e)
        {
            //Prvo plasirani
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 40, 40, 900, 800);
            //drugo plasirani
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 980, 40, 900, 800);
        }
        private void Rasporedi_Event(object sender, EventArgs e)
        {
            Randomize_Groups(GRUPA_1);
            Randomize_Groups(GRUPA_2);
            Randomize_Groups(GRUPA_3);
            Randomize_Groups(GRUPA_4);
            Randomize_Groups(GRUPA_1);
            Randomize_Groups(GRUPA_2);
            Randomize_Groups(GRUPA_3);
            Randomize_Groups(GRUPA_4);

        }

        private void CreateTeamLabels(int PosX, int PosY, List<Timovi> Team)
        {
            Label[] Timovi = new Label[9];

            for (int i = 0; i < 8; i++)
            {
                Timovi[i] = new Label();

                Timovi[i].Location = new Point(PosX, PosY);
                Timovi[i].Text = $"{Team[i].Naziv} {Team[i].Zemlja} {Team[i].Koeficijent}";
                Timovi[i].BackColor = Color.Transparent;
                Timovi[i].Font = new Font("Arial", 13, FontStyle.Bold);
                Timovi[i].Size = new Size(220, 20);
                Timovi[i].ForeColor = Color.White;

                this.Controls.Add(Timovi[i]);

                PosY += 54;
            }
        }

        private void Randomize_Groups(List<Timovi> Group)
        {
            int IzabraniA;
            int IzabraniB;

            do
            {
                Random rand = new Random();

                IzabraniA = rand.Next(pp.Count());
                IzabraniB = rand.Next(dp.Count());

                Group.Add(pp[IzabraniA]);
                Group.Add(dp[IzabraniB]);

            } while (
                CheckCountries(Group[0], Group) &&
                CheckCountries(Group[1], Group)
                );

            pp.RemoveAt(IzabraniA);
            dp.RemoveAt(IzabraniB);
        }

        private bool CheckCountries(Timovi tim, List<Timovi> zreb)
        {
            foreach (Timovi t in zreb)
            {
                if (tim.Zemlja == t.Zemlja)
                    return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var p in GRUPA_1 )
            {
                MessageBox.Show(p.ToString());
            }
            Rasporedi_Event(sender, e);
            osminaF of = new osminaF(GRUPA_1, GRUPA_2, GRUPA_3, GRUPA_4, null, null, null, null);
            of.Show();
        }
    }
}
