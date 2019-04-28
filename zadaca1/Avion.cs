using System;
namespace zadaca1
{
    public class Avion
    {
        private String vrstaAviona { get; set; }
        private int brojSjedista { get; set; }
        private String id { get; set; }
        public Avion()
        {
            this.vrstaAviona = "";
            this.brojSjedista = 0;
            this.id = "";
        }

        public Avion(string vrstaAviona, int brojSjedista, string id)
        {
            this.vrstaAviona = vrstaAviona;
            this.brojSjedista = brojSjedista;
            if(id.Length == 9)
            {
                for(int i = 0; i < id.Length; i++) {
                    if((id[i] >= 'a' && id[i] <= 'z') || (id[i] >= '1' && id[i] <= '5'))
                    {
                        this.id = id;
                    }
                }
            }
        }
    }
}
