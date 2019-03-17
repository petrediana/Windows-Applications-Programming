using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex_2
{
    class myForm : Form
    {
        TextBox no_txt = new TextBox();
        TextBox arr_txt = new TextBox();
        Button btn = new Button();

        public myForm()
        {
            Initialize();
        }

        void Initialize()
        {
            this.Controls.Add(no_txt);
            this.Controls.Add(arr_txt);
            this.Controls.Add(btn);

            Text = "Ex_2";
            Size = new Size(220, 150);

            no_txt.Location = new Point(0, 0);
            no_txt.Size = new Size(100, 40);

            arr_txt.Location = new Point(0, 0 + 50);
            arr_txt.Size = new Size(100, 40);

            btn.Location = new Point(115, 20);
            btn.Size = new Size(40, 40);
            btn.Text = "Enter array";

            btn.Click += btn_show;
            
        }

        void btn_show(object s, EventArgs e)
        {
            int sum = 0;
            int arr_size = int.Parse(no_txt.Text);
            int[] arr = arr_txt.Text.Split(' ').Select(s1 => int.Parse(s1)).ToArray();

            Console.Write("Arr size: {0}\n", arr_size);
          
                foreach (int a in arr)
                {
                    MessageBox.Show(string.Format("{0}", a));
                    sum += a;

                }
                

            Console.Write("Sum: {0}\n", sum);
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Form myform = new myForm();
            myform.ShowDialog();

            Console.Write("Done\n");
        }
    }
}
