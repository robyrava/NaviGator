namespace Dominio
{
    public class Cliente
    {
        private string nome;
        private string cognome;
        private string codiceFiscale;
        private string documento;
        private string numeroTelefono;
        private string numeroCarta;

        public Cliente(string nome, string cognome, string numeroTelefono, string codiceFiscale, string documento, string numeroCarta)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceFiscale = codiceFiscale;
            this.documento = documento;
            this.numeroTelefono = numeroTelefono;
            this.numeroCarta = numeroCarta;
        }

        //METODI GET
        public string GetNome()
        {
            return nome;
        }

        public string GetCognome()
        {
            return cognome;
        }

        public string GetCodiceFiscale()
        {
            return codiceFiscale;
        }

        public string GetDocumento()
        {
            return documento;
        }

        public string GetNumeroTelefono()
        {
            return numeroTelefono;
        }

        public string GetNumeroCarta()
        {
            return numeroCarta;
        }



        public override string ToString()
        {
            return $"nome: {GetNome()}\ncognome: {GetCognome()}\ndocumento: {GetDocumento()}\ncodice fiscale: {GetCodiceFiscale()}\nnumero di telefono: {GetNumeroTelefono()}\nnumero carta di credito: {GetNumeroCarta()}\n";
        }
    }
}

