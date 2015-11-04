using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Danszaal : Verhuur
    {
        public readonly BTWTarief BTWTarief { get; private set { BTWTarief = BTWTarief.Laag; } }

        public readonly decimal PrijsPerUur { get; private set { PrijsPerUur = 10; } }

        public Danszaal(DateTime tijdstip, int urenVerhuurd): base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return "Feestzaal" +"Prijs per uur: "+ PrijsPerUur + "BTW: " + BTWTarief;
        }
    }
    }
}
