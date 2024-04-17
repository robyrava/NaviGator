using Dominio;

namespace Comand
{
    public class ConsoleGestisciServizi
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_SERVIZI);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_SERVIZI);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***Menu gestione portata***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.GESTIONE_SERVIZI));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}