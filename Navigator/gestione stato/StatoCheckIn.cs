using Dominio;

namespace GestioneStato
{
    public class StatoCheckIn : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if (stato.Equals("Check-out", StringComparison.OrdinalIgnoreCase))
                prenotazione.SetStatoPrenotazione(new StatoCheckOut());
        }

        public bool EqualsStato(string stato)
        {
            return stato.Equals("Check-in",StringComparison.OrdinalIgnoreCase);
        }
    }
}