using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeToate
{       
    class Program
    {
        const string CaleFisier =
        @"C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\DeToate\DeToate\Studenti.txt";

        [STAThread]
        static void Main(string[] args)
        {
            List<Student> listaStudenti = new List<Student>();

            string[] fisier = File.ReadAllLines(CaleFisier);
            for (int i = 0; i < fisier.Length; i++)
            {
                string[] linie = fisier[i].Split(',');
                listaStudenti.Add(new Student(int.Parse(linie[0]), linie[1], decimal.Parse(linie[2])));
            }

            ScrieInFisierBinar(listaStudenti);
            CitesteDinFisierBinar(out listaStudenti);

            foreach (var stud in listaStudenti)
            {
                Console.WriteLine(stud);
            }

            Console.WriteLine("\nDragDrop din DataGridView in Word/Excel cu un element din lista");
            Console.WriteLine("--\nControale: (responsive cu control + V)\nCONTROL + A -> GRAFIC BARE" +
                                              "\nCONTROL + B -> GRAFIC LINII" +
                                               "\nCONTROL + D -> CATI STUDENTI AM\n--");


            FormularPrincipal form = new FormularPrincipal(listaStudenti);
            form.ShowDialog();
        }

        static void ScrieInFisierBinar(List<Student> listaStudenti)
        {
            FileStream fileStream = new FileStream("Studenti.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fileStream, listaStudenti);
            fileStream.Close();
        }

        static void CitesteDinFisierBinar(out List<Student> listaStudenti)
        {
            FileStream fileStream = new FileStream("Studenti.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            listaStudenti = (List<Student>)bf.Deserialize(fileStream);

            fileStream.Close();
        }
    }
}
