using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Camera
    {
        private int idCamera;
        private DateTime dataInceputCazare;
        private DateTime dataSfarsitCazare;

        public Camera()
        {

        }

        public Camera(int id, DateTime di, DateTime ds)
        {
            idCamera = id;
            dataInceputCazare = di;
            dataSfarsitCazare = ds;
        }

        public int IdCamera
        {
            get => idCamera;
            set
            {
                idCamera = value;
            }
        }

        public DateTime DataInceputCazare
        {
            get => dataInceputCazare;
            set
            {
                dataInceputCazare = value;
            }
        }

        public DateTime DataSfarsitCazare
        {
            get => dataSfarsitCazare;
            set
            {
                dataSfarsitCazare = value;
            }
        }

        public override string ToString()
        {
            return string.Format("IdCamera: {0}, DataI: {1}, DataS: {2}", idCamera,
                dataInceputCazare, dataSfarsitCazare);
        }

        public static explicit operator string(Camera camera)
        {
            string str = string.Empty;
            int nrZile = 0;

            nrZile = camera.dataSfarsitCazare.Day - camera.dataInceputCazare.Day;

            str = "Camera ocupata: " + nrZile + " zile";
            return str;
        }

        static public Camera operator +(Camera c, int zileInPlus)
        {
            int zi = c.DataSfarsitCazare.Day + zileInPlus;

            DateTime dataNouaSfarsit = new DateTime(c.DataSfarsitCazare.Year, c.DataSfarsitCazare.Month, zi);
            c.DataSfarsitCazare = dataNouaSfarsit;

            return c;
        }

    }
}
