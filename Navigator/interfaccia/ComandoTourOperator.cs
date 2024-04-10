using Dominio;

namespace Interfaccia
{
    public class ComandoTourOperator : IComando
    {
        public static readonly string CodiceComando = "1" ;
        public static readonly string DescrizioneComando = "Tour Operator";

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
            TourOperatorConsole to = new TourOperatorConsole();
            to.Start(istanza);
        }
    }

}