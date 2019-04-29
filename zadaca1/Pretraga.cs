using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class Pretraga : Ipretraga<Avion>
    {
        private KlasaElemenata ke = new KlasaElemenata();
        public Pretraga()
        {
            this.ke.Avioni = new List<Avion>();
        }

        public Pretraga(List<Avion> avioni)
        {
            this.ke.Avioni = avioni;
        }

        public bool pretraga(Avion avion)
        {
            for (int i = 0; i < ke.Avioni.Count; i++)
            {
                if (avion.Vrsta == ke.Avioni[i].Vrsta && avion.Sjedista == ke.Avioni[i].Sjedista)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
