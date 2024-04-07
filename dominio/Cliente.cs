namespace Dominio
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string NumeroTelefono { get; private set; }
        public string CodiceFiscale { get; private set; }        
        public string Documento { get; private set; }
        public string NumeroCarta { get; private set; }

        public Cliente(string nome, string cognome, string numeroTelefono, string codiceFiscale, string documento, string numeroCarta)
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
            NumeroTelefono = numeroTelefono;
            Documento = documento;
            NumeroCarta = numeroCarta;
        }

        public override string ToString()
        {
            return $"nome: {Nome}\ncognome: {Cognome}\ndocumento: {Documento}\ncodice fiscale: {CodiceFiscale}\nnumero di telefono: {NumeroTelefono}\nnumero carta di credito: {NumeroCarta}\n";
        }
    }
}