using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DeToate
{
    public class GraficBare : Control
    {
        private decimal[] valori = new decimal[0];

        public GraficBare()
        {
            Paint += GraficBare_Paint;
            Resize += GraficBare_Resize;
        }

        private void GraficBare_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public DataObject IntoarceGraficBare()
        {
            DataObject dataObject = new DataObject();
            Bitmap b = new Bitmap(Width, Height);

            Deseneaza(Graphics.FromImage(b), DisplayRectangle);
            dataObject.SetData(typeof(Bitmap), b);

            return dataObject;
        }

        public decimal[] Valori
        {
            get => valori;
            set
            {
                if (value != null)
                {
                    valori = value;
                }
            }
        }

        private void GraficBare_Paint(object sender, PaintEventArgs e)
        {
            Deseneaza(e.Graphics, DisplayRectangle);
        }

        public void Deseneaza(Graphics gr, Rectangle r)
        {
            gr.FillRectangle(Brushes.Gray, r);

            if (valori.Length == 0)
                return;

            int Inaltime_Grafic = r.Height;
            int Latime_Grafic = r.Width;

            int numar_bare = valori.Length;

            float bloculet = (float)(Inaltime_Grafic / valori.Max());
            float grosime_bara = (float)(Latime_Grafic / numar_bare);

            for (int i = 0; i < numar_bare; i++)
            {
                float inaltime_bara = ((float)valori[i] * bloculet);

                RectangleF rElement = new RectangleF(i * grosime_bara, Inaltime_Grafic - inaltime_bara,
                        20, inaltime_bara);

                /*
                 Parametrii RectangleF: 
                 1) i * grosime_bara -> de unde incep noua bara (asemanator cu coordonata lui X)
                 2) Inaltime_Grafic - inaltime_bara -> cat de mare este bara
                 3) 20 -> distanta dintre bare
                 4) inaltime_bara -> cat de lunga este bara, construieste bara pe inaltime de sus in jos
                 */

                gr.FillRectangle(Brushes.Yellow, rElement);
            }
        }
    }
}
