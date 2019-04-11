using System;
namespace zadaca1
{
    public class TeretniAvion : Avion
    {
        private int ukupniKapacitet { get; set; }
        public TeretniAvion()
        {
            ukupniKapacitet = 0;
        }

        public TeretniAvion(int ukupniKapacitet)
        {
            this.ukupniKapacitet = ukupniKapacitet;
        }
    }
}
