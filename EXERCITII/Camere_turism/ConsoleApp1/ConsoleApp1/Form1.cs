using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        List<Camera> camere = new List<Camera>();
        public Form1(List<Camera> camere)
        {
            InitializeComponent();
            this.camere = camere;

            listView1.View = View.Details;
            listView1.Dock = DockStyle.Left;

            listView1.Columns.Add("Id camera", 70);
            listView1.Columns.Add("Data inceput", 150);
            listView1.Columns.Add("Data sfarsit", 150);
            listView1.FullRowSelect = true;
            listView1.DoubleClick += ListView1_DoubleClick;

            contextMenuStrip1.ItemClicked += ContextMenuStrip1_ItemClicked;

            AfisareListview();
            this.FormClosing += Form1_FormClosing;
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Camera c = new Camera();
                int index = listView1.Items.IndexOf(listView1.SelectedItems[0]);
                c = camere[index];

                //MessageBox.Show(listView1.SelectedItems[0].SubItems[1].ToString());
                Modifica form = new Modifica(c);
                form.ShowDialog();

                camere[camere.IndexOf(c)] = form.camera;
                AfisareListview();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fileStream = new FileStream("Camere.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fileStream, camere);

            fileStream.Close();
        }

        private void ContextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
                if (item.Text == "Schimba culoare")
                {
                    MessageBox.Show("Schimb culoare");
                    ColorDialog cd = new ColorDialog();
                    cd.ShowDialog();

                    listView1.SelectedItems[0].BackColor = cd.Color;
                }
            }
        }

        private void AfisareListview()
        {
            listView1.Items.Clear();

            foreach (var camera in camere)
            {
                ListViewItem rand = new ListViewItem();
                rand.Text = camera.IdCamera.ToString();
                rand.SubItems.Add(camera.DataInceputCazare.ToString());
                rand.SubItems.Add(camera.DataSfarsitCazare.ToString());

                listView1.Items.Add(rand);
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Filtrare Dupa id PAR Crescator");

                listView1.Items.Clear();
                foreach (var camera in camere.OrderBy(c => c.IdCamera))
                {
                    if (camera.IdCamera % 2 == 0)
                    {
                        ListViewItem rand = new ListViewItem();
                        rand.Text = camera.IdCamera.ToString();
                        rand.SubItems.Add(camera.DataInceputCazare.ToString());
                        rand.SubItems.Add(camera.DataSfarsitCazare.ToString());

                        listView1.Items.Add(rand);
                    }
                }


            }
        }

        private void refreshLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfisareListview();
        }
    }
}
