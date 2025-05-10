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
        private double tempoSosta;
        private int targa;
        private string marca;
        private string modello;
        private Parcheggio park;
        private static Random random = new Random();

        public Parcheggio Park { get { return park; } protected set { park = value; } } 
        public double TempoSosta { get { return tempoSosta; } protected set {  tempoSosta = value; } }
        public string Modello { get {  return modello; } protected set {  modello = value; } }
        public string Marca { get {  return marca; } protected set {  marca = value; } }
        public int Targa { get { return targa; } protected set { targa = value; } }

        public Auto(int tempoS, int targa, string marca, string modello, Parcheggio p)
        {
            TempoSosta = random.Next(10000, 100); ;
            Targa = targa;
            Marca = marca;
            Modello = modello;
            Park = p;
        }
       




    }
}
