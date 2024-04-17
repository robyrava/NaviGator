using Dominio;
namespace State
{
    public class StatoInCorso : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if(stato.Equals("Creato", StringComparison.OrdinalIgnoreCase))
                prenotazione.SetStatoPrenotazione(new StatoCreato());
        }
    
        public bool EqualsStato(string stato)
        {
            return stato.Equals("In_corso", StringComparison.OrdinalIgnoreCase);
        }
    }
}