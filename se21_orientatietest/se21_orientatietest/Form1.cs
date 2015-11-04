using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace se21_orientatietest
{
    public partial class Form1 : Form
    {
        Administratie administratie;
        public Form1()
        {
            InitializeComponent();
            administratie = new Administratie();
        }

        private void btnNieuweVerhuringToevoegen_Click(object sender, EventArgs e)
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
            int aantal = Convert.ToInt32(nudNieuweVerkoopAantal.Value);
            switch(cbNieuweVerkoop.SelectedItem.ToString())
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

            UpdateVerkoopListBox();
        }
    }
}
