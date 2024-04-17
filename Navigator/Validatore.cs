namespace Validazioni
{
    public static class Validatore
    {
        public static bool VerificaFormatoData(string data)
        {
            // Verifica che la data sia nel formato AAAA-MM-GG 
            if (!System.Text.RegularExpressions.Regex.IsMatch(data, @"^\d{4}-\d{2}-\d{2}$"))
                return false;

            //sia una data valida: es: 2024-02-30 non è una data valida
            if (!DateTime.TryParse(data, out DateTime _))
                return false;

            return true;
        }

        public static bool VerificaDataInizio(string data)
        {
            if(!VerificaFormatoData(data))
                return false;
            
            //Verifica che il giorno sia un lunedi
            if (DateTime.Parse(data).DayOfWeek != DayOfWeek.Monday)
                return false;

            return true;

        }

        public static bool VerificaDataFine(string data, string dataInizio)
        {
            if(!VerificaFormatoData(data))
                return false;
            
            //Verifica che il giorno fine sia un sabato
            if (DateTime.Parse(data).DayOfWeek != DayOfWeek.Saturday)
                return false;

            //verifico che sia maggiore di dataInizio
            if (DateTime.Parse(data) <= DateTime.Parse(dataInizio))
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

        public static bool VerificaPrezzo(string prezzo, bool negativo = false)
        {
            if (negativo)
            {
                // Verifica che il prezzo sia un numero intero positivo o negativo
                if (!System.Text.RegularExpressions.Regex.IsMatch(prezzo, @"^-?\d+$"))
                    return false;
                else 
                    return true;    
            }

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