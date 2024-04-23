using Dominio;

namespace Comand
{
    public class ComandoResetServizioCabina : IComando
    {
        public static readonly string codiceComando = "5";
        public static readonly string descrizioneComando = "Annulla servizio cabina in corso";

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
            istanza.ResetServizioCabinaInCorso();
            Console.WriteLine("Servizio cabina annullato con successo!");
        }
    }
}