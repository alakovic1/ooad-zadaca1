using System;
namespace zadaca1
{
    public class Klijent
    {
        private String imeIprezime { get; set; }
        private DateTime datumRodjenja { get; set; }
        private String jmbg { get; set; }
        public Klijent()
        {
            this.imeIprezime = "";
            this.datumRodjenja = new DateTime();
            this.jmbg = "";
        }

        public Klijent(String imeIprezime, DateTime datumRodjenja, String jmbg)
        {
            this.imeIprezime = imeIprezime;
            this.datumRodjenja = datumRodjenja;
            if (jmbg.Length == 6)
            { 
                this.jmbg = jmbg;
            }
        }
    }
}
