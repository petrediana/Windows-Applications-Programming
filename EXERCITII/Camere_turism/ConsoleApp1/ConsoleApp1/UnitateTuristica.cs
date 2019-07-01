using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UnitateTuristica
    {
        private string denumireUT;
        private Camera[] camere;
        private int capacitate;

        public UnitateTuristica() { }

        public UnitateTuristica(string den, Camera[] c, int cap)
        {
            denumireUT = den;
            camere = c;
            capacitate = cap;
        }

        public string DenumireUT
        {
            get => denumireUT;
            set
            {
                denumireUT = value;
            }
        }

        public Camera[] Camere
        {
            get => camere;
            set
            {
                camere = value;
            }
        }

        public int Capacitate
        {
            get => capacitate;
            set
            {
                capacitate = value;
            }
        }

        string puneCamereString()
        {
            string str = string.Empty;

            foreach (var camera in camere)
                str += camera.ToString() + "\n";

            return str;
        }

        public override string ToString()
        {
            return string.Format("Den UT: {0}, Capacitate: {1} \n Camere: {2}",
                denumireUT, capacitate, puneCamereString());
        }
    }
}
