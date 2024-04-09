namespace NaviGator.Test
{
    using Dominio;
    public class NaviGatorTest
    {

        static NaviGator? naviGator;

        public NaviGatorTest()
        {
            naviGator = NaviGator.GetInstance();
        }

        [Fact]
        public void TestInserimentoStanzaPrenotazioneInCorso()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso);
        }

        [Fact]
        public void TestInserimentoPacchettoPrenotazioneInCorso()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso);
        }

        [Fact]
        public void TestInserimentoClientePrenotazioneInCorso()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso);
        }

        [Fact]
        public void TestInserimentoPrenotazioneInCorso()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione(DateTime.Parse("2022-03-11"), DateTime.Parse("2022-03-14"));

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso);
        }
        
    }
}



