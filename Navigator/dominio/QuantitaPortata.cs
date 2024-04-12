namespace Dominio
{
    public class QuantitaPortata : Portata
    {
        private int quantita;

        public QuantitaPortata(Portata p, int quantita) : base(p.GetNome(), p.GetDisponibilita(), p.GetPrezzo(), p.GetCodice())
        {
            this.quantita = quantita;            
        }

        public int GetQuantita()
        {
            return quantita;
        }

        public void SetQuantita(int value)
        {
            quantita = value;
        }

        
    }
}