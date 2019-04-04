using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Student Rezultat { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Rezultat = new Student(textBox2.Text, textBox1.Text);
            Close();
        }
    }
}
