using Dominio;
using Validazioni;
namespace Comand
{
    public class ComandoAggiungiServizioPrenotazione : IComando
    {
        public static readonly string codiceComando = "4";
        public static readonly string descrizioneComando = "Aggiungi servizi aggiuntivi";

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
            
            //verifica se il cliente ha prenotazioni in stato "Check-in"
            bool clientePresente = false;
            foreach (Prenotazione p in istanza.MostraPrenotazioneCliente(cf)) {
                if(p.GetStatoPrenotazione().EqualsStato("Check-in")) {
                    Console.WriteLine($"Cliente: {p.GetCliente().GetNome()} {p.GetCliente().GetCognome()}\n{p.ToString()}");
                    clientePresente = true;
                }
            }

            //Se il cliente ha prenotazioni in stato "Check-in" chiedo il codice della prenotazione a cui aggiungere il servizio
            if(clientePresente)
            {
                Console.WriteLine("Inserisci il codice della prenotazione a cui aggiungere il servizio");
                string codicePrenotazione = Parser.GetInstance().Read();
                
                //verifica se il codice inserito è corretto
                bool codiceCorretto = false;
                foreach (Prenotazione p in istanza.MostraPrenotazioneCliente(cf)) 
                {
                    if (p.GetCodice().Equals(codicePrenotazione)) {
                        codiceCorretto = true;
                        istanza.SetPrenotazioneInCorso(p);
                        break;
                    }
                }

                //se il codice è corretto aggiungo il servizio alla prenotazione
                if(codiceCorretto)
                {
                    //Stampo i servizi disponibili
                    Console.WriteLine("\nServizi disponibili:\n");
                    foreach (Servizio s in istanza.GetListaServizi())
                    {
                        Console.WriteLine(s.ToString());
                    }
                    Console.WriteLine("Inserisci il codice del servizio da aggiungere");
                    //Verifico formato codice 
                    string codiceServizio = Parser.GetInstance().Read();
                    while (!Validatore.VerificaCodice(codiceServizio))
                    {
                        Console.WriteLine("Errore: Codice servizio non valido");
                        codiceServizio = Parser.GetInstance().Read();
                    }
                        
                    bool servizioTrovato = false;

                    //verifica se il servizio è presente
                    foreach (Servizio s in istanza.GetListaServizi())
                    {
                        if (s.GetCodice().Equals(int.Parse(codiceServizio)))
                        {
                            string dataInizio = string.Empty;

                            while (true)
                            {
                                Console.WriteLine("Inserisci la data di inizio del servizio");
                                dataInizio = Parser.GetInstance().Read();
                                //Verifico che la data sia corretta e che sia successiva alla data di inizio della prenotazione e precedente alla data di fine
                                if (!Validatore.VerificaFormatoData(dataInizio) || DateTime.Parse(dataInizio) <= istanza.GetPrenotazioneInCorso().GetDataInizio() || DateTime.Parse(dataInizio) >= istanza.GetPrenotazioneInCorso().GetDataFine())
                                    Console.WriteLine("Errore: La data deve essere compresa tra la data di inizio e la data di fine della prenotazione");                               
                                else
                                    break;   
                            }
                            
                            RichiestaServizio rs = new RichiestaServizio(DateTime.Parse(dataInizio));
                            rs.SetServizio(s);

                            //aggiungo la richiesta di servizo alla prenotazione
                            istanza.GetPrenotazioneInCorso().SetServizio(rs);
                            Console.WriteLine("\nServizio aggiunto con successo");
                            servizioTrovato = true;
                            break;
                        }
                    }
                    istanza.AnnullaPrenotazioneInCorso();
                    if(!servizioTrovato)
                        Console.WriteLine("Codice servizio non valido");
                }
            }
            else
            {
                Console.WriteLine("\nErrore: Cliente non presente");
            }



        }
    }

}