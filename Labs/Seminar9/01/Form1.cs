using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar9
{
    public partial class Form1 : Form
    {
        int raza = 30;
        public Form1()
        {
            InitializeComponent();

            Paint += Form1_Paint;

            button1.Text = "-";
            button1.Click += Button1_Click;

            button2.Text = "+";
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            raza = raza + 2;
            Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            raza = raza - 2;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Blue, ClientSize.Width / 2 - raza, ClientSize.Height / 2 - raza,
                    raza * 2, raza * 2);
        }
    }
}
