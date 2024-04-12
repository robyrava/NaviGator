using Dominio;

namespace Interfaccia
{
    public class ComandoAnnullaPrenotazioneInCorso : IComando
    {
        public static readonly string codiceComando = "4";
        public static readonly string descrizioneComando = "annulla prenotazione in corso";

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
            if(istanza.AnnullaPrenotazioneInCorso())
                Console.WriteLine("Prenotazione annulata con successo");
            else
                Console.WriteLine("Nessuna prenotazione in corso");
        }
    }
}