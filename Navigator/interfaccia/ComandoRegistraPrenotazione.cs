using Dominio;

namespace Interfaccia
{
    public class ComandoRegistraPrenotazione : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "registra prenotazione";

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
            try
            {
                Console.WriteLine("   Inserisci nuovamente data inizio (YYYY-MM-dd): ");
                string dataI = Parser.GetInstance().Read();
                Console.WriteLine("   Inserisci nuovamente data fine (YYYY-MM-dd): ");
                string dataF = Parser.GetInstance().Read();
                
                if (istanza.VerificaCabinaPrenotata(istanza.GetPrenotazioneInCorso().GetCabina().GetCodice(), DateTime.Parse(dataI), DateTime.Parse(dataF)))
                {
                    istanza.RegistraPrenotazione(DateTime.Parse(dataI), DateTime.Parse(dataF));
                    Console.WriteLine("Il cliente: " + istanza.GetPrenotazioneInCorso().GetCliente().ToString() + " ha effettuato la prenotazione!");
                    foreach (Prenotazione p in istanza.visualizzaPrenotazioni())
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
                else
                    Console.WriteLine("\nAttenzione, le date inserite non sono disponibili!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nATTENZIONE! Dati inseriti non validi!");
            }
        }
    }

}