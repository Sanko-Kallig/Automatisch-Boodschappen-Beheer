using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class LichteDrank : Verkoop
    {

        public readonly BTWTarief BTWTarief { get; private set { BTWTarief = BTWTarief.Laag; } }

        public readonly decimal Prijs { get; private set { Prijs = 10; } }

        public LichteDrank(int aantal) : base(aantal)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Sterke Drank" + "-" + Prijs + "-" + "BTW: " + BTWTarief;
        }
    }
    }
}
