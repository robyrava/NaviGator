using Dominio;

namespace GestioneStato
{
    public class StatoCheckIn : IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string stato)
        {
            if (stato.Equals("Check-in"))
                prenotazione.SetStatoPrenotazione(new StatoCheckIn());
        }

        public bool EqualsStato(string stato)
        {
            return stato.Equals("Check-in");
        }
    }
}