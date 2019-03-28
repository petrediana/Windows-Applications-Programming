using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//TEMA!!!!!!
//sa modific datele din listview la dublu click!!!!!!
namespace Seminar6
{
    static class Program
    {
        const string Calefisier = "date.txt";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            List<Student> studenti = new List<Student>();

            string[] linii = File.ReadAllLines(Calefisier);
            int numarStudenti = int.Parse(linii[0]);

            for(int i = 0; i < numarStudenti; i++)
            {
                studenti.Add(new Student(nume: linii[i * 2 + 1], textNote: linii[i * 2 + 2]));
            }

            foreach(var student in studenti)
            {
                Console.WriteLine("Nume: {0}", student.Nume);
                
            }
            Application.Run(new Form1(studenti));

            string rezultat = studenti.Count + "\n";
            foreach(Student student in studenti)
            {
                rezultat += student.Nume + "\n";
                rezultat += student.TextNote + "\n";
            }
            File.WriteAllText(Calefisier, rezultat);
        }
    }
}