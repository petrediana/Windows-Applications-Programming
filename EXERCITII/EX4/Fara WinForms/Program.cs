using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex_4_faraWinForm
{
    public class Persoana
    {
        string Nume
        {
            get;
            set;
        }

        string Gen
        {
            get;
            set;
        }

        public Persoana(string txtNume, string txtGen)
        {
            Nume = txtNume;
            Gen = txtGen;
        }

        public void afiseaza_persoana()
        {
            Console.Write("Nume: {0}, Genul: {1}\n", Nume, Gen);
        }
    }

    public class myForm : Form
    {
        Persoana Rezultat;
        TextBox txtNume = new TextBox();
        TextBox txtGen = new TextBox();
        Label labelNume = new Label();
        Label labelGen = new Label();
        Button buttonInchide = new Button();

        public myForm()
        {
            initializare();
        }

        void initializare()
        {
            Controls.Add(txtNume);
            Controls.Add(txtGen);
            Controls.Add(labelNume);
            Controls.Add(labelGen);
            Controls.Add(buttonInchide);

            Size = new Size(250, 250);

            labelNume.Text = "Nume: ";
            labelNume.Location = new Point(0, 20);
            labelNume.Size = new Size(40, 25);

            txtNume.Location = new Point(0 + 40, 20);
            txtNume.Size = new Size(80, 0);

            labelGen.Text = "Gen: ";
            labelGen.Location = new Point(0, 50);
            labelGen.Size = new Size(50, 50);

            txtGen.Location = new Point(0 + 40, 50);
            txtGen.Size = new Size(80, 0);

            buttonInchide.Text = "Citeste";
            buttonInchide.Location = new Point(65, 100);
            buttonInchide.Size = new Size(100, 40);

            buttonInchide.Click += inchide_click;
        }

        void inchide_click(object sender, EventArgs e)
        {
            Rezultat = new Persoana(txtNume.Text, txtGen.Text);
            Rezultat.afiseaza_persoana();

            Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            myForm formular = new myForm();
            formular.ShowDialog();
        }
    }
}
