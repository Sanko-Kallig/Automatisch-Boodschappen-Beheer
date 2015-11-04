using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class LichteDrank : Verkoop
    {
        public readonly BTWTarief btwtarief = BTWTarief.Laag;
        public readonly decimal prijs = 10;
        public override BTWTarief BTWTarief { get { return btwtarief; } }
        public override decimal Prijs { get { return prijs; } }

        public LichteDrank(int aantal) : base(aantal)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Sterke Drank" + "-" + Prijs + "-" + "BTW: " + BTWTarief;
        }
    }
}
