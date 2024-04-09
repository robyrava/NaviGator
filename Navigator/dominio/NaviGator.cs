namespace Dominio
{
    public class NaviGator
    {
        private static NaviGator? istanza;
    
        private List<Cliente> elencoClienti;
    
        private List<Cabina> elencoCabine;
    
        private List<Prenotazione> elencoPrenotazioni;
    
        private Prenotazione? prenotazioneInCorso; 
    
        private int counter;
    
        private NaviGator()
        {
            elencoClienti = new List<Cliente>();
            elencoCabine = new List<Cabina>();
            elencoPrenotazioni = new List<Prenotazione>();
            prenotazioneInCorso = null;
            counter = 1;
            CaricaCabine();
        }
    
        public static NaviGator GetInstance()
        {
            if (istanza == null)
                istanza = new NaviGator();
            else
                Console.WriteLine("Istanza già creata");
            return istanza;
        }

        public Prenotazione? GetPrenotazioneInCorso()
        {
            return prenotazioneInCorso;
        }
        public void CaricaCabine()
        {
            Cabina c1 = new Cabina("1", "interna", 600);
            elencoCabine.Add(c1);
            Cabina c2 = new Cabina("2", "oblo", 700);
            elencoCabine.Add(c2);
            Cabina c3 = new Cabina("3", "suite", 1000);
            elencoCabine.Add(c3);
        }

        public List<Cliente> visualizzaClienti()
        {
            return elencoClienti;
        }
        public List<Prenotazione> visualizzaPrenotazioni()
        {
            return elencoPrenotazioni;
        }
        public List<Cabina> VisualizzaCabine(string tipologia, DateTime dataInizio, DateTime dataFine)
        {
            
            List<Cabina> cabineDisponibili = new List<Cabina>();

            foreach (Cabina c in elencoCabine)
            {
                if (tipologia.Equals(c.GetTipo()) && IsCabinaDisponibile(c, dataInizio, dataFine))
                {
                    cabineDisponibili.Add(c);
                }
            }

            return cabineDisponibili;
        }

        private bool IsCabinaDisponibile(Cabina cabina, DateTime dataInizio, DateTime dataFine)
        {
            foreach (Prenotazione p in elencoPrenotazioni)
            {
                if (!p.IsDisponibile(cabina.GetCodice(), dataInizio, dataFine))
                {
                    return false;
                }
            }

            return true;
        }

        public bool VerificaCabinaPrenotata(string codiceCabina, DateTime dataInizio, DateTime dataFine)
        {
            bool disponibile = true;
            
            if(elencoPrenotazioni.Count == 0)
                return disponibile;
            
            foreach (Prenotazione p in elencoPrenotazioni)
            {
                if (!p.IsDisponibile(codiceCabina, dataInizio, dataFine))
                {
                    disponibile = false;
                    break;
                }
            }
            return disponibile;
        }

        public void RegistraCabina(string codice)
        {
            prenotazioneInCorso = new Prenotazione(counter.ToString());
            
            foreach (Cabina c in elencoCabine)
            {
                if (codice.Equals(c.GetCodice()))
                {
                    prenotazioneInCorso.SetCabina(c);
                }
            }
            counter++;
        }

        public void RegistraCliente(string nome, string cognome, string codiceFiscale, string documento, string numeroTelefono, string numeroCarta)
        {
            Cliente? c = elencoClienti.FirstOrDefault(cliente => cliente.GetCodiceFiscale() == codiceFiscale); // se non trova nessun cliente con quel codice fiscale, c sarà null

            if (c == null)
            {
                c = new Cliente(nome, cognome, numeroTelefono, codiceFiscale, documento, numeroCarta);
                elencoClienti.Add(c);
            }

            //verifico che la cabina sia stata registrata
            if (prenotazioneInCorso == null)
                throw new Exception("Devi registrare una cabina prima di procedere con la prenotazione");

            prenotazioneInCorso.SetCliente(c);
        }

        public void RegistraPrenotazione(DateTime dataInizio, DateTime dataFine)
        {

            //verifico che la cabina sia stata registrata
            if(prenotazioneInCorso == null)
                throw new Exception("Devi registrare una cabina prima di procedere con la prenotazione");
            //verifico che il cliente sia stato registrato
            if(prenotazioneInCorso.GetCliente() == null)
                throw new Exception("Devi registrare un cliente prima di procedere con la prenotazione");

            prenotazioneInCorso.SetDataInizio(dataInizio);
            prenotazioneInCorso.SetDataFine(dataFine);
            elencoPrenotazioni.Add(prenotazioneInCorso);
            counter++;
        }

        public bool AnnullaPrenotazioneInCorso()
        {
            if(prenotazioneInCorso == null)
                return false;
            
            prenotazioneInCorso = null;
            return true;
        }
        
       
    }
}

