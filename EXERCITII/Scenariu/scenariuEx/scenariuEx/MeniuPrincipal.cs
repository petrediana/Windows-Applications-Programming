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
    public partial class MeniuPrincipal : Form
    {
        List<Student> listaStudenti = new List<Student>();

        public MeniuPrincipal(List<Student> listaStudenti)
        {
            this.listaStudenti = listaStudenti;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeziListaStudenti vezilista = new VeziListaStudenti(listaStudenti);
            vezilista.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VeziGrafic grafic = new VeziGrafic(listaStudenti);
            grafic.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdaugaStudent adauga = new AdaugaStudent();
            adauga.ShowDialog();

            listaStudenti.Add(adauga.deAdaugat);
        }
    }
}
