using System;
namespace zadaca1
{
    public class TeretniAvion : Avion
    {
        private double ukupniKapacitet { get; set; }
        public TeretniAvion()
        {
            ukupniKapacitet = 0;
        }

        public TeretniAvion(double ukupniKapacitet)
        {
            this.ukupniKapacitet = ukupniKapacitet;
        }
    }
}
