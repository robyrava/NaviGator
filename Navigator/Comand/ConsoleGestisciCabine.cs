using Dominio;

namespace Comand
{
    public class ConsoleGestisciCabine
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_CABINE);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.GESTIONE_CABINE);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***Menu gestione cabine***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.GESTIONE_CABINE));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}