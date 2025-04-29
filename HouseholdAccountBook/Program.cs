using System.Collections.Generic;
using System.Xml;

namespace HouseholdAccountBook
{
    class Program
    {
        static bool Quit = false;

        static void Main(string[] args)
        {

            KontoModell kontoModell = new KontoModell();
            Vy vy = new Vy();

            vy.VisaInstruktion();

            /********************* Huvud menyn *********************/
            while (!Quit)
            {
                int huvudMeny = vy.ValjaHuvudMeny();

                switch (huvudMeny)
                {
                    case 0:
                        break;

                    // 1.Visa hushållskonton
                    case 1:
                        HanteraVisning(vy, kontoModell);
                        break;

                    // 2. Registrera ny utgifter eller inkomster
                    case 2:
                        HanteraRegistering(vy, kontoModell);
                        break;

                    // 3. Redigera en existerande rekord
                    case 3:
                        HanteraRedigering(vy, kontoModell);
                        break;


                    case 9:
                        Quit = true;
                        Console.WriteLine("Hej då!");
                        break;
                }
            }



            /********************* Metoder *********************/
            void HanteraVisning(Vy vy, KontoModell kontoModell)
            {

                int listaTyp = vy.ValjaListaMeny();
                string kategori = vy.ValjaKategori();

                List<Konto> lista = new List<Konto>();

                // 1. Utgift och inkomst listan
                // 2. Utgift listan
                // 3. Inkomst listan
                // 4. Årlig utgift och inkomst listan
                // 5. Månatlig utgift och inkomst listan
                // 6. Daglig tgift och inkomst listan
                // 9. Tillbaka till huvudmenyn 

                if (String.IsNullOrEmpty(kategori))
                {
                    switch (listaTyp)
                    {
                        case 1:
                            lista = kontoModell.FaTotalLista();
                            vy.VisaTotalLista(lista);
                            break;

                        case 2:
                            lista = kontoModell.FaUtgiftLista();
                            vy.VisaUtgiftLista(lista);
                            break;

                        case 3:
                            lista = kontoModell.FaInkomstLista();
                            vy.VisaInkomstLista(lista);
                            break;

                        case 4:
                            int ar = vy.FaAr();
                            lista = kontoModell.FaArligLista(ar);
                            vy.VisaArligLista(ar, lista);
                            break;

                        case 5:
                            int[] arManad = vy.FaArManad();
                            lista = kontoModell.FaManatligLista(arManad[0], arManad[1]);
                            vy.VisaManatligLista(arManad[0], arManad[1], lista);
                            break;

                        case 6:
                            DateTime datum = vy.FaDatum();
                            lista = kontoModell.FaDagligLista(datum.Year, datum.Month, datum.Day);
                            vy.VisaDagligLista(datum.Year, datum.Month, datum.Day, lista);
                            break;

                        case 9:

                            break;
                    }
                }
                else
                {
                    switch (listaTyp)
                    {
                        case 1:
                            lista = kontoModell.FaKategoriLista(kategori);
                            vy.VisaKategoriLista(kategori, lista);
                            break;

                        case 2:
                            lista = kontoModell.FaKategoriUtgiftLista(kategori);
                            vy.VisaKategoriUtgiftLista(kategori, lista);
                            break;

                        case 3:
                            lista = kontoModell.FaKategoriInkomstLista(kategori);
                            vy.VisaKategoriInkomstLista(kategori, lista);
                            break;

                        case 4:
                            int ar = vy.FaAr();
                            lista = kontoModell.FaArligLista(kategori, ar);
                            vy.VisaArligLista(kategori, ar, lista);
                            break;

                        case 5:
                            int[] arManad = vy.FaArManad();
                            lista = kontoModell.FaManatligLista(kategori, arManad[0], arManad[1]);
                            vy.VisaManatligLista(kategori, arManad[0], arManad[1], lista);
                            break;

                        case 6:
                            DateTime datum = vy.FaDatum();
                            lista = kontoModell.FaDagligLista(kategori, datum.Year, datum.Month, datum.Day);
                            vy.VisaDagligLista(kategori, datum.Year, datum.Month, datum.Day, lista);
                            break;

                        case 9:

                            break;
                    }
                }

            }

            void HanteraRegistering(Vy vy, KontoModell kontoModell)
            {
                // Få ny ID för ett nytt rekord.
                int nyId = kontoModell.FaNyId();

                Konto nyKonto = vy.InputForNyRekord(nyId);
                if (nyKonto.Id == nyId)
                {
                    kontoModell.SkrivRekord(nyKonto);
                }
            }

            void HanteraRedigering(Vy vy, KontoModell kontoModell)
            {

                // Bestämma att uppdatera eller Radera
                bool villRadera = vy.VillRadera();

                int id = vy.InputId();
                Konto konto = kontoModell.FaEnRekord(id);

                if (konto.Id != id)
                {
                    Console.WriteLine("Rekordet hittas inte.  Börja igen från huvudmenyn.");
                    return;
                }

                if (villRadera)
                {
                    //----- Radera -----
                    bool bestamtRadera = vy.KollaRadera(konto);
                    if (!bestamtRadera)
                    {
                        Console.WriteLine("Ångrar du?  Börja igen från huvudmenyn.");
                        return;
                    }
                    else
                    {
                        kontoModell.RaderaRekord(id);
                    }
                }
                else
                {
                    //----- Uppdatera -----
                    Console.WriteLine("Du ska uppdatera detta rekord :\n");

                    Console.WriteLine(konto.VisaRekord());

                    Konto nyKonto = vy.InputForNyRekord(id);
                    kontoModell.UppdateraRekord(nyKonto);
                }

            }


        }

    }
}