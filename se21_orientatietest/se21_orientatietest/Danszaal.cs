using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Danszaal : Verhuur
    {
        public readonly BTWTarief btwtarief = BTWTarief.Laag;
        public readonly decimal prijsperuur = 20.00M;
        public override BTWTarief BTWTarief { get { return btwtarief; } }

        public override decimal PrijsPerUur { get { return prijsperuur; } }

        public Danszaal(DateTime tijdstip, int urenVerhuurd): base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Danszaal" + "Prijs per uur: " + PrijsPerUur + " - BTW: " + BTWTarief;
        }
    }
}
