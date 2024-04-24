using Stategy;

namespace Dominio
{
    public class NaviGator
    {
        private static NaviGator? istanza;
    
        private List<Cabina> elencoCabine;
    
        private List<Prenotazione> elencoPrenotazioni;
        private List<Portata> elencoPortate;
    
        private Prenotazione? prenotazioneInCorso; 
        private ServizioInCabina? servizioCabinaInCorso;
        private List<ServizioInCabina> elencoServiziCabina;
        private List<Servizio> listaServizi;
        private List<PeriodoVariazione> listaPeriodiVariazione;
    
        private int counter;
    
        private NaviGator()
        {
            elencoCabine = new List<Cabina>();
            elencoPrenotazioni = new List<Prenotazione>();
            elencoPortate = new List<Portata>();
            elencoServiziCabina = new List<ServizioInCabina>();
            listaServizi = new List<Servizio>();
            listaPeriodiVariazione = new List<PeriodoVariazione>();
            prenotazioneInCorso = null;
            counter = 1;
            CaricaCabine();
            CaricaPortate();
            CaricaServizi();
            CaricaPeriodoVariazione();

            //CaricaPrenotazioni();
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
            Cabina c1 = new Cabina(elencoCabine.Count+1, "interna", 600);
            elencoCabine.Add(c1);
            Cabina c2 = new Cabina(elencoCabine.Count+1, "oblo", 700);
            elencoCabine.Add(c2);
            Cabina c3 = new Cabina(elencoCabine.Count+1, "suite", 1000);
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
            Servizio s2 = new Servizio(listaServizi.Count+1, "esplorazione in moto d'acqua", 150); 
            listaServizi.Add(s2);
            Servizio s3 = new Servizio(listaServizi.Count+1, "Snorkeling", 70);
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
            p1.SetDataFine(new DateTime(2024,1, 6));
            p1.SetCabina(elencoCabine[1]); //oblo
            p1.GetStatoPrenotazione().GestioneStatoPrenotazione(p1,"Creato");
            elencoPrenotazioni.Add(p1);

            Cliente c2 = new Cliente("Luca", "Verdi", "3333333333", "w", "w", "1234");
            Prenotazione p2 = new Prenotazione("2");
            p2.SetCliente(c2);
            p2.SetDataInizio(new DateTime(2024,1, 1));
            p2.SetDataFine(new DateTime(2024,1, 6));
            p2.SetCabina(elencoCabine[0]); //interna
            p2.GetStatoPrenotazione().GestioneStatoPrenotazione(p2,"Creato");
            elencoPrenotazioni.Add(p2);
        }

        public List<Prenotazione> VisualizzaPrenotazioni()
        {
            return elencoPrenotazioni;
        }

//****************UC1: Inserisci prenotazione cabina***********************

        public List<Cabina> GetCabineDisponibili(string tipologia, DateTime dataInizio, DateTime dataFine, bool variazionePrezzo = false)
        {
            
            List<Cabina> cabineDisponibili = new List<Cabina>();
            Cabina tmpCabina;

            foreach (Cabina c in elencoCabine)
            {
                if(variazionePrezzo)
                {
                    if (tipologia.Equals(c.GetTipo()) && IsCabinaDisponibile(c, dataInizio, dataFine) && c.GetDisponibilita())
                    {
                        tmpCabina = new Cabina(c.GetCodice(), c.GetTipo(), c.GetPrezzo());
                        tmpCabina.SetPrezzo(GetVariazionePrezzoCabina(c.GetPrezzo(), dataInizio, dataFine));
                        
                        cabineDisponibili.Add(tmpCabina);
                    }
                }
                else
                    if (tipologia.Equals(c.GetTipo()) && IsCabinaDisponibile(c, dataInizio, dataFine))
                        cabineDisponibili.Add(c);     
            }

            return cabineDisponibili;
        }

        private double GetVariazionePrezzoCabina(double prezzo, DateTime dataInizio, DateTime dataFine)
        {
            VariazioneStrategyFactory fs = VariazioneStrategyFactory.GetInstance();
            IVariazioneStrategy vs = fs.GetVariazioneStrategy();

            return vs.ApplicaVariazione(listaPeriodiVariazione, dataInizio, dataFine,  prezzo); 
        }

        private bool IsCabinaDisponibile(Cabina cabina, DateTime dataInizio, DateTime dataFine)
        {
            if(!cabina.GetDisponibilita())
                return false;

            foreach (Prenotazione p in elencoPrenotazioni)
            {
                if (!p.IsDisponibile(cabina.GetCodice(), dataInizio, dataFine))
                {
                    return false;
                }
            }

            return true;
        }

        public bool VerificaCabinaPrenotata(int codiceCabina, DateTime dataInizio, DateTime dataFine)
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

