﻿using System;
namespace zadaca1
{
    public class Drzava
    {
        private String nazivDrzave { get; set; }
        private int brojStanovnika { get; set; }
        public Drzava()
        {

        }

        public Drzava(String naziv)
        {
            this.nazivDrzave = naziv;
        }

        public Drzava(String naziv, int broj)
        {
            this.nazivDrzave = naziv;
            this.brojStanovnika = broj;
        }
    }
}