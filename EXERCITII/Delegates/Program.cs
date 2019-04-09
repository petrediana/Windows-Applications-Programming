using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate int Operatie(int x, int y);

    public class Matematica
    {
        public static int Suma_clasa(int x, int y)
        {
            Console.Write("Suma ->");
            return x + y;
        }

        public static int Produs_clasa(int x, int y)
        {
            Console.Write("Produs->");
            return x * y;
        }
    }

    class Program
    {
        public static int Suma_static(int x, int y)
        {
            Console.Write("Suma ->");
            return x + y;
        }

        public static int Produs_static(int x, int y)
        {
            Console.Write("Produsul ->");
            return x * y;
        }


        static void Main(string[] args)
        {           

            Operatie lista = Suma_static;    
            lista += Produs_static;
            
            lista += (i, j) =>
            {
                Console.Write("Diferenta ->");
                return i - j;
            };

            lista += (i, j) =>
             {
                 Console.Write("Restul impartirii ->");
                 if (j == 0)
                 {
                     Console.Write(" Impartire la 0! ");
                     return -1;
                 }
                 else
                     return i / j;
             };

            Console.WriteLine("\nValori pt x, y: ");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            foreach(Operatie op_individuala in lista.GetInvocationList())
            {
                int rezultat = op_individuala(x, y);
                Console.WriteLine("Rezultatul obtinut: {0}", rezultat);
            }

            Console.Write("\n\n----------------\n");
            Operatie lista2 = new Operatie(Matematica.Suma_clasa);
            lista2 += new Operatie(Matematica.Produs_clasa);
            
            foreach(Operatie op_indv2 in lista2.GetInvocationList())
            {
                int rez = op_indv2(x, y);
                Console.WriteLine("Rez: {0}", rez);
            }

        }
    }
}
