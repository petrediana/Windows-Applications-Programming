using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Departament : System.Object
    {
        int id;
        public Departament(int id, string denumire)
        {
            this.id = id;
            Denumire = denumire;
        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int valoare) { this.id = valoare; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Denumire { get; private set; }


        public ListaDepartamente Lista { get; } = new ListaDepartamente();

        public override string ToString()
        {
            return string.Format("#{0} - {1}", Id, Denumire);
        }
        
    }

    public class ListaDepartamente
    {
        List<Departament> lista = new List<Departament>();
        public void Adauga(Departament departament)
        {
            lista.Add(departament);
        }
        public int Nr
        {
            get { return lista.Count; }
        }

        public Departament this[int index]
        {
            get { return lista[index]; }
            //set { lista[index] = value; }
        }
    }
    class Program
    {
        static void Afisare(Departament departament, int nivel = 0)
        {
            Console.WriteLine(new string(' ', 3 * nivel));
            Console.WriteLine(departament);
            for(int i = 0; i < departament.Lista.Nr; i++)
            {
                Afisare(departament.Lista[i], nivel ++);
        
            }
        }
        static void Main(string[] args)
        {
            Departament ase = new Departament(1, "ASE");
            Departament csie = new Departament(2, "CSIE");
            Departament rei = new Departament(3, "REI");
            Departament cig= new Departament(4, "CIG");
            Departament ie = new Departament(5, "IE");
            Departament cib = new Departament(6, "Cib");
            Departament stat = new Departament(7, "Stat");
            //ase.setId(5);
            //Console.WriteLine(ase.getId());
            ase.Id = 5;
            Console.WriteLine(ase.Id);
            Console.WriteLine(ase.ToString());
            //Console.WriteLine((ase as object).ToString());

            List<Departament> v = new List<Departament>();
            Console.WriteLine(v.Count);
            v.Add(ase);
            Console.WriteLine(v.Count);
            v.AddRange(new Departament[] { csie, rei, cig });
            Console.WriteLine(v.Count);
            Console.WriteLine((v[2] as Departament).Denumire);

            foreach (Departament departament in v)
            {
                Console.WriteLine(departament);
            }
            ase.Lista.Adauga(csie);
            ase.Lista.Adauga(rei);
            ase.Lista.Adauga(cig);

            csie.Lista.Adauga(ie);
            csie.Lista.Adauga(cib);
            csie.Lista.Adauga(stat);

            rei.Lista.Adauga(new Departament(9, "LM"));

            Afisare(ase);

        }
    }
}