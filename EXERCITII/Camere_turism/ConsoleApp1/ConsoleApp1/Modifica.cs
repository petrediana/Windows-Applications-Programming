using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Modifica : Form
    {
        public Camera camera;
        public Modifica(Camera camera)
        {
            InitializeComponent();
            this.camera = camera;

            PuneDate();
        }

        private void PuneDate()
        {
            textBox1.Text = camera.IdCamera.ToString();

            string di = string.Empty;
            di = camera.DataInceputCazare.Day + "," + camera.DataInceputCazare.Month + "," + camera.DataInceputCazare.Year;
            textBox2.Text = di;

            string ds = string.Empty; 
            ds = camera.DataSfarsitCazare.Day + "," + camera.DataSfarsitCazare.Month + "," + camera.DataSfarsitCazare.Year;
            textBox3.Text = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Camp nul!!");
                    throw new Exception("Nu se poate!");
                }
                else
                {
                    camera.IdCamera = int.Parse(textBox1.Text);
                }

                string[] t2 = textBox2.Text.Split(',');
                DateTime di = new DateTime(int.Parse(t2[2]), int.Parse(t2[1]), int.Parse(t2[0]));
                camera.DataInceputCazare = di;

                string[] t3 = textBox3.Text.Split(',');
                DateTime ds = new DateTime(int.Parse(t3[2]), int.Parse(t3[1]), int.Parse(t3[0]));
                camera.DataSfarsitCazare = ds;

                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
