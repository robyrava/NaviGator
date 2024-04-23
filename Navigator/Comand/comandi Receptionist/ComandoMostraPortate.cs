using Dominio;

namespace Comand
{
    public class ComandoMostraPortate : IComando
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

            foreach (Portata p in istanza.MostraPortateDisponibili())
            {
                Console.WriteLine(p.ToString());
            }

        }
    }
}