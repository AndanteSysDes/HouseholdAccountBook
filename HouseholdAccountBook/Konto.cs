using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAccountBook
{
    internal class Konto
    {
        private int _Id;
        private string _Namn;
        private string _Kategori;
        private DateTime _Dag;
        private double _Pengar;
        private bool _IsUtgift;

        public Konto()
        {
            _Namn = "";
            _Kategori = "";
            _Dag = DateTime.Now;
            _Pengar = 0;
        }

        public Konto(int id, string namn, string kategori, DateTime dag, double pengar, bool isUtgift)
        {
            _Id = id;
            _Namn = namn;
            _Kategori = kategori;
            _Dag = dag;
            _Pengar = pengar;
            _IsUtgift = isUtgift;
        }


        public Konto(string rekord)
        {
            string[] kontoArray = rekord.Split(',');

            _Id = Int32.Parse(kontoArray[0]);
            _Namn = kontoArray[1];
            _Kategori = kontoArray[2];
            _Dag = DateTime.Parse(kontoArray[3]);
            _Pengar = Double.Parse(kontoArray[4]);
            _IsUtgift = Boolean.Parse(kontoArray[5]);
        }

        public int Id { get { return _Id; } }
        public bool IsUtgift { get { return _IsUtgift; } }

        public double Pengar { get { return _Pengar; } }

        public bool PassaAr(int ar) 
        {
            if (_Dag.Year.CompareTo(ar) == 0)      
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PassaManad(int ar, int manad)
        {
            if (_Dag.Month.CompareTo(manad) == 0 && _Dag.Year.CompareTo(ar) == 0)      
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PassaDag(int ar, int manad, int dag)
        {
            if (_Dag.Day.CompareTo(dag) == 0 && _Dag.Month.CompareTo(manad) == 0 && _Dag.Year.CompareTo(ar) == 0)     
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PassaKategori(string kategori)
        {
            if(_Kategori != kategori)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public string GeRekord()
        {
            string result = "";

            result += _Id.ToString();
            result += "," + _Namn;
            result += "," + _Kategori;
            result += "," + _Dag.ToString("yyyy/MM/dd");
            result += "," + _Pengar.ToString();
            result += "," + _IsUtgift.ToString();


            return result;
        }

        public string VisaRekord()
        {
            string result = "";
            double pengar;

            result += _Id.ToString().PadLeft(5, ' ');

            if (_IsUtgift)
            {
                pengar = - _Pengar;
            }
            else
            {
                pengar = _Pengar;
            }

            result += ". " + _Dag.ToString("yyyy/MM/dd");
            result += " ".PadRight(10, ' ') + "Kategori: " + _Kategori + "\n";
            result += "       Namn: " + _Namn + "\n";
            result += pengar.ToString("F2").PadLeft(Vy.LinjeLangd, ' ');

            return result;
        }


    }


}
