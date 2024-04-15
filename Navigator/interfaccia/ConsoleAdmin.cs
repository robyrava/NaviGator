using Dominio;

namespace Interfaccia
{
    public class ConsoleAdmin
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.ADMIN);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.ADMIN);
            }
            comando.Esegui(istanza); // comando indietro
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***ADMIN CONSOLE***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.ADMIN));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}