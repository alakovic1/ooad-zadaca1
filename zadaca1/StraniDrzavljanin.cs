using System;
namespace zadaca1
{
    public class StraniDrzavljanin : Klijent
    {
        private String grad;
        private Drzava drzava;
        public StraniDrzavljanin()
        {
            this.grad = "";
            this.drzava = new Drzava();
        }

        public StraniDrzavljanin(String grad, Drzava drzava)
        {
            this.grad = grad;
            this.drzava = drzava;
        }
    }
}
