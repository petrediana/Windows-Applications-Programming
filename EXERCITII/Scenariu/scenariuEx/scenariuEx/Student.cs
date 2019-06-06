using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scenariuEx
{
    public class Student : ICloneable, IComparable<Student>
    {
        private readonly int cod;
        private string numeStudent;
        private int numarMaterii;
        private double[] note;

        public Student() { }

        public Student(int cod, string numeStudent, int numarMaterii, double[] note)
        {
            this.cod = cod;
            this.numeStudent = numeStudent;

            if (numarMaterii >= 0)
                this.numarMaterii = numarMaterii;

            if (note != null)
            {
                this.note = new double[this.numarMaterii];
                for (int i = 0; i < this.numarMaterii; i++)
                {
                    if (note[i] >= 1 && note[i] <= 10)
                    {
                        this.note[i] = note[i];
                    }
                }
            }
        }

        public int Cod
        {
            get { return this.cod; }
        }

        public string NumeStudent
        {
            get { return this.numeStudent; }
            set
            {
                this.numeStudent = value;
            }
        }

        public int NumarMaterii
        {
            get { return this.numarMaterii; }
            set
            {
                if (value >= 0)
                    this.numarMaterii = value;
                else
                    throw new Exception("Numarul de materii nu poate sa fie mai mic decat 0!");
            }
        }

        public double[] Note
        {
            get { return this.note; }
            set
            {
                if (value!= null)
                {
                    this.note = new double[this.numarMaterii];
                    for (int i = 0; i < this.numarMaterii; i++)
                    {
                        if (value[i] >= 1 && value[i] <= 10)
                        {
                            this.note[i] = value[i];
                        }
                    }
                }
            }
        }

        public double MedieStudent
        {
            get
            {
                double sumaNote = 0;
                for (int i = 0; i < this.numarMaterii; i++)
                    sumaNote += note[i];

                if (sumaNote > 0)
                    return (double)(sumaNote / this.numarMaterii);
                else
                    return 0;
            }
        }

        public object Clone()
        {
            Student clona = (Student)MemberwiseClone();

            double[] noteNoi = new double[clona.numarMaterii];
            for (int i = 0; i < clona.numarMaterii; i++)
                noteNoi[i] = clona.note[i];

            clona.Note = noteNoi;

            return clona;
        }

        public int CompareTo(Student other)
        {
            return this.MedieStudent < other.MedieStudent ? -1 : 1;
        }

        public override string ToString()
        {
            string rezultat = string.Format("Cod: {0}, Nume: {1}, NumarMaterii: {2}," +
                                                    " Media: {3} \nNote: ",
                                                this.cod, this.numeStudent, this.numarMaterii, this.MedieStudent);

            for (int i = 0; i < this.numarMaterii; i++)
                rezultat += this.note[i] + " ";

            return rezultat;
        }

    }
}
