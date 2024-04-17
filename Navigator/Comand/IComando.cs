using Dominio;

namespace Comand
{
    public interface IComando
    {
        string GetCodiceComando();

        string GetDescrizioneComando();

        void Esegui(NaviGator istanza);
    }
    
}