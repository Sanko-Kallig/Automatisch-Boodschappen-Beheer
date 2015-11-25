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

        public List<IInkomsten> Overzicht(DateTime van, DateTime tot, bool test)
        {
            List<IInkomsten> temp = new List<IInkomsten>();
            List<IInkomsten> ret = new List<IInkomsten>();

            foreach (Verhuur h in verhuringen)
            {
                temp.Add(h);
            }
            foreach (IInkomsten i in temp)
            {
                if(i.Tijdstip <= tot && i.Tijdstip >= van)
                {
                    ret.Add(i);
                }
            }
            ret.Sort((x, y) => y.Tijdstip.CompareTo(x.Tijdstip));
            return ret;
        }
        public List<IInkomsten> Overzicht(DateTime van, DateTime tot)
        {
            List<IInkomsten> temp = new List<IInkomsten>();
            List<IInkomsten> ret = new List<IInkomsten>();
            foreach (Verkoop k in verkopen)
            {
                temp.Add(k);
            }
            foreach (IInkomsten i in temp)
            {
                if (i.Tijdstip <= tot && i.Tijdstip >= van)
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
            decimal hoog = 0M;
            decimal laag = 0M;
            decimal totaal = 0M;
            List<IInkomsten> templist = Overzicht(tarief);
            StreamWriter writer = new StreamWriter(path);
            if (tarief == BTWTarief.Ongespecificeerd)
            {
                foreach (IInkomsten i in templist)
                {
                    writer.WriteLine(String.Format("{0} - {1}", i.ToString(), i.BTWTarief));
                    if (i.BTWTarief == BTWTarief.Laag)
                    {
                        laag += i.Bedrag;
                    }
                    if (i.BTWTarief == BTWTarief.Hoog)
                    {
                        hoog += i.Bedrag;
                    }
                    totaal += i.Bedrag;
                }
                writer.WriteLine();
                writer.WriteLine("Totaal Laag: EUR " + laag);
                writer.WriteLine("Totaal Hoog: EUR " + hoog);
                writer.WriteLine("Totaal: EUR " + totaal);
                writer.Close();
            }
            else
            {
                foreach (IInkomsten i in templist)
                {
                    writer.WriteLine(String.Format("{0}", i.ToString()));
                    switch (tarief)
                    {
                        case BTWTarief.Hoog:
                            {
                                if (i.BTWTarief == BTWTarief.Hoog)
                                {

                                    hoog += i.Bedrag;
                                }
                                break;
                            }
                        case BTWTarief.Laag:
                            {
                                if (i.BTWTarief == BTWTarief.Laag)
                                {
                                    laag += i.Bedrag;
                                }
                                break;
                            }
                    }
                                   totaal += i.Bedrag;
                }
                switch(tarief)
                {
                    case BTWTarief.Hoog:
                        {             
                            writer.WriteLine();
                            writer.WriteLine("Totaal Hoog: EUR " + hoog);
                            writer.WriteLine("Totaal: EUR " + totaal);
                            writer.Close();
                            break;
                        }
                    case BTWTarief.Laag:
                        {
                            writer.WriteLine();
                            writer.WriteLine("Totaal Laag: EUR " + laag);
                            writer.WriteLine("Totaal: EUR " + totaal);
                            writer.Close();
                            break;
                        }
                }

            }

        }
    }
}
