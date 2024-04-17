using Dominio;
using Validazioni;

namespace Comand
{
    public class ComandoAbilitaCabina : IComando
    {
        public static readonly string codiceComando = "1";
        public static readonly string descrizioneComando = "Abilita Cabina";

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
            List<int> codiciValidi = new List<int>();
        
            //Mostro le cabine disabilitate
            Console.WriteLine("\nCabine sottopposte a manutenzione: ");
            foreach (Cabina c in istanza.MostraCabineInManutenzione())
            {
                Console.WriteLine(c.ToString());
                codiciValidi.Add(c.GetCodice());
            }

            //Richiedo di inserire il codice della cabina da abilitare
            Console.WriteLine("\n   Inserisci il codice della cabina da abilitare: ");
            string codice = Parser.GetInstance().Read();
            while(!Validatore.VerificaCodice(codice))
            {
                Console.WriteLine("Codice non valido!\nInserisci il codice della cabina da abilitare: ");
                codice = Parser.GetInstance().Read();
            }

            //Aabilito la cabina
            if(istanza.ModificaCabina(int.Parse(codice), true, codiciValidi))
            {
                Console.WriteLine("\nCabina abilitata con successo!");
            }
            else
            {
                Console.WriteLine("\nErrore: cabina non presentemtra le cabine in manutenzione!");
            }
        }
    }
}