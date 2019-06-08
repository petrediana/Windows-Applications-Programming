using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DeToate
{
    public class GraficLinii : Control
    {
        private decimal[] valori = new decimal[0];

        public GraficLinii()
        {
            Paint += GraficLinii_Paint;
            Resize += GraficLinii_Resize;
        }

        private void GraficLinii_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public decimal[] Valori
        {
            get => valori;
            set
            {
                if (value != null)
                    valori = value;
            }
        }

        public DataObject IntoarceGraficLinii()
        {
            DataObject dataObject = new DataObject();
            Bitmap b = new Bitmap(Width, Height);

            Deseneaza(Graphics.FromImage(b), DisplayRectangle);
            dataObject.SetData(typeof(Bitmap), b);

            return dataObject;
        }

        private void GraficLinii_Paint(object sender, PaintEventArgs e)
        {
            Deseneaza(e.Graphics, DisplayRectangle);
        }

        public void Deseneaza(Graphics gr, Rectangle r)
        {
            gr.FillRectangle(Brushes.DarkCyan, r);

            int numar_puncte = valori.Length;

            if (numar_puncte < 2)
                return;

            int Inaltime_Grafic = r.Height - 15;
            int Latime_Grafic = r.Width - 15;

            List<Point> puncte = new List<Point>();


            for (int i = 0; i < numar_puncte; i++)
            {
                int xi =  i *(Latime_Grafic / (numar_puncte - 1));

                int inaltime_punct = (int)(Inaltime_Grafic * valori[i] / valori.Max());
                int yi = Inaltime_Grafic - inaltime_punct;

                gr.DrawString("Norta: " + i, Font, Brushes.DarkBlue, new Point(xi, yi));
                puncte.Add(new Point(xi, yi));
            }

            /*
             Pun diferite puncte pe ecran, in cazul asta pe toata dimensiunea pe care o ocupa graficul
             new Point(int x, int y) -> imi permite sa pozitionez un punct de coordonate (x,y) pe suprafata mea
             toata problema se pune in felul in care pozitionez eu punctele pe ecran

            -> xi pt fiecare punt unde pun pe axa X fiecare punct i
            -> yi unde pun pe axa Y fiecare punct i

            si la sfarsit unesc punctele cu linii
             */

            for (int i = 0; i < puncte.Count - 1; i++)
            {
                gr.DrawLine(new Pen(Brushes.Red, 2), puncte[i], puncte[i + 1]);
            }
        }
    }
}
