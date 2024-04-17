using Dominio;

namespace Comand
{
    public class ComandoNonValido : IComando
    {
        public static readonly string codiceComando = "-1";
        public static readonly string descrizioneComando = "comando non valido";

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
            Console.WriteLine("   Comando non valido, riprovare");
        }
    }
}