using Dominio;

namespace Comand
{
    public class ComandoReceptionist : IComando
    {
        public static readonly string codiceComando = "2" ;
        public static readonly string descrizioneComando = "Menu Receptionist";

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
            ReceptionistConsole rc = new ReceptionistConsole();
            rc.Start(istanza);
        }
    }

}