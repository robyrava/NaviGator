using Dominio;

namespace GestioneStato
{
    public class StatoConcluso : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
           //non fa nulla
        }

        public bool EqualsStato(string stato)
        {
            return stato.Equals("Concluso", StringComparison.OrdinalIgnoreCase);
        }
    }
}