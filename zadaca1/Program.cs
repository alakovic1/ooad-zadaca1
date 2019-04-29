using System;
using System.Collections.Generic;

namespace zadaca1
{
    class Program
    {
        static void Main(string[] args)
        {
            KlasaElemenata ke = new KlasaElemenata();
            Console.WriteLine("MENI");
            for (; ; )
            {
                Console.WriteLine("Unesite: 1 - unos vozila/aviona, 2 - unos klijenta, 3 - iznajmljivanje, 4 - povrat aviona i placanje, 5 - ispis liste obavijesti");
                String unos = Convert.ToString(Console.ReadLine());
                if(unos == "1") {
                    Avion avion = new Avion();
                    Console.WriteLine("Unesite podatke o avionu: ");
                    Console.WriteLine("Unesite vrstu aviona: ");
                    String v = Convert.ToString(Console.ReadLine());
                    BROJSJEDISTA: Console.WriteLine("Unesite broj sjedista aviona: ");
                    int b = 0;
                    try
                    {
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Niste unijeli ispravan broj sjedista!");
                        goto BROJSJEDISTA;
                        //return;
                    }
                    ID: Console.WriteLine("Unesite ID aviona (duzine 9, samo mala slova i brojevi (1 - 5)): ");
                    String id = Convert.ToString(Console.ReadLine());
                    avion.Vrsta = v;
                    avion.Sjedista = b;
                    avion.ID = id;
                    if (avion.ID == "")
                    {
                        Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                        goto ID;
                    }
                    ke.dodajAvion(avion);
                }
                else if(unos == "2") {
                    Klijent klijent = new Klijent();
                    Console.WriteLine("Unesite podatke o klijentu: ");
                    Console.WriteLine("Unesite ime i prezime klijenta: ");
                    String imeIPrezimeKlijenta = Convert.ToString(Console.ReadLine());
                    DAN: Console.WriteLine("Unesite dan rodjenja: ");
                    int dan = 0;
                    try
                    {
                        dan = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) {
                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                        goto DAN;
                    }
                    MJESEC: Console.WriteLine("Unesite mjesec rodjenja: ");
                    int mjesec = 0;
                    try
                    {
                        mjesec = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) {
                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                        goto MJESEC;
                    }
                    GODINA: Console.WriteLine("Unesite godinu rodjenja: ");
                    int godina = 0;
                    try
                    {
                        godina = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) {
                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                        goto GODINA;
                    }
                    DateTime datumKlijenta = new DateTime(godina, mjesec,dan,0,0,0);
                    JMBG: Console.WriteLine("Unesite JMBG (6 karaktera): ");
                    String jmbgKlijenta = Convert.ToString(Console.ReadLine());
                    klijent.Naziv = imeIPrezimeKlijenta;
                    klijent.Datum = datumKlijenta;
                    klijent.JMBG = jmbgKlijenta;
                    if(klijent.JMBG == "") {
                        Console.WriteLine("Neispravan JMBG! Pokusajte ponovo: ");
                        goto JMBG;
                    }
                    ke.dodajKlijenta(klijent);
                }
                else if (unos == "3")
                {
                    POCETAK: Console.WriteLine("Unesite vas identifikacijski broj (duzine 6 karaktera): ");
                    String idKlijenta = Convert.ToString(Console.ReadLine());
                    bool duzina6 = false;
                    if (idKlijenta.Length != 6) duzina6 = true;
                    bool ima = false;
                    for (int i = 0; i < ke.Klijenti.Count; i++)
                    {
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
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Niste unijeli ispravan broj sjedista!");
                            goto BROJSJEDISTA;
                            //return;
                        }
                        ID: Console.WriteLine("Unesite ID aviona (duzine 9, samo mala slova i brojevi (1 - 5)): ");
                        String id = Convert.ToString(Console.ReadLine());
                        avion.Vrsta = v;
                        avion.Sjedista = b;
                        avion.ID = id;
                        if (avion.ID == "")
                        {
                            Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                            goto ID;
                        }
                        PRETRAGA: Console.WriteLine("Unesite nacin pretrage (1 za pretragu preko ID, 2 za pretragu po ostalim atributima): ");
                        String nacinPretrage = Convert.ToString(Console.ReadLine());
                        if (nacinPretrage == "1")
                        {
                            Ipretraga<Avion> p = new IDPretraga(ke.Avioni);
                            List<Avion> pretragaAvioni = p.pretraga(avion);
                            if (p.pretraga(avion).Count != 0)
                            {
                                Console.WriteLine("Avion pronadjen!");
                                Console.WriteLine("Svi avioni na raspolaganju: ");
                                for(int i = 0; i < p.pretraga(avion).Count; i++) {
                                    Console.WriteLine("Avion {0}: vrsta: {1}, broj sjedista: {2}, id: {3}", i + 1, p.pretraga(avion)[i].Vrsta, p.pretraga(avion)[i].Sjedista, p.pretraga(avion)[i].ID);
                                }
                                LISTA: Console.WriteLine("Unesite vrstu aviona iz liste koji zelite: ");
                                String zeljenaVrsta = Convert.ToString(Console.ReadLine());
                                int pozicija = -1;
                                for(int i = 0; i < p.pretraga(avion).Count; i++) { 
                                    if(p.pretraga(avion)[i].Vrsta == zeljenaVrsta) {
                                        pozicija = i;
                                    }
                                }
                                if(pozicija != -1) {
                                    Console.WriteLine("Izabrali ste avion!");
                                    Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                    POCETNIDAN: Console.WriteLine("Dan: ");
                                    int pocetniDan = 0;
                                    try
                                    {
                                        pocetniDan = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNIDAN;
                                    }
                                    POCETNIMJESEC: Console.WriteLine("Mjesec: ");
                                    int pocetniMjesec = 0;
                                    try
                                    {
                                        pocetniMjesec = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNIMJESEC;
                                    }
                                    POCETNAGODINA: Console.WriteLine("Godina: ");
                                    int pocetnaGodina = 0;
                                    try
                                    {
                                        pocetnaGodina = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNAGODINA;
                                    }
                                    DateTime pocetniDatum = new DateTime(pocetnaGodina, pocetniMjesec, pocetniDan, 0,0,0);
                                    Console.WriteLine("Unesite krajnji datum iznajmljivanja: ");
                                    KRAJNJIDAN: Console.WriteLine("Dan: ");
                                    int krajnjiDan = 0;
                                    try
                                    {
                                        krajnjiDan = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJIDAN;
                                    }
                                    KRAJNJIMJESEC: Console.WriteLine("Mjesec: ");
                                    int krajnjiMjesec = 0;
                                    try
                                    {
                                        krajnjiMjesec = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJIMJESEC;
                                    }
                                    KRAJNJAGODINA: Console.WriteLine("Godina: ");
                                    int krajnjaGodina = 0;
                                    try
                                    {
                                        krajnjaGodina = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJAGODINA;
                                    }
                                    DateTime krajnjiDatum = new DateTime(krajnjaGodina, krajnjiMjesec, krajnjiDan, 0, 0, 0);
                                }
                                else {
                                    Console.WriteLine("Avion ne postoji! Pokusajte ponovo: ");
                                    goto LISTA;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Avion nije pronadjen!");
                                Console.WriteLine("Unesite ponovo avion:");
                                goto UNOS;
                            }
                        }
                        else if (nacinPretrage == "2")
                        {
                            Ipretraga<Avion> p = new Pretraga(ke.Avioni);
                            p.pretraga(avion);
                            if (p.pretraga(avion).Count != 0)
                            {
                                Console.WriteLine("Avion pronadjen!");
                                Console.WriteLine("Svi avioni na raspolaganju: ");
                                for (int i = 0; i < p.pretraga(avion).Count; i++)
                                {
                                    Console.WriteLine("Avion {0}: vrsta: {1}, broj sjedista: {2}, id: {3}", i + 1, p.pretraga(avion)[i].Vrsta, p.pretraga(avion)[i].Sjedista, p.pretraga(avion)[i].ID);
                                }
                                LISTA2: Console.WriteLine("Unesite vrstu aviona iz liste koji zelite: ");
                                String zeljenaVrsta = Convert.ToString(Console.ReadLine());
                                int pozicija = -1;
                                for (int i = 0; i < p.pretraga(avion).Count; i++)
                                {
                                    if (p.pretraga(avion)[i].Vrsta == zeljenaVrsta)
                                    {
                                        pozicija = i;
                                    }
                                }
                                if (pozicija != -1)
                                {
                                    Console.WriteLine("Izabrali ste avion!");
                                    Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                    POCETNIDAN2: Console.WriteLine("Dan: ");
                                    int pocetniDan = 0;
                                    try
                                    {
                                        pocetniDan = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNIDAN2;
                                    }
                                    POCETNIMJESEC2: Console.WriteLine("Mjesec: ");
                                    int pocetniMjesec = 0;
                                    try
                                    {
                                        pocetniMjesec = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNIMJESEC2;
                                    }
                                    POCETNAGODINA2: Console.WriteLine("Godina: ");
                                    int pocetnaGodina = 0;
                                    try
                                    {
                                        pocetnaGodina = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto POCETNAGODINA2;
                                    }
                                    DateTime pocetniDatum = new DateTime(pocetnaGodina, pocetniMjesec, pocetniDan, 0, 0, 0);
                                    Console.WriteLine("Unesite krajnji datum iznajmljivanja: ");
                                    KRAJNJIDAN2: Console.WriteLine("Dan: ");
                                    int krajnjiDan = 0;
                                    try
                                    {
                                        krajnjiDan = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJIDAN2;
                                    }
                                    KRAJNJIMJESEC2: Console.WriteLine("Mjesec: ");
                                    int krajnjiMjesec = 0;
                                    try
                                    {
                                        krajnjiMjesec = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJIMJESEC2;
                                    }
                                    KRAJNJAGODINA2: Console.WriteLine("Godina: ");
                                    int krajnjaGodina = 0;
                                    try
                                    {
                                        krajnjaGodina = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("GRESKA! Pokusajte ponovo: ");
                                        goto KRAJNJAGODINA2;
                                    }
                                    DateTime krajnjiDatum = new DateTime(krajnjaGodina, krajnjiMjesec, krajnjiDan, 0, 0, 0);
                                }
                                else
                                {
                                    Console.WriteLine("Avion ne postoji! Pokusajte ponovo: ");
                                    goto LISTA2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Avion nije pronadjen!");
                                Console.WriteLine("Unesite ponovo avion:");
                                goto UNOS;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Neispravan unos. Pokusajte ponovo: ");
                            goto PRETRAGA;
                        }
                    }
                    else
                    {
                        if (duzina6) Console.WriteLine("Niste unijeli id sa 6 karaktera!");
                        else Console.WriteLine("Klijent nije u bazi!");
                        Console.WriteLine("Unesite ponovo: ");
                        goto POCETAK;
                    }
                    Console.ReadKey();
                }
                else if(unos == "4") { return; }
                else if(unos == "5") { }
                else {
                    Console.WriteLine("Neispravan unos!"); 
                }
            }
        }
    }
}

