using System;
using System.Data.Common;

namespace ConsoleApp1
{
    class Program
    {
        const string ConnectionString
            = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Stud\Desktop\Seminar10\Database2.mdb";


        const string ProviderName = "System.Data.OleDb";
        static void Main(string[] args)
        {
            //da
            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();

            DbCommand cmdNumar = connection.CreateCommand();
            cmdNumar.CommandText = "SELECT COUNT(*) FROM Persoane";

            DbCommand cmdInsert = connection.CreateCommand();
            cmdInsert.CommandText = "INSERT INTO PERSOANE(Nume, Varsta) VALUES (?, @varsta)";

            DbParameter paramNume = cmdInsert.CreateParameter();
            paramNume.DbType = System.Data.DbType.String;
            cmdInsert.Parameters.Add(paramNume);

            DbParameter paramVarsta = cmdInsert.CreateParameter();
            paramVarsta.DbType = System.Data.DbType.Int32;
            cmdInsert.Parameters.Add(paramVarsta);

            for(int i = 0; i < 10; i++)
            {
                paramNume.Value = "Test " + i;
                paramVarsta.Value = 15 + i;
                cmdInsert.ExecuteNonQuery();
            }

            DbCommand cmdSelect = connection.CreateCommand();
            cmdSelect.CommandText = "SELECT * FROM Persoane ";
            DbDataReader reader = cmdSelect.ExecuteReader(); // pointer catre inregistrearea curenta, asemanator cu un CURSOR 
            while (reader.Read())
            {
                int cod = (int)reader["Cod"]; //reader.GetInt32(0);
                string Nume = reader.GetString(1);
                int varsta = reader.GetInt32(2);

                Console.WriteLine("#{0} - {1} ({2} ani )", cod, Nume, varsta);
            }

            int numarPersoane = (int)cmdNumar.ExecuteScalar();
            Console.WriteLine("Numar persoane: {0}", numarPersoane);
        }
    }
}
