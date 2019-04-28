using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class LetUInostranstvo : PutnickiAvion
    {
        private List<Drzava> drzave { get; set; }
        public LetUInostranstvo()
        {
            this.drzave = new List<Drzava>();
        }
        public LetUInostranstvo(List<Drzava> d)
        {
            this.drzave = d;
        }
    }
}
