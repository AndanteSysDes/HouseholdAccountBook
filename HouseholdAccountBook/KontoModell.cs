using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAccountBook
{
    internal class KontoModell
    {
        private string _FilPass = "konto.txt";

        public KontoModell()
        {
            if (!File.Exists(_FilPass))
            {
                using (StreamWriter sw = File.CreateText(_FilPass))
                {
                    Console.WriteLine($"Du skapade en ny fil: {_FilPass}");
                }
            }
            else
            {
                Console.WriteLine($"Filen existerar: {_FilPass}");
            }
        }

        private bool KollaFil()
        {
            if (!File.Exists(_FilPass))
            {
                Console.WriteLine($"Filen existerar inte: {_FilPass}");
                Console.WriteLine($"Starta om från början.");
                return false;
            }
            return true;
        }

        /********************************** SKAPA **********************************/
        public void SkrivRekord(Konto konto)
        {
            if (!KollaFil())
            {
                return;
            }

            using (StreamWriter sw = File.AppendText(_FilPass))             
            {
                sw.WriteLine(konto.GeRekord());                            
            }
            Console.WriteLine("Nytt rekord sparat!");
        }


        /********************************** LÄSA **********************************/
        // 1 - 1 //
        public List<Konto> FaTotalLista()
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    lista.Add(konto);
                }

                return lista;
            }

        }

        // 2 - 1 //
        public List<Konto> FaUtgiftLista()
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.IsUtgift) { 
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 3 - 1 //
        public List<Konto> FaInkomstLista()
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (!konto.IsUtgift)
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 1 - 2 //
        public List<Konto> FaKategoriLista(string kategori)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaKategori(kategori))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;
        }

        // 2 - 2 //
        public List<Konto> FaKategoriUtgiftLista(string kategori)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.IsUtgift && konto.PassaKategori(kategori))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 3 - 2 //
        public List<Konto> FaKategoriInkomstLista(string kategori)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (!konto.IsUtgift && konto.PassaKategori(kategori))
                    {
                            lista.Add(konto);
                    }
                }

            }

            return lista;
        }

        // 4 - 1 //
        public List<Konto> FaArligLista(int ar)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaAr(ar))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;
        }

        // 4 - 2 //
        public List<Konto> FaArligLista(string kategori, int ar)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaKategori(kategori) && konto.PassaAr(ar))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 5 - 1 //
        public List<Konto> FaManatligLista(int ar, int manad)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaManad(ar, manad))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 5 - 2 //
        public List<Konto> FaManatligLista(string kategori, int ar, int manad)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaKategori(kategori) && konto.PassaManad(ar, manad))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 6 - 1 //
        public List<Konto> FaDagligLista(int ar, int manad, int dag)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaDag(ar, manad, dag))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        // 6 - 2 //
        public List<Konto> FaDagligLista(string kategori, int ar, int manad, int dag)
        {
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return lista;
            }


            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    if (konto.PassaKategori(kategori) && konto.PassaDag(ar,manad, dag))
                    {
                        lista.Add(konto);
                    }
                }

            }

            return lista;

        }

        public Konto FaEnRekord(int id)
        {
            Konto konto = new Konto();
            
            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    string[] kontoArray = filtext.Split(',');
                    if(Int32.Parse(kontoArray[0]) == id)
                    {
                        konto = new Konto(filtext);

                    }
                }

            }

            return konto;
        }

        /********************************** UPPDATERA **********************************/
        public void UppdateraRekord(Konto konto)
        {
            // Få totalt lista från filen.
            List<Konto> lista = new List<Konto>();

            if (!KollaFil())
            {
                return;
            }

            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto filKonto = new Konto(filtext);

                    if (filKonto.Id == konto.Id)
                    {
                        lista.Add(konto);
                    }
                    else
                    {
                        lista.Add(filKonto);
                    }
                }
            }

            lista.Sort((a, b) => a.Id - b.Id);

            // Skriv filen med listan.            
            File.Copy(_FilPass, "_tmp_" + _FilPass, false);
            File.Delete(_FilPass);

            using (StreamWriter sw = File.CreateText(_FilPass))             
            {
                foreach (Konto skrivKonto in lista)
                {
                    sw.WriteLine(skrivKonto.GeRekord());                             
                }
            }

            File.Delete("_tmp_" + _FilPass);

            Console.WriteLine($"Du uppdaterade rekord: [ ID: {konto.Id} ]");
            return;
        }

        /********************************** RADERA **********************************/
        public void RaderaRekord(int id)
        {
            // Få totalt lista från filen.
            List<Konto> gammalLista = new List<Konto>();

            if (!KollaFil())
            {
                return;
            }

            using (StreamReader sr = File.OpenText(_FilPass))
            {
                string filtext = "";

                while ((filtext = sr.ReadLine()) != null)
                {
                    Konto konto = new Konto(filtext);
                    gammalLista.Add(konto);
                }
            }

            List<Konto> nyLista = new List<Konto>(gammalLista);


            // Radera rekorden från listan.
            foreach (Konto konto in gammalLista)
            {
                if(konto.Id == id)
                {
                    Console.WriteLine($"Raderad rekord: [ ID: {id} ]" );
                    nyLista.Remove(konto);

                }
            }

            nyLista.Sort((a, b) => a.Id - b.Id);

            // Skriv filen med listan.            
            File.Copy(_FilPass, "_tmp_" + _FilPass, false);
            File.Delete(_FilPass);

            using (StreamWriter sw = File.CreateText(_FilPass))            
            {
                foreach (Konto skrivKonto in nyLista)
                {
                    sw.WriteLine(skrivKonto.GeRekord());                            
                }
            }

            File.Delete("_tmp_" + _FilPass);

            return;

        }


        /********************************** ÖVRIGA **********************************/
        public int FaNyId()
        {
            int senasteId = 0;
            List<Konto> lista = new List<Konto>();

            if (KollaFil())
            {
                using (StreamReader sr = File.OpenText(_FilPass))
                {
                    string filtext = "";

                    while ((filtext = sr.ReadLine()) != null)
                    {
                        Konto konto = new Konto(filtext);
                        lista.Add(konto);
                    }
                }


                if(lista.Count > 0) {
                    lista.Sort((a, b) => a.Id - b.Id);
                    senasteId = lista[lista.Count - 1].Id;
                }

            }

            return senasteId + 1;

        }


    }
}
