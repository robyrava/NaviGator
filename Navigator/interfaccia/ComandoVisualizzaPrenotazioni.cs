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
            Console.WriteLine("Prenotazioni in corso:\n");
            bool x = false;
            foreach (Prenotazione p in istanza.VisualizzaPrenotazioni())
            {
                if(p.GetStatoPrenotazione().EqualsStato("Check-in"))
                {
                    Console.WriteLine(p.GetCliente().ToString());
                    x = true;
                }
            }
            if (!x)
                Console.WriteLine("Nessuna prenotazione in corso");
        }
    }

}