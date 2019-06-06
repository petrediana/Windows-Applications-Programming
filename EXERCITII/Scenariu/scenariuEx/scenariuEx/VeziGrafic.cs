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
    public partial class VeziGrafic : Form
    {
        List<Student> listaStudent = new List<Student>();

        public VeziGrafic(List<Student> listaStudent)
        {
            InitializeComponent();
            this.listaStudent = listaStudent;

            grafic1.Dock = DockStyle.Fill;

            double[] medii = new double[listaStudent.Count];
            
            for (int i = 0; i < listaStudent.Count; i++)
            {
                medii[i] = listaStudent[i].MedieStudent;
            }

            grafic1.Medii = medii;
        }


    }
}
