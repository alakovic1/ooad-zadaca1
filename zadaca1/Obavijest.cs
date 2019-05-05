using System;
namespace zadaca1
{
    public class Obavijest
    {
        private String tekstPoruke;
        private String sifraKlijenta;
        private DateTime datumIvrijemeObavijesti;
        public String Tekst { get { return tekstPoruke; } set { tekstPoruke = value; } }
        public String Sifra { get { return sifraKlijenta; } set { sifraKlijenta = value; } }
        public DateTime DatumIvrijeme { get { return datumIvrijemeObavijesti; } set { datumIvrijemeObavijesti = value; } }
        public Obavijest()
        {
            this.tekstPoruke = "";
            this.sifraKlijenta = "";
            this.datumIvrijemeObavijesti = new DateTime();
        }

        public Obavijest(string tekstPoruke, string sifraKlijenta, DateTime datumIvrijemeObavijesti)
        {
            this.tekstPoruke = tekstPoruke;
            this.sifraKlijenta = sifraKlijenta;
            this.datumIvrijemeObavijesti = datumIvrijemeObavijesti;
        }
    }
}
