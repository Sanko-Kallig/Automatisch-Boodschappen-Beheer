using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class MedianStatistic : IStatistic
    {
        public double CalculateStatistics(List<double> numbers)
        {
            double[] medianNumbers = numbers.ToArray();
            Array.Sort(medianNumbers);

            int count = medianNumbers.Length;
            int mid = count / 2;
            double median = (count % 2 != 0) ? (double)medianNumbers[mid] : ((double)medianNumbers[mid] + (double)medianNumbers[mid - 1]) / 2;
            return median;
        }
    }
}