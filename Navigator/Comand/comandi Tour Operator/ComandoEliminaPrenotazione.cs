using Dominio;

namespace Comand
{    
    public class ComandoEliminaPrenotazione : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Annulla prenotazione esistente";

        public string GetCodiceComando()
        {
            return codiceComando;
        }

        public string GetDescrizioneComando()
        {
            return descrizioneComando;
        }

        public void Esegui(NaviGator naviGator)
        {
            try
            {
                Console.WriteLine("Inserisci il codice fiscale del cliente: ");
                string codiceCliente = Parser.GetInstance().Read();
                Console.WriteLine();
                bool clientePresente = false;
                foreach (Prenotazione p in naviGator.VisualizzaPrenotazioni())
                {
                    if (p.GetCliente().GetCodiceFiscale() == codiceCliente)
                    {
                        Console.WriteLine(p.ToString());
                        clientePresente = true;
                    }
                }
                if (clientePresente)
                {
                    Console.WriteLine("Inserisci il codice della prenotazione da eliminare: ");
                    string codicePrenotazione = Parser.GetInstance().Read();
                    bool codiceCorretto = false;
                    foreach (Prenotazione p in naviGator.VisualizzaPrenotazioni())
                    {
                        if (p.GetCodice() == codicePrenotazione && p.GetCliente().GetCodiceFiscale() == codiceCliente && p.GetStatoPrenotazione().EqualsStato("Creato")) 
                        {
                            codiceCorretto = true;
                            break;
                        }
                    }
                    if (codiceCorretto)
                    {
                        naviGator.VisualizzaPrenotazioni().RemoveAll(p => p.GetCodice() == codicePrenotazione);

                        //STAMPO LE PRENOTAZIONI AGGIORNATE
                        Console.WriteLine("Prenotazioni aggiornate: ");
                        foreach (Prenotazione p in naviGator.VisualizzaPrenotazioni())
                        {
                            Console.WriteLine(p.ToString());
                        }

                        Console.WriteLine("La prenotazione è stata annullata con successo");
                    }
                    else
                        Console.WriteLine("ATTENZIONE! Il Codice prenotazione inserito non è valido");
                }
                else
                {
                    Console.WriteLine("Il Cliente non ha nessuna prenotazione effettuata");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ATTENZIONE! Dati inseriti non validi");
            }
        }
    }
}