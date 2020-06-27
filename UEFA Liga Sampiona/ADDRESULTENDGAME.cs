using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UEFA_Liga_Sampiona
{
    public partial class ADDRESULTENDGAME : Form
    {
        Timovi[] grupa;
        Timovi[] POBEDNICI;
        int KojiTim;
        int t1, t2;
        public ADDRESULTENDGAME(Timovi[] TIM, int tim1, int tim2, Timovi[] Pobednici, int koji)
        {
            InitializeComponent();

            try
            {
                grupa = TIM;
                POBEDNICI = Pobednici;
                KojiTim = koji;
                t1 = tim1;
                t2 = tim2;
                label3.Text = TIM[t1].Naziv;
                label8.Text = TIM[t1].Naziv;
                label7.Text = TIM[t2].Naziv;
                label4.Text = TIM[t2].Naziv;
            }
            catch (Exception e)
            {
                MessageBox.Show("Timovi jos nisu odabrani, molimo Vas zatvorite prozor");
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            int S = 0, S1 = 0;
            //if( int.Parse(textBox1.Text) >= int.Parse(textBox2.Text))
            //{
            //    S += 1;
            //}
            //else
            //{
            //    S1 += 1;
            //}
            //if (int.Parse(textBox3.Text) >= int.Parse(textBox4.Text))
            //{
            //    S1 += 1;
            //}
            //else
            //{
            //    S += 1;
            //}

            if (int.Parse(textBox1.Text) >= int.Parse(textBox2.Text) && int.Parse(textBox3.Text) >= int.Parse(textBox4.Text))
            {
                S += 1;
                MessageBox.Show("Tim broj 1 nastavlja ligu zbog poena iz prethodnih utakmica");
            }
            else if(int.Parse(textBox3.Text) >= int.Parse(textBox4.Text) && int.Parse(textBox1.Text) == int.Parse(textBox2.Text))
            {
                S1 += 1;
            }
            else if (int.Parse(textBox3.Text) <= int.Parse(textBox4.Text) && int.Parse(textBox1.Text) == int.Parse(textBox2.Text))
            {
                S += 1;
            }
            else if (int.Parse(textBox3.Text) == int.Parse(textBox4.Text) && int.Parse(textBox1.Text) == int.Parse(textBox2.Text))
            {
                S += 1;
                MessageBox.Show("Tim broj 1 nastavlja ligu zbog poena iz prethodnih utakmica");
            }
            else
            {
                S += 1;
            }
            if (S >= S1)
            {
                POBEDNICI[KojiTim] = grupa[t1];
            } 
            else
            {
                POBEDNICI[KojiTim] = grupa[t2];
            }


            POBEDNICI[KojiTim].Polu_Finale = true;

            using (UEFAEntities ctx = new UEFAEntities())
            {
                Timovi temp = ctx.Timovis.Find(POBEDNICI[KojiTim].id);

                temp.Polu_Finale = true;

                ctx.Timovis.AddOrUpdate(temp);

                ctx.SaveChanges();
            }

            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if(!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Uneti karakter nije broj (1-9)");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Uneti karakter nije broj (1-9)");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Uneti karakter nije broj (1-9)");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Uneti karakter nije broj (1-9)");
            }
        }
    }
}
