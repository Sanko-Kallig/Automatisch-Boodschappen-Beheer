using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public interface IInkomsten
    {
        decimal Bedrag { get; }
        BTWTarief BTWTarief { get; }
        DateTime Tijdstip { get; }
    }
}
