namespace Dominio
{
    public class NaviGator
    {
        private static NaviGator? istanza;
    
        public List<Cliente> ListaClienti {get; private set;}
    
        public List<Cabina> ListaCabine {get; private set;}
    
        public List<Prenotazione> ListaPrenotazioni {get; private set;}
    
        public Prenotazione PrenotazioneInCorso {get; private set;} 
    
        private int counter;
    
        private NaviGator()
        {
            ListaClienti = new List<Cliente>();
            ListaCabine = new List<Cabina>();
            ListaPrenotazioni = new List<Prenotazione>();
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
    
        public void CaricaCabine()
        {
            Cabina c1 = new Cabina("1", "interna", 1.1f);
            ListaCabine.Add(c1);
            Cabina c2 = new Cabina("2", "oblo", 1.2f);
            ListaCabine.Add(c2);
            Cabina c3 = new Cabina("3", "suite", 2.1f);
            ListaCabine.Add(c3);
        }
    
        public List<Cabina> VisualizzaCabine(string tipologia, DateTime dataInizio, DateTime dataFine)
        {
            /** LA CORRETEZZA DELLE DATE VA GESTITA NELLA GUI 

            if (dataInizio.Equals(dataFine) || dataInizio > dataFine)
            {
                return new List<Cabina>();
            }
            */

            List<Cabina> cabineDisponibili = new List<Cabina>();

            foreach (Cabina c in ListaCabine)
            {
                if (tipologia.Equals(c.Tipo) && IsCabinaDisponibile(c, dataInizio, dataFine))
                {
                    cabineDisponibili.Add(c);
                }
            }

            return cabineDisponibili;
        }

        private bool IsCabinaDisponibile(Cabina cabina, DateTime dataInizio, DateTime dataFine)
        {
            foreach (Prenotazione p in ListaPrenotazioni)
            {
                if (!p.IsDisponibile(cabina.Codice, dataInizio, dataFine))
                {
                    return false;
                }
            }

            return true;
        }

        public bool VerificaCabinaPrenotata(string codiceCabina, DateTime dataInizio, DateTime dataFine)
        {
            bool disponibile = true;
            
            if(ListaPrenotazioni.Count == 0)
                return disponibile;
            
            foreach (Prenotazione p in ListaPrenotazioni)
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
            PrenotazioneInCorso = new Prenotazione(counter.ToString());
            
            foreach (Cabina c in ListaCabine)
            {
                if (codice.Equals(c.Codice))
                {
                    PrenotazioneInCorso.Cabina = c;
                }
            }
            counter++;
        }

        public void RegistraCliente(string nome, string cognome, string codiceFiscale, string documento, string numeroTelefono, string numeroCarta)
        {
            
            if (PrenotazioneInCorso == null)
            {
                throw new InvalidOperationException("Non c'è nessuna prenotazione in corso.");
            }

            Cliente? c = ListaClienti.FirstOrDefault(cliente => cliente.CodiceFiscale == codiceFiscale); // se non trova nessun cliente con quel codice fiscale, c sarà null

            if (c == null)
            {
                c = new Cliente(nome, cognome, numeroTelefono, codiceFiscale, documento, numeroCarta);
                ListaClienti.Add(c);
            }

            PrenotazioneInCorso.Cliente = c;
        }

        public void RegistraPrenotazione(DateTime dataInizio, DateTime dataFine)
        {
            if (PrenotazioneInCorso == null || PrenotazioneInCorso.Cliente == null)
            {
                throw new InvalidOperationException("Non c'è nessuna prenotazione in corso.");
            }
            
            PrenotazioneInCorso.DataInizio = dataInizio;
            PrenotazioneInCorso.DataFine = dataFine;
            ListaPrenotazioni.Add(PrenotazioneInCorso);
            counter++;
        }

       
    }
}

