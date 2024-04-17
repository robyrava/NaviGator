namespace Stategy
{
    public class VariazioneStrategyFactory
    {
        private static VariazioneStrategyFactory singleton;

        private VariazioneStrategyFactory(){}

        public static VariazioneStrategyFactory GetInstance()
        {
            if(singleton == null)
                singleton = new VariazioneStrategyFactory();
            else
                Console.WriteLine("Istanza già creata");
            return singleton;
        }

        public IVariazioneStrategy GetVariazioneStrategy()
        {
            return new VariazioneStandardStrategy();
        }
    }
}