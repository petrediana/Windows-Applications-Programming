using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Formular : Form
    {
        TextBox txtA = new TextBox();
        TextBox txtB = new TextBox();
        Button button = new Button();

        public Formular()
        {
            Initializare();
        }

        void Initializare()
        {
            this.Controls.Add(txtA);
            this.Controls.Add(txtB);
            this.Controls.Add(button);


            Size = new Size(250, 200);

            txtA.Location = new Point(10, 10);
            txtA.Size = new Size(35, 25);

            txtB.Location = new Point(10 + 35 + 10, 10);
            txtB.Size = new Size(35, 25);

            button.Location = new Point(10, 10 + 25 + 10);
            button.Size = new Size(35 + 10 + 35, 25);


            Text = "aplicatie";
            button.Text = "SUMA";
            txtA.Text = "0.0";
            txtB.Text = "0.0";

            button.ForeColor = Color.Blue;
            button.Click += ActiuneButon;
        }

        void ActiuneButon(object s, EventArgs e)
        {
            Console.Write(s);
            decimal a = decimal.Parse(txtA.Text);
            decimal b = decimal.Parse(txtB.Text);

            MessageBox.Show(string.Format(
                "{0} + {1}  = {2}", a, b, a + b));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Formular
            // 
            this.ClientSize = new System.Drawing.Size(198, 233);
            this.Name = "Formular";
            this.ResumeLayout(false);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            Application.Run(new Formular());
            Console.Write("Final");
        }
    }
}
