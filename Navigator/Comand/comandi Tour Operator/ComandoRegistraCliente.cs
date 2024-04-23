using Dominio;
using Validazioni;
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
            
            Console.WriteLine("\n   Nome: ");
            string nomeCliente = Parser.GetInstance().Read();
            while(!Validatore.VerificaNome(nomeCliente))
            {
                Console.WriteLine("\n   Errore: Nome non valido. Inserire un nome valido: ");
                nomeCliente = Parser.GetInstance().Read();
            }

            Console.WriteLine("\n   Cognome: ");
            string cognomeCliente = Parser.GetInstance().Read();
            while(!Validatore.VerificaNome(nomeCliente))
            {
                Console.WriteLine("\n   Errore: Cognome non valido. Inserire un nome valido: ");
                nomeCliente = Parser.GetInstance().Read();
            }

            Console.WriteLine("\n   Codice fiscale: ");
            string codiceCliente = Parser.GetInstance().Read();

            Console.WriteLine("\n   Documento: ");
            string documentoCliente = Parser.GetInstance().Read();
            while(!Validatore.VerificaDocumento(documentoCliente))
            {
                Console.WriteLine("\n   Errore: Documento non valido. Inserire un documento valido: ");
                documentoCliente = Parser.GetInstance().Read();
            }

            Console.WriteLine("\n   Numero telefono: ");
            string numeroTelCliente = Parser.GetInstance().Read();
            while(!Validatore.VerificaTelefono(numeroTelCliente))
            {
                Console.WriteLine("\n   Errore: Numero di telefono non valido. Inserire un numero di telefono valido: ");
                numeroTelCliente = Parser.GetInstance().Read();
            }

            Console.WriteLine("\n   Numero carta: ");
            string numeroCartaCliente = Parser.GetInstance().Read();
            while(!Validatore.VerificaCarta(numeroCartaCliente))
            {
                Console.WriteLine("\n   Errore: Numero di carta non valido. Inserire un numero di carta valido: ");
                numeroCartaCliente = Parser.GetInstance().Read();
            }
            
            if(istanza.RegistraCliente(nomeCliente, cognomeCliente, codiceCliente, documentoCliente, numeroTelCliente, numeroCartaCliente))
            {
                Console.WriteLine("\nCliente registrato con successo!");
            }
            else
            {
                Console.WriteLine("\nErrore: Nessuna cabina registrata");
            }
            
        }
    }

}