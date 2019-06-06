using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scenariuEx
{
    public class Grafic : Control
    {
        double[] medii;

        public Grafic()
        {
            Paint += Grafic_Paint;
            Resize += Grafic_Resize;
        }

        private void Grafic_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        public double[] Medii
        {
            set
            {
                if (value != null)
                    medii = value;
            }
        }

        private void Grafic_Paint(object sender, PaintEventArgs e)
        {
            Desen(e.Graphics, DisplayRectangle);
        }

        private void Desen(Graphics graphics, Rectangle r)
        {
            graphics.FillRectangle(Brushes.Gray, r);

            if (medii == null)
                return;
            else
            {
                int Latime = r.Width;
                int Inaltime = r.Height;

                double inaltime_bloculet = Inaltime / medii.Max();
                double latime_dreptunghi = Latime / medii.Length;

                for (int i = 0; i < medii.Length; i++)
                {
                    double bloc = inaltime_bloculet * medii[i];

                    RectangleF rElement = new RectangleF((float)(i * latime_dreptunghi),
                        (float)(Inaltime - bloc), 20, (float)bloc);

                    graphics.FillRectangle(Brushes.Yellow, rElement);
                }
            }
        }
    }
}
