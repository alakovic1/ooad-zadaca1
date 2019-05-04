using System;
using System.Collections.Generic;

namespace zadaca1
{
    public class LetUInostranstvo : PutnickiAvion
    {
        private List<Drzava> drzave;
        public List<Drzava> Drzave { get { return drzave; } set { drzave = value; } }

        public LetUInostranstvo(string vrstaAviona, int brojSjedista, string id, List<Drzava> drzave) : base(vrstaAviona, brojSjedista, id)
        {
            this.drzave = drzave;
        }
    }
}
