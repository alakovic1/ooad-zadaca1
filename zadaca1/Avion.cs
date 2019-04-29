using System;
namespace zadaca1
{
    public class Avion
    {
        private String vrstaAviona;
        private int brojSjedista;
        private String id;
        public String Vrsta { get { return vrstaAviona; } set { vrstaAviona = value; } }
        public int Sjedista { get { return brojSjedista; } set { brojSjedista = value; } }
        public String ID { get { return id; } 
        set {
                bool netacno = false;
                if(value.Length == 9) {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < '1' || (value[i] > '5' && value[i] < 'a') || value[i] > 'z'))
                        {
                            netacno = true;
                        }
                    }
                    if (!netacno) id = value;
                }
            } 
            }
        public Avion()
        {
            this.vrstaAviona = "";
            this.brojSjedista = 0;
            this.id = "";
        }

        public Avion(string vrstaAviona, int brojSjedista, string id)
        {
            bool netacno = false;
            this.vrstaAviona = vrstaAviona;
            this.brojSjedista = brojSjedista;
            if(id.Length == 9)
            {
                for(int i = 0; i < id.Length; i++) {
                    if((id[i] < '1' || (id[i] > '5' && id[i] < 'a') || id[i] > 'z'))
                    {
                        netacno = true;
                    }
                }
                if(!netacno) this.id = id;
            }
        }
    }
}
