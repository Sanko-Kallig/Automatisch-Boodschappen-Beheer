using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class GematigdDrank : Verkoop
    {
        public readonly BTWTarief BTWTarief { get; private set { BTWTarief = BTWTarief.Laag; } }

        public readonly decimal Prijs { get; private set { Prijs = 10; } }

        public GematigdDrank(int aantal) : base(aantal)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Gematigd Drank" + "-" + Prijs + "-" + "BTW: " + BTWTarief;
        }
    }
    }
}
