using Dominio;

namespace Comand{

    public class NaviGatorConsole
    {
        public void Start()
        {
            NaviGator NaviGator = NaviGator.GetInstance();
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.NAVIGATOR);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(NaviGator);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.NAVIGATOR);
            }
            comando.Esegui(NaviGator);
            Console.WriteLine("   Grazie per aver utilizzato NaviGator\n");
        }

        public void Visualizza()
        {
            Console.WriteLine("Benvenuto in NaviGator");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.NAVIGATOR));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }


}