        public bool RegistraCabina(int codice, string tipologia, DateTime dataInizio, DateTime dataFine)
        {
            //Verifico che il codice appartiene ad una cabina esistente
            foreach (Cabina c in GetCabineDisponibili(tipologia, dataInizio, dataFine,true))
            {
                if (codice.Equals(c.GetCodice()))
                {
                    //Creo nuova Prenotazione
                    prenotazioneInCorso = new Prenotazione(counter.ToString());
                    
                    prenotazioneInCorso.SetCabina(c);
                    prenotazioneInCorso.SetDataInizio(dataInizio);
                    prenotazioneInCorso.SetDataFine(dataFine);
                    counter++;
                    return true;
                }
            }
            
            return false;
            
        }

        public bool RegistraCliente(string nome, string cognome, string codiceFiscale, string documento, string numeroTelefono, string numeroCarta)
        {
            
            //verifico che la cabina sia stata registrata
            if (prenotazioneInCorso == null)
                return false;

            Cliente c = new Cliente(nome, cognome, numeroTelefono, codiceFiscale, documento, numeroCarta);
            
            //aggiorno la prenotazione in corso
            prenotazioneInCorso.SetCliente(c);

            return true;
          

            
        }

        public bool RegistraPrenotazione()
        {

            //verifico che la cabina sia stata registrata
            if(prenotazioneInCorso == null)
                return false;

            //verifico siano stati registrati i dati del cliente
            if(prenotazioneInCorso.GetCliente() == null)
                return false;

            //Cambio stato prenotazione
            prenotazioneInCorso.GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazioneInCorso,"Creato");
            
            //aggiungo prenotazione all'elenco
            elencoPrenotazioni.Add(prenotazioneInCorso);

            counter++;

            return true;
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


//******************Metodi UC5: CREA NUOVO ORDINE SERVIZIO IN CABINA******************

        public List<Cabina> GetCabine()
        {
            return elencoCabine;
        }

        public bool CreaServizioCabina(int codice, DateTime data)
        {
            foreach (Prenotazione p in elencoPrenotazioni)
            {
                if (codice.Equals(p.GetCabina().GetCodice()) && p.GetStatoPrenotazione().EqualsStato("Check-in"))
                {
                    servizioCabinaInCorso = new ServizioInCabina(data, p.GetCabina());
                    return true;
                }
            }

            return false;   
        }

        public ServizioInCabina? GetServizioCabinaInCorso() {
            return servizioCabinaInCorso;
        }

        public List<Portata> MostraPortateDisponibili()
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
        public List<Portata> GetElencoPortate()
        {
            return elencoPortate;
        }

        public List<ServizioInCabina> GetServiziCabina()
        {
            return elencoServiziCabina;
        }

        public bool RegistraPortata(Portata p, int quantita)
        {
            p.SetQuantita(quantita);
            
            if(servizioCabinaInCorso != null)
            {
                servizioCabinaInCorso.GetOrdineInCorso().AggiungiPortata(p);
                servizioCabinaInCorso.GetOrdineInCorso().SetSubTotale(p.GetPrezzo() * quantita);
                return true;
            }

            return false;   
        }

        public string RegistraServizioCabina()
        {
            if (servizioCabinaInCorso == null)
                return "\nATTENZIONE! Nessuna cabina selezionata. Selezionare una cabina prima di ordinare.";
            if(servizioCabinaInCorso.GetOrdineInCorso().GetElencoPortate().Count == 0)
                return "\nATTENZIONE! Nessuna portata selezionata. Selezionare almeno una portata prima di registrare il servizio.";
            
            elencoServiziCabina.Add(servizioCabinaInCorso);

            //Resetto il servizio in corso
            ResetServizioCabinaInCorso();

            return "\nServizio registrato con successo!";
        }

        public void ResetServizioCabinaInCorso()
        {
            servizioCabinaInCorso = null;
        }

//******************Metodi UC7******************
    public bool VerificaCheckOut(string cf)
    {
        foreach (Prenotazione p in elencoPrenotazioni) {
            if( p.GetCliente().GetCodiceFiscale().Equals(cf) && p.GetStatoPrenotazione().EqualsStato("Check-out")) 
            {
                Console.WriteLine($"Cliente: {p.GetCliente().GetNome()} {p.GetCliente().GetCognome()}\n{p.ToString()}");

                //Setto prenotazione in corso
                prenotazioneInCorso = p;
                
                return true;
            }
        }

        return false;   
    }

    public bool MostraServiziAcquistati()
    {
        foreach (RichiestaServizio rs in prenotazioneInCorso.GetServiziRichiesti())
        {
            if (rs.GetServizi().Count > 0)
            {
                foreach (Servizio s in rs.GetServizi())
                {
                    Console.WriteLine(s.ToString());
                }

                return true;
            }
        }

        return false;
    }
    
