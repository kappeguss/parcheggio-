using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParcheggioMazzoleni.Auto;

namespace ParcheggioMazzoleni
{
    internal class Ingresso
    {
        private Random casuale = new Random();
        private int tempoIngresso;
        private List<Auto> coda;

        public List<Auto> Coda { get { return coda; } }
        public int TempoIngresso { get { return tempoIngresso; } }

        public Ingresso()
        {
            tempoIngresso = casuale.Next(1, 5);
            coda = new List<Auto>();
        }
    }
}

