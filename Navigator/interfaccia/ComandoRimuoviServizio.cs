using Dominio;
using Validazioni;

namespace Interfaccia
{
    public class ComandoRimuoviServizio : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Rimuovi Servizi aggiuntivi";

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
            string nome,input;
            bool esito;

            //Stampo l'elenco dei servizi aggiuntivi
            foreach(Servizio s in istanza.GetListaServizi())
            {
                Console.WriteLine(s.ToString());
            }
            
            //Richiedo il codice
            Console.WriteLine("Inserisci il codice del servizio da rimuovere: ");
            while(true)
            {
                input = Parser.GetInstance().Read();
                if(Validatore.VerificaCodice(input))
                    break;
                Console.WriteLine("Codice non valido, riprova: ");
            }

            //Rimuovo il servizio
            esito = istanza.RimuoviServizio(int.Parse(input));
            if(esito)
                Console.WriteLine("\nServizio rimosso con successo");
            else
                Console.WriteLine("\nServizio non presente");
        }
    }

}