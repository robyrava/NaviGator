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

        public static bool VerificaQuantita(string quantita)
        {
            // Verifica che la quantita sia un numero intero positivo, maggiore di 0 e minore di 5
            if (!System.Text.RegularExpressions.Regex.IsMatch(quantita, @"^[1-4]$"))
                return false;
            
            return true;
        }

        public static bool VerificaTelefono(string telefono)
        {
            // Verifica che il numero di telefono sia composto da 10 cifre
            if (!System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{10}$"))
                return false;

            return true;
        }
        public static bool VerificaCarta(string carta)
        {
            // Verifica che il numero della carta sia composto da 16 cifre
            if (!System.Text.RegularExpressions.Regex.IsMatch(carta, @"^\d{16}$"))
                return false;

            return true;
        }

        public static bool VerificaDocumento(string documento)
        {
            // Verifica che il documento sia composto da 9 cifre: primi due caratteri lettere, seguenti 5 caratteri numeri, ultimi due caratteri lettere
            if (!System.Text.RegularExpressions.Regex.IsMatch(documento, @"^[a-zA-Z]{2}\d{5}[a-zA-Z]{2}$"))
                return false;
            return true;
        }

    }
}