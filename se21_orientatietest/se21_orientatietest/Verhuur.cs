using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public abstract class Verhuur : IInkomsten
    {
        public int UrenVerhuurd { get; set; }

        public decimal Bedrag { get; }

        public DateTime Tijdstip { get; set; }

        public abstract readonly BTWTarief BTWTarief { get; set; }

        public abstract readonly decimal PrijsPerUur { get; set; }

        public Verhuur(DateTime tijdstip, int urenVerhuurd)
        {
            this.Tijdstip = tijdstip;
            this.UrenVerhuurd = urenVerhuurd;
        }

        public override string ToString()
        {
            return Tijdstip.ToString() + UrenVerhuurd + Bedrag;
        }
    }
}
