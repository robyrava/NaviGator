using Dominio;

namespace Interfaccia
{
    public class ComandoGestisciPortata : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Gestisci Portata";

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
            ConsoleGestisciPortata gp = new ConsoleGestisciPortata();
            gp.Start(istanza);
            
        }
    }

}