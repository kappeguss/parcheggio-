using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class Ingresso
    {
        public int TempoI { get; set; }
        Queue<Auto> coda = new Queue<Auto>();
        private Semaphore semaforo = new Semaphore(1, 1);
        Parcheggio park;
        public Ingresso(int tempoI, Parcheggio p)
        {
            TempoI = tempoI;
            park = p;
        }
        public void Entra(Auto auto)
        {
            park.semaforo.WaitOne();
            if (park.Posti > 0)
            {
                semaforo.WaitOne();
                park.posti--;
                park.semaforo.Release();
                Thread.Sleep(TempoI);
                semaforo.Release();

            }
            else
                park.semaforo.Release();

        }
    }
}
