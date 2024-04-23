namespace Dominio
{
    public class Portata
    {
        private string nome;
        private bool disponibilita;
        private double prezzo;
        private int codice;
        private int quantita;

        public Portata(string nome, bool disponibilita, double prezzo, int codice)
        {
            this.nome = nome;
            this.disponibilita = disponibilita;
            this.prezzo = prezzo;
            this.codice = codice;
        }

        public string GetNome()
        {
            return nome;
        }

         public bool GetDisponibilita()
        {
            return disponibilita;
        }
        public void SetDisponibilita(bool value)
        {
            disponibilita = value;
        }

        public double GetPrezzo()
        {
            return prezzo;
        }
        public void SetPrezzo(double value)
        {
            prezzo = value;
        }

        public int GetCodice()
        {
            return codice;
        }
        public void SetCodice(int value)
        {
            codice = value;
        }

        public int GetQuantita()
        {
            return quantita;
        }

        public void SetQuantita(int value)
        {
            quantita = value;
        }

        public override string ToString()
        {
            return $"Codice: {codice}\tNome: {nome}\t Prezzo: {prezzo}$";
        }
    }
}
