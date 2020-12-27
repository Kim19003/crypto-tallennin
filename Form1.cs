using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bitcoin_Sovellus
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        string formMainFolder = AppDomain.CurrentDomain.BaseDirectory; // Sovelluksen pääkansio
        string formConfig; // Sovelluksen config-tiedosto

        string directoryPath; // Mahdollinen vaihdettu tiedoston sijainti (ks. vaihdaSijaintiButton)
        string tiedostonSijainti; // Tiedoston virallinen sijainti (oletus: "D:\stuff\fileread\bitcoin.txt")

        // CONFIG INIT:
        /*
            directoryPath = null
            dateTime = null
        */

        private void Form_Load(object sender, EventArgs e)
        {
            formConfig = formMainFolder + @"\config.txt";

            List<string> lines = new List<string>(); // Uuden listan luominen
            lines = File.ReadAllLines(formConfig).ToList(); // Lue koko tiedosto ja lisää se listaan

            // Lue directory path
            if (lines[0] == "directoryPath = null")
            {
                directoryPath = null;
                tiedostonSijainti = @"D:\stuff\fileread\bitcoin.txt"; // Myynti- ja ostotietojen normaali tallennussijainti
            }
            else if (lines[0].Contains("directoryPath ="))
            {
                string lines0 = lines[0];
                directoryPath = lines0.Substring(16);
                tiedostonSijainti = directoryPath;
            }

            tiedostonSijaintiLabel.Text = tiedostonSijainti;

            // Lue date time
            if (lines[1] == "dateTime = null")
            {
                kaytitViimeksiDownLabel.Text = "";
            }
            else if (lines[1].Contains("dateTime ="))
            {
                string lines1 = lines[1];
                kaytitViimeksiDownLabel.Text = lines1.Substring(11);
            }

            // Ilmoita päivämäärä
            DateTime date = DateTime.Now;
            paivaMaaraDownLabel.Text = date.ToString("dd/MM/yyyy");
        }

        private void ostettuNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että OSTAT bitcoineja?", "Ostatko?", MessageBoxButtons.YesNo);

            if (varmistus == DialogResult.Yes)
            {
            string teksti = tekstiLaatikko.Text; // Lue tekstilaatikon teksti ja lisää se muuttujaan

            string fileLocation = tiedostonSijainti; // Tallennettavan tiedoston sijainti

            DateTime date = DateTime.Now; // Määritä tämänhetkinen aika

            List<string> lines = new List<string>(); // Uuden listan luominen
            lines = File.ReadAllLines(fileLocation).ToList(); // Lue koko tiedosto ja lisää se listaan

            lines.Add("Ostettu [" + date.ToString("dd/MM/yyyy") + "]: " + teksti + "€\n"); // Lisää listaan "Ostettu [_AIKA_]: _EUROMÄÄRÄ_€"
            File.WriteAllLines(fileLocation, lines); // Päivitä tiedosto listan sisällöllä

                // Päivitä config-tiedostoon aika, jolloin tallennus tehtiin
                formConfig = formMainFolder + @"\config.txt";

                List<string> lines2 = new List<string>(); // Uuden listan luominen
                lines2 = File.ReadAllLines(formConfig).ToList(); // Lue koko tiedosto ja lisää se listaan

                lines2[1] = "dateTime = " + date.ToString("dd/MM/yyyy");
                File.WriteAllLines(formConfig, lines2); // Päivitä tiedosto listan sisällöllä
            }
        }

        private void myytyNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että MYYT bitcoineja?", "Myytkö?", MessageBoxButtons.YesNo);

            if (varmistus == DialogResult.Yes)
            {
                string teksti = tekstiLaatikko.Text; // Lue tekstilaatikon teksti ja lisää se muuttujaan

                string fileLocation = tiedostonSijainti; // Tallennettavan tiedoston sijainti

                DateTime date = DateTime.Now; // Määritä tämänhetkinen aika

                List<string> lines = new List<string>(); // Uuden listan luominen
                lines = File.ReadAllLines(fileLocation).ToList(); // Lue koko tiedosto ja lisää se listaan

                lines.Add("Myyty [" + date.ToString("dd/MM/yyyy") + "]: " + teksti + "€\n"); // Lisää listaan "Myyty [_AIKA_]: _EUROMÄÄRÄ_€"
                File.WriteAllLines(fileLocation, lines); // Päivitä tiedosto listan sisällöllä

                    // Päivitä config-tiedostoon aika, jolloin tallennus tehtiin
                    formConfig = formMainFolder + @"\config.txt";

                    List<string> lines2 = new List<string>(); // Uuden listan luominen
                    lines2 = File.ReadAllLines(formConfig).ToList(); // Lue koko tiedosto ja lisää se listaan

                    lines2[1] = "dateTime = " + date.ToString("dd/MM/yyyy");
                    File.WriteAllLines(formConfig, lines2); // Päivitä tiedosto listan sisällöllä
            }
        }

        private void tekstiLaatikko_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void vaihdaSijaintiButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "Bitcoin-tapahtumani.txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                directoryPath = fileDialog.InitialDirectory + fileDialog.FileName;

                if (!File.Exists(fileDialog.FileName)) // Jos tiedostoa ei ole olemassa
                {
                    File.Create(fileDialog.FileName).Close(); // Luo uusi tiedosto
                }
                /* else // Jos tiedosto on olemassa
                {
                    // Tee jotain
                } */

                // Päivitä config-tiedosto
                DateTime date = DateTime.Now;

                formConfig = formMainFolder + @"\config.txt";

                List<string> lines = new List<string>(); // Uuden listan luominen
                lines = File.ReadAllLines(formConfig).ToList(); // Lue koko tiedosto ja lisää se listaan

                lines[0] = "directoryPath = " + directoryPath;
                lines[1] = "dateTime = " + date.ToString("dd/MM/yyyy");
                File.WriteAllLines(formConfig, lines); // Päivitä tiedosto listan sisällöllä
            }

            // Päivitä tiedoston sijainti -teksti
            if (directoryPath != null)
            {
                tiedostonSijainti = directoryPath; // Myynti- ja ostotietojen uusi tallennussijainti
            }
            else
            {
                tiedostonSijainti = @"D:\stuff\fileread\bitcoin.txt"; // Myynti- ja ostotietojen normaali tallennussijainti
            }

            tiedostonSijaintiLabel.Text = tiedostonSijainti;
        }
    }
}
