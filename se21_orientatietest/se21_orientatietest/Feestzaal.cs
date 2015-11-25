using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Feestzaal : Verhuur
    {
        public readonly BTWTarief btwtarief = BTWTarief.Hoog;
        public readonly decimal prijsperuur = 30.00M;
        public override BTWTarief BTWTarief { get { return btwtarief; } }

        public override decimal PrijsPerUur { get { return prijsperuur; } }

        public Feestzaal(DateTime tijdstip, int urenVerhuurd): base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Feestzaal" + "Prijs per uur: " + PrijsPerUur + " - BTW: " + BTWTarief;
        }
    }
}
