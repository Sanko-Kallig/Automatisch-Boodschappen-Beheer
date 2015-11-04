using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Bar : Verhuur
    {
        public readonly BTWTarief btwtarief = BTWTarief.Hoog;
        public readonly decimal prijsperuur = 10;
        public override BTWTarief BTWTarief { get { return btwtarief; } }

        public override decimal PrijsPerUur { get { return prijsperuur; } }
        public Bar(DateTime tijdstip, int urenVerhuurd): base(tijdstip, urenVerhuurd)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Bar -" +"Prijs per uur: "+ PrijsPerUur + "- BTW: " + BTWTarief;
        }
    }
}
