namespace Dominio
{
    public class Ordine
    {
        private List<Portata> elencoPortate;
        private double subTotale;

        public Ordine()
        {
            elencoPortate = new List<Portata>();
        }

        public List<Portata> GetElencoPortate() 
        {
            return elencoPortate;
        }
        public void AggiungiPortata(Portata p)
        {
            elencoPortate.Add(p);
        }

        public double GetSubTotale() {
            return subTotale;
        }
        public void SetSubTotale(double prezzo) {
            subTotale += prezzo;
        }
        
    }
}