namespace Dominio
{
    public class Cabina
    {
        private int codice;
        private string tipo;
        private double prezzo;
        private bool disponibile;

        public Cabina(int codice, string tipo, double prezzo)
        {
            this.codice = codice;
            this.tipo = tipo;
            this.prezzo = prezzo;
            disponibile = true;
        }

        //Metodi GET
        public int GetCodice()
        {
            return codice;
        }
        public string GetTipo()
        {
            return tipo;
        }
        public double GetPrezzo()
        {
            return prezzo;
        }

        public bool GetDisponibilita()
        {
            return disponibile;
        }

        public void SetDisponibilita(bool disponibile)
        {
            this.disponibile = disponibile;
        }


        public override string ToString()
        {
            return $"codice: {codice}\ttipo: {tipo}\tprezzo: {prezzo}";
        }
    }
}