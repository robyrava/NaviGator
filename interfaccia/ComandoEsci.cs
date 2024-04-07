using Dominio;

namespace Interfaccia
{
    public class ComandoEsci : IComando
    {
        public static readonly string CodiceComando = "0";
        public static readonly string DescrizioneComando = "esci";

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
            //torna al menu precedente oppure esce se non ci sono menu precedenti
        }
    }

}