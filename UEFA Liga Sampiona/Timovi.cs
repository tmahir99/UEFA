//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UEFA_Liga_Sampiona
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timovi
    {
        public int id { get; set; }
        public string Naziv { get; set; }
        public string Zemlja { get; set; }
        public string Liga { get; set; }
        public Nullable<int> Koeficijent { get; set; }

        public Timovi()
        {

        }

        public Timovi(string Naziv, string Zemlja, string Liga, int Koeficijent)
        {
            this.Naziv = Naziv;
            this.Zemlja = Zemlja;
            this.Liga = Liga;
            this.Koeficijent = Koeficijent;
        }

        public override string ToString()
        {
            return $"{this.Naziv} {this.Zemlja}";
        }
    }
}
