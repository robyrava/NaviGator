namespace Dominio
{
    public class PeriodoVariazione
    {
        private DateTime dataInizio;
        private DateTime dataFine;
        private int variazione;

        public PeriodoVariazione(DateTime dataInizio, DateTime dataFine, int variazione)
        {
            this.dataInizio = dataInizio;
            this.dataFine = dataFine;
            this.variazione = variazione;
        }

        //METODI GET E SET
        public DateTime GetDataInizio()
        {
            return dataInizio;
        }  
        public void SetDataInizio(DateTime dataInizio)
        {
            this.dataInizio = dataInizio;
        }

        public DateTime GetDataFine()
        {
            return dataFine;
        }
        public void SetDataFine(DateTime dataFine)
        {
            this.dataFine = dataFine;
        }

        public int GetVariazione()
        {
            return variazione; 
        }

        public void SetVariazione(int variazione)
        {
            this.variazione = variazione;
        }

        public bool IsDisponibile(DateTime dataInizio, DateTime dataFine)
        {
            //devo verificare che dataInizio e dataFine siano comprese tra this.dataInizio e this.dataFine facendo attenzione ai casi in cui le varizioni vanno da un anno all'altro
            if (dataInizio.Year == dataFine.Year)
            {
                if (dataInizio >= this.dataInizio && dataFine <= this.dataFine)
                    return false;
            }
            else
            {
                if (dataInizio.Year == this.dataInizio.Year)
                {
                    if (dataInizio >= this.dataInizio && dataInizio <= this.dataFine)
                        return false;
                }
                else if (dataFine.Year == this.dataFine.Year)
                {
                    if (dataFine >= this.dataInizio && dataFine <= this.dataFine)
                        return false;
                }
            }


            return true;
        }
    }
}