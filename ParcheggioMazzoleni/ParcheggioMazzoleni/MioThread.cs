using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class MioThread
    {
        private Thread thread;

        public void Avvia(Action azione)
        {
            thread = new Thread(new ThreadStart(azione));
            thread.Start();
        }

        public void Join()
        {
            thread?.Join();
        }

    }

}

