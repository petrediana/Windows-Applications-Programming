using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ruta
    {
        private string denumire;
        private int nrKm;


        public Ruta() { }

        public Ruta(string denumire, int nrKm)
        {
            this.denumire = denumire;
            this.nrKm = nrKm;
        }

        public string Denumire
        {
            get => denumire;
            set
            {
                denumire = value;
            }
        }

        public int NrKM
        {
            get => nrKm;
            set
            {
                nrKm = value;
            }
        }
    }
}
