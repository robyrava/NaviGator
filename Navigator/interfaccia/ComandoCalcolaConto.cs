using Dominio;
using Validazioni;
namespace Interfaccia
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
            
            //verifica se il cliente ha prenotazioni in stato "Check-out"
            bool isCheckOut = false;
            foreach (Prenotazione p in istanza.MostraPrenotazioneCliente(cf)) {
                if(p.GetStatoPrenotazione().EqualsStato("Check-out")) {
                    Console.WriteLine($"Cliente: {p.GetCliente().GetNome()} {p.GetCliente().GetCognome()}\n{p.ToString()}");
                    isCheckOut = true;
                }
            }

            //Se il cliente ha prenotazioni in stato "Check-out" chiedo il codice della prenotazione su cui calcolare il conto
            if(isCheckOut)
            {
                Console.WriteLine("Inserisci il codice della prenotazione su cui calcolare il conto");
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

                //se il codice è corretto calcolo il conto
                if(codiceCorretto)
                {
                    double conto = 0;
                    
                    //Stampo i servizi aggiuntivi acquistati
                    Console.WriteLine("\nServizi acquistati:");
                    bool haServizi = false;
                    foreach (RichiestaServizio rs in istanza.GetPrenotazioneInCorso().GetServiziRichiesti())
                    {
                        haServizi = true;

                        foreach (Servizio s in rs.GetServizi())
                        {
                            Console.WriteLine(s.ToString());
                        }
                    }
                    if (!haServizi)
                        Console.WriteLine("Nessun servizio acquistato\n");
                    
                    //Stampo le portate acquistate nel servizio cabina
                    Console.WriteLine("\nPortate servizio in cabina acquistate:");
                    bool haServiziInCabina = false;
                    foreach (ServizioInCabina sc in istanza.GetServiziCabina())
                    {
                       
                        if (sc.GetCabina().GetCodice().Equals(istanza.GetPrenotazioneInCorso().GetCabina().GetCodice()))
                        {
                            foreach (Portata po in sc.GetOrdineInCorso().GetQuantitaPortate())
                            {
                                haServiziInCabina = true;
                                Console.WriteLine(po.ToString() + $" Quantità: {sc.GetOrdineInCorso().GetQuantitaPortate().Count}");
                            }
                        }                        
                    }
                    if (!haServiziInCabina)
                        Console.WriteLine("Nessun servizio in cabina acquistato\n");

                    //Stampo il conto dal pagare
                    Console.WriteLine($"\nTotale da pagare: {istanza.CalcolaConto(istanza.GetPrenotazioneInCorso())}$");


                    //Rimuovo il cliente dalla lista delle prenotazioni in corso
                    istanza.RimuoviPrenotazione(istanza.GetPrenotazioneInCorso());
                    //Aggiorno stato prenotazione
                    istanza.GetPrenotazioneInCorso().GetStatoPrenotazione().GestioneStatoPrenotazione(istanza.GetPrenotazioneInCorso(),"Conclusa");
                    istanza.AnnullaPrenotazioneInCorso();
                }
            }
            else
            {
                Console.WriteLine("\nErrore: Il Cliente deve prima effettuare il check-out\n");
            }



        }
    }

}