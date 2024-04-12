using Dominio;

namespace Interfaccia
{
    public class ComandoServizioCabina : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Servizio in Cabina";

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
            ServizioCabinaConsole nsc= new ServizioCabinaConsole();
            nsc.Start(istanza);
        }
    }

}