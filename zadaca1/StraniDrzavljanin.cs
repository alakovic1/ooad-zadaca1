using System;
namespace zadaca1
{
    public class StraniDrzavljanin : Klijent
    {
        private String grad;
        private Drzava drzava;
        public String Grad { get { return grad; } set { grad = value; } }
        public Drzava Drzava { get { return drzava; } set { drzava = value; } }
        public StraniDrzavljanin()
        {
            this.grad = "";
            this.drzava = new Drzava();
        }

        public StraniDrzavljanin(String imeIprezime, DateTime datumRodjenja, String jmbg, String grad, Drzava drzava) : base(imeIprezime, datumRodjenja, jmbg)
        {
            this.grad = grad;
            this.drzava = drzava;
        }
    }
}
