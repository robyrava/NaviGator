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
                    /**
                    if (parola.Equals("2"))
                        comando = new ComandoReceptionist();
                    if (parola.Equals("3"))
                        comando = new ComandoAdmin();
                    */
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