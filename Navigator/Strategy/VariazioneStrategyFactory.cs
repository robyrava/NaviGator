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
            
            return singleton;
        }

        public IVariazioneStrategy GetVariazioneStrategy()
        {
            return new VariazioneStandardStrategy();
        }
    }
}