    public bool MostraPortateAcquistate()
    {
        foreach (ServizioInCabina sc in elencoServiziCabina)
        {
            if (sc.GetCabina().GetCodice().Equals(prenotazioneInCorso.GetCabina().GetCodice()) && sc.GetOrdineInCorso().GetElencoPortate().Count > 0)
            {
                foreach (Portata po in sc.GetOrdineInCorso().GetElencoPortate())
                {
                    Console.WriteLine(po.ToString() + $"\tQuantità: {po.GetQuantita()}");
                }
                return true;
            }                        
        }

        return false;
    }
        
    
    public double CalcolaConto()
    {       
        double contoServizi = 0;
        double contoServizioCabina = 0;
        
    
        foreach (RichiestaServizio rs in prenotazioneInCorso.GetServiziRichiesti())
        {
            contoServizi = contoServizi + rs.GetSubTotale();
        }

        foreach (ServizioInCabina sc in elencoServiziCabina)
        {
            if (sc.GetCabina().GetCodice().Equals(prenotazioneInCorso.GetCabina().GetCodice()))
            {
                contoServizioCabina = contoServizioCabina + sc.GetOrdineInCorso().GetSubTotale();
            }
        }

        //Applico Sconto del 20% se la cabina è una suite
        if (prenotazioneInCorso.GetCabina().GetTipo().Equals("suite", StringComparison.OrdinalIgnoreCase))
        {
            contoServizioCabina = contoServizioCabina - (contoServizioCabina * 0.2);
        }

        return contoServizioCabina + contoServizi;
        
    }

    public void RimuoviPrenotazione()
    {
        //cambio stato prenotazione
        prenotazioneInCorso.GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazioneInCorso,"Conclusa");
        elencoPrenotazioni.Remove(prenotazioneInCorso);
    }

//******************Metodi UC8: GESTISCI CABINE******************
        public List<Cabina> MostraCabineNonPrenotate(DateTime dataInizio, DateTime dataFine)
        {
            List<Cabina> cabineDisponibili = new List<Cabina>();
            
            //Se non ci sono prenotazioni aggiungo tutte le cabine disponibili
            if(elencoPrenotazioni.Count == 0)
            {
                foreach (Cabina c in elencoCabine)
                {
                    if (c.GetDisponibilita())
                        cabineDisponibili.Add(c);
                }

                return cabineDisponibili;
            }

            //Se ci sono prenotazioni verifico che la cabina non sia prenotata
            foreach (Cabina c in elencoCabine)
            {
                if (c.GetDisponibilita() && VerificaCabinaPrenotata(c.GetCodice(), dataInizio, dataFine))
                    cabineDisponibili.Add(c);
            }

            return cabineDisponibili;            
        }

        public bool AbilitaDisabilitaCabina(int codice, bool disponibilita, List<int> codiciValidi)
        {
            foreach (Cabina c in elencoCabine)
            {
                if (c.GetCodice().Equals(codice) && codiciValidi.Contains(codice))
                {
                    c.SetDisponibilita(disponibilita);
                    return true;
                }
            }

            return false;
        }

        public List<Cabina> MostraCabineInManutenzione()
        {
            List<Cabina> cabineInManutenzione = new List<Cabina>();
            foreach (Cabina c in elencoCabine)
            {
                if (!c.GetDisponibilita())
                    cabineInManutenzione.Add(c);
            }
            return cabineInManutenzione;
        }

//******************Metodi UC9: GESTISCI PREZZO CABINE******************
       public void CaricaPeriodoVariazione()
       {
            listaPeriodiVariazione.Add(new PeriodoVariazione(new DateTime(2024, 6, 3), new DateTime(2024, 9, 7), 40));
            listaPeriodiVariazione.Add(new PeriodoVariazione(new DateTime(2024, 12, 2), new DateTime(2025, 3, 1), -20));
            
       } 
        public List<PeriodoVariazione> GetListaPeriodiVariazione()
        {
            return listaPeriodiVariazione;
        }

        public bool AggiungiPeriodoVariazione(DateTime dataI, DateTime dataF, int variazione)
        {
            bool trovato = false;
            
            if(GetListaPeriodiVariazione().Count == 0)
                trovato = false;
            else             
                foreach (PeriodoVariazione pv in GetListaPeriodiVariazione()) 
                {
                    if (!pv.IsDisponibile(dataI, dataF)) 
                    {
                        trovato = true;
                    }
                }
            
            if(!trovato)
            {
                listaPeriodiVariazione.Add(new PeriodoVariazione(dataI, dataF, variazione));
                return true;
            }

            return false;
        }


//******************Metodi UC10: GESTISCI PORTATA******************
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


//******************Metodi UC11: GESTISCI SERVIZI******************
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

//-----------------------------------

        public Cabina? GetCabina(int codice)
        {
            foreach (Cabina c in GetCabine())
            {
                if (c.GetCodice().Equals(codice))
                {
                    return c;
                }
            }
            return null;
        }
       
    }
}

