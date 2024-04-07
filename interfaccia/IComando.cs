using Dominio;

namespace Interfaccia
{
    public interface IComando
    {
        string GetCodiceComando();

        string GetDescrizioneComando();

        void Esegui(NaviGator istanza);
    }
    
}