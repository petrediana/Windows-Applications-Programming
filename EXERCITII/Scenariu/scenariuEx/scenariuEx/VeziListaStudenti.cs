using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scenariuEx
{
    public partial class VeziListaStudenti : Form
    {
        List<Student> listaStudenti = new List<Student>();
        public VeziListaStudenti(List<Student> listaStudenti)
        {            
            InitializeComponent();
            this.listaStudenti = listaStudenti;


            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;

            listView1.Columns.Add("Cod", 120);
            listView1.Columns.Add("Nume", 120);
            listView1.Columns.Add("Nr Materii", 120);
            listView1.Columns.Add("Note", 120);
            listView1.Columns.Add("Medie", 120);

            Afiseaza(); 
        }

        private void Afiseaza()
        {
            listView1.Items.Clear();
            
            foreach (var student in listaStudenti.OrderBy(s => s.MedieStudent))
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = student.Cod.ToString();
                rand.SubItems.Add(student.NumeStudent);
                rand.SubItems.Add(student.NumarMaterii.ToString());

                string rezultat = string.Empty;
                for (int i = 0; i < student.NumarMaterii; i++)
                    rezultat += student.Note[i] + " ";

                rand.SubItems.Add(rezultat);
                rand.SubItems.Add(student.MedieStudent.ToString());

                listView1.Items.Add(rand);

            }
        }
    }
}
