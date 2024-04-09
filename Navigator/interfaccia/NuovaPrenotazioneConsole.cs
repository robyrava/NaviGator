using Dominio;

namespace Interfaccia
{
    public class NuovaPrenotazioneConsole
    {
        public void Start(NaviGator istanza)
        {
            Visualizza();
            IComando comando = Parser.GetInstance().GetComando(ElencoComandi.NUOVA_PRENOTAZIONE);

            while (!comando.GetCodiceComando().Equals("0"))
            {
                comando.Esegui(istanza);
                Console.WriteLine();
                Visualizza();
                comando = Parser.GetInstance().GetComando(ElencoComandi.NUOVA_PRENOTAZIONE);
            }
            comando.Esegui(istanza); // sicuramente è il comando esci
        }

        public void Visualizza()
        {
            Console.WriteLine("INSERIMENTO NUOVA PRENOTAZIONE");
            Console.WriteLine(ElencoComandi.ElencoTuttiComandi(ElencoComandi.NUOVA_PRENOTAZIONE));
            Console.WriteLine("FAI LA TUA SCELTA");
        }
    }
}