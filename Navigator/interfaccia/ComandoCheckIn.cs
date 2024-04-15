using Dominio;

namespace Interfaccia
{
    public class ComandoCheckIn : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "effettua check-in";

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
            string cf = Parser.GetInstance().Read();
            
            //verifica se il cliente ha prenotazioni in stato "Creato"
            bool cliente_presente = false;
            foreach (Prenotazione p in istanza.MostraPrenotazioneCliente(cf)) {
                if(p.GetStatoPrenotazione().EqualsStato("Creato")) {
                    Console.WriteLine(p.ToString());
                    cliente_presente = true;
                }
            }

            //se il cliente ha prenotazioni in stato "Creato" chiedo il codice della prenotazione da effettuare il check-in
            if(cliente_presente){
                Console.WriteLine("   Inserisci il codice della prenotazione di cui fare il check-in: ");
                string codice_prenotazione = Parser.GetInstance().Read();
                
                //verifica se il codice inserito è corretto
                bool codice_corretto = false;
                foreach (Prenotazione p in istanza.MostraPrenotazioneCliente(cf)) {
                    if (p.GetCodice().Equals(codice_prenotazione)) {
                        codice_corretto = true;
                        istanza.SetPrenotazioneInCorso(p);
                        break;
                    }
                }

                //se il codice è corretto e la prenotazione è in stato "Creato" effettuo il check-in
                if(codice_corretto && istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().EqualsStato("Creato")){
                    var prenotazioni = istanza.VisualizzaPrenotazioni();
                    for (int i = 0; i < istanza.VisualizzaPrenotazioni().Count; i++) {
                        if (istanza.GetPrenotazioneInCorso().GetCodice().Equals(prenotazioni[i].GetCodice())) {
                            prenotazioni.RemoveAt(i);
                            break;
                        }
                    }
                    istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().GestioneStatoPrenotazione(istanza.GetPrenotazioneInCorso(),"Check-in");
                    istanza.VisualizzaPrenotazioni().Add(istanza.GetPrenotazioneInCorso());
                    Console.WriteLine("\nCheck-in effettuato con successo!");
                    
                }else 
                {
                    Console.WriteLine("\nIl Cliente ha già effettuato il check-in o il codice prenotazione è errato");
                    
                }
            }else {
                Console.WriteLine("\nIl Cliente non ha effettuato nessuna prenotazione");
                
            }
            istanza.AnnullaPrenotazioneInCorso();
        }
    }

}