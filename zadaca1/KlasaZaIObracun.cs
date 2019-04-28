using System;
namespace zadaca1
{
    public class KlasaZaIObracun : IObracun
    {
        private DateTime pocetniDatumIznajmljivanja { get; set; }
        private DateTime krajnjiDatumIznajmljivanja { get; set; }

        public KlasaZaIObracun()
        {
            this.pocetniDatumIznajmljivanja = new DateTime();
            this.krajnjiDatumIznajmljivanja = new DateTime();
        }

        public KlasaZaIObracun(DateTime p, DateTime k)
        {
            this.pocetniDatumIznajmljivanja = p;
            this.krajnjiDatumIznajmljivanja = k;
        }

        public void NekaMetoda()
        {

        }
    }
}
