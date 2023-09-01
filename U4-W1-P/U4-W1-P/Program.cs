using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace U4_W1_P
{
    internal class Program
    {
        static ContribuentiManager manager = new ContribuentiManager();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            bool continua = true;
            while (continua)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Inserimento di una nuova dichiarazione di un contribuente");
                Console.WriteLine("2) La lista completa di tutti i contribuenti che sono stati analizzati");
                Console.WriteLine("3) Esci");
                Console.WriteLine("Scelta: ");

                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        InserisciContribuente();
                        break;
                    case "2":
                        MostraContribuenti();
                        break;
                    case "3":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova.");
                        break;
                }
            }
        }
        static void InserisciContribuente()
        {
            Console.WriteLine("Inserisci i dati del contribuente:");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Data di nascita (formato: dd/MM/yyyy): ");
            DateTime dataNascita;
            bool dataValida = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascita);

            if (!dataValida)
            {
                Console.WriteLine("Data di nascita non valida. Riprova.");
                return; 
            }

            Console.Write("Codice Fiscale: ");
            string codiceFiscale = Console.ReadLine();

            char sesso;
            do
            {
                Console.Write("Sesso (M/F): ");
                sesso = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (sesso != 'M' && sesso != 'F')
                {
                    Console.WriteLine("Valore non valido per il sesso. Riprova.");
                }
            } while (sesso != 'M' && sesso != 'F');

            Console.Write("Comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            Console.Write("Reddito annuale: ");
            decimal redditoAnnuale;
            bool redditoValido = decimal.TryParse(Console.ReadLine(), out redditoAnnuale);

            if (!redditoValido)
            {
                Console.WriteLine("Reddito annuale non valido. Riprova.");
                return; 
            }

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
            manager.AggiungiContribuente(contribuente);

            Console.WriteLine("\nDichiarazione inserita con successo!\n");
            Console.WriteLine("Riepilogo dell'imposta:");
            Console.WriteLine(contribuente);
            Console.WriteLine("=====================================\n");
        }

        static void MostraContribuenti()
        {
            List<Contribuente> contribuenti = manager.GetContribuenti();

            if (contribuenti.Count == 0)
            {
                Console.WriteLine("Nessun contribuente in lista.");
            }
            else
            {
                Console.WriteLine("Elenco dei contribuenti:");
                foreach (var contribuente in contribuenti)
                {
                    Console.WriteLine(contribuente);
                    Console.WriteLine("=====================================");
                }
            }
        }
    }
}