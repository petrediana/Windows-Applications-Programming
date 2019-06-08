using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeToate
{
    [Serializable]
    public class Student
    {
        public int Cod;
        public string Denumire;
        public decimal Medie;

        public Student() { }

        public Student(int cod, string denumire, decimal medie)
        {
            Cod = cod;
            Denumire = denumire;
            Medie = medie;
        }

        public override string ToString()
        {
            return Cod + " " + Denumire + " " + Medie;
        }
    }
}
