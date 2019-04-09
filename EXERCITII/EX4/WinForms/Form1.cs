using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex_4
{
    public partial class Form1 : Form
    {
        public Persoana Rezultat
        {
            get;
            set;
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rezultat = new Persoana(textBox1.Text, textBox2.Text);
            Rezultat.afisare_persoana();
            Close();
        }
    }
}
