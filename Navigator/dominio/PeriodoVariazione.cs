namespace Dominio
{
    public class PeriodoVariazione
    {
        private DateTime dataInizio;
        private DateTime dataFine;
        private float variazione;

        public PeriodoVariazione(DateTime dataInizio, DateTime dataFine, float variazione)
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

        public float GetVariazione()
        {
            return variazione;
        }

        public void SetVariazione(float variazione)
        {
            this.variazione = variazione;
        }

        public int CalcolaGiorniVariazione(DateTime dataInizio, DateTime dataFine)
        {
            return 1;
        }

        public bool IsDisponibile(DateTime dataInizio, DateTime dataFine)
        {
            //Se le date di inizio e fine coincidono con quelle del periodo di variazione ritorna falso
            if (dataInizio == this.dataInizio && dataFine == this.dataFine)
                return false;

            return true;
        }
    }
}