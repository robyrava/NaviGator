using Dominio;

namespace Interfaccia
{
    public class ComandoIndietro : IComando
    {
        public static readonly string codiceComando = "0";
        public static readonly string descrizioneComando = "Indietro";

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
            //torna al menu precedente
        }
    }

}