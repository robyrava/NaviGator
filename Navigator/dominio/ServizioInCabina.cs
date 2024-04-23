namespace Dominio
{
    public class ServizioInCabina
    {
        private DateTime data;
        private Cabina cabina;
        private Ordine ordineInCorso;
        

        public ServizioInCabina(DateTime data, Cabina cabina)
        {
            this.data = data;
            this.cabina = cabina;
            ordineInCorso = new Ordine();
            ordineInCorso.SetSubTotale(0);          
        }
        
        public DateTime GetData()
        {
            return data;
        }

        public Cabina GetCabina()
        {
            return cabina;
        }

        public Ordine GetOrdineInCorso()
        {
            return ordineInCorso;
        }

    }
}