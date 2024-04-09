namespace Dominio
{
    public class Cabina
    {
        private string codice;
        private string tipo;
        private double prezzo;

        public Cabina(string codice, string tipo, double prezzo)
        {
            this.codice = codice;
            this.tipo = tipo;
            this.prezzo = prezzo;
        }

        //Metodi GET
        public string GetCodice()
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

        public override string ToString()
        {
            return $"codice: {codice}\ntipo: {tipo}\nprezzo: {prezzo}\n";
        }
    }
}