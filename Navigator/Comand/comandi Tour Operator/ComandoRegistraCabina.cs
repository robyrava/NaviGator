using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoRegistraCabina : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "registra cabina";

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
            Console.WriteLine("   Inserisci la tipologia di cabina (interna, oblo, suite): ");
            string tipologiaCabina = Parser.GetInstance().Read();
            if (!(tipologiaCabina.Equals("interna", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("oblo", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("suite", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Errore: Tipologia cabina non valida");
                    return;
                }
            
            Console.WriteLine("   Inserisci data di partenza (YYYY-MM-dd): ");
            string dataI = Parser.GetInstance().Read();
            while(!Validatore.VerificaDataInizio(dataI))
            {
                Console.WriteLine("   Data non valida!\nRicorda le crociere partono di Lunedi\nInserisci data di partenza(YYYY-MM-dd): ");
                dataI = Parser.GetInstance().Read();
            }
            
            Console.WriteLine("   Inserisci data fine (YYYY-MM-dd): ");
            string dataF = Parser.GetInstance().Read();
            while(!Validatore.VerificaDataFine(dataF,dataI))
            {
                Console.WriteLine("   Data non valida!\n   Ricorda le crociere terminano di Sabato\nInserisci data fine(YYYY-MM-dd): ");
                dataF = Parser.GetInstance().Read();
            }

            //Verifico disponibilità cabine
            if (!istanza.GetCabineDisponibili(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)).Any())
            {
                Console.WriteLine($"\nNessuna cabina del tipo {tipologiaCabina} disponibile per questa data");
            }
            else
            {
                //Stampo cabine disponibili con il prezzo aggiornato a secondo del periodo selezionato
                foreach (Cabina c in istanza.GetCabineDisponibili(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF), true))
                {
                    Console.WriteLine(c.ToString());
                }

                //Chiedo di selezionare una cabina tramite il codice
                Console.WriteLine("   Inserisci il codice della cabina: ");
                string codiceCabina = Parser.GetInstance().Read();
                while (!Validatore.VerificaCodice(codiceCabina))
                {
                    Console.WriteLine("   Codice non valido!\nInserisci il codice della cabina: ");
                    codiceCabina = Parser.GetInstance().Read();
                }
                
                //Verifico che il codice inserito appartiene ad una cabina disponibile
                if(istanza.RegistraCabina(int.Parse(codiceCabina), tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)))
                    Console.WriteLine("\nLa cabina è stata registrata con successo!");
                else
                    Console.WriteLine("\nErrore: Il codice non appartiene a nessuna cabina disponibile");
            }

        }
    }

}