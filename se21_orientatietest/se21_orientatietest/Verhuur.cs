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

        public decimal Bedrag { get; set; }

        public DateTime Tijdstip { get; set; }

        public abstract BTWTarief BTWTarief { get; }

        public abstract decimal PrijsPerUur { get; }

        public Verhuur(DateTime tijdstip, int urenVerhuurd)
        {
            this.Tijdstip = tijdstip;
            this.UrenVerhuurd = urenVerhuurd;
        }

        public override string ToString()
        {
            return "Datum: "+ Tijdstip.ToString() +" - " +"Uren verhuurd: " + UrenVerhuurd + Bedrag;
        }
    }
}
