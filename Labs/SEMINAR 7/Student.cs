using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_7
{
    public class Student
    {
        public Student(string nume, string textNote)
        {
            Nume = nume;
            string[] temp = textNote.Split(' ');

            Note = new int[temp.Length];
            for (int i = 0; i < Note.Length; i++)
            {
                Note[i] = int.Parse(temp[i]);
            }

            //sau
            //Note = textNote.Split(' ').Select( v => int.Parse(v)).ToArray();
        }

        public string Nume { get; set; }
        public int[] Note { get; set; }


        public decimal Medie
        {
            get
            {
                return Note.Length > 0 ? Note.Sum() / (decimal)Note.Length : 0;
            }
        }

        public string TextNote
        {
            get
            {
                return string.Join(" ", Note);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1:0.00}, Note: {2}", Nume, Medie, TextNote);
        }
    }
}
