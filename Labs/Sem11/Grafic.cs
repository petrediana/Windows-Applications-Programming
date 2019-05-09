using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace WindowsFormsApp1
{
    class Grafic : Control
    {
        int[] valori = new int[0];
        public Grafic()
        {
            Paint += Grafic_paint;

            KeyDown += Grafic_KeyDown;

            MouseDown += Grafic_MouseDown;

            AllowDrop = true;
            DragEnter += Grafic_DragEnter;
            DragDrop += Grafic_DragDrop;
        }

        private void Grafic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string strValori = (string)e.Data.GetData(typeof(string));
                Valori = strValori.Split(',').Select(val => int.Parse(val)).ToArray();
            }
        }

        private void Grafic_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public int[] Valori
        {
            get { return valori; }
            set
            {
                if(value != null)
                {
                    valori = value;
                    Invalidate();
                }
            }
        }

        private void Grafic_paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(Brushes.Red, DisplayRectangle);
            Desenare(e.Graphics, DisplayRectangle);
        }

        private void Desenare(Graphics g, Rectangle r)
        {
            g.FillRectangle(Brushes.White, r);

            if(valori.Length == 0)
            {
                return;
            }

            float W = r.Width, H = r.Height;
            int n = valori.Length;
            float w = W / n, f = ((float)H / valori.Max());

            for(var i = 0; i < n; i++)
            {
                float h = valori[i] * f;
                RectangleF rElem = new RectangleF(r.Left + i * w + 0.1f *w, r.Top + H - h,
                                    w * 0.8f, h);

                g.FillRectangle(Brushes.Red, rElem);
            }
        }

        private void Grafic_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.P)
            {
                PrintDocument document = new PrintDocument();
                document.PrintPage += (s, ea) =>
                 {
                     Desenare(ea.Graphics, ea.MarginBounds);
                     ea.HasMorePages = false;                     
                 };
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = document;
                ppd.ShowDialog(this);
            }
        }

        private void Grafic_MouseDown(object sender, MouseEventArgs e)
        {
            DataObject data = new DataObject();
            data.SetData(typeof(string), string.Join(",", valori));
            DoDragDrop(data, DragDropEffects.Copy);
        }
    }

  
}
