using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int n = Citire("Nr elemente: ");

            int[] v = new int[n];
            for(int i = 0; i < n; i++)
            {
                v[i] = Citire("element " + (i + 1));
            }

            MessageBox.Show(v.Sum().ToString());

           

        }

        static int Citire(string mesaj)
        {
            Form1 myform = new Form1(mesaj);
            myform.ShowDialog();
            return(myform.Rezultat);
        }
    }
}
