using System;
namespace zadaca1
{
    public class Drzava
    {
        private String nazivDrzave { get; set; }
        private int brojStanovnika { get; set; }
        public String Naziv { get { return nazivDrzave; } set { nazivDrzave = value; } }
        public int BrojStanovnika { get { return brojStanovnika; } set { brojStanovnika = value; } }
        public Drzava()
        {
            this.nazivDrzave = "";
            this.brojStanovnika = 0;
        }

        public Drzava(String naziv)
        {
            this.nazivDrzave = naziv;
            this.brojStanovnika = 5000000;
        }

        public Drzava(String naziv, int broj)
        {
            this.nazivDrzave = naziv;
            this.brojStanovnika = broj;
        }
    }
}
