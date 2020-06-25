using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Entity.Migrations;

namespace UEFA_Liga_Sampiona
{
    public partial class player : Form
    {
        public player()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            using (UEFAEntities ctx = new UEFAEntities())
            {
                Timovi tim = new Timovi(name.Text, country.Text, ligue.Text, int.Parse(coeficient.Text), 0);

                ctx.Timovis.Add(tim);

                ctx.SaveChanges();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ctx.Timovis.ToList();
            }
        }


        private void metroButton5_Click(object sender, EventArgs e)
        {
            using (UEFAEntities ctx = new UEFAEntities())
            {
                foreach (Timovi t in ctx.Timovis)
                    t.Poeni = 0;

                dataGridView1.DataSource = ctx.Timovis.OrderByDescending(tim => tim.Koeficijent).ToList();

                ctx.SaveChanges();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            using (UEFAEntities ctx = new UEFAEntities())
            {
                //Zato sto je id int mora da se parsa u int sa stringa
                Timovi tim = ctx.Timovis.Find(int.Parse(id.Text));

                tim.Naziv = name.Text;
                tim.Liga = ligue.Text;
                tim.Zemlja = country.Text;
                tim.Koeficijent = int.Parse(coeficient.Text);

                ctx.Timovis.AddOrUpdate(tim);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ctx.Timovis.ToList();
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            using(UEFAEntities ctx = new UEFAEntities())
            {
                Timovi tim = ctx.Timovis.Find(int.Parse(id.Text));

                ctx.Timovis.Remove(tim);

                ctx.SaveChanges();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ctx.Timovis.ToList();
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
