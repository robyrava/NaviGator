using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoAggiungiServizio : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Aggiungi Servizi aggiuntivi";

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
            
            //Richiedo il nome
            Console.WriteLine("Inserisci il nome del servizio da aggiungere: ");
            while(true)
            {
                nome = Parser.GetInstance().Read();
                if(Validatore.VerificaNome(nome))
                    break;
                Console.WriteLine("Nome non valido, riprova: ");
            }

            //Richiedo il prezzo
            Console.WriteLine("Inserisci il prezzo del servizio: ");
            while(true)
            {
                input = Parser.GetInstance().Read();
                if(Validatore.VerificaPrezzo(input))
                    break;

                Console.WriteLine("Prezzo non valido, riprova: ");
            }


            //Aggiungo il servizio
            esito = istanza.AggiungiServizio(nome, double.Parse(input));
            if(esito)
                Console.WriteLine("\nServizio aggiunto con successo");
            else
                Console.WriteLine("\nServizio già presente");
        }
    }

}