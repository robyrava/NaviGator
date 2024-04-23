using Dominio;
using Validazioni;
namespace Comand
{
    public class ComandoCalcolaConto: IComando
    {
        public static readonly string codiceComando = "5";
        public static readonly string descrizioneComando = "Calcola conto cliente";

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
            //verifico cliente
            Console.WriteLine("Inserisci il codice fiscale del cliente");
            string cf = Parser.GetInstance().Read();
            
            if(!istanza.VerificaCheckOut(cf))
            {
                Console.WriteLine("\nErrore: nessuna prenotazione in stato 'Check-out' trovata\n");
                return;
            }

            //Stampo le portate acquistate nel servizio cabina
            Console.WriteLine("\nPortate servizio in cabina acquistate:");
            if(!istanza.MostraPortateAcquistate())
                Console.WriteLine("\nNessun servizio acquistato");

            //Stampo i servizi aggiuntivi acquistati
            Console.WriteLine("\n Servizi acquistati:");
            if(!istanza.MostraServiziAcquistati())
                Console.WriteLine("\nNessun servizio acquistato");
            
            //Stampo il conto dal pagare
            Console.WriteLine($"\nTotale da pagare: {istanza.CalcolaConto()}$");

            //Rimuovo il cliente dalla lista delle prenotazioni in corso
            istanza.RimuoviPrenotazione();

            //Aggiorno stato prenotazione
            istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().GestioneStatoPrenotazione(istanza.GetPrenotazioneInCorso(),"Conclusa");
            
            //annullo la prenotazione in corso
            istanza.AnnullaPrenotazioneInCorso();
        }
    }

}