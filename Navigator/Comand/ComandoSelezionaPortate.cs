using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoSelezionaPortate : IComando
    {
        public static readonly string codiceComando = "2";
        public static readonly string descrizioneComando = "Elenco portate disponibili";

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

            bool ordineCreato = false;
            while (true)
            {
                Console.WriteLine();
                foreach (Portata p in istanza.MostraPortate())
                {
                    Console.WriteLine(p.ToString());
                }

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

                foreach (Portata p in istanza.GetPortateDisponibili())
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

                        istanza.GetServizioCabinaInCorso().RegistraPortata(p, int.Parse(quantita));
                        Console.WriteLine("\nPortata inserita con successo all'ordine");
                        ordineCreato = true;

                        portataDisponibile = true;
                        break;
                    }
                }

                if (!portataDisponibile)
                {
                    Console.WriteLine("\nPortata non disponibile");
                }
            }

            if (ordineCreato)
            {
                istanza.GetServiziCabina().Add(istanza.GetServizioCabinaInCorso());
                Console.WriteLine("\nOrdine registrato con successo");
                istanza.ResetServizioCabinaInCorso();
            }
            else
            {
                istanza.ResetServizioCabinaInCorso();
                Console.WriteLine("\nErrore: nessuna portata selezionata");
            }
        }
    }

}