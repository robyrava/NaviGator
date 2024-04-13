using Dominio;

namespace Interfaccia
{
    public class CheckInOutConsole
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.CHECK_IN_OUT);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.CHECK_IN_OUT);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***MENU CHECK IN/OUT***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.CHECK_IN_OUT));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}