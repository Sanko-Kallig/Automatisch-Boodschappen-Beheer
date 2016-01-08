using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automatisch_Boodschappen_Beheer;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Automatisch_Boodschappen_Beheer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        List<double> numbers = new List<double>();

        IStatistic calculate = null;
        [TestMethod]
        public void AverageCalculation()
        {
            numbers.Add(13.50);
            numbers.Add(8.00);
            numbers.Add(5.25);
            numbers.Add(20.99);
            numbers.Add(1.00);
            numbers.Add(3.50);
            numbers.Add(30.00);

            calculate = new AverageStatistic();

            Assert.AreEqual(calculate.CalculateStatistics(numbers), 11.748571428571427);
        }
        [TestMethod]
        public void MedianCalculation()
        {
            numbers.Add(13.50);
            numbers.Add(8.00);
            numbers.Add(5.25);
            numbers.Add(20.99);
            numbers.Add(1.00);
            numbers.Add(3.50);
            numbers.Add(30.00);
            calculate = new MedianStatistic();

            Assert.AreEqual(calculate.CalculateStatistics(numbers), 8.00);

        }

        [TestMethod]
        public void MedianEvenNumberCalculation()
        {
            numbers.Add(13.50);
            numbers.Add(8.00);
            numbers.Add(5.25);
            numbers.Add(20.99);
            numbers.Add(1.00);
            numbers.Add(3.50);
            numbers.Add(30.00);
            numbers.Add(7.00);

            calculate = new MedianStatistic();

            Assert.AreEqual(calculate.CalculateStatistics(numbers), 7.50);
        }

        [TestMethod]
        public void RangeCalculation()
        {
            numbers.Add(13.50);
            numbers.Add(8.00);
            numbers.Add(5.25);
            numbers.Add(20.99);
            numbers.Add(1.00);
            numbers.Add(3.50);
            numbers.Add(30.00);

            calculate = new RangeStatistic();

            Assert.AreEqual(calculate.CalculateStatistics(numbers), 29.00);
        }
    }
}
