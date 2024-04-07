using Dominio;

namespace Interfaccia
{
    public class ComandoNonValido : IComando
    {
        public static readonly string CodiceComando = "-1";
        public static readonly string DescrizioneComando = "comando non valido";

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
            Console.WriteLine("   COMANDO INESISTENTE");
        }
    }
}