using System;
using System.Collections.Generic;
using se21_orientatietest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class AdministratieTests
    {
        static Administratie administratie;

        [TestInitialize]
        public void GenereerTestData()
        {
            administratie = new Administratie();
            administratie.VoegToe(new Feestzaal(DateTime.Now, 3));
            administratie.VoegToe(new Bar(DateTime.Now, 2));
            administratie.VoegToe(new Danszaal(DateTime.Now, 5));
            administratie.VoegToe(new Feestzaal(new DateTime(2015, 11,20, 12, 00, 00), 1));
            administratie.VoegToe(new Bar(new DateTime(2015, 11, 20, 13, 00, 00), 2));
            administratie.VoegToe(new Feestzaal(new DateTime(2015, 11, 21, 14, 45, 00), 3));
            administratie.VoegToe(new Danszaal(new DateTime(2015, 11, 21, 12, 00, 00), 5));
            administratie.VoegToe(new Feestzaal(new DateTime(2015, 11, 20, 12, 00, 00), 3));
            administratie.VoegToe(new Sterkedrank(1));
            administratie.VoegToe(new GematigdDrank(3));
            administratie.VoegToe(new LichteDrank(6));
            administratie.VoegToe(new LichteDrank(3));
            administratie.VoegToe(new Sterkedrank(1));


        }

        [TestMethod]
        public void AdminVoegToe1()
        {
            administratie.VoegToe(new Feestzaal(DateTime.Now, 1));
            Assert.IsNotNull(administratie);
            Assert.IsNotNull(administratie.verhuringen[0]);
        }

        [TestMethod]
        public void AdminVoegToe2()
        {
            administratie.VoegToe(new Sterkedrank(5));
            Assert.IsNotNull(administratie);
            Assert.IsNotNull(administratie.verkopen[0]);
        }
        [TestMethod]
        public void TestOverzichtHogeBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Hoog);

            Assert.AreEqual(overzicht.Find(i => i.BTWTarief != BTWTarief.Hoog), null);
        }
        [TestMethod]
        public void TestOverzichtLageBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Laag);

            Assert.AreEqual(overzicht.Find(i => i.BTWTarief != BTWTarief.Laag), null);
        }
        [TestMethod]
        public void TestOverzichtAlleBTWTarieven()
        {
            List<IInkomsten> overzicht = administratie.Overzicht(BTWTarief.Ongespecificeerd);

            Assert.AreEqual(overzicht.Count, administratie.verhuringen.Count + administratie.verkopen.Count);
        }


    }
}
