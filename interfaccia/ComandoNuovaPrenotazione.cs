using Dominio;

namespace Interfaccia
{
    public class ComandoNuovaPrenotazione : IComando
    {
        public static readonly string CodiceComando = "1" ;
        public static readonly string DescrizioneComando = "nuova prenotazione";

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
            NuovaPrenotazioneConsole npc = new NuovaPrenotazioneConsole();
            npc.Start(istanza);
        }
    }

}