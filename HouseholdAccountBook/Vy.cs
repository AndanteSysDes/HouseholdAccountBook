using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAccountBook
{
    internal class Vy
    {

        public const int LinjeLangd = 80;


        public void VisaInstruktion()
        {
            string inst = "Hej. Här kan du hantera dina hushållskonton.\n" +
                "Börja med att välja en funktion från menyn.";

            Console.WriteLine("/".PadLeft(LinjeLangd, '/'));
            Console.WriteLine("");
            Console.WriteLine(inst);
            Console.WriteLine("");
            Console.WriteLine("/".PadLeft(LinjeLangd, '/'));

        }

        /****************************** Menyer  ******************************/

        public int ValjaHuvudMeny()
        {

            Console.WriteLine("\n\n");
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
            Console.WriteLine("Välj förjande nummer:");
            Console.WriteLine("  1. Visa hushållskonton");
            Console.WriteLine("  2. Registrera ny utgifter eller inkomster");
            Console.WriteLine("  3. Redigera en existerande rekord");
            Console.WriteLine(" ");
            Console.WriteLine("  9. Avsluta program");
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));

            // Ta emot indata
            string menyVal = Console.ReadLine();
            int menyNum;
            Int32.TryParse(menyVal, out menyNum);

            return menyNum;
        }

        public int ValjaListaMeny()
        {
            bool isMenynVald = false;

            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
            Console.WriteLine("Välj typ av lista :");
            Console.WriteLine("  1. Utgift och inkomst listan");
            Console.WriteLine("  2. Utgift listan");
            Console.WriteLine("  3. Inkomst listan");
            Console.WriteLine("  4. Årlig utgift och inkomst listan");
            Console.WriteLine("  5. Månatlig utgift och inkomst listan");
            Console.WriteLine("  6. Daglig tgift och inkomst listan");
            Console.WriteLine(" ");
            Console.WriteLine("  9. Tillbaka till huvudmenyn ");
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));

            // Ta emot indata
            string menyVal = Console.ReadLine();
            int menyNum = 0;

            while (!isMenynVald)
            {
                Int32.TryParse(menyVal, out menyNum);
                switch (menyNum)
                {

                    case 1:

                    case 2:

                    case 3:

                    case 4:

                    case 5:

                    case 6:

                    case 9:
                        isMenynVald = true;
                        break;

                    default:
                        Console.Write("Ange numret igen : ");
                        menyVal = Console.ReadLine();
                        continue;
                }
            }

            return menyNum;
        }

        // Returnerar kategorinamnet eller "".
        public string ValjaKategori()
        {
            bool isMenynVald = false;
            string kategoriNamn = "";

            while (!isMenynVald)
            {
                Console.Write("Vill du välja en viss kategori?  ( j / n ) : ");
                string menyVal = Console.ReadLine();

                switch (menyVal)
                {
                    case "j":
                        kategoriNamn = FaKategori();
                        isMenynVald = true;
                        break;

                    case "n":
                        isMenynVald = true;
                        break;

                    default:
                        continue;
                }
            }

            return kategoriNamn;
        }


        /****************************** 1. Visa hushållskonton  ******************************/
        // 1 - 1 //
        public void VisaTotalLista(List<Konto> kontos)
        {

            Console.WriteLine("\n--- Utgift och inkomst listan (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));

        }

        // 2 - 1 //
        public void VisaUtgiftLista(List<Konto> kontos)
        {
            Console.WriteLine("\n--- Utgift listan (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 3 - 1 //
        public void VisaInkomstLista(List<Konto> kontos)
        {

            Console.WriteLine("\n--- Inkomst listan (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 1 - 2 //
        public void VisaKategoriLista(string kategori, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift och inkomst listan ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 2 - 2 //
        public void VisaKategoriUtgiftLista(string kategori, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift listan ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 3 - 2 //
        public void VisaKategoriInkomstLista(string kategori, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Inkomst listan ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 4 - 1 //
        public void VisaArligLista(int ar, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar} (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 4 - 2 //
        public void VisaArligLista(string kategori, int ar, List<Konto> kontos)
        {

            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar} ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 5 - 1 //
        public void VisaManatligLista(int ar, int manad, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar}/{manad} (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 5 - 2 //
        public void VisaManatligLista(string kategori, int ar, int manad, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar}/{manad} ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 6 - 1 //
        public void VisaDagligLista(int ar, int manad, int dag, List<Konto> kontos)
        {

            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar}/{manad}/{dag} (totalt) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }

        // 6 - 2 //
        public void VisaDagligLista(string kategori, int ar, int manad, int dag, List<Konto> kontos)
        {
            Console.WriteLine($"\n--- Utgift och inkomst listan i {ar}/{manad}/{dag} ({kategori}) ".PadRight(LinjeLangd, '-'));
            Console.WriteLine("\n");
            foreach (Konto el in kontos)
            {
                Console.WriteLine(el.VisaRekord());
            }
            VisaVinst(kontos);
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
        }



        /********************* 2. Registrera ny utgifter eller inkomster *********************/
        // Om användare vill gå tillbaka menyn får programmet en tom Konto objekt.
        public Konto InputForNyRekord(int nyId)
        {
            int id = nyId;
            string namn;
            string kategori;
            DateTime dag;
            double pengar = 0;
            bool isUppgift = true;
            bool isBokforts = false;


            Console.Write("Välj utgift eller inkomst.\n 1. Utgift / 2. Inkomst / 3. Tillbaka till huvudmenyn : ");
            string indataVal = Console.ReadLine();
            while (!isBokforts)
            {
                switch (indataVal)
                {
                    case "1":
                        isUppgift = true;
                        isBokforts = true;
                        break;

                    case "2":
                        isUppgift = false;
                        isBokforts = true;
                        break;

                    case "3":
                        Konto tomKonto = new Konto();
                        return tomKonto;

                    default:
                        Console.Write("Välj utgift eller inkomst.\n 1. Utgift / 2. Inkomst / 3. Tillbaka till menyn : ");
                        indataVal = Console.ReadLine();
                        continue;
                }
            }


            Console.Write("Ange namnet på det objekt som ska registreras.\nText : ");
            namn = Console.ReadLine();
            if (String.IsNullOrEmpty(namn))
            {
                namn = "Anonym";
            }

            kategori = FaKategori();
            dag = FaDatum();

            Console.Write("Ange ett belopp (SEK) : ");
            string indataPengar = Console.ReadLine();
            Double.TryParse(indataPengar, out pengar);

            Konto konto = new Konto(nyId, namn, kategori, dag, pengar, isUppgift);

            Console.WriteLine("Du skapar förjande rekorden : ");
            Console.WriteLine(konto.VisaRekord());

            return konto;
        }


        /****************************** 3. Redigera en existerande rekord  ******************************/
        
        public bool VillRadera()
        {
            bool radera = false;
            bool kollad = false;

            Console.Write("Vill du uppdatera eller radera rekord?\n  ( [uppdatera : u ] / [radera : r ] ) : ");
            string indataVal = Console.ReadLine();
            while (!kollad)
            {
                switch (indataVal)
                {
                    case "u":
                        radera = false;
                        kollad = true;
                        break;

                    case "r":
                        radera = true;
                        kollad = true;
                        break;


                    default:
                        Console.Write("Vill du uppdatera eller radera rekord?\n  ( [uppdatera : u ] / [radera : r ] ) : ");
                        indataVal = Console.ReadLine();
                        continue;
                }
            }

            return radera;
        }

        public int InputId()
        {
            int id = 0;
            Console.Write("Ange ID : ");

            string idVal = Console.ReadLine();
            Int32.TryParse(idVal, out id);
            
            return id;
        }

        public bool KollaRadera(Konto konto)
        {
            bool gorRadera = false;
            Console.WriteLine("Vill du att detta rekord ska raderas?\n");
            Console.WriteLine(konto.VisaRekord());

            Console.Write("\nVill du radera det? ( j / n ) : ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "j":
                    gorRadera = true;
                    break;

                case "n":
                default:
                    break;

            }

            return gorRadera;
        }

        /********************************** ÖVRIGA **********************************/
        public string FaKategori()
        {
            string kategoriNamn = "Övrig";

            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));
            Console.WriteLine("Välj kategori från förjande nummer:");
            Console.WriteLine("  1.  Mat");
            Console.WriteLine("  2.  Dagliga förnödenheter");
            Console.WriteLine("  3.  Transporter");
            Console.WriteLine("  4.  Kommunikation");
            Console.WriteLine("  5.  Utbildning");
            Console.WriteLine("  6.  Kläder och skönhetsvård");
            Console.WriteLine("  7.  Sjukvård");
            Console.WriteLine("  8.  Hyra");
            Console.WriteLine("  9.  El och vatten");
            Console.WriteLine("  10. Övrig");
            Console.WriteLine("-".PadLeft(LinjeLangd, '-'));

            // Ta emot indata
            string kategoriVal = Console.ReadLine();
            int kategoriNum;
            Int32.TryParse(kategoriVal, out kategoriNum);

            switch (kategoriNum)
            {
                case 1:
                    kategoriNamn = "Mat";
                    break;

                case 2:
                    kategoriNamn = "Dagliga förnödenheter";
                    break;

                case 3:
                    kategoriNamn = "Transporter";
                    break;

                case 4:
                    kategoriNamn = "Kommunikation";
                    break;

                case 5:
                    kategoriNamn = "Utbildning";
                    break;

                case 6:
                    kategoriNamn = "Kläder och skönhetsvård";
                    break;

                case 7:
                    kategoriNamn = "Sjukvård";
                    break;

                case 8:
                    kategoriNamn = "Hyra";
                    break;

                case 9:
                    kategoriNamn = "El och vatten";
                    break;

                default:
                    break;

            }

            return kategoriNamn;
        }

        public int FaAr()
        {
            int ar = 0;
            string indata = "";
            bool checkad = false;

            while (!checkad)
            {
                Console.Write("Ange År  (yyyy) : ");
                indata = Console.ReadLine();
                Int32.TryParse(indata, out ar);

                if( ar > 1950 && ar < 2100)
                {
                    checkad = true;
                }
            }

            return ar;

        }

        public int[] FaArManad()
        {
            int[] arManad = { 0, 0 };
            string indata = "";
            bool checkad = false;

            arManad[0] = FaAr();

            while (!checkad)
            {
                Console.Write("Ange månad  ( 1 - 12 ) : ");
                indata = Console.ReadLine();
                Int32.TryParse(indata, out arManad[1]);


                if (arManad[1] >= 1 && arManad[1] <= 12)
                {
                    checkad = true;
                }

            }

            return arManad;

        }

        public DateTime FaDatum()
        {
            DateTime datum = default;
            string indata = "";

            while (String.IsNullOrWhiteSpace(indata) || datum == default)
            {
                Console.Write("Ange Datum  (yyyy/mm/dd) : ");
                indata = Console.ReadLine();
                DateTime.TryParse(indata, out datum);
            }

            return datum;

        }

        private void VisaVinst(List<Konto> kontos)
        {
            double totalUtgift = 0;
            double totalInkomst = 0;
            double totalVinst;

            foreach (Konto konto in kontos)
            {
                if (konto.IsUtgift)
                {
                    totalUtgift -= konto.Pengar;
                }
                else
                {
                    totalInkomst += konto.Pengar;
                }
            }

            totalVinst = totalInkomst + totalUtgift;

            string totalUtgiftText = totalUtgift.ToString("F2");
            string totalInkomstText = totalInkomst.ToString("F2");
            string totalVinstText = totalVinst.ToString("F2");


            Console.WriteLine("=".PadLeft(LinjeLangd, '='));
            Console.WriteLine("Totalt utgiftsbelopp :");
            Console.WriteLine(totalUtgiftText.PadLeft(LinjeLangd, ' '));
            Console.WriteLine("Totalt inkomstbelopp :");
            Console.WriteLine(totalInkomstText.PadLeft(LinjeLangd, ' '));
            Console.WriteLine("Total vinst :");
            Console.WriteLine(totalVinstText.PadLeft(LinjeLangd, ' '));

        }
    }
}
