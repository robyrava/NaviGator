using System.Text;

namespace Interfaccia
{
    class ElencoComandi
    {
        public const int NAVIGATOR = 0;
        public const int NUOVA_PRENOTAZIONE = 1;

        private static readonly string[][] comandiValidiNaviGatorConsole = {
            new string[] {ComandoNuovaPrenotazione.CodiceComando, ComandoNuovaPrenotazione.DescrizioneComando},
            new string[] {ComandoEsci.CodiceComando, ComandoEsci.DescrizioneComando}
        };

        private static readonly string[][] comandiValidiNuovaPrenotazioneConsole = {
            new string[] {ComandoRegistraCabina.CodiceComando, ComandoRegistraCabina.DescrizioneComando},
            //new string[] {ComandoRegistraPacchetto.CodiceComando, ComandoRegistraPacchetto.DescrizioneComando},
            new string[] {ComandoRegistraCliente.CodiceComando, ComandoRegistraCliente.DescrizioneComando},
            new string[] {ComandoRegistraPrenotazione.CodiceComando, ComandoRegistraPrenotazione.DescrizioneComando},
            new string[] {ComandoEsci.CodiceComando, ComandoEsci.DescrizioneComando}
        };


        public static string ElencoTuttiComandi(int console)
        {
            StringBuilder elenco = new StringBuilder();
            string[][] comandi = GetComandi(console);

            for (int i = 0; i < comandi.Length - 1; i++)
            {
                elenco.AppendLine(Comando(i, console));
            }
            elenco.Append(Comando(comandi.Length - 1, console));
            return elenco.ToString();
        }

        private static string Comando(int i, int console)
        {
            string[][] comandi = GetComandi(console);
            return " " + comandi[i][0] + ")" + comandi[i][1];
        }

        public static string[][] GetComandi(int console)
        {
            string[][]? comandi = null;

            switch (console)
            {
                case NAVIGATOR:
                    comandi = comandiValidiNaviGatorConsole;
                    break;
                case NUOVA_PRENOTAZIONE:
                    comandi = comandiValidiNuovaPrenotazioneConsole;
                    break;
            };
            return comandi;
        }

        public bool ComandoValido(string stringa, int console)
        {
            string[][] comandi = GetComandi(console);
            for (int i = 0; i < comandi.Length; i++)
            {
                if (comandi[i][0].Equals(stringa))
                    return true;
            }
            return false;
        }
    }


}