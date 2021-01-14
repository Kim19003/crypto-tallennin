using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bitcoin_Tallennin;
using System.IO;

namespace Bitcoin_Sovellus
{
    public partial class Form : System.Windows.Forms.Form
    {
        public const string appName = "Bitcoin Tallennin";
        public const string appCreator = "Kim19003";

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
            string path = formMainFolder + @"\config.txt";

            if (File.Exists(path)) // Tarkista löytyykö käyttäjältä config-tiedosto
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();

                if (lines.Count > 0 && lines.Count < 3)
                { 
                    if (lines.Count == 2)
                    {
                        if (lines[0].Contains("directoryPath =") && lines[1].Contains("dateTime ="))
                        {
                            lataaConfig();
                        }
                        else
                        {
                            lines.Clear();
                            lines.Add("directoryPath = null");
                            lines.Add("dateTime = null");
                            File.WriteAllLines(path, lines); // Päivitä tiedosto listan sisällöllä
                            MessageBox.Show("Config-tiedosto resetoitiin, koska se ei toiminut kunnolla.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        lines.Clear();
                        lines.Add("directoryPath = null");
                        lines.Add("dateTime = null");
                        File.WriteAllLines(path, lines); // Päivitä tiedosto listan sisällöllä
                        MessageBox.Show("Config-tiedosto resetoitiin, koska se ei toiminut kunnolla.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (lines.Count > 2)
                    {
                        if (lines[0].Contains("directoryPath =") && lines[1].Contains("dateTime ="))
                        {
                            for (int i = 2; i < lines.Count; i++)
                            {
                                lines.RemoveAt(i);
                            }
                        }
                        else
                        {
                            lines.Clear();
                            lines.Add("directoryPath = null");
                            lines.Add("dateTime = null");
                            File.WriteAllLines(path, lines); // Päivitä tiedosto listan sisällöllä
                            MessageBox.Show("Config-tiedosto resetoitiin, koska se ei toiminut kunnolla.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        lines.Clear();
                        lines.Add("directoryPath = null");
                        lines.Add("dateTime = null");
                        File.WriteAllLines(path, lines); // Päivitä tiedosto listan sisällöllä
                        MessageBox.Show("Config-tiedosto resetoitiin, koska se ei toiminut kunnolla.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            { 
                if (MessageBox.Show("Config-tiedostoa ei löydy.\nLuodaanko uusi config-tiedosto?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Create(path).Close();

                    List<string> lines = new List<string>(); // Uuden listan luominen
                    lines = File.ReadAllLines(path).ToList(); // Lue koko tiedosto ja lisää se listaan

                    lines.Add("directoryPath = null");
                    lines.Add("dateTime = null");
                    File.WriteAllLines(path, lines); // Päivitä tiedosto listan sisällöllä
                }
                else
                {
                    if (MessageBox.Show("Config-tiedosto on välttämätön ohjelman toimivuuden kannalta.\nSuljetaan ohjelma...", appName, MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
            }

        // Ilmoita päivämäärä
        DateTime date = DateTime.Now;
            paivaMaaraDownLabel.Text = date.ToString("dd/MM/yyyy");

        // Aja pienohjelmat
        bitcoinApi();
        viimeisinTapahtuma();
        }

        private void ostettuNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että ostit bitcoineja?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                MessageBox.Show("Osto onnistui!", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void myytyNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että myit bitcoineja?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                MessageBox.Show("Myynti onnistui!", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Salli vain numeroita tekstilaatikon syötteeksi
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
            OpenFileDialog fileDialog = new OpenFileDialog();
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

        private void avaaTiedostoButton_Click(object sender, EventArgs e)
        {
            if (tiedostonSijainti != null)
            {
                try
                {
                    System.Diagnostics.Process.Start(tiedostonSijainti); // Avaa tiedosto
                    //System.Diagnostics.Process.Start("0"); // Kokeile virheilmoitusta
                }
                catch
                {
                    MessageBox.Show("Tiedoston avaaminen epäonnistui.\nVarmista, että tiedoston polku on oikea.", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Lataa tiedot config-tiedostosta
        private void lataaConfig()
        {
            formConfig = formMainFolder + @"\config.txt";

            if (File.Exists(formConfig)) // Tarkista löytyykö käyttäjältä config-tiedosto
            {
                List<string> lines = new List<string>(); // Uuden listan luominen
                lines = File.ReadAllLines(formConfig).ToList(); // Lue koko tiedosto ja lisää se listaan

                if (lines.Count > 0)
                {
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
                }
            }
        }

        // Lue viimeisin tapahtuma käyttäjän tekstitiedostosta
        void viimeisinTapahtuma()
        {
            List<string> lines = new List<string>(); // Uuden listan luominen

            try
            {
                lines = File.ReadAllLines(tiedostonSijainti).ToList(); // Lue koko tiedosto ja lisää se listaan

                if (lines.Count > 0)
                {
                    string last = lines[lines.Count - 2];
                    viimeisinTapahtumasiRightLabel.Text = last;
                }
            }
            catch (Exception error)
            {
                //Console.WriteLine(error);
            }
        }

        // Bitcoin API
        void bitcoinApi()
        {
            string response, value;

            try
            {
                API api = new API();

                response = api.Response();

                int i = response.IndexOf("&euro;\",\"rate\":");

                value = response.Substring(i);
                value = value.Substring(16, 6);

                bitcoininHintaDownLabel.Text = (value.ToString() + "€");
                apiVirheLabel.Text = "";
            }
            catch (Exception error)
            {
                bitcoininHintaDownLabel.Text = "(bitcoinin arvo)";
                apiVirheLabel.Text = "Bitcoinin arvoa ei voida hakea.";
                //Console.WriteLine(error);
            }
        }
    }
}
