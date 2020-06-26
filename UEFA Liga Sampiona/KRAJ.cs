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

    public partial class KRAJ : Form
    {
        List<Timovi> PRVI;
        List<Timovi> DRUGI;

        Timovi[] LeviGore = new Timovi[2];
        Timovi[] LeviDole = new Timovi[2];
        
        Timovi[] DesniDole = new Timovi[2];
        Timovi[] DesniGore = new Timovi[2];

        //ZADNJA CETVORICA
        Timovi[] Pobednici = new Timovi[4];
        public KRAJ(List <Timovi> pp, List<Timovi> dp)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            PRVI = pp;
            DRUGI = dp;

            LeviGore[0] = PRVI[0];
            LeviGore[1] = PRVI[1];
            LeviDole[0] = PRVI[2];
            LeviDole[1] = PRVI[3];

            DesniGore[0] = DRUGI[0];
            DesniGore[1] = DRUGI[1];
            DesniDole[0] = DRUGI[2];
            DesniDole[1] = DRUGI[3];

        }

        private void KRAJ_Paint(object sender, PaintEventArgs e)
        {
            //Crtanje samo Boxova za timove
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 146, 111, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 146, 333, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 146, 555, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 146, 777, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 438, 222, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 438, 666, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 730, 444, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1022, 444, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1314, 222, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1314, 666, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1606, 111, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1606, 333, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1606, 555, 146, 111);
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1606, 777, 146, 111);

            //crtanje linija
            e.Graphics.DrawLine(new Pen(Brushes.White), 292, 166, 438, 277);
            e.Graphics.DrawLine(new Pen(Brushes.White), 292, 388, 438, 277);
            e.Graphics.DrawLine(new Pen(Brushes.White), 292, 610, 438, 721);
            e.Graphics.DrawLine(new Pen(Brushes.White), 292, 832, 438, 721);

            e.Graphics.DrawLine(new Pen(Brushes.White), 584, 277, 730, 499);
            e.Graphics.DrawLine(new Pen(Brushes.White), 584, 721, 730, 499);


            e.Graphics.DrawLine(new Pen(Brushes.White), 876, 499, 1022, 499);


            e.Graphics.DrawLine(new Pen(Brushes.White), 1168, 499, 1314, 277);
            e.Graphics.DrawLine(new Pen(Brushes.White), 1168, 499, 1314, 721);

            e.Graphics.DrawLine(new Pen(Brushes.White), 1460, 277, 1606, 166);
            e.Graphics.DrawLine(new Pen(Brushes.White), 1460, 277, 1606, 388);
            e.Graphics.DrawLine(new Pen(Brushes.White), 1460, 721, 1606, 610);
            e.Graphics.DrawLine(new Pen(Brushes.White), 1460, 721, 1606, 832);
        }

        public void LABELISPIS (int x, int y, Timovi[] tim, int koji)
        {
            if(tim[koji] != null)
            { 
            Label lb = new Label();
            lb = new Label();
            lb.Location = new Point(x, y);
            lb.BackColor = Color.Transparent;
            lb.ForeColor = Color.White;
            lb.Font = new Font("Arial", 10, FontStyle.Bold);
            lb.Size = new Size(220, 20);
            this.Controls.Add(lb);
            lb.Text = tim[koji].Naziv;
            }

        }

        private void ADD0_Click(object sender, EventArgs e)
        {
            ADDRESULTENDGAME AddRes = new ADDRESULTENDGAME(LeviGore, Pobednici, 0);
            AddRes.Show();
        }

        private void ADD1_Click(object sender, EventArgs e)
        {
            ADDRESULTENDGAME AddRes = new ADDRESULTENDGAME(LeviDole, Pobednici, 1);
            AddRes.Show();
        }

        private void ADD2_Click(object sender, EventArgs e)
        {
            ADDRESULTENDGAME AddRes = new ADDRESULTENDGAME(DesniGore, Pobednici, 2);
            AddRes.Show();
        }

        private void ADD3_Click(object sender, EventArgs e)
        {
            ADDRESULTENDGAME AddRes = new ADDRESULTENDGAME(DesniDole, Pobednici, 3);
            AddRes.Show();
        }

        private void KRAJ_MouseMove(object sender, MouseEventArgs e)
        {
            //skroz levo
            LABELISPIS(150, 120, LeviGore, 0);
            LABELISPIS(150, 342, LeviGore, 1);
            LABELISPIS(150, 561, LeviDole, 0);
            LABELISPIS(150, 786, LeviDole, 1);

            //skroz desno
            LABELISPIS(1610, 120, DesniGore, 0);
            LABELISPIS(1610, 342, DesniGore, 1);
            LABELISPIS(1610, 561, DesniDole, 0);
            LABELISPIS(1610, 786, DesniDole, 1);
            //manje levo
            LABELISPIS(442, 231, Pobednici, 0);
            LABELISPIS(442, 675, Pobednici, 1);
            //manje desno
            LABELISPIS(1318, 231, Pobednici, 2);
            LABELISPIS(1318, 675, Pobednici, 3);
            //levo
            LABELISPIS(734, 453, Pobednici, 0);
            //desno
            LABELISPIS(1026, 453, Pobednici, 1);


        }
    }
}
