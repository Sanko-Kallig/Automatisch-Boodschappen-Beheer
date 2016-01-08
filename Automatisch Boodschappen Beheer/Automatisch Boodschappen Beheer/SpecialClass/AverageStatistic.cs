using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class AverageStatistic : IStatistic
    {
        public double CalculateStatistics(List<double> numbers)
        {
            int count = numbers.Count();
            double average = new double();
            foreach(double number in numbers)
            {
                average += number;
            }
            average /= count;
            return average;
        }
    }
}