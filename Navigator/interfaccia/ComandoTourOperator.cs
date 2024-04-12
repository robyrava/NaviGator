using Dominio;

namespace Interfaccia
{
    public class ComandoTourOperator : IComando
    {
        public static readonly string codiceComando = "1" ;
        public static readonly string descrizioneComando = "Menu Tour Operator";

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
            TourOperatorConsole to = new TourOperatorConsole();
            to.Start(istanza);
        }
    }

}