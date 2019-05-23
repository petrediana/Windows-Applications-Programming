using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<int> v = new List<int>();
        public Form1()
        {
            InitializeComponent();
            //Bitmap b = new Bitmap(200, 100);
           // Graphics g = Graphics.FromImage(b);
            //b.Save("C:\\Users\\Stud\\Desktop\\seminar\\WindowsFormsApp1");
           // Bitmap b2 = new Bitmap("C:\\Users\\Stud\\Desktop\\seminar\\WindowsFormsApp1");
          

            v = new List<int> { 2, 7, 6, 4, 9, 13};
            Paint += Form1_Paint;

            Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int W = ClientSize.Width, H = ClientSize.Height;
            e.Graphics.FillRectangle(Brushes.White, DisplayRectangle);
            int n = v.Count;

            if ( n < 2 )
            {
                return;
            }

            List<Point> puncte = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                int xi = i * W / (n - 1);
                int hi = H * v[i] / v.Max();
                int yi = H - hi;

                puncte.Add(new Point(xi, yi));
            }

            for (int i = 1; i < n; i++)
            {
                Pen pen = new Pen(Color.Blue, 3);
                e.Graphics.DrawLine(pen, puncte[i - 1], puncte[i]);
            }
        }
    }
}
