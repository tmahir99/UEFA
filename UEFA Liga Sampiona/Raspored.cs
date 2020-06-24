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
        List<Timovi> A_GRUPA = new List<Timovi>();
        List<Timovi> B_GRUPA = new List<Timovi>();
        List<Timovi> C_GRUPA = new List<Timovi>();
        List<Timovi> D_GRUPA = new List<Timovi>();

        List<Timovi> GRUPA_1 = new List<Timovi>();
        List<Timovi> GRUPA_2 = new List<Timovi>();
        List<Timovi> GRUPA_3 = new List<Timovi>();
        List<Timovi> GRUPA_4 = new List<Timovi>();
        List<Timovi> GRUPA_5 = new List<Timovi>();
        List<Timovi> GRUPA_6 = new List<Timovi>();
        List<Timovi> GRUPA_7 = new List<Timovi>();
        List<Timovi> GRUPA_8 = new List<Timovi>();

        public Raspored(List<Timovi> A, List<Timovi> B, List<Timovi> C, List<Timovi> D)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            A_GRUPA = A;
            B_GRUPA = B;
            C_GRUPA = C;
            D_GRUPA = D;

            //GRUPA A
            Label AG = new Label();
            AG.Location = new Point(480, 40);
            AG.BackColor = Color.Transparent;
            AG.ForeColor = Color.White;
            AG.Text = "GRUPA A";

            this.Controls.Add(AG);

            //GRUPA B
            Label BG = new Label();
            BG.Location = new Point(1430, 40);
            BG.BackColor = Color.Transparent;
            BG.ForeColor = Color.White;
            BG.Text = "GRUPA B";

            this.Controls.Add(BG);

            //GRUPA C
            Label CG = new Label();
            CG.Location = new Point(480, 530);
            CG.BackColor = Color.Transparent;
            CG.ForeColor = Color.White;
            CG.Text = "GRUPA C";

            this.Controls.Add(CG);

            //GRUPA D
            Label DG = new Label();
            DG.Location = new Point(1430, 530);
            DG.BackColor = Color.Transparent;
            DG.ForeColor = Color.White;
            DG.Text = "GRUPA D";

            this.Controls.Add(DG);

            //Rasporedi
            Button Rasporedi = new Button();
            Rasporedi.Location = new Point(920, 490);
            Rasporedi.Size = new Size(80, 40);
            Rasporedi.Text = "Rasporedi";

            Rasporedi.Click += new EventHandler(this.Rasporedi_Event);

            this.Controls.Add(Rasporedi);

            CreateTeamLabels(60, 60, A_GRUPA);
            CreateTeamLabels(1000, 60, B_GRUPA);
            CreateTeamLabels(60, 550, C_GRUPA);
            CreateTeamLabels(1000, 550, D_GRUPA);
        }

        private void Rasporedi_Event(object sender, EventArgs e)
        {
            Randomize_Groups(GRUPA_1);
            Randomize_Groups(GRUPA_2);
            Randomize_Groups(GRUPA_3);
            Randomize_Groups(GRUPA_4);
            Randomize_Groups(GRUPA_5);
            Randomize_Groups(GRUPA_6);
            Randomize_Groups(GRUPA_7);
            Randomize_Groups(GRUPA_8);
        }

        private void CreateTeamLabels(int PosX, int PosY, List<Timovi> Team)
        {
            Label[] Timovi = new Label[8];

            for (int i = 0; i < 8; i++)
            {
                Timovi[i] = new Label();

                Timovi[i].Location = new Point(PosX, PosY);
                Timovi[i].Text = $"{Team[i].Naziv} {Team[i].Zemlja} {Team[i].Koeficijent}";
                Timovi[i].BackColor = Color.Transparent;
                Timovi[i].ForeColor = Color.White;

                this.Controls.Add(Timovi[i]);

                PosY += 54;
            }
        }

        private void Randomize_Groups(List<Timovi> Group)
        {
            int IzabraniA;
            int IzabraniB;
            int IzabraniC;
            int IzabraniD;

            do
            {
                Random rand = new Random();

                IzabraniA = rand.Next(A_GRUPA.Count());
                IzabraniB = rand.Next(B_GRUPA.Count());
                IzabraniC = rand.Next(C_GRUPA.Count());
                IzabraniD = rand.Next(D_GRUPA.Count());

                Group.Add(A_GRUPA[IzabraniA]);
                Group.Add(B_GRUPA[IzabraniB]);
                Group.Add(C_GRUPA[IzabraniC]);
                Group.Add(D_GRUPA[IzabraniD]);

            } while (
                CheckCountries(Group[0], Group) &&
                CheckCountries(Group[1], Group) &&
                CheckCountries(Group[2], Group) &&
                CheckCountries(Group[3], Group)
                );

            A_GRUPA.RemoveAt(IzabraniA);
            B_GRUPA.RemoveAt(IzabraniB);
            C_GRUPA.RemoveAt(IzabraniC);
            D_GRUPA.RemoveAt(IzabraniD);
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

        private void Raspored_Paint(object sender, PaintEventArgs e)
        {
            //A
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 40, 40, 900, 450);

            //B
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 980, 40, 900, 450);

            //C
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 40, 530, 900, 450);

            //D
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 980, 530, 900, 450);
        }
    }
}
