using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class KlasaElemenata
    {
        private List<Avion> avioni = new List<Avion>();
        private List<Klijent> klijenti = new List<Klijent>();
        public List<Avion> Avioni { get { return avioni; } set { avioni = value; } }
        public List<Klijent> Klijenti { get { return klijenti; } set { klijenti = value; } }
        public KlasaElemenata()
        {
            napuniBazu();   
        }
        public void napuniBazu() {
            Avion a = new Avion("vrsta", 13, "123451234");
            avioni.Add(a);
            Klijent k = new Klijent("klijent1", new DateTime(), "333333");
            klijenti.Add(k);
        }
    }
}
