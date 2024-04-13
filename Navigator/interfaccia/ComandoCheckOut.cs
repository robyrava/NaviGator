using Dominio;

namespace Interfaccia
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
            string codiceCliente = Console.ReadLine();
            

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
                string codicePrenotazione = Console.ReadLine();
                
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

                    istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().GestioneStatoPrenotazione(istanza.GetPrenotazioneInCorso(), "Check-out");
                    istanza.VisualizzaPrenotazioni().Add(istanza.GetPrenotazioneInCorso());
                    Console.WriteLine("Check-out effettuato con successo!");
                    
                    istanza.AnnullaPrenotazioneInCorso();
                }
                else
                {
                    Console.WriteLine("Il codice non è corretto o il check-out non è applicabile");
                    istanza.AnnullaPrenotazioneInCorso();
                }
            }
            else
                Console.WriteLine("Il cliente non è presente");
        }
    }
}