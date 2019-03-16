using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex_5
{
    class myForm : Form
    {
        TextBox txt = new TextBox();
        Button btn_plus = new Button();
        Button btn_minus = new Button();
        Button btn_show_txt = new Button();

        public myForm()
        {
            Initializare();
        }

        void Initializare()
        {
            this.Controls.Add(txt);
            this.Controls.Add(btn_plus);
            this.Controls.Add(btn_minus);
            this.Controls.Add(btn_show_txt);

           

            Size = new Size(250, 250);
            Text = "Exercitiul 5";
            

            txt.Location = new Point(0, 0);
            txt.Size = new Size(250, 50);
            txt.Text = "0";

            btn_plus.Location = new Point(65, 35);
            btn_plus.Size = new Size(45, 75);
            btn_plus.Text = "+";

            btn_minus.Location = new Point(65 + 50, 35);
            btn_minus.Size = new Size(45, 75);
            btn_minus.Text = "-";

            btn_show_txt.Location = new  Point(65, 120);
            btn_show_txt.Size = new Size(100, 35);
            btn_show_txt.Text = "Show number";
            btn_show_txt.ForeColor = Color.BlueViolet;

            btn_show_txt.Click += Show_Number;
            btn_plus.Click += Add_to_Number;
            btn_minus.Click += Substract_to_Number;
        }

        void Show_Number(object s, EventArgs e)
        {
            int number = int.Parse(txt.Text);
            MessageBox.Show(string.Format("Current number: {0}", number));
        }

        void Add_to_Number(object s, EventArgs e)
        {
            int number = int.Parse(txt.Text);
            number++;
            MessageBox.Show(string.Format("You increased the number, the result: {0}", number));
           
        }

        void Substract_to_Number(object s, EventArgs e)
        {
            int number = int.Parse(txt.Text);
            number--;
            MessageBox.Show(string.Format("You decreased the number, the result: {0}", number));

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myForm));
            this.SuspendLayout();
            // 
            // myForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "myForm";
            this.ResumeLayout(false);

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new myForm());
        }
    }
}
