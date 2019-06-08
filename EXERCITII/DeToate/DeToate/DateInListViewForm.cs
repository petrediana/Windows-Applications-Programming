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
    public partial class DateInListViewForm : Form
    {
        List<Student> listaStudenti = new List<Student>();

        public DateInListViewForm(List<Student> listaStudenti)
        {
            InitializeComponent();
            this.listaStudenti = listaStudenti;

            listView1.Dock = DockStyle.Left;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Cod", 120);
            listView1.Columns.Add("Nume", 120);
            listView1.Columns.Add("Medie", 120);

            Afiseaza();

            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            contextMenuStrip1.ItemClicked += ContextMenuStrip1_ItemClicked;
        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;

            if (item.Text == "Vezi")
            {
                MessageBox.Show("Vezi");

                MessageBox.Show(listaStudenti[listView1.SelectedItems[0].Index].ToString());
            }

            if (item.Text == "Sterge")
            {
                MessageBox.Show("Sterge| Index: " + listView1.SelectedItems[0].Index);
                listView1.SelectedItems[0].Remove();
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
            }
        }

        private void Afiseaza()
        {
            listView1.Items.Clear();

            foreach (var stud in listaStudenti)
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = stud.Cod.ToString();
                rand.SubItems.Add(stud.Denumire);
                rand.SubItems.Add(stud.Medie.ToString());

                listView1.Items.Add(rand);
            }
        }
    }
}
