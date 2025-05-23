using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class Auto 
    {
        private string numeroAuto;
        private Random random = new Random();
        private static int id=0;
        private Parcheggio parcheggio;
        private int tempoSosta;
        private ListBox ingressiBox;
        private ListBox uscitaBox;

        public static int Id { get { return id; } }
        public int TempoSosta { get { return tempoSosta; } }

        public Thread thread { get; set; }

        public Auto(Parcheggio parcheggio)
        {
            this.tempoSosta = random.Next(5, 10);
            numeroAuto = $"Auto{GeneraNum()} ({tempoSosta}s)"; 
            this.parcheggio = parcheggio;
            thread = new Thread(CicloAuto);
            thread.Start();
            //Avvia(CicloAuto);
        }

        private static string GeneraNum()
        {
            id++;
            return id.ToString();
        }
        /*public override string ToString()
        {
            return $"Auto{id} ({tempoSosta}s)";
        }*/

        public void CicloAuto()
        {
            // Fase di ingresso
            Ingresso ingresso = Entra();
            int nSem = parcheggio.IngressoList.IndexOf(ingresso);

            parcheggio.SemIngressi[nSem].WaitOne();
            Thread.Sleep(ingresso.TempoIngresso * 1000);
            parcheggio.SemIngressi[nSem].Release();

            ingresso.Coda.Remove(this);
            parcheggio.AggiornaListBox(ingressiBox, numeroAuto, false);
            parcheggio.AggiornaListBox(parcheggio.Form.CentroBox, numeroAuto, true);

            // Sosta
            Thread.Sleep(tempoSosta * 1000);
            parcheggio.AggiornaListBox(parcheggio.Form.CentroBox, numeroAuto, false);

            // Fase di uscita
            int uscitaIndex = random.Next(0, parcheggio.UscitaList.Count);
            Uscita uscita = parcheggio.UscitaList[uscitaIndex];
            uscitaBox = parcheggio.GetUscitaBox(uscitaIndex);
            Esci(uscita);

            parcheggio.SemUscite[uscitaIndex].WaitOne();
            Thread.Sleep(uscita.TempoUscita * 1000);
            parcheggio.SemUscite[uscitaIndex].Release();

            uscita.Coda.Remove(this);
            parcheggio.AggiornaListBox(uscitaBox, numeroAuto, false);
        }

        private Ingresso Entra()
        {
            int ingressoIndex = random.Next(0, parcheggio.IngressoList.Count);
            Ingresso codaIngressi = parcheggio.IngressoList[ingressoIndex];
            codaIngressi.Coda.Add(this);
            ingressiBox = parcheggio.GetIngressoBox(ingressoIndex);
            parcheggio.AggiornaListBox(ingressiBox, numeroAuto, true);
            return codaIngressi;
        }

        private void Esci(Uscita uscita)
        {
            uscita.Coda.Add(this);
            parcheggio.AggiornaListBox(uscitaBox, numeroAuto, true);
        }
    }
}
