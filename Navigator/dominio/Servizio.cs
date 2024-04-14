namespace Dominio
{
    public class Servizio
    {
        private string codice;
        private string descrizione;
        private double prezzo;

        public Servizio(string codice, string descrizione, double prezzo)
        {
            this.codice = codice;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
        }

        public string GetCodice()
        {
            return codice;
        }

        public string GetDescrizione()
        {
            return descrizione;
        }

        public double GetPrezzo()
        {
            return prezzo;
        }

        public override string ToString()
        {
            return $"{codice} - {descrizione} - {prezzo}$";
        }
    }
}