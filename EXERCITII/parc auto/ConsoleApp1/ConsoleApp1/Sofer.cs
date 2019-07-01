using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sofer : Ruta, ICloneable, IComparable<Sofer>
    {
        private int idSofer;
        private string denumireSofer;
        private int nrOpririPeRuta; //un vector cu km parcursi la fiecare oprire
        private float[] kmParcursi;

        public Sofer() { }

        public Sofer(int idS, string denumireS, int nrO, float[] km, string denumireRuta, int nrKm) 
        {
            this.Denumire = denumireRuta;
            this.NrKM = nrKm;

            idSofer = idS;
            denumireSofer = denumireS;
            nrOpririPeRuta = nrO;
            kmParcursi = km;
        }

        public int IDSofer
        {
            get => idSofer;
            set
            {
                idSofer = value;
            }
        }

        public string DenumireSofer
        {
            get => denumireSofer;
            set
            {
                denumireSofer = value;
            }
        }

        public int NrOpririPeRuta
        {
            get => nrOpririPeRuta;
            set
            {
                nrOpririPeRuta = value;
            }
        }

        public float[] KMParcursi
        {
            get => kmParcursi;
            set
            {
                kmParcursi = value;
            }
        }

        public object Clone()
        {
            Sofer clona = (Sofer)this.MemberwiseClone();

            float[] newVector = new float[clona.kmParcursi.Length];
            for (int i = 0; i < clona.kmParcursi.Length; i++)
                newVector[i] = clona.kmParcursi[i];

            clona.KMParcursi = newVector;

            return clona;
        }

        public int CompareTo(Sofer other)
        {
            return idSofer.CompareTo(other.idSofer);
        }

        string puneVector()
        {
            string km = String.Empty;

            foreach (var elementV in kmParcursi)
                km += elementV.ToString() + " ";

            return km;
        }

        public override string ToString()
        {
            return string.Format("Id sofer: {0}, Den sofer: {1}, Cate opriri face: {2}, " +
                "Km parcursi pt fiecare oprire: {3} \n -> merge pe ruta: Denumire ruta: {4}, Nr km: {5}\n",
                IDSofer, denumireSofer, NrOpririPeRuta, puneVector(), Denumire, NrKM);
        }

        public static explicit operator double(Sofer s)
        {
            double medie = 0;

            foreach (var element in s.KMParcursi)
                medie += (double)element;

            return (double)(medie / s.KMParcursi.Length);
        }

        public static Sofer operator+(Sofer s, float km)
        {
            Sofer sofer = (Sofer)s.Clone();
            ++(sofer.NrOpririPeRuta);
            sofer.NrKM += (int)km;

            float[] vectorNou = new float[sofer.kmParcursi.Length + 1];
            for (int i = 0; i < sofer.kmParcursi.Length; ++i)
                vectorNou[i] = sofer.kmParcursi[i];

            vectorNou[sofer.kmParcursi.Length] = km;
            sofer.KMParcursi = vectorNou;

            return sofer;
        }

    }
}
