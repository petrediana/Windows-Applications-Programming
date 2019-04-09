using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adauga_in_listView
{
    public class Student
    {
        public string Nume { get; set; }
        int[] Note { get; set; }
        public float Medie;

        public string TextNote
        {
            get
            {
                return string.Join(" ", Note);
            }
        }

        public Student(string txtNume, string txtNote)
        {
            Nume = txtNume;
            string[] temp_note = txtNote.Split(' ');

            Note = new int[temp_note.Length];
            for(int i = 0; i < temp_note.Length; i++)
            {
                Note[i] = int.Parse(temp_note[i]);
                Console.WriteLine(Note[i]);
            }

            Medie = Note.Sum() / (float)Note.Length;
        }

        public override string ToString()
        {
            return string.Format("Nume: {0}, Medie: {1:00}, Note: {2}", Nume, Medie, Note);
        }
    }
}
