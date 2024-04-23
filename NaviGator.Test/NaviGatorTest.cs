//**** PER LA CORRETTA ESECUZIONE DEI TEST, E' NECESSARIO COMMENTARE CaricaPrenotazioni() in NaviGator.cs *********

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

//**************TEST UC1**************        
        [Fact]
        public void TestRegistraCabina()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso.GetCabina());
        }

        [Fact]
        public void TestRegistraCliente()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");

            //Act
            var prenotazioneInCorso = naviGator.GetPrenotazioneInCorso();

            //Assert
            Assert.NotNull(prenotazioneInCorso.GetCliente());
        }

        [Fact]
        public void TestRegistraPrenotazione()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");

            //Act
            naviGator.RegistraPrenotazione();
            var prenotazione = naviGator.VisualizzaPrenotazioni();

            //Assert
            Assert.NotNull(prenotazione[0].GetCliente());
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
            //faccio il check-in
            var prenotazione = naviGator.VisualizzaPrenotazioni();
            prenotazione[0].GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazione[0], "Check-in");
            //creo un nuovo servizio in cabina
            naviGator.CreaServizioCabina(1, DateTime.Parse("2022-04-17"));
        
            //Assert
            Assert.NotNull(naviGator.GetServizioCabinaInCorso());
        }
        
        [Fact]
        public void TestRegistraPortate()
        {
            //Assign
            TestCreaNuovoServizioInCabina();
            Portata portata = new Portata("Tiramisu", true, 5, 1);
        
            //Act
            naviGator.RegistraPortata(portata, 1);

            //Assert
            Assert.NotNull(naviGator.GetServizioCabinaInCorso().GetOrdineInCorso().GetElencoPortate()[0]);
        }
        
        
        [Fact]
        public void TestRegistraServizioInCabina()
        {
            //Assign
            TestRegistraPortate();

            //Act
            naviGator.RegistraServizioCabina();
        
            //Assert
            Assert.Null(naviGator.GetServizioCabinaInCorso());
            Assert.NotNull(naviGator.GetServiziCabina()[0].GetOrdineInCorso());
        }

//******************TEST UC8: GESTISCI CABINE******************
        [Fact]
        public void TestDisabilitaCabina()
        {
            // Assign
            List<int> codiciValidi = new List<int> { 5 };
            Cabina c = new Cabina(5, "Singola", 750);
            naviGator.GetCabine().Add(c);
        
            // Act
            bool result1 = naviGator.AbilitaDisabilitaCabina(5, false, codiciValidi);
        
            // Assert
            Assert.True(result1, "La cabina dovrebbe essere stata disabilitata");
            Assert.False(naviGator.GetCabina(5).GetDisponibilita(), "La cabina dovrebbe essere non disponibile");
        }

        [Fact]
        public void TestAbilitaCabina()
        {
            // Assign
            List<int> codiciValidi = new List<int> { 5 };
            TestDisabilitaCabina();

            // Act
            bool result2 = naviGator.AbilitaDisabilitaCabina(5, true, codiciValidi);
        
            // Assert
            Assert.True(result2, "La cabina dovrebbe essere stata abilitata");
            Assert.True(naviGator.GetCabina(5).GetDisponibilita(), "La cabina dovrebbe essere disponibile");
        }


//******************TEST UC9: GESTISCI PREZZO CABINE******************
        [Fact]
        public void TestPeriodoVariazioniPeriodoValido()
        {
            // Assign
            int expected = naviGator.GetListaPeriodiVariazione().Count;
        
            // Act
            naviGator.AggiungiPeriodoVariazione(DateTime.Parse("2024-04-01"), DateTime.Parse("2024-04-06"), 10);
            expected++;

            // Assert
            Assert.Equal(expected, naviGator.GetListaPeriodiVariazione().Count);

        }


//******************TEST UC7******************      
        [Fact]
        public void TestCalcolaConto()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(1,"interna",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();
            
            //faccio il check-in
            var prenotazione = naviGator.VisualizzaPrenotazioni();
            prenotazione[0].GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazione[0], "Check-in");
            //creo servizio cabina
            naviGator.CreaServizioCabina(1, DateTime.Parse("2022-04-17"));
            //registro portata
            Portata portata = new Portata("Tiramisu", true, 5, 7);
            naviGator.RegistraPortata(portata, 4); //Tot = 20
            
            double totPortate = portata.GetPrezzo() * 4;

            portata = new Portata("Test2", true, 10, 8);
            naviGator.RegistraPortata(portata, 2); //Tot = 20

            totPortate += portata.GetPrezzo() * 2;

            naviGator.RegistraServizioCabina();
            //registro servizio
            Servizio s = new Servizio(10,"Test", 10);
            RichiestaServizio rs = new RichiestaServizio(DateTime.Parse("2022-04-17"));
            rs.SetServizio(s);
            prenotazione[0].SetServizio(rs);

            // Act
            double result = naviGator.CalcolaConto();
        
            // Assert
            Assert.Equal(totPortate+s.GetPrezzo(), result);
        }
       
        [Fact]
        public void TestCalcolaContoSconto()
        {
            //Assign
            naviGator.CaricaCabine();
            naviGator.RegistraCabina(3,"suite",DateTime.Parse("2024/04/15"),DateTime.Parse("2024/04/20"));
            naviGator.RegistraCliente("Pippo", "Franco", "AQ12SD34DE12", "AZ1234567", "3324343434", "4050987845464049");
            naviGator.RegistraPrenotazione();
            
            //faccio il check-in
            var prenotazione = naviGator.VisualizzaPrenotazioni();
            prenotazione[0].GetStatoPrenotazione().GestioneStatoPrenotazione(prenotazione[0], "Check-in");
            //creo servizio cabina
            naviGator.CreaServizioCabina(3, DateTime.Parse("2022-04-17"));
            //registro portata
            Portata portata = new Portata("Tiramisu", true, 5, 1);
            naviGator.RegistraPortata(portata, 4); //Tot = 20
            double totPortate = (portata.GetPrezzo() - portata.GetPrezzo() * 0.2) * 4;
            naviGator.RegistraServizioCabina();
            //registro servizio
            Servizio s = new Servizio(10,"Test", 10);
            RichiestaServizio rs = new RichiestaServizio(DateTime.Parse("2022-04-17"));
            rs.SetServizio(s);
            prenotazione[0].SetServizio(rs);

            // Act
            double result = naviGator.CalcolaConto();
        
            // Assert
            Assert.Equal(totPortate+s.GetPrezzo(), result);
            
        }

//******************TEST UC10: GESTISCI PORTATA******************
        [Fact]
        public void TestRimuoviPortata()
        {
            // Arrange
            Portata portata = new Portata("Test", true, 5, 10);
            naviGator.GetElencoPortate().Add(portata);

            // Act
            bool result = naviGator.RimuoviPortata(10);

            // Assert
            Assert.True(result);
            Assert.False(portata.GetDisponibilita());
        }

        [Fact]
        public void TestInserisciPortate()
        {
            // Arrange
            int expected = naviGator.GetElencoPortate().Count;
        
            // Act
            naviGator.AggiornaMenu("Diavola", 6);
            expected++;
        
            // Assert
            Assert.Equal(expected, naviGator.GetElencoPortate().Count);
        }
        
    }
}



