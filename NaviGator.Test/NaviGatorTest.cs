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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));

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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));

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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();

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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();
        
            //Act
            naviGator.CreaServizioCabina(1, DateTime.Parse("2022-04-17"));
        
            //Assert
            Assert.NotNull(naviGator.GetPrenotazioneInCorso());
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }
        
        [Fact]
        public void TestRegistraPortate()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();
            naviGator.CreaServizioCabina(1, DateTime.Parse("2022-03-30"));
            Portata portata = new Portata("Tiramisu", true, 1, 1);
        
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
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();
            naviGator.CreaServizioCabina(1, DateTime.Parse("2022-03-30"));
            Portata portata = new Portata("Tiramisu", true, 1, 1);
            naviGator.GetServizioCabinaInCorso().RegistraPortata(portata, 1);
        
            //Act
            naviGator.RegistraServizioCabina();
        
            //Assert
            Assert.NotNull(naviGator.GetPrenotazioneInCorso());
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }

        [Fact]
        public void TestPeriodoVariazioni()
        {
            // 1° Periodo esatto 

            // Assign
            int expected = naviGator.GetListaPeriodiVariazione().Count;
        
            // Act
            naviGator.AggiungiPeriodoVariazione(DateTime.Parse("2024-04-01"), DateTime.Parse("2024-04-06"), 10);
            expected++;

            // Assert
            Assert.Equal(expected, naviGator.GetListaPeriodiVariazione().Count);

            //2° Periodo con dataInizio > dataFine 

            // Assign
            expected = naviGator.GetListaPeriodiVariazione().Count;
            
            // Act
            naviGator.AggiungiPeriodoVariazione(DateTime.Parse("2024-04-08"), DateTime.Parse("2024-04-06"), 10);
            expected++;
        
            // Assert
            Assert.NotEqual(expected, naviGator.GetListaPeriodiVariazione().Count);

        }


        [Fact]
        public void TestAbilitaDisabilitaCabina()
        {
            // Arrange
            List<int> codiciValidi = new List<int> { 5 };
            Cabina c = new Cabina(5, "Singola", 750);
            naviGator.GetCabine().Add(c);
        
            // Act
            bool result1 = naviGator.AbilitaDisabilitaCabina(5, false, codiciValidi);
        
            // Assert
            Assert.True(result1, "La cabina dovrebbe essere stata disabilitata");
            Assert.False(naviGator.GetCabina(5).GetDisponibilita(), "La cabina dovrebbe essere non disponibile");
        
            // Act
            bool result2 = naviGator.AbilitaDisabilitaCabina(5, true, codiciValidi);
        
            // Assert
            Assert.True(result2, "La cabina dovrebbe essere stata abilitata");
            Assert.True(naviGator.GetCabina(5).GetDisponibilita(), "La cabina dovrebbe essere disponibile");
        }
        
    }
}



