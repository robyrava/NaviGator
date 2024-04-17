using Dominio;

namespace Comand
{
    public class ComandoNuovaPrenotazione : IComando
    {
        public static readonly string codiceComando = "1" ;
        public static readonly string descrizioneComando = "Inserisci nuova prenotazione";

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
            NuovaPrenotazioneConsole npc = new NuovaPrenotazioneConsole();
            npc.Start(istanza);
        }
    }

}