using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scenariuEx
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student(10, "Gigel", 2, new double[]{ 7, 8 });
            Student s3 = new Student(11, "Ionel", 2, new double[] { 9, 9 });

            Console.WriteLine(s1);
            Console.WriteLine("\n---" + s2);

            Console.WriteLine("\nEXEMPLU DEEP COPY:");
            s2 = (Student)s3.Clone();
            s3.NumeStudent = "aaaaaa";

            Console.WriteLine(s2);
            Console.WriteLine(s3);

            List<Student> listaStudenti = new List<Student>();
            Grupa grupa1 = new Grupa(listaStudenti, "Grupa mea");
            grupa1.AdaugaStudent(s1);
            grupa1.AdaugaStudent(s2);
            grupa1.AdaugaStudent(s3);

            Console.WriteLine("\n\n" + grupa1);

            Grupa grupa2 = (Grupa)grupa1.Clone();
            grupa1.AdaugaStudent(new Student());

            Console.WriteLine(grupa2);
            Console.WriteLine(grupa1);

            Console.WriteLine(grupa1[2]);


            Console.WriteLine("\nLista de studenti sortata pt grupa1: ");
            grupa1.SorteazaDupaMedie();
            Console.WriteLine(grupa1);


            const string ConnectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source
        =C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\scenariuEx\scenariuEx\Studenti.mdb;";

            const string ProviderName = "System.Data.OleDb";

            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();

            DbCommand SelectComanda = connection.CreateCommand();
            SelectComanda.CommandText = "SELECT * FROM STUDENTI";

            DbDataReader reader = SelectComanda.ExecuteReader();

            List<Student> listaNoua = new List<Student>();
            while (reader.Read())
            {
                int cod;
                string numeStudent;
                int nrNote;
                double[] note;

                string stringNote;

                cod = (int)reader["Cod"];
                numeStudent = (string)reader["Nume"];
                nrNote = (int)reader["NrMaterii"];

                stringNote = (string)reader["Note"];
                string[] note_seperate = stringNote.Split(',');

                note = new double[nrNote];
                for (int i = 0; i < nrNote; i++)
                {
                    note[i] = double.Parse(note_seperate[i]);
                }

                Student student = new Student(cod, numeStudent, nrNote, note);
                listaNoua.Add(student);
            }

            foreach (var student in listaNoua)
            {
                Console.WriteLine(student);
            }

            MeniuPrincipal meniu = new MeniuPrincipal(listaNoua);
            meniu.ShowDialog();
        }
    }
}
