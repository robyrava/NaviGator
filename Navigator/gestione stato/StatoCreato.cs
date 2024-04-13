using Dominio;

namespace GestioneStato
{
    public class StatoCreato : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if (stato.Equals("Check-in", StringComparison.OrdinalIgnoreCase))
                prenotazione.SetStatoPrenotazione(new StatoCheckIn());
        }

        public bool EqualsStato(string stato)
        {
            return stato.Equals("Creato", StringComparison.OrdinalIgnoreCase);
        }
    }
}