using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace DeToate
{
    public partial class FormularPrincipal : Form
    {
        List<Student> listaStudenti = new List<Student>();

        public FormularPrincipal(List<Student> listaStudenti)
        {
            InitializeComponent();
            this.listaStudenti = listaStudenti;

            AfiseazaDateInGridView();

            this.KeyPreview = true;
            this.KeyDown += FormularPrincipal_KeyDown;

            graficBare1.Valori = GetListaNote();
            graficLinii1.Valori = GetListaNote();

            dataGridView1.MouseDown += DataGridView1_MouseDown;

                    }



        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indexRandSelectat = dataGridView1.SelectedRows[0].Index;

                List<Student> listaSortat = new List<Student>();

                foreach (var stud in listaStudenti.OrderBy(s => s.Medie))
                {
                    listaSortat.Add(stud);
                }

                string mesaj = string.Empty;
                mesaj += "NumeStudent: " + listaSortat[indexRandSelectat].Denumire +
                    " Cod: " + listaSortat[indexRandSelectat].Cod.ToString() + " Medie: " +
                    listaSortat[indexRandSelectat].Medie.ToString();

                dataGridView1.DoDragDrop(mesaj, DragDropEffects.Move);
            }
        }

        decimal[] GetListaNote()
        {
            List<decimal> note = new List<decimal>();

            foreach (var stud in listaStudenti)
            {
                note.Add(stud.Medie);
            }

            return note.ToArray();
        }

        //eveniment pentru apasarea unor taste / tasta
        private void FormularPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                Console.WriteLine("Control + D\nAm copiat cati studenti am in datagridview\nApasa control + v undeva");

                DataObject dataObject = new DataObject();
                dataObject.SetData(typeof(string), "Am inregistrati: " + listaStudenti.Count + " studenti");

                Clipboard.SetDataObject(dataObject);

            }

            if (e.Control && e.KeyCode.ToString() == "A")
            {
                Console.WriteLine("CONTROL + A\nSe copiaza graficul cu bare");

                DataObject doo = graficBare1.IntoarceGraficBare();
                Clipboard.SetDataObject(doo);
            }

            if (e.Control && e.KeyCode.ToString() == "B")
            {
                Console.WriteLine("CONTROL + B\nSe copiaza graficul cu linii");

                DataObject dataob = graficLinii1.IntoarceGraficLinii();
                Clipboard.SetDataObject(dataob);
            }
        }

        /*
        Ca sa copiez continutul unui grafic am nevoie sa il transmit cu ajutorul unui DataObject
        DataObject e doar un mecanism care ma ajuta sa trasmit date
        Graficele mele fiind un control-user, deci nu le desenez implicit in formularul meu principal, am nevoie de o metoda
        care sa imi intoarca un DataObject cu continutul graficului la momentul respectiv
        */

        private void AfiseazaDateInGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var stud in listaStudenti.OrderBy(s => s.Medie))
            {
                dataGridView1.Rows.Add(stud.Cod, stud.Denumire, stud.Medie);
            }
        }

        //printeaza datele din grid view
        private void aAaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.Show();
        }

        //desenez foaia pe care o printez
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            Graphics gr = e.Graphics;

            gr.DrawString("Date despre studentii inregistrati", new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold),
                Brushes.Black, new PointF(10, 10));

            int spatiu = 0;
            foreach (var stud in listaStudenti)
            {
                gr.DrawString(stud.Denumire, new Font(FontFamily.GenericMonospace, 15, FontStyle.Bold),
                    Brushes.Black, new PointF(10, 200 + spatiu));

                gr.DrawString("Cod Student: "+ stud.Cod.ToString() + " Medie Student:" +stud.Medie.ToString(), 
                    new Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic),
                    Brushes.Red, new PointF(10, 200 + 20 + spatiu));

                spatiu += 100;

            }
        }

        //inchid aplicatia
        private void cCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Salveaza in BD
        private void bBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string ConnectionString =
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Peanutt\Desktop\VS\C#\EXERCITII\DeToate\DeToate\Studenti.mdb;";

            const string ProviderName = "System.Data.OleDb";

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

                DbConnection connection = factory.CreateConnection();
                connection.ConnectionString = ConnectionString;
                connection.Open();

                DbCommand DropDbCommand = connection.CreateCommand();
                DropDbCommand.CommandText = "DELETE * FROM STUDENTI";
                DropDbCommand.ExecuteNonQuery();

                foreach (var stud in listaStudenti)
                {
                    DbCommand InsertDbCommand = connection.CreateCommand();
                    InsertDbCommand.CommandText = "INSERT INTO STUDENTI(COD, NUME, MEDIE) VALUES (?, ?, ?);";

                    DbParameter CodParameter = InsertDbCommand.CreateParameter();
                    CodParameter.DbType = DbType.Int32;

                    DbParameter NumeParameter = InsertDbCommand.CreateParameter();
                    NumeParameter.DbType = DbType.String;

                    DbParameter MedieParameter = InsertDbCommand.CreateParameter();
                    MedieParameter.DbType = DbType.Decimal;

                    InsertDbCommand.Parameters.Add(CodParameter);
                    InsertDbCommand.Parameters.Add(NumeParameter);
                    InsertDbCommand.Parameters.Add(MedieParameter);

                    CodParameter.Value = stud.Cod;
                    NumeParameter.Value = stud.Denumire;
                    MedieParameter.Value = stud.Medie;
                    InsertDbCommand.ExecuteNonQuery();
                }                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateInListViewForm date = new DateInListViewForm(listaStudenti);
            date.ShowDialog();
        }

        private void treeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VeziTreeViewForm form = new VeziTreeViewForm(listaStudenti);
            form.ShowDialog();
        }
    }
}
