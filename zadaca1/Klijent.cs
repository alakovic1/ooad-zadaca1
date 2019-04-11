using System;
namespace zadaca1
{
    public class Klijent
    {
        private String imeIprezime { get; set; }
        private String datumRodjenja { get; set; }
        private String jmbg { get; set; }
        public Klijent()
        {
            this.imeIprezime = "";
            this.datumRodjenja = "";
            this.jmbg = "";
        }

        public Klijent(string imeIprezime, string datumRodjenja, String jmbg)
        {
            this.imeIprezime = imeIprezime;
            this.datumRodjenja = datumRodjenja;
            if (jmbg.Length == 6)
            {
                for (int i = 0; i < jmbg.Length; i++)
                {
                    if (jmbg[i] >= '0' && jmbg[i] <= '9') this.jmbg = jmbg;
                }
            }
        }
    }
}
