using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class KlasaElemenata
    {
        private List<Avion> avioni = new List<Avion>();
        private List<Klijent> klijenti = new List<Klijent>();
        private List<Obavijest> obavijesti = new List<Obavijest>();
        public List<Avion> Avioni { get { return avioni; } set { avioni = value; } }
        public List<Klijent> Klijenti { get { return klijenti; } set { klijenti = value; } }
        public List<Obavijest> Obavijesti { get { return obavijesti; } set { obavijesti = value; } }
        public KlasaElemenata()
        {
            napuniBazu();   
        }
        public void dodajAvion(Avion avion)
        {
            this.avioni.Add(avion);
        }
        public void dodajKlijenta(Klijent klijent)
        {
            this.klijenti.Add(klijent);
        }
        public void dodajObavijest(Obavijest obavijest) {
            this.obavijesti.Add(obavijest);
        }
        public void napuniBazu() {
            List<Drzava> drzave = new List<Drzava>();
            drzave.Add(new Drzava("Bosna i Hercegovina",300000000));
            drzave.Add(new Drzava("Hrvatska", 500000000));
            drzave.Add(new Drzava("Srbija", 400000000));
            avioni.Add(new LetUInostranstvo("vrsta", 13, "123451234", drzave));
            avioni.Add(new LetUnutarZemlje("Airbus",123,"broj12345"));
            avioni.Add(new TeretniAvion("Cessna",45,"nekasifra",10));
            klijenti.Add(new DomaciDrzavljanin("klijent1", new DateTime(1998,6,18), "333333"));
            klijenti.Add(new StraniDrzavljanin("klijent2", new DateTime(1998, 4, 22), "222222","Ljubljana",new Drzava("Slovenija",2000000000)));
        }
    }
}
