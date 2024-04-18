using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoDisabilitaCabina : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Disabilita cabina";

        public string GetCodiceComando()
        {
            return codiceComando;
        }

        public string GetDescrizioneComando()
        {
            return descrizioneComando;
        }

        public void Esegui(NaviGator istanza)
        {
            List<int> codiciValidi = new List<int>();

            Console.WriteLine("   Inserisci data inizio manutenzione (YYYY-MM-dd): ");
            string dataI = Parser.GetInstance().Read();
            while (!Validatore.VerificaDataInizio(dataI))
            {
                Console.WriteLine("   Data non valida!\nInserisci data inizio manutenzione (YYYY-MM-dd): ");
                dataI = Parser.GetInstance().Read();
            }
            
            Console.WriteLine("   Inserisci data fine manutenzione (YYYY-MM-dd): ");
            string dataF = Parser.GetInstance().Read();
            while (!Validatore.VerificaDataFine(dataF,dataI))
            {
                Console.WriteLine("   Data non valida!\n   Inserisci data fine manutenzione (YYYY-MM-dd): ");
                dataF = Parser.GetInstance().Read();
            }
            
            //Mostro le cabine non Prenotate per la settimana selezionata
            Console.WriteLine("\nCabine non prenotate per il periodo selezionato: ");
            foreach (Cabina c in istanza.MostraCabineNonPrenotate(DateTime.Parse(dataI), DateTime.Parse(dataF)))
            {
                Console.WriteLine(c.ToString());
                codiciValidi.Add(c.GetCodice());
            }

            if(codiciValidi.Count == 0)
            {
                Console.WriteLine("\nNon ci sono cabine disponibili per il periodo selezionato!");
                return;
            }

            //Richiedo di inserire il codice della cabina da disabilitare
            Console.WriteLine("\n   Inserisci il codice della cabina da disabilitare: ");
            string codice = Parser.GetInstance().Read();
            while(!Validatore.VerificaCodice(codice))
            {
                Console.WriteLine("Codice non valido!\nInserisci il codice della cabina da disabilitare: ");
                codice = Parser.GetInstance().Read();
            }

            //Disabilito la cabina
            if(istanza.AbilitaDisabilitaCabina(int.Parse(codice), false, codiciValidi))
            {
                Console.WriteLine("\nCabina disabilitata con successo!");
            }
            else
            {
                Console.WriteLine("\nErrore: cabina non presente tra le cabine disponibili!");
            }
        }
    }

}