using System.Collections.Generic;
using System.Text;

namespace Interfaccia
{
    class ElencoComandi
    {
        public const int NAVIGATOR = 0;
        public const int NUOVA_PRENOTAZIONE = 1;

        private static readonly Dictionary<string, string> comandiValidiNaviGatorConsole = new Dictionary<string, string>
        {
            { ComandoNuovaPrenotazione.CodiceComando, ComandoNuovaPrenotazione.DescrizioneComando },
            { ComandoEsci.CodiceComando, ComandoEsci.DescrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiNuovaPrenotazioneConsole = new Dictionary<string, string>
        {
            { ComandoRegistraCabina.CodiceComando, ComandoRegistraCabina.DescrizioneComando },
            { ComandoRegistraCliente.CodiceComando, ComandoRegistraCliente.DescrizioneComando },
            { ComandoRegistraPrenotazione.CodiceComando, ComandoRegistraPrenotazione.DescrizioneComando },
            { ComandoAnnullaPrenotazioneInCorso.CodiceComando, ComandoAnnullaPrenotazioneInCorso.DescrizioneComando},
            { ComandoEsci.CodiceComando, ComandoEsci.DescrizioneComando }
        };

        public static string ElencoTuttiComandi(int console)
        {
            StringBuilder elenco = new StringBuilder();
            Dictionary<string, string> comandi = GetComandi(console);

            foreach (var comando in comandi)
            {
                elenco.AppendLine($" {comando.Key}){comando.Value}");
            }

            return elenco.ToString();
        }

        public static Dictionary<string, string> GetComandi(int console)
        {
            switch (console)
            {
                case NAVIGATOR:
                    return comandiValidiNaviGatorConsole;
                case NUOVA_PRENOTAZIONE:
                    return comandiValidiNuovaPrenotazioneConsole;
                default:
                    return new Dictionary<string, string>();
            };
        }

        public bool ComandoValido(string stringa, int console)
        {
            Dictionary<string, string> comandi = GetComandi(console);
            return comandi.ContainsKey(stringa);
        }
    }
}