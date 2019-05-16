using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDropTest
{
    public partial class Form1 : Form
    {
        TestObject test;
        bool selected = false;

        public Form1()
        {
            InitializeComponent();

            listView1.Dock = DockStyle.Top;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Range");
            listView1.Columns.Add("Total");

            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = "Random name";
            listViewItem.SubItems.Add("100");
            listViewItem.SubItems.Add("200");

            ListViewItem item = new ListViewItem();
            item.Text = "Another random Name";
            item.SubItems.Add("50");
            item.SubItems.Add("150");

            listView1.Items.Add(listViewItem);
            listView1.Items.Add(item);
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        private void ListView_MouseDown(object sender, MouseEventArgs e)
        {
            //DoDragDrop(listView1.SelectedItems.ToString(), DragDropEffects.Move);

            //string something = listView1.SelectedItems.ToString();
            // MessageBox.Show(something);
            if (!selected)
                MessageBox.Show("Not selected yet!!!");
            else
            {
                //MessageBox.Show("Might work?");
                DoDragDrop(test.ToString(), DragDropEffects.Move);
                selected = false;
            }
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                test = new TestObject(listView1.SelectedItems[0].Text,
                    listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text);
                // MessageBox.Show(test.ToString());
                selected = true;
            }
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = "";
            string result = e.Data.GetData(DataFormats.StringFormat) as string;
            MessageBox.Show(result);
            textBox1.Text = result;
            
        }
    }
}
