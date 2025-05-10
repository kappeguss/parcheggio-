using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcheggioMazzoleni
{
    internal class MioThread
    {
        private Thread _thread;
        public MioThread()
        {
            _thread = new Thread(Run);
        }
        public virtual void Run()
        { }
        public void Start()
        {
            _thread.Start();
        }
        public void Join()
        {
            _thread.Join();
        }




    }

