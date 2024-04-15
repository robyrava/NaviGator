using System.Security.Cryptography;

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
        private ServizioInCabina? servizioCabinaInCorso;
        private List<ServizioInCabina> elencoServiziCabina;
        private List<Servizio> listaServizi;
    
        private int counter;
    
        private NaviGator()
        {
            elencoClienti = new List<Cliente>();
            elencoCabine = new List<Cabina>();
            elencoPrenotazioni = new List<Prenotazione>();
            elencoPortate = new List<Portata>();
            elencoServiziCabina = new List<ServizioInCabina>();
            listaServizi = new List<Servizio>();
            prenotazioneInCorso = null;
            counter = 1;
            CaricaCabine();
            CaricaPortate();
            CaricaServizi();

            //Da rimuovere
            CaricaPrenotazioni();
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
        public void SetPrenotazioneInCorso(Prenotazione p)
        {
            prenotazioneInCorso = p;
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
            Portata p1 = new Portata("Spaghetti alla carbonara", true, 20,elencoPortate.Count+1);
            elencoPortate.Add(p1);
            Portata p2 = new Portata("Pennette all'arrabbiata", true, 15, elencoPortate.Count+1);
            elencoPortate.Add(p2);
            Portata p3 = new Portata("Insalata mista", true, 5 ,elencoPortate.Count+1);
            elencoPortate.Add(p3);
            Portata p4 = new Portata("Tiramisu", false, 6, elencoPortate.Count+1);
            elencoPortate.Add(p4);
        }

        public void CaricaServizi()
        {
            Servizio s1 = new Servizio(listaServizi.Count+1, "Spa: Massaggio rilassante", 50);
            listaServizi.Add(s1);
            Servizio s2 = new Servizio(listaServizi.Count+1, "Escursione: Alla scoperta di Malta", 150); 
            listaServizi.Add(s2);
            Servizio s3 = new Servizio(listaServizi.Count+1, "Snorkeling a Santorini", 70);
            listaServizi.Add(s3);
            Servizio s4 = new Servizio(listaServizi.Count+1, "Bagno con i delfini", 100);
            listaServizi.Add(s4);
        }

        //DA RIMUOVERE
        public void CaricaPrenotazioni()
        {
            
            Cliente c1 = new Cliente("Mario", "Rossi", "3333333333", "q", "q", "1234");
            Prenotazione p1 = new Prenotazione("1");
            p1.SetCliente(c1);
            p1.SetDataInizio(new DateTime(2024,1, 1));
            p1.SetDataFine(new DateTime(2024,1, 10));
            p1.SetCabina(elencoCabine[1]);
            p1.GetStatoPrenotazione().GestioneStatoPrenotazione(p1,"Creato");
            elencoPrenotazioni.Add(p1);

            Cliente c2 = new Cliente("Luca", "Verdi", "3333333333", "w", "w", "1234");
            Prenotazione p2 = new Prenotazione("2");
            p2.SetCliente(c2);
            p2.SetDataInizio(new DateTime(2024,1, 1));
            p2.SetDataFine(new DateTime(2024,1, 10));
            p2.SetCabina(elencoCabine[0]);
            p2.GetStatoPrenotazione().GestioneStatoPrenotazione(p2,"Creato");
            elencoPrenotazioni.Add(p2);
        }

        public List<Cliente> VisualizzaClienti()
        {
            return elencoClienti;
        }
        public List<Prenotazione> VisualizzaPrenotazioni()
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
            //verifico siano stati registrati i dati del cliente
            if(prenotazioneInCorso.GetCliente() == null)
                throw new Exception("Devi registrare un cliente prima di procedere con la prenotazione");

            prenotazioneInCorso.SetDataInizio(dataInizio);
            prenotazioneInCorso.SetDataFine(dataFine);
            prenotazioneInCorso.GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazioneInCorso,"Creato");
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

//******************Metodi UC3 check-in/out******************
        public List<Prenotazione> MostraPrenotazioneCliente(string codice_fiscale)
        {
            List<Prenotazione> prenotazioniCliente = new List<Prenotazione>();
            foreach (Prenotazione p in elencoPrenotazioni)
            {
                if (p.GetCliente().GetCodiceFiscale().Equals(codice_fiscale, StringComparison.OrdinalIgnoreCase))
                    prenotazioniCliente.Add(p);
            }
            return prenotazioniCliente;
        }
//******************Metodi UC4******************
        public List<Servizio> GetListaServizi()
        {
            return listaServizi;
        }

//******************Metodi UC5******************
    public double CalcolaConto(Prenotazione p)
    {       
        double contoServizi = 0;
        double contoServizioCabina = 0;
        
    
        foreach (RichiestaServizio rs in p.GetServiziRichiesti())
        {
            contoServizi = contoServizi + rs.GetSubTotale();
        }

        foreach (ServizioInCabina sc in elencoServiziCabina)
        {
            if (sc.GetCabina().GetCodice().Equals(p.GetCabina().GetCodice()))
            {
                contoServizioCabina = contoServizioCabina + sc.GetSubTot();
            }
        }

        //Applico Sconto del 20% se la cabina è una suite
        if (p.GetCabina().GetTipo().Equals("suite", StringComparison.OrdinalIgnoreCase))
        {
            contoServizioCabina = contoServizioCabina - (contoServizioCabina * 0.2);
        }

        return contoServizioCabina + contoServizi;
        
    }

    public void RimuoviPrenotazione(Prenotazione p)
    {
        elencoPrenotazioni.Remove(p);
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
                    servizioCabinaInCorso = new ServizioInCabina(data, c);
                    break;
                }
            }
        }
        public ServizioInCabina? GetServizioCabinaInCorso() {
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

        public List<ServizioInCabina> GetServiziCabina()
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
        

//******************Metodi UC10******************
        public string AggiornaMenu(string nome, double prezzo)
        {
            //Se la portata è già presente tra quelle non disponibili, la rendo disponibile. Senno la aggiungo
            foreach (Portata p in elencoPortate)
            {
                if (p.GetNome().Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    p.SetDisponibilita(true);
                    p.SetPrezzo(prezzo);
                    return "\nPortata aggiornata con successo";
                }
            }
            
            Portata nuovaPortata = new Portata(nome, true, prezzo, elencoPortate.Count+1);
            elencoPortate.Add(nuovaPortata);
            return "\nPortata aggiunta con successo";
        }

        public bool RimuoviPortata(int codice)
        {
            //Se la portata è presente tra quelle disponibili, la rendo non disponibile
            foreach (Portata p in elencoPortate)
            {
                if (p.GetCodice().Equals(codice))
                {
                    p.SetDisponibilita(false);
                    return true;
                }
            }
            return false;
        }


//******************Metodi UC11******************
        public bool AggiungiServizio(string nome, double prezzo)
        {
            foreach (Servizio s in listaServizi)
            {
                if (s.GetDescrizione().Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            Servizio nuovoServizio = new Servizio(listaServizi.Count+1, nome, prezzo);
            listaServizi.Add(nuovoServizio);
            return true;
        }

        public bool RimuoviServizio(int codice)
        {
            foreach (Servizio s in listaServizi)
            {
                if (s.GetCodice().Equals(codice))
                {
                    //rimuovo il servizio
                    listaServizi.Remove(s);
                    return true;
                }
            }

            return false;
        }
       
    }
}

