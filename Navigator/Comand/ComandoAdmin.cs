using Dominio;

namespace Comand
{
    public class ComandoAdmin : IComando
    {
        public static readonly string codiceComando = "3" ;
        public static readonly string descrizioneComando = "Menu Admin";

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
            ConsoleAdmin ca = new ConsoleAdmin();
            ca.Start(istanza);
        }
    }

}