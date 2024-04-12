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
            naviGator.RegistraPrenotazione(DateTime.Parse("2024-03-11"), DateTime.Parse("2024-03-18"));

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso);
        }

//**************TEST UC7**************
        [Fact]
        public void TestCreaNuovoServizioInCabina()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione(DateTime.Parse("2024-03-11"), DateTime.Parse("2024-03-18"));
        
            //Act
            naviGator.CreaServizioCabina("1", DateTime.Parse("2022-03-30"));
        
            //Assert
            Assert.NotNull(naviGator.GetPrenotazioneInCorso());
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }
        
        [Fact]
        public void TestRegistraPortate()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione(DateTime.Parse("2024-03-11"), DateTime.Parse("2024-03-18"));
            naviGator.CreaServizioCabina("1", DateTime.Parse("2022-03-30"));
            Portata portata = new Portata("Tiramisu", true, 1, "01");
        
            //Act
            naviGator.GetServizioCabinaInCorso().RegistraPortata(portata, 1);
        
            //Assert
            Assert.NotNull(naviGator.GetPrenotazioneInCorso());
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }
        
        [Fact]
        public void TestRegistraServizioInCamera()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina("1");
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione(DateTime.Parse("2024-03-11"), DateTime.Parse("2024-03-18"));
            naviGator.CreaServizioCabina("1", DateTime.Parse("2022-03-30"));
            Portata portata = new Portata("Tiramisu", true, 1, "01");
            naviGator.GetServizioCabinaInCorso().RegistraPortata(portata, 1);
        
            //Act
            naviGator.RegistraServizioCabina();
        
            //Assert
            Assert.NotNull(naviGator.GetPrenotazioneInCorso());
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }

        
    }
}



