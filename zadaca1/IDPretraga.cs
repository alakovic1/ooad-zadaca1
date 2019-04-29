using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class IDPretraga : Ipretraga<Avion>
    {
        private KlasaElemenata ke = new KlasaElemenata();
        public IDPretraga()
        {
            this.ke.Avioni = new List<Avion>();
        }

        public IDPretraga(List<Avion> avioni)
        {
            this.ke.Avioni = avioni;
        }

        public bool pretraga(Avion avion)
        {
            for(int i = 0; i < ke.Avioni.Count; i++) { 
                if(avion.ID == ke.Avioni[i].ID) {
                    return true;
                }
            }
            return false;
        }
    }
}
