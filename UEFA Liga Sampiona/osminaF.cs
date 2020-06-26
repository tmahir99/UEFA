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
        List<Timovi> GRUPA1 = new List<Timovi>();
        List<Timovi> GRUPA2 = new List<Timovi>();
        List<Timovi> GRUPA3 = new List<Timovi>();
        List<Timovi> GRUPA4 = new List<Timovi>();
        List<Timovi> GRUPA5 = new List<Timovi>();
        List<Timovi> GRUPA6 = new List<Timovi>();
        List<Timovi> GRUPA7 = new List<Timovi>();
        List<Timovi> GRUPA8 = new List<Timovi>();

        List<Timovi> PRVO_PLASIRANI = new List<Timovi>();

        List<Timovi> DRUGO_PLASIRANI = new List<Timovi>();

        public osminaF(List<Timovi> GRUPA_1, List<Timovi> GRUPA_2, List<Timovi> GRUPA_3, List<Timovi> GRUPA_4, List<Timovi> GRUPA_5, List<Timovi> GRUPA_6, List<Timovi> GRUPA_7, List<Timovi> GRUPA_8)
        {
            InitializeComponent();

            GRUPA1 = GRUPA_1;
            GRUPA2 = GRUPA_2;
            GRUPA3 = GRUPA_3;
            GRUPA4 = GRUPA_4;
            GRUPA5 = GRUPA_5;
            GRUPA6 = GRUPA_6;
            GRUPA7 = GRUPA_7;
            GRUPA8 = GRUPA_8;

            WindowState = FormWindowState.Maximized;

            FvF(GRUPA_1, 60, 80);
            FvF(GRUPA_2, 542, 80);
            FvF(GRUPA_3, 1024, 80);
            FvF(GRUPA_4, 1506, 80);
            if (GRUPA_5 != null)
            {
                FvF(GRUPA_5, 60, 560);
                FvF(GRUPA_6, 542, 560);
                FvF(GRUPA_7, 1024, 560);
                FvF(GRUPA_8, 1506, 560);
            }
        }

        void FvF (List<Timovi> tim, int x, int y)
        {
            Label[] Timovi = new Label[6];
            int i;
            for (i = 0; i < 6; i++)
            {
                Timovi[i] = new Label();
                Timovi[i].Location = new Point(x, y);
                Timovi[i].BackColor = Color.Transparent;
                Timovi[i].ForeColor = Color.White;
                Timovi[i].Font = new Font("Arial", 10, FontStyle.Bold);
                Timovi[i].Size = new Size(220, 20);
                this.Controls.Add(Timovi[i]);

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


            if (GRUPA5 != null)
            { 
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 10, 500, 452, 450);
            //grup 6
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 492, 500, 452, 450);
            //grup 7
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 974, 500, 452, 450);
            //grup 8
            e.Graphics.DrawRectangle(new Pen(Brushes.White), 1456, 500, 452, 450);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA1, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA2, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA3, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA4, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA5, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA6, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA7, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddRes ar = new AddRes(GRUPA8, PRVO_PLASIRANI, DRUGO_PLASIRANI);
            ar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cetvrtina_Finala CF = new Cetvrtina_Finala(PRVO_PLASIRANI, DRUGO_PLASIRANI);
            CF.Show();

        }

        private void osminaF_Load(object sender, EventArgs e)
        {
            if(GRUPA5 != null)
            {
                button10.Hide();
            }
            else
            {
                button4.Hide();
                button2.Hide();
                button3.Hide();
                button7.Hide();
                button9.Hide();
                button10.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KRAJ kraj = new KRAJ(PRVO_PLASIRANI, DRUGO_PLASIRANI);
            kraj.Show();
        }
    }
}
