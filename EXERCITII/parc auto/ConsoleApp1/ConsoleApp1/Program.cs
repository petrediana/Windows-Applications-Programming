using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sofer s1 = new Sofer(1, "Sofer1", 2, new float[] { 30, 56 }, "Ruta1", 86);
            Sofer s2 = new Sofer(2, "Sofer2", 3, new float[] { 15, 50, 15 }, "Ruta2", 80);

            Console.WriteLine(s1);
            Console.WriteLine(s2);

            Sofer s3 = (Sofer)s1.Clone();
            s1.KMParcursi = new float[] { 10, 15 };

            //merge, cloneaza profund
            Console.WriteLine("\n---Test Clona---");
            Console.WriteLine(s3);

            Console.WriteLine("\n---Test CompareTo---");
            Console.WriteLine(s1.CompareTo(s2));

            Console.WriteLine("\n---Test cast explicit la double---");
            Console.WriteLine((double)s2);

            Console.WriteLine("\n---Test operator +---");
            Sofer s4 = s2 + 10;
            Console.WriteLine(s4);


            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\tuliga1\parc auto\ConsoleApp1\ConsoleApp1\Database5.mdb";Persist Security Info=True
            const string ConnectionString
            = @"Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source=C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\tuliga1\parc auto\ConsoleApp1\ConsoleApp1\Database5.mdb";

            const string ProviderName = "System.Data.OleDb";

            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();

            DbCommand cmdSelect = connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM Soferi";
            DbDataReader reader = cmdSelect.ExecuteReader();

            List<Sofer> listaSoferi = new List<Sofer>();
            while (reader.Read())
            {
                Sofer s = new Sofer();
                s.IDSofer = reader.GetInt32(0);
                s.DenumireSofer = reader.GetString(1);
                s.NrOpririPeRuta = reader.GetInt32(2);

                string[] elemente = reader.GetString(3).Split(',');
                float[] ptVector = new float[elemente.Length];
                for (int i = 0; i < elemente.Length; ++i)
                    ptVector[i] = float.Parse(elemente[i]);

                s.KMParcursi = ptVector;
                s.Denumire = reader.GetString(4);
                s.NrKM = reader.GetInt32(5);

                listaSoferi.Add(s);
            }

            Console.WriteLine("\n---Afisare elemente citite din BD---");
            foreach (var sofer in listaSoferi)
                Console.WriteLine(sofer);

        }
    }
}
