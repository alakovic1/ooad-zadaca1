using System;
namespace zadaca1
{
    public class StraniDrzavljanin : Klijent
    {
        private String grad;
        private String drzava;
        public StraniDrzavljanin()
        {
            this.grad = "";
            this.drzava = "";
        }

        public StraniDrzavljanin(string grad, string drzava)
        {
            this.grad = grad;
            this.drzava = drzava;
        }
    }
}
