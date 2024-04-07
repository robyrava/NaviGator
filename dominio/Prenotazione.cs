namespace Dominio
{
    public class Prenotazione
    {
        public string? Codice { get; private set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public Cabina? Cabina { get; set; }
        public Cliente? Cliente { get; set; }

        public Prenotazione(string codice)
        {
            Codice = codice;
        }

/**
        public Prenotazione(string codice, DateTime dataInizio, DateTime dataFine, Cabina cabina, Cliente cliente)
        {
            Codice = codice;
            DataInizio = dataInizio;
            DataFine = dataFine;
            Cabina = cabina;
            Cliente = cliente;
        }
*/
        public bool IsDisponibile(string codiceCabina, DateTime dataInizio, DateTime dataFine)
        {
            if (dataInizio > dataFine || dataInizio == dataFine)
            {
                return false;
            }
            if (Cabina != null && Cabina.Codice.Equals(codiceCabina))
            {
                if ((dataInizio > this.DataInizio && dataInizio < this.DataFine) ||
                    (dataFine > this.DataInizio && dataFine < this.DataFine) ||
                    (dataInizio < this.DataInizio && dataFine > this.DataFine) ||
                    (dataInizio == this.DataInizio) ||
                    (dataFine == this.DataFine) ||
                    (dataInizio == this.DataFine) ||
                    (dataFine == this.DataInizio))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return $"codice: {Codice}\ndata inizio: {DataInizio}\ndata fine: {DataFine}\n";
        }
    }
}