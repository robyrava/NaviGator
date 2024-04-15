using Dominio;

namespace Interfaccia
{
    public class ComandoGestisciServizi : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Gestisci servizi aggiuntivi";

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
            ConsoleGestisciServizi cs = new ConsoleGestisciServizi();
            cs.Start(istanza);
            
        }
    }

}