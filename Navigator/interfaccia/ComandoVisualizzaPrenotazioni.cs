using Dominio;

namespace Interfaccia
{
    public class ComandoVisualizzaPrenotazioni : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "Visualizza prenotazioni";

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
            Console.WriteLine("Prenotazioni in corso:");
            bool x = false;
            bool haServizi = false;
            int i = 0;

            foreach (Prenotazione p in istanza.VisualizzaPrenotazioni())
            {
                Console.WriteLine();
                if(p.GetStatoPrenotazione().EqualsStato("Check-in"))
                {
                    Console.WriteLine($"Prenotazione {++i}");
                    Console.WriteLine(p.GetCliente().ToString());
                    //Stampo i servizi richiesti
                    Console.WriteLine("Servizi richiesti:");
                    foreach (RichiestaServizio rs in p.GetServiziRichiesti())
                    {
                        haServizi = true;
                        foreach (Servizio s in rs.GetServizi())
                        {
                            Console.WriteLine(s.ToString());
                        }
                    }
                    if (!haServizi)
                        Console.WriteLine("Nessun servizio richiesto");
                    
                    haServizi = false;
                    x = true;
                }
            }
            if (!x)
                Console.WriteLine("Nessuna prenotazione in corso");
        }
    }

}