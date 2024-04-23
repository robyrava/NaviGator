using Dominio;

namespace Comand
{
    public class ComandoRegistraServizioCabina : IComando
    {
        public static readonly string codiceComando = "4";
        public static readonly string descrizioneComando = "Registra servizio cabina";

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
            string msg;

            msg = istanza.RegistraServizioCabina();
            Console.WriteLine(msg);
        }
    }
}