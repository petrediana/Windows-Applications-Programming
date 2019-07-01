using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera c1 = new Camera(10, new DateTime(2019, 10, 02), new DateTime(2019, 10, 05));
            Console.WriteLine(c1);

            Console.WriteLine("\n---Test operator +");
            c1 = c1 + 2;
            Console.WriteLine(c1);

            Console.WriteLine("\n---Test cast explicit string");
            Console.WriteLine((string)c1);


            List<Camera> camere = new List<Camera>();

            string[] t = File.ReadAllLines(@"C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\tuliga1\Camere_turism\ConsoleApp1\ConsoleApp1\Camere.txt");

            for (int i = 0; i < t.Length; ++i)
            {
                string[] elementeCamera = t[i].Split(',');
                Camera c = new Camera();
                c.IdCamera = int.Parse(elementeCamera[0]);

                DateTime di = new DateTime(int.Parse(elementeCamera[1]), int.Parse(elementeCamera[2]),
                    int.Parse(elementeCamera[3]));
                DateTime ds = new DateTime(int.Parse(elementeCamera[4]), int.Parse(elementeCamera[5]),
                    int.Parse(elementeCamera[6]));

                c.DataInceputCazare = di;
                c.DataSfarsitCazare = ds;

                camere.Add(c);
            }

            Console.WriteLine("\n---Afisare camere din fisier txt");
            foreach (var c in camere)
                Console.WriteLine(c);

            UnitateTuristica unitateTuristica = new UnitateTuristica("Unitate1",
                camere.ToArray(), 4);

            Console.WriteLine("\n---Afisare unitate turistica");
            Console.WriteLine(unitateTuristica);

            Form1 form = new Form1(camere);
            form.ShowDialog();
        }
    }
}
