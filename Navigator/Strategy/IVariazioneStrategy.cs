using Dominio;

namespace Stategy
{
    public interface IVariazioneStrategy
    {
        public float ApplicaVariazione(List<PeriodoVariazione> periodoVariazione, string dataInizio, string dataFine);
    }
}