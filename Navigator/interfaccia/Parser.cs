namespace Interfaccia
{
    class Parser
    {
        private ElencoComandi comandi;
        private static Parser singleton;

        private Parser()
        {
            comandi = new ElencoComandi();
        }

        public static Parser GetInstance()
        {
            if (singleton == null)
                singleton = new Parser();
            return singleton;
        }

        public string Read()
        {
            Console.Write(" > ");
            return Console.ReadLine();
        }

        public IComando GetComando(int console)
        {
            string parola = Read();
            IComando? comando = null;

            if (comandi.ComandoValido(parola, console))
            {
                if (console == ElencoComandi.NAVIGATOR)
                {
                    if (parola.Equals("1"))
                        comando = new ComandoTourOperator();
                    if (parola.Equals("2"))
                        comando = new ComandoReceptionist();
                    if (parola.Equals("3"))
                        comando = new ComandoAdmin();

                }

                if (console == ElencoComandi.TOUR_OPERATOR)
                {
                    if (parola.Equals("1"))
                        comando = new ComandoNuovaPrenotazione();
                    if (parola.Equals("2"))
                        comando = new ComandoEliminaPrenotazione();                    
                }

                if (console == ElencoComandi.NUOVA_PRENOTAZIONE)
                {
                    if (parola.Equals("1"))
                        comando = new ComandoRegistraCabina();
                    if (parola.Equals("2"))
                        comando = new ComandoRegistraCliente();
                    if (parola.Equals("3"))
                        comando = new ComandoRegistraPrenotazione();
                    if (parola.Equals("4"))
                        comando = new ComandoAnnullaPrenotazioneInCorso();
                }

                if(console == ElencoComandi.RECEPTIONIST)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoCheckInOut();
                    if(parola.Equals("2"))
                        comando = new ComandoServizioCabina();
                    if(parola.Equals("3"))
                        comando = new ComandoVisualizzaPrenotazioni();
                    if(parola.Equals("4"))
                        comando = new ComandoAggiungiServizioPrenotazione();
                    if(parola.Equals("5"))
                        comando = new ComandoCalcolaConto();                        
                }

                if(console == ElencoComandi.SERVIZIO_CABINA)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoAssociaServizioCabina();
                    if(parola.Equals("2"))
                        comando = new ComandoSelezionaPortate();
                }

                if(console == ElencoComandi.CHECK_IN_OUT)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoCheckIn();
                    if(parola.Equals("2"))
                        comando = new ComandoCheckOut();
                }

                if(console == ElencoComandi.ADMIN)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoGestisciPortata();
                    if(parola.Equals("2"))
                        comando = new ComandoGestisciServizi();
                /** 
                    if(parola.Equals("3"))
                        comando = new ComandoGestisciPrezzoCabine();
                    if(parola.Equals("4"))
                        comando = new ComandoGestisciCabine();
                */
                }
                if(console == ElencoComandi.GESTIONE_PORTATA)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoAggiungiPortata();
                    if(parola.Equals("2"))
                        comando = new ComandoRimuoviPortata();
                }
                if(console == ElencoComandi.GESTIONE_SERVIZI)
                {
                    if(parola.Equals("1"))
                        comando = new ComandoAggiungiServizio();
                    if(parola.Equals("2"))
                        comando = new ComandoRimuoviServizio();
                }

                if (parola.Equals("0"))
                    comando = new ComandoEsci();
            }
            else
            {
                comando = new ComandoNonValido();
            }

            return comando;
        }
    }


}