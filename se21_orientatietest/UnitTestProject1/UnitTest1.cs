using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using se21_orientatietest;

namespace UnitTestProject1
{
    [TestClass]
    public class IInkomstentest
    {
        [TestInitialize]
        public void MytestData()
        {
                
        }
        [TestMethod]
        public void Twee_Verhuringen_Kunnen_Vergeleken_Worden()
        {
            DateTime datum = new DateTime(2015, 10, 10, 12, 12, 00);

            Feestzaal a = new Feestzaal(datum, 1);
            Feestzaal b = new Feestzaal(datum, 1);

            Assert.AreEqual(a, b);

            Danszaal c = new Danszaal(datum, 1);

            Assert.AreNotEqual(a, c);

            Bar d = new Bar(datum, 1);

            Assert.AreNotEqual(c, d);
            Assert.AreNotEqual(a, d);
        }

        [TestMethod]
        public void Twee_Lijsten_Van_Verhuringen_Kunnen_Vergeleken_Worden()
        {
            DateTime datum = DateTime.Now;

            List<Verhuur> verhuringenA = new List<Verhuur>();
            Danszaal a = new Danszaal(datum, 1);
            Bar b = new Bar(datum, 1);
            verhuringenA.Add(a);
            verhuringenA.Add(b);

            List<Verhuur> verhuringenB = new List<Verhuur>();
            verhuringenB.Add(a);
            verhuringenB.Add(b);

            CollectionAssert.Equals(verhuringenA, verhuringenB);

            List<Verhuur> verhuringenC = new List<Verhuur>();
            Feestzaal c = new Feestzaal(datum, 1);
            verhuringenC.Add(a);
            verhuringenC.Add(c);

            CollectionAssert.AreNotEqual(verhuringenA, verhuringenC);
        }
    }
}
