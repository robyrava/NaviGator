using Dominio;

namespace Interfaccia
{
    public class ComandoAnnullaPrenotazioneInCorso : IComando
    {
        public static readonly string CodiceComando = "4";
        public static readonly string DescrizioneComando = "annulla prenotazione in corso";

        public string GetCodiceComando()
        {
            return CodiceComando;
        }

        public string GetDescrizioneComando()
        {
            return DescrizioneComando;
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