using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public abstract class Verkoop : IInkomsten
    {
        public int Aantal { get; set; }
        public decimal Bedrag { get; set; }

        public DateTime Tijdstip { get; set; }

        public abstract BTWTarief BTWTarief { get;  }

        public abstract decimal Prijs { get; }

        public Verkoop(int aantal)
        {
            this.Aantal = aantal;
            Tijdstip = DateTime.Now;
        }

        public override string ToString()
        {
            return "Datum: "+ Tijdstip.ToString() + "-" + Aantal + "-" + Bedrag;
        }
    }
}
