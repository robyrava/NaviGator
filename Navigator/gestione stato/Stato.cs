using Dominio;

namespace GestioneStato
{
    public interface IStato
    {
        public void GestioneStatoPrenotazione(Prenotazione prenotazione, string operazione);
        public bool EqualsStato(string stato);
    }

}