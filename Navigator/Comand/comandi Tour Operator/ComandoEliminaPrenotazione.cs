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
                string codiceCliente = Console.ReadLine();
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
                    string codicePrenotazione = Console.ReadLine();
                    bool codiceCorretto = false;
                    foreach (Prenotazione p in naviGator.VisualizzaPrenotazioni())
                    {
                        if (p.GetCodice() == codicePrenotazione && p.GetCliente().GetCodiceFiscale() == codiceCliente)
                        {
                            codiceCorretto = true;
                            break;
                        }
                    }
                    if (codiceCorretto)
                    {
                        naviGator.VisualizzaPrenotazioni().RemoveAll(p => p.GetCodice() == codicePrenotazione);
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