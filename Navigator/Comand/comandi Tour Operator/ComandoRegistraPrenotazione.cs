using Dominio;

namespace Comand
{
    public class ComandoRegistraPrenotazione : IComando
    {
        public static readonly string codiceComando = "3";
        public static readonly string descrizioneComando = "registra prenotazione";

        public string GetCodiceComando()
        {
            return codiceComando;
        }

        public string GetDescrizioneComando()
        {
            return descrizioneComando;
        }

        public void Esegui(NaviGator istanza)
        {
            
            if(istanza.RegistraPrenotazione())
            {
                Console.WriteLine($"\nIl cliente: {istanza.GetPrenotazioneInCorso().GetCliente().GetNome()} {istanza.GetPrenotazioneInCorso().GetCliente().GetCognome()}\nha effettuato la prenotazione dal {istanza.GetPrenotazioneInCorso().GetDataInizio()} al {istanza.GetPrenotazioneInCorso().GetDataFine()}" 
                + $"\nDetagli Cabina:\n {istanza.GetPrenotazioneInCorso().GetCabina().ToString()}");
                
                //annullo prenotazione in corso
                istanza.AnnullaPrenotazioneInCorso() ;
                
            }
            else
                Console.WriteLine("\nAttenzione, cabina o cliente non registrati!");
        }
    }

}