using Dominio;

namespace Comand
{
    public class ComandoCheckOut : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "effetua check-out";

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
            Console.WriteLine("   Inserisci il codice fiscale del cliente: ");
            string codiceCliente = Parser.GetInstance().Read();
            
            //verifica se il cliente ha prenotazioni in stato "Check-in"
            bool clientePresente = false;
            foreach (var p in istanza.MostraPrenotazioneCliente(codiceCliente))
            {
                if (p.GetStatoPrenotazione().EqualsStato("Check-in"))
                {
                    Console.WriteLine(p.ToString());
                    clientePresente = true;
                }
            }

            if (clientePresente)
            {
                Console.WriteLine("   Inserisci il codice della prenotazione di cui effettuare il check-out: ");
                string codicePrenotazione = Parser.GetInstance().Read();
                
                bool codiceCorretto = false;
                foreach (var p in istanza.MostraPrenotazioneCliente(codiceCliente))
                {
                    if (p.GetCodice().Equals(codicePrenotazione))
                    {
                        codiceCorretto = true;
                        istanza.SetPrenotazioneInCorso(p);
                        break;
                    }
                }

                if (codiceCorretto && istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().EqualsStato("Check-in"))
                {
                    
                    var prenotazione = istanza.VisualizzaPrenotazioni().FirstOrDefault(p => p.GetCodice() == istanza.GetPrenotazioneInCorso().GetCodice());
                    
                    if (prenotazione != null)
                    {
                        istanza.VisualizzaPrenotazioni().Remove(prenotazione);
                    }
                    
                    //imposto lo stato della prenotazione a "Check-out"
                    istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().GestioneStatoPrenotazione(istanza.GetPrenotazioneInCorso(), "Check-out");
                    
                    //aggiorno la lista delle prenotazioni
                    istanza.VisualizzaPrenotazioni().Add(istanza.GetPrenotazioneInCorso());
                    Console.WriteLine("Check-out effettuato con successo!");
                    
                    
                }
                else
                {
                    Console.WriteLine("Il codice non è corretto o il check-out non è applicabile");
                    
                }
            }
            else
                Console.WriteLine("Il cliente non è presente");
        
            istanza.AnnullaPrenotazioneInCorso();
        }
    }
}