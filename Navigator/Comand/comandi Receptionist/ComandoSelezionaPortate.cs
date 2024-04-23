using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoSelezionaPortate : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "Aggiungi portata all'ordine";

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
            if (istanza.GetServizioCabinaInCorso() == null)
            {
                Console.WriteLine("\nATTENZIONE! Nessuna cabina selezionata. Selezionare una cabina prima di ordinare.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nInserisci il codice della portata da ordinare (0 per terminare): ");
                string input = Parser.GetInstance().Read();
                while(!Validatore.VerificaCodice(input))
                {
                    Console.WriteLine("Codice non valido. Reinserire il codice della portata da ordinare (0 per terminare): ");
                    input = Parser.GetInstance().Read();
                }

                int codicePortata = int.Parse(input);
                if (codicePortata.Equals(0))
                    break;

                bool portataDisponibile = false;

                foreach (Portata p in istanza.MostraPortateDisponibili())
                {
                    if (codicePortata.Equals(p.GetCodice()))
                    {
                        Console.WriteLine("Inserisci la quantita (max 4): ");
                        string quantita = Parser.GetInstance().Read();
                        while (!Validatore.VerificaQuantita(quantita))
                        {
                            Console.WriteLine("Quantita non valida. Reinserire la quantita (max 4): ");
                            quantita = Parser.GetInstance().Read();
                        }

                        if(istanza.RegistraPortata(p, int.Parse(quantita)))
                            Console.WriteLine("\nPortata inserita con successo all'ordine");

                        portataDisponibile = true;
                        break;
                    }
                }

                if (!portataDisponibile)
                {
                    Console.WriteLine("\nPortata non disponibile");
                }
            }
        }
    }

}