using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class Parcheggio
    {
        public Ingresso[] nIngressi;
        public Uscita[] nUscite;
        public int posti;
        public Semaphore semaforo = new Semaphore(1, 1);

        public Ingresso[] NIngressi { get {  return nIngressi; } protected set {  nIngressi = value; } }
        public Uscita[] NUscite { get {  return nUscite; } protected set { nUscite = value; } }
        public int Posti { get { return posti; } protected set { posti = value; } }

        public Parcheggio(int ingressiAttuali, int UsciteAttuali, int posti)
        {
            nIngressi = new Ingresso[ingressiAttuali];
            for (int i = 0; i < ingressiAttuali; i++)
                nIngressi[i] = new Ingresso(new Random().Next(1, 10), this);

            nUscite = new Uscita[UsciteAttuali];
            for (int i = 0; i < UsciteAttuali; i++)
                nUscite[i] = new Uscita(new Random().Next(1, 10), this);
            Posti = posti;
        }


    }
}
