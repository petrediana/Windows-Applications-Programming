using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeToate
{
    public partial class VeziTreeViewForm : Form
    {
        List<Student> listaStudenti = new List<Student>();

        public VeziTreeViewForm(List<Student> listaStudenti)
        {
            InitializeComponent();
            this.listaStudenti = listaStudenti;

            Afiseaza();
        }

        private void Afiseaza()
        {
            foreach (var stud in listaStudenti)
            {
                if (stud.Cod % 2 == 0)
                {
                    TreeNode nod = new TreeNode(stud.ToString());
                    treeView1.Nodes[0].Nodes.Add(nod);
                }
                else
                {
                    TreeNode nod = new TreeNode(stud.ToString());
                    treeView1.Nodes[1].Nodes.Add(nod);
                }
            }
        }
    }
}
