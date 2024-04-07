namespace Dominio
{
    public class Cabina
    {
        public string Codice { get; private set; }
        public string Tipo { get; private set; }
        public double Prezzo { get; private set; }

        public Cabina(string codice, string tipo, double prezzo)
        {
            Codice = codice;
            Tipo = tipo;
            Prezzo = prezzo;
        }

        public override string ToString()
        {
            return $"codice: {Codice}\ntipo: {Tipo}\nprezzo: {Prezzo}\n";
        }
    }
}