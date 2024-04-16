namespace Validazioni
{
    public static class Validatore
    {
        // Verifica che la data sia nel formato AAAA-MM-GG e sia una data valida
        public static bool VerificaFormatoData(string data)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(data, @"^\d{4}-\d{2}-\d{2}$"))
                return false;

            if (!DateTime.TryParse(data, out DateTime _))
                return false;
                
            return true;
        }

        //Metdo che verifica la validità del formato di dataF e verifica che tra dataI e dataF ci sia una differenza di 7 giorni
        public static bool ConfrontaData(string dataI,string dataF)
        {
            if (!VerificaFormatoData(dataF))
             return false;

            DateTime dataInizio = DateTime.Parse(dataI);
            DateTime dataFine = DateTime.Parse(dataF);

            if (dataFine.Subtract(dataInizio).Days != 6)
                return false;

            return true;

        }

        public static bool VerificaNome(string nome)
        {
            // Verifica che il nome contenga solo lettere e spazi
            if (!System.Text.RegularExpressions.Regex.IsMatch(nome, @"^[a-zA-Z\s]+$"))
                return false;

            return true;
        }

        public static bool VerificaPrezzo(string prezzo)
        {
            // Verifica che il prezzo sia un numero decimale positivo
            if (!System.Text.RegularExpressions.Regex.IsMatch(prezzo, @"^\d+(\.\d+)?$"))
                return false;

            return true;
        }

        public static bool VerificaCodice(string codice)
        {
            // Verifica che il codice sia composto da 1 o 2 cifre
            if (!System.Text.RegularExpressions.Regex.IsMatch(codice, @"^\d{1,2}$"))
                return false;

            return true;
        }

    }
}