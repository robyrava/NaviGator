using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoCreaServizioCabina : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Associa cabina";

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
            Console.WriteLine("Inserisci il codice della cabina: ");
            string codice = Parser.GetInstance().Read();
            //Verifico formato codice
            if (!Validatore.VerificaCodice(codice))
            {
                Console.WriteLine("Errore: codice cabina non valido");
                return;
            }

            if (istanza.CreaServizioCabina(int.Parse(codice), DateTime.Now))
                Console.WriteLine("Cabina associata con successo!");
            else
                Console.WriteLine("Errore: la cabina non risulta prenotata.");
        }
    }

}