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
        public Form1(int n)
        {
            InitializeComponent();

            int W = Size.Width, H = Size.Height;
            int w = W / n, h = H / n;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Panel p = new Panel();
                    p.Location = new Point(i * w, j * h);
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Size = new Size(w, h);
                    Controls.Add(p);
                }
            }
        }
    }
}
