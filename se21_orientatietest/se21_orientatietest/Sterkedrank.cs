﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    class Sterkedrank : Verkoop
    {
        public readonly BTWTarief BTWTarief { get; private set { BTWTarief = BTWTarief.Hoog; } }

        public readonly decimal Prijs { get; private set { Prijs = 10; } }

        public Sterkedrank(int aantal) : base(aantal)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "Sterke Drank" + "-" + Prijs + "-" + "BTW: " + BTWTarief;
        }
    }
}
