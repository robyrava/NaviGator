using Dominio;
namespace GestioneStato
{
    [Serializable]
    public class StatoInCorso : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if(stato.Equals("Creato", StringComparison.OrdinalIgnoreCase))
                prenotazione.SetStatoPrenotazione(new StatoCreato());
        }
    
        public bool EqualsStato(string stato)
        {
            return stato.Equals("In corso", StringComparison.OrdinalIgnoreCase);
        }
    }
}