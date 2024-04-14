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

    }
}