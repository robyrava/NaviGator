using Dominio;

namespace GestioneStato
{
    public class StatoCheckOut : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if (stato.Equals("Concluso",StringComparison.OrdinalIgnoreCase))
                prenotazione.SetStatoPrenotazione(new StatoConcluso());
        }

        public bool EqualsStato(string stato)
        {
            return stato.Equals("Check-out", StringComparison.OrdinalIgnoreCase);
        }
    }
}