using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace se21_orientatietest
{
    public class Administratie
    {
        public List<Verhuur> verhuringen = new List<Verhuur>();
        public List<Verkoop> verkopen = new List<Verkoop>();
        public Administratie()
        {
        }

        public void VoegToe(Verhuur verhuur)
        {
            verhuringen.Add(verhuur);
        }

        public void VoegToe(Verkoop verkoop)
        {
            verkopen.Add(verkoop);
        }

    }
}
