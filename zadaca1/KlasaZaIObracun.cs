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

        public double RacunajCijenu(Klijent trenutniKlijent)
        {
            double cijena = 0;
            int brojDana = Math.Abs((krajnjiDatumIznajmljivanja - pocetniDatumIznajmljivanja).Days);
            if (trenutniKlijent.Avion is PutnickiAvion)
            {
                if (trenutniKlijent.Avion is LetUnutarZemlje)
                {
                    cijena = brojDana * 120;
                    if (pocetniDatumIznajmljivanja.DayOfWeek.Equals("Saturday") || pocetniDatumIznajmljivanja.DayOfWeek.Equals("Sunday"))
                    {
                        cijena += 500;
                    }
                }
                else if (trenutniKlijent.Avion is LetUInostranstvo)
                {
                    cijena = brojDana * 200;
                    if (pocetniDatumIznajmljivanja.DayOfWeek.Equals("Saturday") || pocetniDatumIznajmljivanja.DayOfWeek.Equals("Sunday"))
                    {
                        cijena += 1000;
                    }
                }
            }
            else if (trenutniKlijent.Avion is TeretniAvion)
            {
                cijena = brojDana * 350;
                double tonaUkg = ((TeretniAvion) trenutniKlijent.Avion).Kapacitet * 1000;
                cijena += tonaUkg * 0.02;
            }
            return cijena;
        }
    }
}
