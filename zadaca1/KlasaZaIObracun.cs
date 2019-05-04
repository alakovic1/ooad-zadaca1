using System;
namespace zadaca1
{
    public class KlasaZaIObracun : IObracun
    {
        private DateTime pocetniDatumIznajmljivanja;
        private DateTime krajnjiDatumIznajmljivanja;
        public DateTime PocetniDatumIznajmljivanja { get { return pocetniDatumIznajmljivanja; } set { pocetniDatumIznajmljivanja = value; } }
        public DateTime KrajnjiDatumIznajmljivanja { get { return krajnjiDatumIznajmljivanja; } set { krajnjiDatumIznajmljivanja = value; } }
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

        public double RacunajCijenu(Klijent k)
        {
            double cijena = 0;
            int brojDana = Math.Abs((krajnjiDatumIznajmljivanja - pocetniDatumIznajmljivanja).Days);
            if (k.Avion is PutnickiAvion)
            {
                if (k.Avion is LetUnutarZemlje)
                {
                    cijena = brojDana * 120;
                    if (pocetniDatumIznajmljivanja.DayOfWeek.Equals("Saturday") || pocetniDatumIznajmljivanja.DayOfWeek.Equals("Sunday"))
                    {
                        cijena += 500;
                    }
                }
                else if (k.Avion is LetUInostranstvo)
                {
                    cijena = brojDana * 200;
                    if (pocetniDatumIznajmljivanja.DayOfWeek.Equals("Saturday") || pocetniDatumIznajmljivanja.DayOfWeek.Equals("Sunday"))
                    {
                        cijena += 1000;
                    }
                }
            }
            else if (k.Avion is TeretniAvion)
            {
                cijena = brojDana * 350;
                double tonaUkg = ((TeretniAvion)k.Avion).Kapacitet * 1000;
                cijena += tonaUkg * 0.02;
            }
            return cijena;
        }
    }
}
