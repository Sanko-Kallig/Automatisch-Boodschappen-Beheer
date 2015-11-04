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
            if(cbNieuweVerhuring.SelectedValue != null)
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
            if(cbNieuweVerkoop.SelectedValue != null)
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
            List<IInkomsten> test = administratie.Overzicht(dtpOverzichtVan.Value, dtpOverzichtTot.Value);
            var message = string.Join(Environment.NewLine, test.ToString());
            MessageBox.Show(message);
        }

        private void btnOverzichtExporteer_Click(object sender, EventArgs e)
        {
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
                        temp = BTWTarief.Ongespecificeerd;
                        break;
                    }
                case "Hoog":
                    {
                        temp = BTWTarief.Ongespecificeerd;
                        break;
                    }
            }
            if(temp != null)
            {
                if (saveLogDialog.ShowDialog() == DialogResult.OK)
                {
                    administratie.Exporteer(saveLogDialog.FileName, temp);
                }
            }
            else
            {
                MessageBox.Show("Er is iets fouts gegaan");
            }

        }
    }
}
