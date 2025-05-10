using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class Uscita
    {
        public int TempoU { get; set; }
        Queue<Auto> coda = new Queue<Auto>();
        public Semaphore semaforo = new Semaphore(1, 1);
        Parcheggio park;
        public Uscita(int tempoU, Parcheggio p)
        {
            TempoU = tempoU;
            park = p;
        }

        public void Exit(Auto auto)
        {
            semaforo.WaitOne();
            Thread.Sleep(TempoU);
            semaforo.Release();
        }

    }
    
}
