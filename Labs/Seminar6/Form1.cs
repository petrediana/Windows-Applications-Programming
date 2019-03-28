using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar6
{
    public partial class Form1 : Form
    {
        List<Student> studenti;
        public Form1(List<Student> studenti)
        {
            InitializeComponent();
            this.studenti = studenti;

            listView1.Dock = DockStyle.Fill;

            listView1.View = View.Details;
            listView1.Columns.Add("Nume: ", 120);
            listView1.Columns.Add("Medie", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("Note: ", 200);

            Afisare();
        }

        private void Afisare()
        {
            listView1.Items.Clear();

            foreach(var student in studenti.OrderByDescending(s => s.Medie))
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = student.Nume;
                rand.SubItems.Add(student.Medie.ToString("0.00"));
                rand.SubItems.Add(student.TextNote);
                listView1.Items.Add(rand);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 formular = new Form2();
            formular.ShowDialog();

            if(formular.Rezultat != null)
            {
                studenti.Add(formular.Rezultat);
                Afisare();
            }
        }
    }
}
