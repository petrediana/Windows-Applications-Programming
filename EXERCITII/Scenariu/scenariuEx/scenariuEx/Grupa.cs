using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scenariuEx
{
    public class Grupa : ICloneable
    {
        private List<Student> listaStudenti = new List<Student>();
        private string denumireGrupa;

        public Grupa() { }

        public Grupa(List<Student> listaStudenti, string denumireGrupa)
        {
            this.listaStudenti = listaStudenti;
            this.denumireGrupa = denumireGrupa;
        }

        private List<Student> ListaStudenti
        {
            set
            {
                this.listaStudenti = value;
            }
        }

        public void AdaugaStudent(Student student)
        {
            listaStudenti.Add(student);
        }

        public string DenumireGrupa
        {
            get { return this.denumireGrupa; }
            set { this.denumireGrupa = value; }
        }

        public override string ToString()
        {
            string rezultat = string.Format("NumeGrupa: {0}, Studentii: \n", this.denumireGrupa);

            foreach (var student in listaStudenti)
            {
                rezultat += student.ToString() + "\n";
            }

            return rezultat;
        }

        public object Clone()
        {
            Grupa clona = (Grupa)MemberwiseClone();

            List<Student> listaNoua = new List<Student>();
            foreach (var student in clona.listaStudenti)
            {
                listaNoua.Add((Student)student.Clone());
            }

            clona.ListaStudenti = listaNoua;

            return clona;
        }

        public Student this [int index]
        {
            get
            {
                if (index >= 0 && index <= listaStudenti.Count)
                    return listaStudenti[index];
                else
                    throw new Exception("Indexul nu exista!!!");
            }
        }

        public void SorteazaDupaMedie()
        {
            listaStudenti.Sort();
        }
    }
}
