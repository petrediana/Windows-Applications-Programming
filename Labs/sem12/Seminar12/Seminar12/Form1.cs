using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar12
{
    public partial class Form1 : Form
    {
        Traseu traseu;
        public Form1()
        {
            InitializeComponent();

            traseu = new Traseu();
            traseu.AdaugaLocatie(new Locatie("Brasov", 25.58m, 45.63m));
            traseu.AdaugaLocatie(new Locatie("Bucuresti", 26.10m, 44.43m));
            traseu.AdaugaLocatie(new Locatie("Constanta", 28.65m, 44.18m));
            traseu.AdaugaLocatie(new Locatie("Timisoara", 21.23m, 45.75m));

            Afisare();

            panel1.Paint += Panel1_Paint;

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            List<decimal> vLong = new List<decimal>();
            List<decimal> vLat = new List<decimal>();
            List<string> vDen = new List<string>();

            for(int i = 0; i < traseu.NumarLocatii; i++)
            {
                vLong.Add(traseu[i].Longitudine);
                vLat.Add(traseu[i].Latitudine);
                vDen.Add(traseu[i].Denumire);
            }

            float W = panel1.Width, H = panel1.Height;
            float flong = 0.8f * W / ((float)vLong.Max() - (float)vLong.Min());
            float flat = 0.8f * H / ((float)vLat.Max() - (float)vLat.Min());

            List<Point> vPct = new List<Point>();
            for(int i = 0; i < traseu.NumarLocatii; i++)
            {
                float x = 0.1f * W + ((float)vLong[i] - (float)vLong.Min()) * flong;
                float y = H - (0.1f * H + ((float)vLat[i] - (float)vLat.Min()) * flat);

                vPct.Add(new Point((int)x, (int)y));
            }
            
            for(int i = 0; i < traseu.NumarLocatii; i++)
            {
                e.Graphics.FillEllipse(Brushes.Red, vPct[i].X, vPct[i].Y, 5, 5);
                e.Graphics.DrawString(vDen[i], Font, Brushes.Red, vPct[i].X, vPct[i].Y);

                if(i > 0)
                {
                    e.Graphics.DrawLine(Pens.Blue, vPct[i - 1], vPct[i]);
                }
            }
        }

        private void Afisare()
        {
            dataGridView1.Rows.Clear();

            for(int i = 0; i < traseu.NumarLocatii; i++)
            {
                dataGridView1.Rows.Add(traseu[i].Denumire, traseu[i].Longitudine, traseu[i].Latitudine);
                //imi intoarce un index unde se pozitioneaza

            }
        }

        //(longitudine, latitudine) -> (x, y)
        // f(longitudine = 0.8 * W / ( max(long) - min(long) )
        // x = (long[i] - min(long)) * f(longitudine + 0.1 * W
        // y = H - x
        //
    
    }
}
