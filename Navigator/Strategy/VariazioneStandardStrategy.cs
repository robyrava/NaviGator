using System.Data;
using Dominio;

namespace Stategy
{
    public class VariazioneStandardStrategy : IVariazioneStrategy
    {
        public double ApplicaVariazione(List<PeriodoVariazione> pv, DateTime dataInizio, DateTime dataFine, double prezzoBase)
        {
            foreach (PeriodoVariazione p in pv)
            {
                if (!p.IsDisponibile(dataInizio, dataFine))
                {
                        prezzoBase += prezzoBase * p.GetVariazione()/100;          
                        break;
                }
            }

            return prezzoBase;
        }
    }
}