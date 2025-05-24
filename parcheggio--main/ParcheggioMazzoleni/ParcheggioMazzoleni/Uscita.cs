using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParcheggioMazzoleni.Auto;

namespace ParcheggioMazzoleni
{
    internal class Uscita
    {
        private Random casuale = new Random();
        private int tempoUscita;
        private List<Auto> coda;

        public List<Auto> Coda { get { return coda; } }
        public int TempoUscita { get { return tempoUscita; } }

        public Uscita()
        {
            tempoUscita = casuale.Next(1, 5);
            coda = new List<Auto>();
        }

    }
    
}
