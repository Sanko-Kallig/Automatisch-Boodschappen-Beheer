using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Sterkedrank : Verkoop
    {
        public readonly BTWTarief btwtarief = BTWTarief.Hoog;
        public readonly decimal prijs = 10;
        public override BTWTarief BTWTarief { get { return btwtarief; } }
        public override decimal Prijs { get { return prijs; } }

        public Sterkedrank(int aantal) : base(aantal)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Sterke Drank" + "-" + Prijs + "-" + "BTW: " + BTWTarief;
        }
    }
}
