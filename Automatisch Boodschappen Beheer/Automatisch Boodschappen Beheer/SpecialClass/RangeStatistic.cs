using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Automatisch_Boodschappen_Beheer
{
    public class RangeStatistic : IStatistic
    {
        public double CalculateStatistics(List<double> numbers)
        {
            double[] rangenumbers = numbers.ToArray();
            Array.Sort(rangenumbers);

            return (rangenumbers.Last() - rangenumbers.First());
        }
    }
}