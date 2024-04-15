namespace Dominio
{
    public class Servizio
    {
        private int codice;
        private string descrizione;
        private double prezzo;

        public Servizio(int codice, string descrizione, double prezzo)
        {
            this.codice = codice;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
        }

        public int GetCodice()
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