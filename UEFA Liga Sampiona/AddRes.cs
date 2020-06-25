﻿using System;
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
    public partial class AddRes : Form
    {
        List<Timovi> t1;
        List<Timovi> zreb;

        List<Timovi> PRVO_PLASIRANI;
        List<Timovi> DRUGO_PLASIRANI;
        public AddRes(List<Timovi> tim, List<Timovi> Prvi, List<Timovi> Drugi)
        {
            InitializeComponent();

            PRVO_PLASIRANI = Prvi;
            DRUGO_PLASIRANI= Drugi;

            using (UEFAEntities ctx = new UEFAEntities())
            {
                zreb = ctx.Timovis.ToList();
            }

            t1 = tim;

            label1.Text = $"{tim[0].Naziv}";
            label2.Text = $"{tim[1].Naziv}";
            label5.Text = $"{tim[0].Naziv}";
            label4.Text = $"{tim[2].Naziv}";
            label8.Text = $"{tim[0].Naziv}";
            label7.Text = $"{tim[3].Naziv}";
            label11.Text = $"{tim[1].Naziv}";
            label10.Text = $"{tim[2].Naziv}";
            label14.Text = $"{tim[1].Naziv}";
            label13.Text = $"{tim[3].Naziv}";
            label17.Text = $"{tim[2].Naziv}";
            label16.Text = $"{tim[3].Naziv}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UEFAEntities ctx = new UEFAEntities())
            {
                if (Convert.ToInt32(textBox1.Text) >= Convert.ToInt32(textBox2.Text))
                {
                    t1[0].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[1].Poeni += 1;
                    ctx.SaveChanges();
                }

                if (Convert.ToInt32(textBox3.Text) >= Convert.ToInt32(textBox4.Text))
                {
                    t1[0].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[2].Poeni += 1;
                    ctx.SaveChanges();
                }

                if (Convert.ToInt32(textBox5.Text) >= Convert.ToInt32(textBox6.Text))
                {
                    t1[0].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[3].Poeni += 1;
                    ctx.SaveChanges();
                }

                if (Convert.ToInt32(textBox7.Text) >= Convert.ToInt32(textBox8.Text))
                {
                    t1[1].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[2].Poeni += 1;
                    ctx.SaveChanges();
                }

                if (Convert.ToInt32(textBox9.Text) >= Convert.ToInt32(textBox10.Text))
                {
                    t1[1].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[3].Poeni += 1;
                    ctx.SaveChanges();
                }

                if (Convert.ToInt32(textBox11.Text) >= Convert.ToInt32(textBox12.Text))
                {
                    t1[2].Poeni += 1;
                    ctx.SaveChanges();
                }
                else
                {
                    t1[3].Poeni += 1;
                    ctx.SaveChanges();
                }

                for(int i = 0; i < 4; i++)
                {
                    Timovi Tim = ctx.Timovis.Find(t1[i].id);

                    Tim.Poeni = t1[i].Poeni;
                }

                t1.OrderByDescending(tim => tim.Poeni);

                Timovi first = ctx.Timovis.Find(t1[0].id);

                Timovi second = ctx.Timovis.Find(t1[1].id);

                first.Osmina_Finala = true;
                second.Osmina_Finala = true;

                PRVO_PLASIRANI.Add(first);
                DRUGO_PLASIRANI.Add(second);

                ctx.SaveChanges();
            }

            this.Close();
        }
    }
}
