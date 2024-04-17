using Dominio;

namespace Stategy
{
    public interface IVariazioneStrategy
    {
        public double ApplicaVariazione(List<PeriodoVariazione> periodoVariazione, DateTime dataInizio, DateTime dataFine, double prezzoBase);
    }
}