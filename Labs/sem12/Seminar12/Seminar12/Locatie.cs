using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar12
{
    public class Locatie
    {
        decimal longitudine;
        decimal latitudine;
        string denumire;

        public decimal Longitudine { get => longitudine; set
            {
                if(value < 20.21m || value > 29.79m) {
                    throw new ArgumentOutOfRangeException("longitudine");
                }

                longitudine = value;
            }
        }
        public decimal Latitudine { get => latitudine; set => latitudine = value; }
        public string Denumire { get => denumire; set => denumire = value; }


        public Locatie(string denumire, decimal longitudine, decimal latitudine) {
            Denumire = denumire;
            Latitudine = latitudine;
            Longitudine = longitudine;
        }
    }

    public class Traseu
    {
        List<Locatie> locatii = new List<Locatie>();

        public int NumarLocatii
        {
            get
            {
                return locatii.Count;
            }
        }

        public Locatie this[int index]
        {
            get
            {
                return locatii[index];
            }
        }

        public void AdaugaLocatie(Locatie locatie)
        {
            locatii.Add(locatie);
        }


    }
}
