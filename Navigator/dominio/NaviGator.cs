namespace Dominio
{
    public class NaviGator
    {
        private static NaviGator? istanza;
    
        private List<Cliente> elencoClienti;
    
        private List<Cabina> elencoCabine;
    
        private List<Prenotazione> elencoPrenotazioni;
        private List<Portata> elencoPortate;
    
        private Prenotazione? prenotazioneInCorso; 
        private ServizioInCamera? servizioCabinaInCorso;
        private List<ServizioInCamera> elencoServiziCabina;
    
        private int counter;
    
        private NaviGator()
        {
            elencoClienti = new List<Cliente>();
            elencoCabine = new List<Cabina>();
            elencoPrenotazioni = new List<Prenotazione>();
            elencoPortate = new List<Portata>();
            elencoServiziCabina = new List<ServizioInCamera>();
            prenotazioneInCorso = null;
            counter = 1;
            CaricaCabine();
            CaricaPortate();
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
        
        public void CaricaPortate()
        {
            Portata p1 = new Portata("Spaghetti alla carbonara", true, 20, "01");
            elencoPortate.Add(p1);
            Portata p2 = new Portata("Pennette all'arrabbiata", true, 15, "02");
            elencoPortate.Add(p2);
            Portata p3 = new Portata("Insalata mista", true, 5 , "03");
            elencoPortate.Add(p3);
            Portata p4 = new Portata("Tiramisù", false, 6, "04");
            elencoPortate.Add(p4);
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

//******************Metodi UC7******************

        public List<Cabina> GetCabine()
        {
            return elencoCabine;
        }

        public void CreaServizioCabina(string codice, DateTime data)
        {
            foreach (Cabina c in GetCabine())
            {
                if (codice.Equals(c.GetCodice(), StringComparison.OrdinalIgnoreCase))
                {
                    servizioCabinaInCorso = new ServizioInCamera(data, c);
                    break;
                }
            }
        }
        public ServizioInCamera? GetServizioCabinaInCorso() {
            return servizioCabinaInCorso;
        }

        public List<Portata> GetPortateDisponibili()
        {
            List<Portata> portateDisponibili = new List<Portata>();
            foreach (Portata p in elencoPortate)
            {
                if (p.GetDisponibilita())
                {
                    portateDisponibili.Add(p);
                }
            }
            return portateDisponibili;
        }
        public List<Portata> MostraPortate()
        {
            return elencoPortate;
        }

        public List<ServizioInCamera> GetServiziCabina()
        {
            return elencoServiziCabina;
        }

        public void RegistraServizioCabina()
        {
            if (servizioCabinaInCorso == null)
            {
                Console.WriteLine("ATTENZIONE! Deve essere selezionata la cabina su cui effettuare il servizio in camera");
                return;
            }

            elencoServiziCabina.Add(servizioCabinaInCorso);
        }

        public void ResetServizioCabinaInCorso()
        {
            servizioCabinaInCorso = null;
        }
        
        
       
    }
}

