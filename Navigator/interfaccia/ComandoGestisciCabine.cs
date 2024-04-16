using Dominio;

namespace Interfaccia
{
    public class ComandoGestisciCabine : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "Gestisci cabine";

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
            ConsoleGestisciCabine cc = new ConsoleGestisciCabine();
            cc.Start(istanza);
            
        }
    }

}