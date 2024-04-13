using Dominio;

namespace Interfaccia
{
    public class ReceptionistConsole
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.RECEPTIONIST);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.RECEPTIONIST);
            }
            comando.Esegui(istanza); // comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("\n***RECEPTIONIST CONSOLE***");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.RECEPTIONIST));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}