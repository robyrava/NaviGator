using Dominio;

namespace Interfaccia
{
    public class ComandoRegistraCabina : IComando
    {
        public static readonly string CodiceComando = "1";
        public static readonly string DescrizioneComando = "registra cabina";

        public string GetCodiceComando()
        {
            return CodiceComando;
        }

        public string GetDescrizioneComando()
        {
            return DescrizioneComando;
        }

        public void Esegui(NaviGator istanza)
        {
            try
            {
                Console.WriteLine("   Inserisci la tipologia di cabina (interna, oblo, suite): ");
                string tipologiaCabina = Parser.GetInstance().Read();
                if (!(tipologiaCabina.Equals("interna", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("oblo", StringComparison.OrdinalIgnoreCase) || tipologiaCabina.Equals("suite", StringComparison.OrdinalIgnoreCase)))
                    throw new Exception();
                Console.WriteLine("   Inserisci data inizio (YYYY-MM-dd): ");
                string dataI = Parser.GetInstance().Read();
                Console.WriteLine("   Inserisci data fine (YYYY-MM-dd): ");
                string dataF = Parser.GetInstance().Read();
                Console.WriteLine();
                foreach (Cabina c in istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)))
                {
                    Console.WriteLine(c.ToString());
                }
                if (!istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)).Any())
                {
                    Console.WriteLine("Non ci sono stanze disponibili per quella tipologia e data");
                }
                else
                {
                    bool codiceCorretto = false;
                    Console.WriteLine("   Inserisci il codice della cabina: ");
                    string codiceCabina = Parser.GetInstance().Read();
                    foreach (Cabina c in istanza.VisualizzaCabine(tipologiaCabina, DateTime.Parse(dataI), DateTime.Parse(dataF)))
                    {
                        if (c.Codice.Equals(codiceCabina))
                            codiceCorretto = true;
                    }
                    Console.WriteLine();
                    if (codiceCorretto)
                    {
                        istanza.RegistraCabina(codiceCabina);
                        Console.WriteLine("La stanza è stata registrata");
                    }
                    else
                        Console.WriteLine("Il codice della stanza inserito non è valido");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ATTENZIONE! Dati inseriti non validi!");
            }
        }
    }

}