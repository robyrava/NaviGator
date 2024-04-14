namespace Dominio
{
    public class RichiestaServizio
    {
        private DateTime dataInizio;
        private double subTotale;
        private List<Servizio> elencoServizi;

        public RichiestaServizio(DateTime dataInizio)
        {
            this.dataInizio = dataInizio;
            elencoServizi = new List<Servizio>();
            subTotale = 0;
        }

        public DateTime GetDataInizio()
        {
            return this.dataInizio;
        }

        public void SetDataInizio(DateTime dataInizio)
        {
            this.dataInizio = dataInizio;
        }

        public double GetSubTotale()
        {
            return this.subTotale;
        }

        public void SetServizio(Servizio s)
        {
            elencoServizi.Add(s);
            subTotale += s.GetPrezzo();
        }

        public List<Servizio> GetServizi()
        {
            return elencoServizi;
        }
    }
        
}