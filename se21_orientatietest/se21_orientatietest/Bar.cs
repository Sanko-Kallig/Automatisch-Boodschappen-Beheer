using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Bar : Verhuur
    {
        public readonly BTWTarief BTWTarief { get; private set { BTWTarief = BTWTarief.Hoog; } }

        public readonly decimal PrijsPerUur { get; private set { PrijsPerUur = 10; } }

        public Bar(DateTime tijdstip, int urenVerhuurd): base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return "Bar -" +"Prijs per uur: "+ PrijsPerUur + "- BTW: " + BTWTarief;
        }
    }
    }
}
