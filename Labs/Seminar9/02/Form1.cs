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
        List<List<Point>> linii;
        bool desenare = false;


        public Form1()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            linii = new List<List<Point>>();
            linii.Add(new List<Point>
            {
                new Point(0, 0), new Point(30, 30), new Point(50, 30)
            });

            linii.Add(new List<Point>
            {
                new Point(60, 60), new Point(60, 130)
            });

            Paint += Form1_Paint;

            MouseDown += Form1_MouseDown;
            MouseUp += Form1_MouseUp;
            MouseMove += Form1_MouseMove;

            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject dataObject = new DataObject();
                dataObject.SetData(typeof(string), linii.Count + " linii");
                Bitmap b = new Bitmap(ClientSize.Width, ClientSize.Height);
                Desenare(Graphics.FromImage(b));
                dataObject.SetData(typeof(Bitmap), b);
                Clipboard.SetDataObject(dataObject);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (desenare)
            {
                linii.Last().Add(e.Location);
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            desenare = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            desenare = true;
            linii.Add(new List<Point>());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Desenare(e.Graphics);
        }

        private void Desenare(Graphics graphics)
        {
            Pen mypen = new Pen(Color.ForestGreen, 3);
            foreach (var linie in linii)
            {
                for (int i = 0; i < linie.Count - 1; i++)
                {
                    graphics.DrawLine(mypen, linie[i], linie[i + 1]);
                }
            }
        }
    }
}