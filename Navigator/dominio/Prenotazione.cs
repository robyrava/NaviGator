using State;

namespace Dominio
{
    public class Prenotazione
    {
        private string? codice;
        private DateTime dataInizio;
        private DateTime dataFine;
        private Cabina? cabina;
        private Cliente? cliente;
        private IStato statoPrenotazione;
        private List<RichiestaServizio> serviziRichiesti;

        public Prenotazione(string codice)
        {
            this.codice = codice;
            statoPrenotazione= new StatoInCorso();
            serviziRichiesti = new List<RichiestaServizio>();
        }
        
        public bool IsDisponibile(int codiceCabina, DateTime dataInizio, DateTime dataFine)
        {
            if (dataInizio > dataFine || dataInizio == dataFine)
            {
                return false;
            }
            if (cabina != null && cabina.GetCodice().Equals(codiceCabina))
            {
                if ((dataInizio > this.dataInizio && dataInizio < this.dataFine) ||
                    (dataFine > this.dataInizio && dataFine < this.dataFine) ||
                    (dataInizio < this.dataInizio && dataFine > this.dataFine) ||
                    (dataInizio == this.dataInizio) ||
                    (dataFine == this.dataFine) ||
                    (dataInizio == this.dataFine) ||
                    (dataFine == this.dataInizio))
                {
                    return false;
                }
            }
            return true;
        }

        //MEtodi GET
        public string? GetCodice()
        {
            return codice;
        }
        public DateTime GetDataInizio()
        {
            return dataInizio;
        }
        public DateTime GetDataFine()
        {
            return dataFine;
        }
        public Cabina? GetCabina()
        {
            return cabina;
        }
        public Cliente? GetCliente()
        {
            return cliente;
        }
        

        //METODI SET
        public void SetDataInizio(DateTime dataInizio)
        {
            this.dataInizio = dataInizio;
        }
        public void SetDataFine(DateTime dataFine)
        {
            this.dataFine = dataFine;
        }
        public void SetCabina(Cabina cabina)
        {
            this.cabina = cabina;
        }
        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

        public void SetStatoPrenotazione(IStato statoPrenotazione)
        {
            this.statoPrenotazione = statoPrenotazione;
        }
        
        public IStato GetStatoPrenotazione()
        {
            return statoPrenotazione;
        }
        
        public List<RichiestaServizio> GetServiziRichiesti()
        {
            return serviziRichiesti;
        }
        public void SetServizio(RichiestaServizio s)
        {
            serviziRichiesti.Add(s);
        }
        
        
        public override string ToString()
        {
            return $"codice: {GetCodice()}\ndata inizio: {GetDataInizio()}\ndata fine: {GetDataFine()}\n";
        }
    }
}