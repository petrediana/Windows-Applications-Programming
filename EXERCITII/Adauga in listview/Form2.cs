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
    public partial class Form2 : Form
    {
        public Student Rezultat { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rezultat = new Student(textBox1.Text, textBox2.Text);
            MessageBox.Show(string.Format("Note: {0}", Rezultat.TextNote));
            Close();
        }
    }
}
