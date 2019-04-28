using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class Pretraga : Ipretraga<Avion>
    {
        private List<Avion> avioni { get; set; }

        public Pretraga()
        {
            this.avioni = new List<Avion>();
        }

        public Pretraga(List<Avion> avioni)
        {
            this.avioni = avioni;
        }

        public bool pretraga(Avion avion)
        {
            return false;
        }
    }
}
