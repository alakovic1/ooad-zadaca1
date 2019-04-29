using System;
namespace zadaca1
{
    public class Klijent
    {
        private String imeIprezime;
        private DateTime datumRodjenja;
        private String jmbg;
        public String Naziv { get { return imeIprezime; } set { imeIprezime = value; } }
        public DateTime Datum { get { return datumRodjenja; } set { datumRodjenja = value; } }
        public String JMBG { get { return jmbg; } set { jmbg = value; } }
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
