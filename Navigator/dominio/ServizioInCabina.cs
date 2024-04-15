namespace Dominio
{
    public class ServizioInCabina
    {
        private string? codice;
        private DateTime data;
        private Cabina cabina;
        private Ordine ordineInCorso;
        private double subTot;

        public ServizioInCabina(DateTime data, Cabina cabina)
        {
            this.data = data;
            this.cabina = cabina;
            subTot = 0;
            ordineInCorso = new Ordine();
        }
        
        public DateTime GetData()
        {
            return data;
        }

        public Cabina GetCabina()
        {
            return cabina;
        }

        public void RegistraPortata(Portata p, int quantita)
        {
            ordineInCorso.SetQuantitaPortata(p, quantita);
            subTot += p.GetPrezzo() * quantita;
        }

        public Ordine GetOrdineInCorso()
        {
            return ordineInCorso;
        }

        public double GetSubTot()
        {
            return subTot;
        }
    }
}