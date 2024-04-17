using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoRegistraCabina : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "registra cabina";

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
                Console.WriteLine("   Inserisci la tipologia di cabina (interna, oblo, suite): ");
                string tipologiaCabina = Parser.GetInstance().Read();
                if (!(tipologiaCabina.Equals("interna", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("oblo", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("suite", StringComparison.OrdinalIgnoreCase)))
                    throw new Exception();
                
                Console.WriteLine("   Inserisci data di partenza (YYYY-MM-dd): ");
                string dataI = Parser.GetInstance().Read();
                while(!Validatore.VerificaDataInizio(dataI))
                {
                    Console.WriteLine("   Data non valida!\nRicorda le crociere partono di Lunedi\nInserisci data di partenza(YYYY-MM-dd): ");
                    dataI = Parser.GetInstance().Read();
                }

                Console.WriteLine("   Inserisci data fine (YYYY-MM-dd): ");
                string dataF = Parser.GetInstance().Read();
                while(!Validatore.VerificaDataFine(dataF))
                {
                    Console.WriteLine("   Data non valida!\nRicorda le crociere terminano di Sabato\nInserisci data fine(YYYY-MM-dd): ");
                    dataF = Parser.GetInstance().Read();
                }

                Console.WriteLine();
                foreach (Cabina c in istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)))
                {
                    Console.WriteLine(c.ToString());
                }
                if (!istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)).Any())
                {
                    Console.WriteLine($"Nessuna cabina del tipo {tipologiaCabina} disponibile per questa data");
                }
                else
                {
                    bool codiceCorretto = false;
                    
                    Console.WriteLine("   Inserisci il codice della cabina: ");
                    string codiceCabina = Parser.GetInstance().Read();
                    while (!Validatore.VerificaCodice(codiceCabina))
                    {
                        Console.WriteLine("   Codice non valido!\nInserisci il codice della cabina: ");
                        codiceCabina = Parser.GetInstance().Read();
                    }

                    foreach (Cabina c in istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)))
                    {
                        if (c.GetCodice().Equals(codiceCabina))
                            codiceCorretto = true;
                    }
                    Console.WriteLine();
                    if (codiceCorretto)
                    {
                        istanza.RegistraCabina(codiceCabina);
                        Console.WriteLine("La stanza è stata registrata con successo!");
                    }
                    else
                        Console.WriteLine("Errore: Il codice della stanza inserito non è valido");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ATTENZIONE! Dati inseriti non validi!");
            }
        }
    }

}