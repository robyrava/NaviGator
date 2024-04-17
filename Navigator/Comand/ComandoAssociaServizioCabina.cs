using Dominio;

namespace Comand
{
    public class ComandoAssociaServizioCabina : IComando
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
            Console.WriteLine();
            bool esiste = false;
            
            //verifico se la cabina esiste (è occupata)
            foreach (Cabina c in istanza.GetCabine())
            {
                if (codice.Equals(c.GetCodice()))
                {
                    DateTime data = DateTime.Now;
                    istanza.CreaServizioCabina(codice, data);
                    esiste = true;
                    break;
                }
            }
            if (esiste)
                Console.WriteLine("Cabina associata con successo!");
            else
                Console.WriteLine("Errore: la cabina scelta non esiste");
        }
    }

}