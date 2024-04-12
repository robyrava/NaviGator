using System.Text;

namespace Interfaccia
{
    class ElencoComandi
    {
        //Console
        public const int NAVIGATOR = 0;
        public const int TOUR_OPERATOR = 1;
        public const int NUOVA_PRENOTAZIONE = 2;
        public const int RECEPTIONIST = 3;
        public const int SERVIZIO_CABINA = 4;

        
        
        private static readonly Dictionary<string, string> comandiValidiNaviGatorConsole = new Dictionary<string, string>
        {
            { ComandoTourOperator.codiceComando, ComandoTourOperator.descrizioneComando },
            { ComandoReceptionist.codiceComando, ComandoReceptionist.descrizioneComando },
            //{ ComandoAdmin.codiceComando, ComandoAdmin.descrizioneComando },
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiTourOperatorConsole = new Dictionary<string, string>
        {
            { ComandoNuovaPrenotazione.codiceComando, ComandoNuovaPrenotazione.descrizioneComando },
            { ComandoEliminaPrenotazione.codiceComando, ComandoEliminaPrenotazione.descrizioneComando },
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiNuovaPrenotazioneConsole = new Dictionary<string, string>
        {
            { ComandoRegistraCabina.codiceComando, ComandoRegistraCabina.descrizioneComando },
            { ComandoRegistraCliente.codiceComando, ComandoRegistraCliente.descrizioneComando },
            { ComandoRegistraPrenotazione.codiceComando, ComandoRegistraPrenotazione.descrizioneComando },
            { ComandoAnnullaPrenotazioneInCorso.codiceComando, ComandoAnnullaPrenotazioneInCorso.descrizioneComando},
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiReceptionistConsole = new Dictionary<string, string>
        {
            {ComandoServizioCabina.codiceComando, ComandoServizioCabina.descrizioneComando },
            //Gestisci check-in/check out
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiServizioCabina = new Dictionary<string, string>
        {
            {ComandoAssociaServizioCabina.codiceComando, ComandoAssociaServizioCabina.descrizioneComando},
            {ComandoSelezionaPortate.codiceComando,ComandoSelezionaPortate.descrizioneComando},
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
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
                case TOUR_OPERATOR:
                    return comandiValidiTourOperatorConsole;
                case RECEPTIONIST:
                    return comandiValidiReceptionistConsole;
                /**
                case ADMIN:
                    return comandiValidiAdminConsole;
                */
                case NUOVA_PRENOTAZIONE:
                    return comandiValidiNuovaPrenotazioneConsole;
                case SERVIZIO_CABINA:
                    return comandiValidiServizioCabina;

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