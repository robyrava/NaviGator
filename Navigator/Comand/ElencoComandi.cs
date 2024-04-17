using System.Text;

namespace Comand
{
    class ElencoComandi
    {
        //Console
        public const int NAVIGATOR = 0;
        public const int TOUR_OPERATOR = 1;
        public const int NUOVA_PRENOTAZIONE = 2;
        public const int RECEPTIONIST = 3;
        public const int SERVIZIO_CABINA = 4;
        public const int CHECK_IN_OUT = 5;
        public const int ADMIN = 6;
        public const int GESTIONE_PORTATA = 7;
        public const int GESTIONE_SERVIZI = 8;
        public const int GESTIONE_CABINE = 9;

        
        
        private static readonly Dictionary<string, string> comandiValidiNaviGatorConsole = new Dictionary<string, string>
        {
            { ComandoTourOperator.codiceComando, ComandoTourOperator.descrizioneComando },
            { ComandoReceptionist.codiceComando, ComandoReceptionist.descrizioneComando },
            { ComandoAdmin.codiceComando, ComandoAdmin.descrizioneComando },
            { ComandoEsci.codiceComando, ComandoEsci.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiTourOperatorConsole = new Dictionary<string, string>
        {
            { ComandoNuovaPrenotazione.codiceComando, ComandoNuovaPrenotazione.descrizioneComando },
            { ComandoEliminaPrenotazione.codiceComando, ComandoEliminaPrenotazione.descrizioneComando },
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiNuovaPrenotazioneConsole = new Dictionary<string, string>
        {
            { ComandoRegistraCabina.codiceComando, ComandoRegistraCabina.descrizioneComando },
            { ComandoRegistraCliente.codiceComando, ComandoRegistraCliente.descrizioneComando },
            { ComandoRegistraPrenotazione.codiceComando, ComandoRegistraPrenotazione.descrizioneComando },
            { ComandoAnnullaPrenotazioneInCorso.codiceComando, ComandoAnnullaPrenotazioneInCorso.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiReceptionistConsole = new Dictionary<string, string>
        {
            { ComandoCheckInOut.codiceComando, ComandoCheckInOut.descrizioneComando},
            {ComandoServizioCabina.codiceComando, ComandoServizioCabina.descrizioneComando },
            {ComandoVisualizzaPrenotazioni.codiceComando, ComandoVisualizzaPrenotazioni.descrizioneComando},
            {ComandoAggiungiServizioPrenotazione.codiceComando, ComandoAggiungiServizioPrenotazione.descrizioneComando},
            {ComandoCalcolaConto.codiceComando, ComandoCalcolaConto.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiServizioCabina = new Dictionary<string, string>
        {
            {ComandoAssociaServizioCabina.codiceComando, ComandoAssociaServizioCabina.descrizioneComando},
            {ComandoSelezionaPortate.codiceComando,ComandoSelezionaPortate.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiCheckINOUTConsole = new Dictionary<string, string>
        {
            { ComandoCheckIn.codiceComando, ComandoCheckIn.descrizioneComando },
            { ComandoCheckOut.codiceComando, ComandoCheckOut.descrizioneComando },
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };
        private static readonly Dictionary<string, string> comandiValidiAdminConsole = new Dictionary<string, string>
        {
            {ComandoGestisciPortata.codiceComando, ComandoGestisciPortata.descrizioneComando},
            {ComandoGestisciServizi.codiceComando, ComandoGestisciServizi.descrizioneComando},
            {ComandoGestisciCabine.codiceComando, ComandoGestisciCabine.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };
        private static readonly Dictionary<string, string> comandiValidiGestionePortataConsole = new Dictionary<string, string>
        {
            {ComandoAggiungiPortata.codiceComando, ComandoAggiungiPortata.descrizioneComando},
            {ComandoRimuoviPortata.codiceComando, ComandoRimuoviPortata.descrizioneComando},            
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiGestioneServiziConsole = new Dictionary<string, string>
        {
            {ComandoAggiungiServizio.codiceComando, ComandoAggiungiServizio.descrizioneComando},
            {ComandoRimuoviServizio.codiceComando, ComandoRimuoviServizio.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
        };

        private static readonly Dictionary<string, string> comandiValidiGestioneCabineConsole = new Dictionary<string, string>
        {
            {ComandoAbilitaCabina.codiceComando, ComandoAbilitaCabina.descrizioneComando},
            {ComandoDisabilitaCabina.codiceComando, ComandoDisabilitaCabina.descrizioneComando},
            {ComandoVariazionePrezzoCabine.codiceComando, ComandoVariazionePrezzoCabine.descrizioneComando},
            { ComandoIndietro.codiceComando, ComandoIndietro.descrizioneComando }
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
                case ADMIN:
                    return comandiValidiAdminConsole;
                case NUOVA_PRENOTAZIONE:
                    return comandiValidiNuovaPrenotazioneConsole;
                case SERVIZIO_CABINA:
                    return comandiValidiServizioCabina;
                case CHECK_IN_OUT:
                    return comandiValidiCheckINOUTConsole;
                case GESTIONE_PORTATA:
                    return comandiValidiGestionePortataConsole;
                case GESTIONE_SERVIZI:
                    return comandiValidiGestioneServiziConsole;
                case GESTIONE_CABINE:
                    return comandiValidiGestioneCabineConsole;

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