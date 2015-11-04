using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public List<IInkomsten> Overzicht(DateTime van, DateTime tot)
        {
            List<IInkomsten> temp = new List<IInkomsten>();
            List<IInkomsten> ret = new List<IInkomsten>();
            foreach(Verkoop k in verkopen)
            {
                temp.Add(k);
            }
            foreach (Verhuur h in verhuringen)
            {
                temp.Add(h);
            }
            foreach (IInkomsten i in temp)
            {
                if(i.Tijdstip >= tot && i.Tijdstip <= van)
                {
                    ret.Add(i);
                }
            }
            ret.Sort((x, y) => y.Tijdstip.CompareTo(x.Tijdstip));
            return ret;
        }

        public List<IInkomsten> Overzicht(BTWTarief tarief)
        {
            List<IInkomsten> temp = new List<IInkomsten>();
            List<IInkomsten> ret = new List<IInkomsten>();
            foreach (Verkoop k in verkopen)
            {
                temp.Add(k);
            }
            foreach (Verhuur h in verhuringen)
            {
                temp.Add(h);
            }
            foreach (IInkomsten i in temp)
            {
                if (tarief == BTWTarief.Ongespecificeerd)
                {
                    ret.Add(i);
                }

                if (i.BTWTarief == tarief)
                {
                    ret.Add(i);
                }
            }
            ret.Sort((x, y) => y.Tijdstip.CompareTo(x.Tijdstip));
            return ret;
        }

        public void Exporteer(string path, BTWTarief tarief)
        {
            if (tarief == BTWTarief.Ongespecificeerd)
            {
                List<IInkomsten> templist = Overzicht(tarief);

            }
            else
            {
                List<IInkomsten> templist = Overzicht(tarief);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (IInkomsten i in templist)
                    {
                        writer.WriteLine(i.ToString());
                    }
                }
            }

        }
    }
}
