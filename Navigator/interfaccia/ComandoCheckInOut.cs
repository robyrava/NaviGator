using Dominio;

namespace Interfaccia
{
    public class ComandoCheckInOut : IComando
    {
        public static readonly string codiceComando = "2" ;
        public static readonly string descrizioneComando = "Check-in/Check-out";

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
            CheckInOutConsole ch = new CheckInOutConsole();
            ch.Start(istanza);
        }
    }

}