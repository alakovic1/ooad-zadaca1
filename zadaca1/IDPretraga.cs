using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class IDPretraga : Ipretraga<Avion>
    {
        private List<Avion> avioni { get; set; }

        public IDPretraga()
        {
            this.avioni = new List<Avion>();
        }

        public IDPretraga(List<Avion> avioni)
        {
            this.avioni = avioni;
        }

        public bool pretraga(Avion avion)
        {
            //if ( == 0) return true;
            return false;
        }
    }
}
