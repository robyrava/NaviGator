using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoAggiungiPortata : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Aggiungi Portata";

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
            bool presente = false;
            string input, risposta;

            //Stampo il menu delle portate
            foreach(Portata p in istanza.MostraPortate())
            {
                Console.WriteLine(p.ToString() + $"\tDisponibilità: {p.GetDisponibilita()}");
            }

            Console.WriteLine("Inserisci il nome della portata da aggiungere: ");
            while(true)
            {
                nome = Parser.GetInstance().Read();
                if(Validatore.VerificaNome(nome))
                    break;
                Console.WriteLine("Nome non valido, riprova: ");
            }

            //verifico che il nome non sia già presente tra le portate disponibili
            foreach(Portata p in istanza.GetPortateDisponibili())
            {
                if(p.GetNome().Equals(nome,StringComparison.OrdinalIgnoreCase))
                {
                    presente = true;
                    break;
                }
            }

            if(presente)
            {
                Console.WriteLine("Portata già disponibile");
            }
            else
            {
                //Richiedo prezzo
                Console.WriteLine("Inserisci il prezzo della portata: ");
                while(true)
                {
                    input = Parser.GetInstance().Read();
                    if(Validatore.VerificaPrezzo(input))
                        break;
                
                    Console.WriteLine("Prezzo non valido, riprova: ");
                }

                risposta = istanza.AggiornaMenu(nome, double.Parse(input));
                Console.WriteLine(risposta);
            }


        }
    }

}