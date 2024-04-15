using Dominio;
using Validazioni;

namespace Interfaccia
{
    public class ComandoRimuoviPortata : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Rimuovi Portata";

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
            string input;
            bool esito;

            //Stampo il menu delle portate
            foreach(Portata p in istanza.MostraPortate())
            {
                Console.WriteLine(p.ToString() + $"\tDisponibilità: {p.GetDisponibilita()}");
            }

            //Richiedo codice
            Console.WriteLine("Inserisci il codice della portata da rimuovere dal menu: ");
            while(true)
            {
                input = Parser.GetInstance().Read();
                if(Validatore.VerificaCodice(input))
                    break;
                Console.WriteLine("Codice non valido, riprova: ");
            }

            esito = istanza.RimuoviPortata(int.Parse(input));
            
            if(esito)
                Console.WriteLine("\nPortata rimossa con successo");
            else
                Console.WriteLine("\nPortata non trovata");
            
        }
    }

}