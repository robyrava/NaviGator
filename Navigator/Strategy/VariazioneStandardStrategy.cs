using System.Data;
using Dominio;

namespace Stategy
{
    public class VariazioneStandardStrategy : IVariazioneStrategy
    {
        public float ApplicaVariazione(List<PeriodoVariazione> pv, string dataInizio, string dataFine)
        {
            float variazione = 0.0f;
            foreach (PeriodoVariazione p in pv)
            {
                int giorniVariazione = p.CalcolaGiorniVariazione(DateTime.Parse(dataInizio), DateTime.Parse(dataFine));
                if(giorniVariazione != 0)
                    variazione += giorniVariazione * p.GetVariazione();
            }

            return variazione;
        }
    }
}