using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace se21_orientatietest
{
    public partial class SanderKochForm : Form
    {
        Administratie administratie;
        public SanderKochForm()
        {
            InitializeComponent();
            administratie = new Administratie();
        }

        private void btnNieuweVerhuringToevoegen_Click(object sender, EventArgs e)
        {
            if(cbNieuweVerhuring.SelectedItem != null)
            {
                DateTime datetime = dtpNieuweVerhuringTijdstip.Value;
                int uren = Convert.ToInt32(nudNieuweVerhuringUren.Value);
                switch (cbNieuweVerhuring.SelectedItem.ToString())
                {
                    case "Feestzaal":
                        administratie.VoegToe(new Feestzaal(datetime, uren));
                        break;
                    case "Danszaal":
                        administratie.VoegToe(new Danszaal(datetime, uren));
                        break;
                    case "Bar":
                        administratie.VoegToe(new Bar(datetime, uren));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Er is iets fouts gegaan");
            }

            UpdateVerhuurListBox();

        }
        private void UpdateVerhuurListBox()
        {
            lbVerhuringen.DataSource = null;
            lbVerhuringen.DataSource = administratie.verhuringen;
            lbVerhuringen.Refresh();
        }

        private void UpdateVerkoopListBox()
        {
            lbVerkopen.DataSource = null;
            lbVerkopen.DataSource = administratie.verkopen;
            lbVerkopen.Refresh();
        }

        private void btnNieuweVerkoopToevoegen_Click(object sender, EventArgs e)
        {
            if(cbNieuweVerkoop.SelectedItem != null)
            {
                int aantal = Convert.ToInt32(nudNieuweVerkoopAantal.Value);
                switch (cbNieuweVerkoop.SelectedItem.ToString())
                {
                    case "Sterkedrank":
                        {
                            administratie.VoegToe(new Sterkedrank(aantal));
                            break;
                        }
                    case "Gematigddrank":
                        {
                            administratie.VoegToe(new GematigdDrank(aantal));
                            break;
                        }
                    case "Lichtedrank":
                        {
                            administratie.VoegToe(new LichteDrank(aantal));
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Er is iets fouts gegaan");
            }


            UpdateVerkoopListBox();
        }

        private void btnOverzichtDatumbereik_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach(Verhuur v in administratie.Overzicht(dtpOverzichtVan.Value, dtpOverzichtTot.Value, false))
            {
                message += v.ToString() + Environment.NewLine;
            }
            foreach (Verkoop v in administratie.Overzicht(dtpOverzichtVan.Value, dtpOverzichtTot.Value))
            {
                message += v.ToString() + Environment.NewLine;
            }
            MessageBox.Show(message);
            }

            private void btnOverzichtExporteer_Click(object sender, EventArgs e)
            {
                SaveFileDialog Save = new SaveFileDialog();
                Save.DefaultExt = ".txt";
                Save.Filter = "Text file (*.txt)|*.txt|Alle bestanden|*.*";
            BTWTarief temp = new BTWTarief();
            switch(cbOverzichtBTW.SelectedItem.ToString())
            {
                case "Ongespecificeerd":
                    {
                        temp = BTWTarief.Ongespecificeerd;
                        break;
                    }
                case "Laag":
                    {
                        temp = BTWTarief.Laag;
                        break;
                    }
                case "Hoog":
                    {
                        temp = BTWTarief.Hoog;
                        break;
                    }
            }
            if(cbOverzichtBTW.SelectedIndex == -1)
            {
                if (Save.ShowDialog() == DialogResult.OK)
                {
                    administratie.Exporteer(Save.FileName, temp);
                }
            }
            else
            {
                MessageBox.Show("Selecteer een BTW Tarief");
            }

        }
    }
}
