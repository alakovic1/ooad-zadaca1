using System;
namespace zadaca1
{
    public class TeretniAvion : Avion
    {
        private double ukupniKapacitet;
        public double Kapacitet { get { return ukupniKapacitet; } set { ukupniKapacitet = value; } }
        public TeretniAvion(string vrstaAviona, int brojSjedista, string id, double ukupniKapacitet) : base(vrstaAviona, brojSjedista, id)
        {
            this.ukupniKapacitet = ukupniKapacitet;
        }

        public TeretniAvion(double ukupniKapacitet)
        {
            this.ukupniKapacitet = ukupniKapacitet;
        }
    }
}
