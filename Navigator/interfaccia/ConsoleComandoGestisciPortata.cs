using Dominio;

namespace Interfaccia
{
    public class ConsoleGestisciPortata
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_PORTATA);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_PORTATA);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***Menu gestione portata***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.GESTIONE_PORTATA));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}