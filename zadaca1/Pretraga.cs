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

        List<Avion> Ipretraga<Avion>.pretraga(Avion avion)
        {
            List<Avion> avioni = new List<Avion>();
            for (int i = 0; i < ke.Avioni.Count; i++)
            {
                if (avion.Vrsta == ke.Avioni[i].Vrsta && avion.Sjedista == ke.Avioni[i].Sjedista)
                {
                    avioni.Add(ke.Avioni[i]);
                }
            }
            return avioni;
        }
    }
}
