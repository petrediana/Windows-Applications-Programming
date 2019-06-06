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
    public partial class AdaugaStudent : Form
    {
        public Student deAdaugat;
        public AdaugaStudent()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string codStud = textBox2.Text;
            string denumireStud = textBox1.Text;
            string nrMaterii = textBox3.Text;
            string note = textBox4.Text;
            bool iesi = true;

            try
            {
                if (string.IsNullOrEmpty(codStud))
                    throw new Exception("Cod student null!!");

                if (string.IsNullOrEmpty(denumireStud))
                    throw new Exception("Nume null");

                if (string.IsNullOrEmpty(nrMaterii))
                    throw new Exception("Nr Materii null");

                if (string.IsNullOrEmpty(note))
                    throw new Exception("Note null");

                int cod = int.Parse(codStud);
                int materii = int.Parse(nrMaterii);
                double[] noteS = new double[materii];
                int i = 0;

                string[] nota = note.Split(' ');
                foreach (var n in nota)
                {

                    if (i < materii)
                    {
                        noteS[i] = double.Parse(n);
                        i++;

                    }
                }

                deAdaugat = new Student(cod, denumireStud, materii, noteS);
                MessageBox.Show(deAdaugat.ToString());
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exceptie: {0}", ex.Message));
                Console.WriteLine(ex.Message);
                iesi = false;
            }

            if (iesi)
                Close();
        }
    }
}
