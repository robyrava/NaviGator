namespace Dominio
{
    public class Ordine
    {
        private List<QuantitaPortata> quantitaPortate;
        private double subTotale;

        public Ordine()
        {
            quantitaPortate = new List<QuantitaPortata>();
        }

        public List<QuantitaPortata> GetQuantitaPortate() 
        {
            return quantitaPortate;
        }
        public void SetQuantitaPortata(Portata p, int q)
        {
            QuantitaPortata qp = new QuantitaPortata(p, q);
            quantitaPortate.Add(qp);
        }

        public double GetSubTotale() {
            return subTotale;
        }
        
    }
}