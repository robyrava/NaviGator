using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoVariazionePrezzoCabine : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "Variazione prezzo cabine";

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
            //Stampo la lista delle cabine della nave
            Console.WriteLine("Lista delle cabine della nave: ");
            foreach (Cabina c in istanza.GetCabine())
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("Inserisci la data di inizio del periodo variazione(YYYY-MM-dd): ");
            string dataI = Parser.GetInstance().Read();
            while (!Validatore.VerificaDataInizio(dataI))
            {
                Console.WriteLine("   Data non valida!\nRicorda le crociere partono di Lunedi\nInserisci la data di inizio del periodo variazione(YYYY-MM-dd): ");
                dataI = Parser.GetInstance().Read();
            }

            Console.WriteLine("Inserisci la data di fine del periodo di variazione(YYYY-MM-dd): ");
            string dataF = Parser.GetInstance().Read();
            while (!Validatore.VerificaDataFine(dataF,dataI))
            {
                Console.WriteLine("   Data non valida!\nRicorda le crociere terminano di Sabato\nInserisci la data di fine del periodo di variazione(YYYY-MM-dd): ");
                dataF = Parser.GetInstance().Read();
            }

            Console.WriteLine("   Inserisci la variazione di prezzo: ");
            string var = Parser.GetInstance().Read();
            while (!Validatore.VerificaPrezzo(var, true))
            {
                Console.WriteLine("   Pre3zzo non valido: deve essere un valore intero\nInserisci la variazione di prezzo: ");
                var = Parser.GetInstance().Read();
            }

            if(istanza.AggiungiPeriodoVariazione(DateTime.Parse(dataI), DateTime.Parse(dataF), int.Parse(var)))
                Console.WriteLine("\nPeriodo di variazione aggiunto con successo!");
            else
                Console.WriteLine("\nErrore: periodo variazione già presente!");


        }
    }

}