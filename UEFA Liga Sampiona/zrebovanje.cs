using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UEFA_Liga_Sampiona
{
    public class zrebovanje
    {
        public int sifra;
        public string naziv;
        public string zemlja;
        public string liga;
        public float koificijent;

        public zrebovanje()
        {
            sifra = 0;
            naziv = "Name";
            zemlja = "Country";
            liga = "Ligue";
            koificijent = 0;
        }
        public zrebovanje(int sifra, string naziv, string zemlja, string liga, float koificijent)
        {
            this.sifra = sifra;
            this.naziv = naziv;
            this.zemlja = zemlja;
            this.liga = liga;
            this.koificijent = koificijent;
        }

        public override string ToString()
        {
            return naziv + " " + zemlja + " " + liga ;
        }
    }

}
