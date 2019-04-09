using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adauga_in_listView
{
    public partial class Form1 : Form
    {
        List<Student> studenti = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            listView1.Dock = DockStyle.Fill;

            listView1.View = View.Details;
            listView1.Columns.Add("Nume: ", 120);
            listView1.Columns.Add("Medie", 60, HorizontalAlignment.Right);
            listView1.Columns.Add("Note: ", 200);
        }

        public void Afisare()
        {
            listView1.Items.Clear();
            foreach(var s in studenti.OrderByDescending(m => m.Medie))
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = s.Nume;
                rand.SubItems.Add(s.Medie.ToString("0.00"));
                rand.SubItems.Add(s.TextNote);

                listView1.Items.Add(rand);
            }
        }

        private void adaugaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 formular = new Form2();
            formular.ShowDialog();

            studenti.Add(formular.Rezultat);
            Afisare();
        }
    }
}
