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
        public ADDRESULTENDGAME(Timovi[] TIM, Timovi[] Pobednici, int koji)
        {
            InitializeComponent();

            grupa = TIM;
            POBEDNICI = Pobednici;
            KojiTim = koji;

            label3.Text = TIM[0].Naziv;
            label8.Text = TIM[0].Naziv;
            label7.Text = TIM[1].Naziv;
            label4.Text = TIM[1].Naziv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( int.Parse(textBox1.Text) > int.Parse(textBox2.Text))
            {
                grupa[0].Poeni += 1;
            }
            else
            {
                grupa[1].Poeni += 1;
            }
            if (int.Parse(textBox3.Text) > int.Parse(textBox4.Text))
            {
                grupa[1].Poeni += 1;
            }
            else
            {
                grupa[0].Poeni += 1;
            }

            if(grupa[0].Poeni >= grupa[1].Poeni)
            {
                POBEDNICI[KojiTim] = grupa[0];
            } 
            else
            {
                POBEDNICI[KojiTim] = grupa[1];
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
