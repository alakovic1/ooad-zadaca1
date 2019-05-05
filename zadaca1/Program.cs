using System;
using System.Collections.Generic;

namespace zadaca1
{
    class Program
    {
        public delegate void MojDelegat(KlasaElemenata ke, String tekstPoruke, String idKlijenta);
        public static void metodaZaObavijestiDELEGAT(KlasaElemenata ke, String tekstPoruke, String idKlijenta) {
            MojDelegat delegat = metodaZaObavijesti;
            delegat(ke,tekstPoruke,idKlijenta);
        }
        public static void metodaZaObavijesti(KlasaElemenata ke, String tekstPoruke, String idKlijenta)
        {
            Obavijest obavijest = new Obavijest(tekstPoruke,idKlijenta,DateTime.Now);
            ke.dodajObavijest(obavijest);
        }

        static void Main(string[] args)
        {
            KlasaElemenata ke = new KlasaElemenata();
            List<Drzava> d = new List<Drzava>();
            KlasaZaIObracun kio = new KlasaZaIObracun();
            int placanjeKaucije = 0;
            Console.WriteLine("MENI");
            for (; ; )
            {
                MENI: Console.WriteLine("Unesite: 0 - kraj programa, 1 - unos vozila/aviona, 2 - unos klijenta, 3 - iznajmljivanje, 4 - povrat aviona i placanje, 5 - ispis liste obavijesti");
                String unos = Convert.ToString(Console.ReadLine());
                if(unos == "0") {
                    Console.WriteLine("Kraj programa!");
                    break;
                }
                else if (unos == "1") {
                    Avion avion = new Avion();
                    Console.WriteLine("Unesite podatke o avionu: ");
                    IZBOR: Console.WriteLine("Izaberite: 1 - putnicki avion, 2 - teretni avion: ");
                    String v = Convert.ToString(Console.ReadLine());
                    if(v != "1" && v!="2") {
                        Console.WriteLine("Pokusajte ponovo: ");
                        goto IZBOR;
                    }
                    Console.WriteLine("Unesite vrstu aviona: ");
                    String vrsta = Convert.ToString(Console.ReadLine());
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
                    if (v == "1") {
                        avion = new PutnickiAvion(vrsta,b,id);
                        if (avion.ID == "")
                        {
                            Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                            goto ID;
                        }
                        LET: Console.WriteLine("Izabrali ste putnicki avion! Izaberite da li zelite let u inostranstvo (1) ili unutar zemlje (2): ");
                        String let = Convert.ToString(Console.ReadLine());
                        if(let == "1") {
                            Console.WriteLine("Unesite naziv drzave u koju putujete: ");
                            String nazivDrzave = Convert.ToString(Console.ReadLine());
                            bool ima = false;
                            for (int i = 0; i < d.Count; i++)
                            {
                                if (d[i].Naziv == nazivDrzave) ima = true;
                            }
                            if(!ima) d.Add(new Drzava(nazivDrzave));
                            LetUInostranstvo novi = new LetUInostranstvo(vrsta, b, id, d);
                            if (novi.ID == "")
                            {
                                Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                                goto ID;
                            }
                            avion = novi;
                            ke.dodajAvion(avion);
                            Console.WriteLine("Uspjesno dodan avion!");
                        }
                        else if(let == "2") {
                            avion = new LetUnutarZemlje(vrsta,b,id);
                            ke.dodajAvion(avion);
                            Console.WriteLine("Uspjesno dodan avion!");
                        }
                        else {
                            Console.WriteLine("Pogresan unos! Pokusajte ponovo: ");
                            goto LET;
                        }
                    }
                    else if(v == "2") {
                        TERETNI: Console.WriteLine("Izabrali ste teretni avion! Unesite ukupni kapacitet u tonama: ");
                        int tAvion = 0;
                        try {
                            tAvion = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception) {
                            Console.WriteLine("GRESKA! Pokusajte ponovo!");
                            goto TERETNI;
                        }
                        avion = new TeretniAvion(vrsta, b, id, tAvion);
                        if (avion.ID == "")
                        {
                            Console.WriteLine("Neispravan ID! Pokusajte ponovo: ");
                            goto ID;
                        }
                        ke.dodajAvion(avion);
                        Console.WriteLine("Uspjesno dodan avion!");
                    }
                }
                else if(unos == "2") {
                    Klijent klijent = new Klijent();
                    Console.WriteLine("Unesite podatke o klijentu: ");
                    IZBOR2: Console.WriteLine("Izaberite: 1 - domaci drzavljanin, 2 - strani drzavljanin");
                    String k = Convert.ToString(Console.ReadLine());
                    if (k != "1" && k != "2")
                    {
                        Console.WriteLine("Pokusajte ponovo: ");
                        goto IZBOR2;
                    }
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
                    if(k == "1") {
                        klijent = new DomaciDrzavljanin(imeIPrezimeKlijenta,datumKlijenta,jmbgKlijenta);
                        if (klijent.JMBG == "")
                        {
                            Console.WriteLine("Neispravan JMBG! Pokusajte ponovo: ");
                            goto JMBG;
                        }
                        ke.dodajKlijenta(klijent);
                        Console.WriteLine("Uspjesno dodan klijent!");
                    }
                    else if(k == "2") {
                        Console.WriteLine("Unesite grad stanovanja: ");
                        String grad = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("Unesite drzavu stanovanja: ");
                        Drzava drzava = new Drzava(Convert.ToString(Console.ReadLine()));
                        klijent = new StraniDrzavljanin(imeIPrezimeKlijenta, datumKlijenta, jmbgKlijenta,grad,drzava);
                        if (klijent.JMBG == "")
                        {
                            Console.WriteLine("Neispravan JMBG! Pokusajte ponovo: ");
                            goto JMBG;
                        }
                        ke.dodajKlijenta(klijent);
                        Console.WriteLine("Uspjesno dodan klijent!");
                    }
                }
                else if (unos == "3")
                {
                    Klijent trenutniKlijent = new Klijent();
                    POCETAK: Console.WriteLine("Unesite vas identifikacijski broj (duzine 6 karaktera): ");
                    String idKlijenta = Convert.ToString(Console.ReadLine());
                    bool duzina6 = false;
                    if (idKlijenta.Length != 6) duzina6 = true;
                    bool ima = false;
                    for (int i = 0; i < ke.Klijenti.Count; i++)
                    {
                        if (ke.Klijenti[i].JMBG == idKlijenta)
                        {
                            trenutniKlijent = ke.Klijenti[i];
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
                                    trenutniKlijent.Avion = p.pretraga(avion)[pozicija];
                                    Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                    POCETNIDAN: Console.WriteLine("Dan: ");
                                    int pocetniDan = 0;
                                    try
                                    {
                                        pocetniDan = Convert.ToInt32(Console.ReadLine());
                                        if (pocetniDan <= 0 || pocetniDan > 31)
                                        {
                                            Console.WriteLine("Neispravan dan! Unesite ponovo: ");
                                            goto POCETNIDAN;
                                        }
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
                                        if(pocetniMjesec <= 0 || pocetniMjesec > 12) {
                                            Console.WriteLine("Neispravan mjesec! Unesite ponovo: ");
                                            goto POCETNIMJESEC;
                                        }
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
                                    trenutniKlijent.PocetakDatum = pocetniDatum;
                                    kio.PocetniDatumIznajmljivanja = pocetniDatum;
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
                                    trenutniKlijent.KrajDatum = krajnjiDatum;
                                    kio.KrajnjiDatumIznajmljivanja = krajnjiDatum;
                                    if(krajnjiDatum < pocetniDatum) {
                                        Console.WriteLine("Krajnji datum prije pocetnog! Unesite pocetni datum iznajmljivanja: ");
                                        goto POCETNIDAN;
                                    }
                                }
                                else {
                                    Console.WriteLine("Avion ne postoji! Pokusajte ponovo: ");
                                    goto LISTA;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Avion nije pronadjen!");
                                Console.WriteLine("Unesite tekst poruke za obavijest: ");
                                String obavijest = Convert.ToString(Console.ReadLine());
                                metodaZaObavijestiDELEGAT(ke, obavijest, trenutniKlijent.JMBG);
                                GRESKA: Console.WriteLine("Unesite ponovo avion (1) ili se vratite na meni (2): ");
                                String izbor = Convert.ToString(Console.ReadLine());
                                if (izbor == "1") goto UNOS;
                                else if (izbor == "2") goto MENI;
                                else {
                                    Console.WriteLine("Pogresan unos! Unesite ponovo: ");
                                    goto GRESKA;
                                }
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
                                    trenutniKlijent.Avion = p.pretraga(avion)[pozicija];
                                    Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                    POCETNIDAN2: Console.WriteLine("Dan: ");
                                    int pocetniDan = 0;
                                    try
                                    {
                                        pocetniDan = Convert.ToInt32(Console.ReadLine());
                                        if(pocetniDan <= 0 || pocetniDan > 31) {
                                            Console.WriteLine("Neispravan dan! Unesite ponovo: ");
                                            goto POCETNIDAN2;
                                        }
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
                                        if (pocetniMjesec <= 0 || pocetniMjesec > 12)
                                        {
                                            Console.WriteLine("Neispravan mjesec! Unesite ponovo: ");
                                            goto POCETNIMJESEC2;
                                        }
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
                                    trenutniKlijent.PocetakDatum = pocetniDatum;
                                    kio.PocetniDatumIznajmljivanja = pocetniDatum;
                                    Console.WriteLine("Unesite iznajmljivanja: ");
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
                                    trenutniKlijent.KrajDatum = krajnjiDatum;
                                    kio.KrajnjiDatumIznajmljivanja = krajnjiDatum;
                                    if (krajnjiDatum < pocetniDatum)
                                    {
                                        Console.WriteLine("Krajnji datum prije pocetnog! Unesite pocetni datum iznajmljivanja: ");
                                        goto POCETNIDAN2;
                                    }
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
                                Console.WriteLine("Unesite tekst poruke za obavijest: ");
                                String obavijest = Convert.ToString(Console.ReadLine());
                                metodaZaObavijestiDELEGAT(ke, obavijest, trenutniKlijent.JMBG);
                                GRESKA2: Console.WriteLine("Unesite ponovo avion (1) ili se vratite na meni (2): ");
                                String izbor = Convert.ToString(Console.ReadLine());
                                if (izbor == "1") goto UNOS;
                                else if (izbor == "2") goto MENI;
                                else
                                {
                                    Console.WriteLine("Pogresan unos! Unesite ponovo: ");
                                    goto GRESKA2;
                                }
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
                    Console.WriteLine("Uspjesno iznajmljen avion!");
                    if(trenutniKlijent is DomaciDrzavljanin) {
                        placanjeKaucije = 50;
                    }
                    else if(trenutniKlijent is StraniDrzavljanin) {
                        placanjeKaucije = 100;
                    }
                }
                else if(unos == "4") {
                    IObracun iObracun = new KlasaZaIObracun(kio.PocetniDatumIznajmljivanja,kio.KrajnjiDatumIznajmljivanja);
                    Console.WriteLine("Unesite vase podatke: ");
                    Klijent trenutniKlijent = new Klijent();
                    POCETAK2: Console.WriteLine("Unesite vas identifikacijski broj (duzine 6 karaktera): ");
                    String idKlijenta = Convert.ToString(Console.ReadLine());
                    bool duzina6 = false;
                    if (idKlijenta.Length != 6) duzina6 = true;
                    bool ima = false;
                    for (int i = 0; i < ke.Klijenti.Count; i++)
                    {
                        if (ke.Klijenti[i].JMBG == idKlijenta)
                        {
                            trenutniKlijent = ke.Klijenti[i];
                            ima = true;
                        }
                    }
                    if (ima) {
                        try
                        {
                            if (trenutniKlijent.Avion == null)
                            {
                                Console.WriteLine("Nije nista iznajmljeno!");
                                goto MENI;
                            }
                        }
                        catch (Exception) {
                            Console.WriteLine("Nije nista iznajmljeno!");
                            goto MENI;
                        }
                        double cijena = iObracun.RacunajCijenu(trenutniKlijent);
                        cijena -= placanjeKaucije;
                        Console.WriteLine("Ukupna cijena iznosi {0}", cijena);
                        if(placanjeKaucije > cijena) {
                            Console.WriteLine("Nema povrata novca!");
                        }
                    }
                    else {
                        if (duzina6) Console.WriteLine("Niste unijeli id sa 6 karaktera!");
                        else Console.WriteLine("Klijent nije u bazi!");
                        Console.WriteLine("Unesite ponovo: ");
                        goto POCETAK2;
                    }
                }
                else if(unos == "5") {
                    if(ke.Obavijesti.Count == 0) {
                        Console.WriteLine("Nema obavijesti!");
                    }
                    else {
                        Console.WriteLine("Lista svih obavijesti: ");
                        for(int i = 0; i < ke.Obavijesti.Count; i++) {
                            Console.WriteLine("{0}. Obavijest: \n Tekst poruke: {1}, ID klijenta: {2}, Datum i vrijeme obavijesti: {3}", i + 1, ke.Obavijesti[i].Tekst, ke.Obavijesti[i].Sifra, ke.Obavijesti[i].DatumIvrijeme);
                        }
                    }
                }
                else {
                    Console.WriteLine("Neispravan unos!"); 
                }
            }
        }
    }
}

