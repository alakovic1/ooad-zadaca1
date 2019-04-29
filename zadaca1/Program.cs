using System;

namespace zadaca1
{
    class Program 
    {
        static void Main(string[] args)
        {
            KlasaElemenata ke = new KlasaElemenata();

            POCETAK: Console.WriteLine("Unesite vas identifikacijski broj (duzine 6 karaktera): ");
            String idKlijenta = Convert.ToString(Console.ReadLine());
            bool duzina6 = false;
            if (idKlijenta.Length != 6) duzina6 = true;
            bool ima = false;
            for(int i = 0; i < ke.Klijenti.Count; i++) {
                if (ke.Klijenti[i].JMBG == idKlijenta)
                {
                    ima = true;
                }
            }
            if (ima == true)
            {
                Avion avion = new Avion();
                UNOS: Console.WriteLine("Unesite podatke o avionu: ");
                Console.WriteLine("Unesite vrstu aviona: ");
                String v = Convert.ToString(Console.ReadLine());
                BROJSJEDISTA: Console.WriteLine("Unesite broj sjedista aviona: ");
                int b = 0;
                try
                {
                    b = Convert.ToInt32(Console.ReadLine());
                }catch(Exception) {
                    Console.WriteLine("Niste unijeli ispravan broj sjedista!");
                    goto BROJSJEDISTA;
                    //return;
                }
                ID: Console.WriteLine("Unesite ID aviona (duzine 9, samo mala slova i brojevi (1 - 5)): ");
                String id = Convert.ToString(Console.ReadLine());
                avion.Vrsta = v;
                avion.Sjedista = b;
                avion.ID = id;
                if(avion.ID == "") {
                    Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                    goto ID;
                }
                PRETRAGA: Console.WriteLine("Unesite nacin pretrage (1 za pretragu preko ID, 2 za pretragu po ostalim atributima): ");
                String nacinPretrage = Convert.ToString(Console.ReadLine());
                if(nacinPretrage == "1") {
                    IDPretraga p = new IDPretraga(ke.Avioni);
                    p.pretraga(avion);
                    if (p.pretraga(avion)) {
                        Console.WriteLine("Avion pronadjen!");
                    }
                    else {

                        Console.WriteLine("Avion nije pronadjen!");
                        Console.WriteLine("Unesite ponovo avion:");
                        goto UNOS;
                    }
                }
                else if(nacinPretrage == "2") {
                    Pretraga p = new Pretraga(ke.Avioni);
                    p.pretraga(avion);
                    if (p.pretraga(avion))
                    {
                        Console.WriteLine("Avion pronadjen!");
                    }
                    else
                    { 
                        Console.WriteLine("Avion nije pronadjen!");
                        Console.WriteLine("Unesite ponovo avion:");
                        goto UNOS;
                    }
                }
                else {
                    Console.WriteLine("Neispravan unos. Pokusajte ponovo: ");
                    goto PRETRAGA;
                }
            }
            else {
                if(duzina6) Console.WriteLine("Niste unijeli id sa 6 karaktera!");
                else Console.WriteLine("Klijent nije u bazi!");
                Console.WriteLine("Unesite ponovo: ");
                goto POCETAK;
            }
            Console.ReadKey();
        }
    }
}

