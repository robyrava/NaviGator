using Dominio;

namespace Comand
{
    public class TourOperatorConsole
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.TOUR_OPERATOR);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.TOUR_OPERATOR);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***TOUR OPERATOR CONSOLE***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.TOUR_OPERATOR));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}