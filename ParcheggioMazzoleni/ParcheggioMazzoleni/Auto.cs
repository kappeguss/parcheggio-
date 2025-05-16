using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class Auto : MioThread
    {
        private int counter = 0;
        private Random random = new Random();
        private int id;
        private Parcheggio parcheggio;
        private int tempoSosta;
        private ListBox ingrBox;
        private ListBox uscitaBox;

        public int Id { get { return id; } }
        public int TempoSosta { get { return tempoSosta; } }

        public Auto(Parcheggio parcheggio)
        {
            this.id = ++counter;
            this.parcheggio = parcheggio;
            this.tempoSosta = random.Next(5, 10);

            Avvia(CicloAuto);
        }

        public override string ToString()
        {
            return $"Auto{id} ({tempoSosta}s)";
        }

        public void CicloAuto()
        {
            // Fase di ingresso
            Ingresso ingresso = Entra();
            int nSem = parcheggio.IngressoList.IndexOf(ingresso);

            while (parcheggio.Form.CentroBox.Items.Count >= parcheggio.Posti)
                Thread.Sleep(2000);

            parcheggio.SemIngressi[nSem].WaitOne();
            Thread.Sleep(ingresso.TempoIngresso * 1000);
            parcheggio.SemIngressi[nSem].Release();

            ingresso.Coda.Remove(this);
            parcheggio.AggiornaListBox(ingrBox, ToString(), false);
            parcheggio.AggiornaListBox(parcheggio.Form.CentroBox, ToString(), true);

            // Sosta
            Thread.Sleep(tempoSosta * 1000);
            parcheggio.AggiornaListBox(parcheggio.Form.CentroBox, ToString(), false);

            // Fase di uscita
            int uscitaIndex = random.Next(0, parcheggio.UscitaList.Count);
            Uscita uscita = parcheggio.UscitaList[uscitaIndex];
            uscitaBox = parcheggio.GetUscitaBox(uscitaIndex);
            Esci(uscita);

            parcheggio.SemUscite[uscitaIndex].WaitOne();
            Thread.Sleep(uscita.TempoUscita * 1000);
            parcheggio.SemUscite[uscitaIndex].Release();

            uscita.Coda.Remove(this);
            parcheggio.AggiornaListBox(uscitaBox, ToString(), false);
        }

        private Ingresso Entra()
        {
            int ingressoIndex = random.Next(0, parcheggio.IngressoList.Count);
            Ingresso ingresso = parcheggio.IngressoList[ingressoIndex];
            ingresso.Coda.Add(this);
            ingrBox = parcheggio.GetIngressoBox(ingressoIndex);
            parcheggio.AggiornaListBox(ingrBox, ToString(), true);
            return ingresso;
        }

        private void Esci(Uscita uscita)
        {
            uscita.Coda.Add(this);
            parcheggio.AggiornaListBox(uscitaBox, ToString(), true);
        }
    }
}
