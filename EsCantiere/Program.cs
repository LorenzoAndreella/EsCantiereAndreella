using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EsCantiere
{
    internal class Program
    {
        public static List<CMacchinariPesanti> macchinari = new List<CMacchinariPesanti>();
        public static List<CCantiere> cantieri = new List<CCantiere>();

        static void Main(string[] args)
        {
            CCantiere cantiere1 = new CCantiere("Cantiere1");
            cantieri.Add(cantiere1);
            CCantiere cantiere2 = new CCantiere("Cantiere2");
            cantieri.Add(cantiere2);

            macchinari.Add(new CRuspa("AB123CD", "Modello1", 2020, 1000, DimensioneBenna.Mm1000));
            macchinari.Add(new CRuspa("XY987ZT", "Modello4", 2015, 1200, DimensioneBenna.Mm1500));
            macchinari.Add(new CGru("EF456GH", "Modello2", 2013, 2000, 5000, 20));
            macchinari.Add(new CBetoniera("IJ789KL", "Modello3", 2018, 1500, 300));

            do
            {
                Console.WriteLine("Seleziona un'opzione:");
                Console.WriteLine("1. Visualizza macchinari in parcheggio");
                Console.WriteLine("2. Visualizza descrizioni dei macchinari");
                Console.WriteLine("3. Assegna/libera macchinario a cantiere");
                Console.WriteLine("4. Cambia benna di una ruspa");
                Console.WriteLine("5. Cambia altezza di una gru");
                Console.WriteLine("6. Carica cemento in una betoniera");
                Console.WriteLine("0. Esci");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        VisualizzaMacchinariParcheggio();
                        break;
                    case "2":
                        VisualizzaDescrizioni();
                        break;
                    case "3":
                        AssegnaMacchinarioACantiere();
                        break;
                    case "4":
                        CambiaBennaRuspa();
                        break;
                    case "5":
                        CambiaAltezzaGru();
                        break;
                    case "6":
                        CaricaVersoCementoBetoniera();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            } while (true);

        }
        public static string ChiediString(string messaggio)
        {
            string targa;
            do
            {
                Console.WriteLine(messaggio);
                targa = Console.ReadLine();
            } while (string.IsNullOrEmpty(targa));
            return targa;
        }
        public static bool ChiediBool(string messaggio)
        {
            string input;
            do
            {
                Console.WriteLine(messaggio);
                input = Console.ReadLine().ToLower();
            } while (input != "1" && input != "2");
            bool risp;
            if (input == "1")
            {
                risp = true;
            }
            else
            {
                risp = false;
            }
            return risp;
        }

        public static void VisualizzaMacchinariParcheggio()
        {
            string stringa = "Macchinari in parcheggio:";
            bool trovato = false;
            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Stato == false)
                {
                    stringa += $"\n{macchinario.Descrizione()}";
                    trovato = true;
                }
            }
            if (trovato)
            {
                Console.WriteLine(stringa);
            }
            else
            {
                Console.WriteLine("Nessun macchinario in parcheggio.");
            }
        }
        public static void VisualizzaDescrizioni()
        {
            string stringa = "Descrizioni dei macchinari:";
            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                stringa += $"\n{macchinario.Descrizione()}";
            }
            Console.WriteLine(stringa);
        }

        public static void AssegnaMacchinarioACantiere()
        {
            string targa = ChiediString("Inserisci targa del macchinario:");
            string nomeCantiere = ChiediString("Inserisci nome del cantiere:");
            bool assegnaRimuovi = ChiediBool("Vuoi assegnare (1) o rimuovere (2) il macchinario dal cantiere?");
            bool trovatoCantiere = false;
            foreach (CCantiere cantiere in cantieri)
            {
                if (cantiere.NomeCantiere.ToLower() == nomeCantiere.ToLower())
                {
                    if (assegnaRimuovi)
                    {
                        AssegnaMacchinario(targa, cantiere);
                        trovatoCantiere = true;
                    }
                    else
                    {
                        LiberaMacchinario(targa, cantiere);
                        trovatoCantiere = true;
                    }
                }
            }
            if (!trovatoCantiere)
            {
                Console.WriteLine("Cantiere non trovato.");
            }
            return;
        }
        public static void AssegnaMacchinario(string targa, CCantiere cantiere)
        {
            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Targa.ToLower() == targa.ToLower())
                {
                    if (macchinario.Stato)
                    {
                        Console.WriteLine($"Macchinario con targa {targa} è assegnato al cantiere {cantiere.NomeCantiere}.");
                        return;
                    }

                    macchinario.Assegna(cantiere);
                    Console.WriteLine($"Macchinario con targa {targa} assegnato al cantiere {cantiere.NomeCantiere}.");
                    return;
                }
            }
            Console.WriteLine($"Macchinario con targa {targa} non trovato.");
        }

        public static void LiberaMacchinario(string targa, CCantiere cantiere)
        {
            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Targa.ToLower() == targa.ToLower())
                {
                    if (macchinario.CantiereAssegnato != cantiere)
                    {
                        Console.WriteLine($"Macchinario con targa {targa} non è assegnato al cantiere {cantiere.NomeCantiere}.");
                        return;
                    }
                    macchinario.Libera();
                    Console.WriteLine($"Macchinario con targa {targa} liberato dal cantiere {cantiere.NomeCantiere}.");
                    return;
                }
            }
            Console.WriteLine($"Macchinario con targa {targa} non trovato.");
        }
        public static void CambiaBennaRuspa()
        {
            string targa = ChiediString("Inserisci targa della ruspa:");
            DimensioneBenna nuovaBenna;
            int numeroBenna;
            do
            {
                Console.WriteLine("Inserisci la nuova dimensione della benna (300, 500, 700, 1000, 1500, 2000): ");
            } while (!int.TryParse(Console.ReadLine(), out numeroBenna) || !Enum.IsDefined(typeof(DimensioneBenna), 
            (DimensioneBenna)numeroBenna));

            nuovaBenna = (DimensioneBenna)numeroBenna;

            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Targa.ToLower() == targa.ToLower() && macchinario is CRuspa ruspa)
                {
                    ruspa.CambiaBenna(nuovaBenna);
                    Console.WriteLine($"Benna della ruspa con targa {targa} cambiata a {numeroBenna} mm.");
                    return;
                }
            }
            Console.WriteLine($"Ruspa con targa {targa} non trovata.");
        }
        public static void CambiaAltezzaGru()
        {
            string targa = ChiediString("Inserisci targa della gru:");
            bool aumenta = ChiediBool("Vuoi aumentare (1) o diminuire (2) l'altezza della gru?");
            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Targa.ToLower() == targa.ToLower() && macchinario is CGru gru)
                {
                    if (!aumenta)
                    {
                        gru.DiminuisciAltezza();
                        Console.WriteLine($"Altezza della gru con targa {targa} diminuita a {gru.AltezzaLavoro}.");
                        return;
                    }
                    gru.AumentaAltezza();
                    Console.WriteLine($"Altezza della gru con targa {targa} aumentata a {gru.AltezzaLavoro}.");
                    return;
                }
            }
            Console.WriteLine($"Gru con targa {targa} non trovata.");
        }
        public static void CaricaVersoCementoBetoniera()
        {
            string targa = ChiediString("Inserisci targa della betoniera:");
            int quantita;
            do
            {
                Console.WriteLine("Inserisci la quantità di cemento da caricare/versare:");
            } while (!int.TryParse(Console.ReadLine(), out quantita));
            bool carica = ChiediBool("Vuoi caricare (1) o versare (2) il cemento?");

            foreach (CMacchinariPesanti macchinario in macchinari)
            {
                if (macchinario.Targa.ToLower() == targa.ToLower() && macchinario is CBetoniera betoniera)
                {
                    if (carica)
                    {
                        string risultato = betoniera.CaricaCemento(quantita);
                        Console.WriteLine(risultato);
                        return;
                    }
                    string risultatoVersa = betoniera.VersaCemento(quantita);
                    Console.WriteLine(risultatoVersa);
                    return;
                }
            }
            Console.WriteLine($"Betoniera con targa {targa} non trovata.");
        }
    }
}
