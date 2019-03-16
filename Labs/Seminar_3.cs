using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate int Operatie(int x, int y);  

    interface IOperatie
    {
        int ExecutaOperatie(int a, int b);
    }
    enum TipOperarie
    {
        Suma,
        Produs
    }

    class Persoana
    {
        public int Cod { get; set; }
        public String Nume { get; set; }
    }
    class Program
    {
        static void ExecutaOperatie(Operatie op)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            foreach (Operatie opindv in op.GetInvocationList())
            {
                int rezultat = op(a, b);
                Console.WriteLine("Rezultatul este: {0}", rezultat);
            }
        }

        class Suma : IOperatie
        {
            public int ExecutaOperatie(int a, int b)
            {
                return a + b;
            }
        }

        class Produs : IOperatie
        {
            public int ExecutaOperatie(int a, int b)
            {
                return a * b;
            }
        }

        public static int Suma1(int x, int y)
        {
            return x + y;
        }

        public static int Produs1(int x, int y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {

            Persoana ion = new Persoana() { Cod = 1, Nume = "Ion" };
            Persoana ana = new Persoana() { Cod = 2, Nume = "Ana" };
            Persoana maria = new Persoana() { Cod = 3, Nume = "Maria" };
            Persoana vasile = new Persoana() { Cod = 4, Nume = "Vasile" };

            List<Persoana> v = new List<Persoana> { ion, ana, maria, vasile };
            v = v.Where(p => p.Cod % 2 == 0).ToList();
            foreach (Persoana persoana in v)
            {
                Console.WriteLine(persoana.Nume);
            }

            foreach(string nume in v.Select(p => p.Nume))
            {
                Console.WriteLine(nume);
            }

            //Operatie lista = Suma1;
            //lista += Produs1;
            //lista += (i, j) =>
            //{
            //    Console.WriteLine("Diferenta!!");
            //    return i - j;
            //};
            //    lista += Produs1;
            //ExecutaOperatie(lista);


            ////ExecutaOperatie(new Suma());
            ////ExecutaOperatie(new Produs());
            //ExecutaOperatie(Suma1);
            //ExecutaOperatie(Produs1);

            //ExecutaOperatie((i, j) => i - j);
            //ExecutaOperatie((a, b) =>
            //{
            //    if (b == 0)
            //    {
            //        Console.WriteLine("Impartire la 0");
            //        return 0;
            //    }
            //    else
            //        return a / b;
            //});

        }
    }
}
