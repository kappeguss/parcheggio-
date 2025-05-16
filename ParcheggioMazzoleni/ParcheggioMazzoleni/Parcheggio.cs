using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParcheggioMazzoleni.Auto;

namespace ParcheggioMazzoleni
{
    internal class Parcheggio
    {
            private Form1 form;
            private int posti;
            private List<Semaphore> semIngressi = new List<Semaphore>();
            private List<Semaphore> semUscite = new List<Semaphore>();
            private Random rnd = new Random();
            private List<Ingresso> ingressoList;
            private List<Uscita> uscitaList;
            private List<ListBox> ingressiBoxes = new List<ListBox>();
            private List<ListBox> usciteBoxes = new List<ListBox>();

            public List<Ingresso> IngressoList { get { return ingressoList; } }
            public List<Uscita> UscitaList { get { return uscitaList; } }
            public Form1 Form { get { return form; } }
            public List<Semaphore> SemIngressi { get { return semIngressi; } }
            public List<Semaphore> SemUscite { get { return semUscite; } }
            public int Posti { get { return posti; } }

            public Parcheggio(Form1 form, int posti)
            {
                this.form = form;
                this.posti = posti;
                ingressoList = new List<Ingresso>();
                uscitaList = new List<Uscita>();

                int numIngressi = rnd.Next(1, 6);
                int numUscite = rnd.Next(1, 6);

                for (int i = 0; i < numIngressi; i++)
                {
                    ingressoList.Add(new Ingresso());
                    SemIngressi.Add(new Semaphore(1, 1));

                    ListBox box = new ListBox { Width = 200, Height = 180, Name = "lstIngresso" + i };
                    ingressiBoxes.Add(box);
                    form.FlowPanelIngressi.Controls.Add(box);
                }

                for (int i = 0; i < numUscite; i++)
                {
                    uscitaList.Add(new Uscita());
                    SemUscite.Add(new Semaphore(1, 1));

                    ListBox box = new ListBox { Width = 200, Height = 180, Name = "lstUscita" + i };
                    usciteBoxes.Add(box);
                    form.FlowPanelUscite.Controls.Add(box);
                }

                form.Shown += (sender, e) => AvviaAuto();
            }

            private void AvviaAuto()
            {
                new Thread(() =>
                {
                    for (int i = 10; i > 0; i--)
                    {
                        new Auto(this);
                        Thread.Sleep(1000);
                    }
                }).Start();
            }

            public ListBox GetIngressoBox(int index)
            {
                return ingressiBoxes[index];
            }

            public ListBox GetUscitaBox(int index)
            {
                return usciteBoxes[index];
            }

            public void AggiornaListBox(ListBox box, string testo, bool aggiungi)
            {
            box.Invoke(new Action(() =>
            {
                if (aggiungi)
                    box.Items.Add(testo);
                else
                    box.Items.Remove(testo);
            }));
            }



    }
}
