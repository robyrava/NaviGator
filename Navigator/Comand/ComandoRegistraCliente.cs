using Dominio;

namespace Comand
{
    public class ComandoRegistraCliente : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "registra cliente";

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
            try
            {
                Console.WriteLine("   Nome: ");
                string nomeCliente = Parser.GetInstance().Read();
                Console.WriteLine("   Cognome: ");
                string cognomeCliente = Parser.GetInstance().Read();
                Console.WriteLine("   Codice fiscale: ");
                string codiceCliente = Parser.GetInstance().Read();
                Console.WriteLine("   Documento: ");
                string documentoCliente = Parser.GetInstance().Read();
                Console.WriteLine("   Numero telefono: ");
                string numeroTelCliente = Parser.GetInstance().Read();
                Console.WriteLine("   Numero carta: ");
                string numeroCartaCliente = Parser.GetInstance().Read();
                
                istanza.RegistraCliente(nomeCliente, cognomeCliente, codiceCliente, documentoCliente, numeroTelCliente, numeroCartaCliente);
                Console.WriteLine("\nIl cliente è stato registrato con successo!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nATTENZIONE! Devi prima effettuare la registrazione della cabina!");
            }
        }
    }

}