﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatisch_Boodschappen_Beheer
{
    public interface IStatistic
    {
        double CalculateStatistics(List<double> numbers);
    }
}
