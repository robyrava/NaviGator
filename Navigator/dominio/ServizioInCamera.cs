namespace Dominio
{
    public class ServizioInCamera
    {
        private string? codice;
        private DateTime data;
        private Cabina cabina;
        private Ordine ordineInCorso;

        public ServizioInCamera(DateTime data, Cabina cabina)
        {
            this.data = data;
            this.cabina = cabina;
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
        }

        public Ordine GetOrdineInCorso()
        {
            return ordineInCorso;
        }
    }
}