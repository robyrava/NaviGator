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
            string nome;
            bool esito;

            //Stampo il menu delle portate
            foreach(Portata p in istanza.MostraPortate())
            {
                Console.WriteLine(p.ToString() + $"\tDisponibilità: {p.GetDisponibilita()}");
            }

            Console.WriteLine("Inserisci il nome della portata da rimuovere dal menu: ");
            while(true)
            {
                nome = Parser.GetInstance().Read();
                if(Validatore.VerificaNome(nome))
                    break;
                Console.WriteLine("Nome non valido, riprova: ");
            }

            esito = istanza.RimuoviPortata(nome);
            
            if(esito)
                Console.WriteLine("\nPortata rimossa con successo");
            else
                Console.WriteLine("\nPortata non trovata");
            
        }
    }

}