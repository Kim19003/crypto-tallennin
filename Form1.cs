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
using System.Media;

namespace Bitcoin_Sovellus
{
    public partial class Form : System.Windows.Forms.Form
    {
        public const string appName = "Crypto Tallennin";
        public const string appCreator = "Kim19003";

        string formMainFolder = AppDomain.CurrentDomain.BaseDirectory; // Sovelluksen pääkansio
        string configPath; // Config-tiedoston lokaatio
        string directoryPath; // Mahdollinen vaihdettu tiedoston sijainti (-> vaihdaSijaintiButton)
        string defaultFileLocation; // Tallennettavan tekstitiedoston oletussijainti
        string tiedostonSijainti; // Tallennettavan tekstitiedoston muuttuva sijainti

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            configPath = formMainFolder + @"\config.txt";
            defaultFileLocation = @"C:\Tiedostot\Bitcoin Tapahtumat.txt";

            if (File.Exists(configPath)) // Tarkista löytyykö käyttäjältä config-tiedosto
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(configPath).ToList();

                if (lines.Count > 0 && lines.Count < 3)
                {
                    if (lines.Count == 2)
                    {
                        if (lines[0].Contains("directoryPath =") && lines[1].Contains("dateTime ="))
                        {
                            LataaConfig(configPath);
                        }
                        else
                        {
                            ClearConfig(configPath, lines, true);
                        }
                    }
                    else
                    {
                        ClearConfig(configPath, lines, true);
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
                            ClearConfig(configPath, lines, true);
                        }
                    }
                    else
                    {
                        ClearConfig(configPath, lines, true);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Config-tiedostoa ei löydy.\nLuodaanko uusi config-tiedosto?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Create(configPath).Close();

                    List<string> lines = new List<string>();
                    lines = File.ReadAllLines(configPath).ToList();

                    ClearConfig(configPath, lines, false);
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
            HaeBitcoininHinta();
            ViimeisinTapahtuma();
        }

        private void ostettuNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että teit ostotapahtuman?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (varmistus == DialogResult.Yes)
            {
                MakeABuyEvent();
            }
        }

        private void myytyNappula_Click(object sender, EventArgs e)
        {
            DialogResult varmistus = MessageBox.Show("Oletko varma, että teit myyntitapahtuman?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (varmistus == DialogResult.Yes)
            {
                MakeASellEvent();
            }
        }

        private void vaihdaSijaintiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.FileName = "Crypto Tapahtumat.txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ChangeFileOrCreateNewIfNone(fileDialog); // Vaihda tiedosto tai luo uusi, jos ei ole
            }

            // Päivitä tiedoston sijainti -teksti
            if (directoryPath != null)
            {
                tiedostonSijainti = directoryPath; // Myynti- ja ostotietojen uusi tallennussijainti
            }
            else
            {
                tiedostonSijainti = defaultFileLocation;
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
                }
                catch
                {
                    MessageBox.Show("Tiedoston avaaminen epäonnistui.\nVarmista, että tiedoston polku on oikea.", appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Salli vain numeroita tekstilaatikon syötteeksi
        private void tekstiLaatikko_KeyPress(object textBox, KeyPressEventArgs keyPressed)
        {
            if (!char.IsControl(keyPressed.KeyChar) && !char.IsDigit(keyPressed.KeyChar) && (keyPressed.KeyChar != '.'))
            {
                keyPressed.Handled = true;
            }
            if ((keyPressed.KeyChar == '.') && ((textBox as TextBox).Text.IndexOf('.') > -1))
            {
                keyPressed.Handled = true;
            }
        }

        // Lataa tiedot config-tiedostosta
        private void LataaConfig(string configPath)
        {
            if (File.Exists(configPath)) // Tarkista löytyykö käyttäjältä config-tiedosto
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(configPath).ToList();

                if (lines.Count > 0)
                {
                    ReadConfigDirectoryPath(lines); // Lue directory path
                    ReadConfigDateTime(lines); // Lue date time

                    tiedostonSijaintiLabel.Text = tiedostonSijainti;
                }
            }
        }

        // Lue viimeisin tapahtuma käyttäjän tekstitiedostosta
        void ViimeisinTapahtuma()
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
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        // Bitcoin API
        void HaeBitcoininHinta()
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
            catch (Exception err)
            {
                bitcoininHintaDownLabel.Text = "(bitcoinin arvo)";
                apiVirheLabel.Text = "Bitcoinin arvoa ei voida hakea.";
                Console.WriteLine(err);
            }
        }

        // Toista ääni
        void PlayCoinSound()
        {
            SoundPlayer sp = new SoundPlayer(formMainFolder + @"\SuperMarioCoinSound.wav");
            sp.Play();
        }

        void ClearConfig(string configPath, List<string> configData, bool causedByError)
        {
            if (configData.Count > 0)
            {
                configData.Clear();
            }
            configData.Add("directoryPath = null");
            configData.Add("dateTime = null");
            File.WriteAllLines(configPath, configData); // Päivitä tiedosto listan sisällöllä
            if (causedByError)
            {
                MessageBox.Show("Config-tiedosto resetoitiin, koska se ei toiminut kunnolla.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void UpdateConfig(string configPath, string directoryPath)
        {
            DateTime date = DateTime.Now;

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(configPath).ToList();

            lines[0] = "directoryPath = " + directoryPath;
            lines[1] = "dateTime = " + date.ToString("dd/MM/yyyy");
            File.WriteAllLines(configPath, lines); // Päivitä tiedosto listan sisällöllä
        }

        void UpdateConfigDateTime(string configPath, DateTime date)
        {
            List<string> lines = File.ReadAllLines(configPath).ToList();

            lines[1] = "dateTime = " + date.ToString("dd/MM/yyyy");
            File.WriteAllLines(configPath, lines);
        }

        void ReadConfigDateTime(List<string> configData)
        {
            if (configData[1] == "dateTime = null")
            {
                kaytitViimeksiDownLabel.Text = "";
            }
            else if (configData[1].Contains("dateTime ="))
            {
                string readDateTime = configData[1];

                try
                {
                    kaytitViimeksiDownLabel.Text = readDateTime.Substring(11);
                }
                catch (Exception err)
                {
                    Console.WriteLine(readDateTime + " >>>" + err + "<<<");
                }
            }
        }

        void ReadConfigDirectoryPath(List<string> configData)
        {
            if (configData[0] == "directoryPath = null")
            {
                directoryPath = null;
                tiedostonSijainti = defaultFileLocation;
            }
            else if (configData[0].Contains("directoryPath ="))
            {
                string readDirectoryPath = configData[0];

                try
                {
                    directoryPath = readDirectoryPath.Substring(16);
                    tiedostonSijainti = directoryPath;
                }
                catch (Exception err)
                {
                    Console.WriteLine(readDirectoryPath + " >>>" + err + "<<<");
                }
            }
        }

        void ChangeFileOrCreateNewIfNone(OpenFileDialog fileDialog)
        {
            directoryPath = fileDialog.InitialDirectory + fileDialog.FileName;

            if (!File.Exists(fileDialog.FileName)) // Jos tiedostoa ei ole olemassa
            {
                File.Create(fileDialog.FileName).Close(); // Luo uusi tiedosto
            }

            UpdateConfig(configPath, directoryPath); // Päivitä config-tiedosto
        }

        void UpdateFileLocationText(string directoryPath)
        {
            if (directoryPath != null)
            {
                tiedostonSijainti = directoryPath; // Myynti- ja ostotietojen uusi tallennussijainti
            }
            else
            {
                tiedostonSijainti = defaultFileLocation; // Myynti- ja ostotietojen normaali tallennussijainti
            }

            tiedostonSijaintiLabel.Text = tiedostonSijainti;
        }

        void MakeABuyEvent()
        {
            string teksti = tekstiLaatikko.Text, rahaValuutta = rahaValuuttaBox.Text, cryptoValuutta = cryptoValuuttaBox.Text;
            string fileLocation = tiedostonSijainti; // Tallennettavan tiedoston sijainti

            DateTime date = DateTime.Now; // Määritä tämänhetkinen aika

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(fileLocation).ToList();

            lines.Add("Ostettu [" + date.ToString("dd/MM/yyyy") + "] (" + cryptoValuutta + "): " + teksti + rahaValuutta + "\n"); // Lisää listaan "Ostettu [_AIKA_] (_CRYPTOVALUUTTA_): _EUROMÄÄRÄ__RAHAVALUUTTA_"
            File.WriteAllLines(fileLocation, lines);

            UpdateConfigDateTime(configPath, date); // Päivitä config-tiedostoon aika, jolloin tallennus tehtiin

            //MessageBox.Show("Osto onnistui!", appName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //PlayCoinSound();
        }

        void MakeASellEvent()
        {
            string teksti = tekstiLaatikko.Text, rahaValuutta = rahaValuuttaBox.Text, cryptoValuutta = cryptoValuuttaBox.Text;
            string fileLocation = tiedostonSijainti; // Tallennettavan tiedoston sijainti

            DateTime date = DateTime.Now; // Määritä tämänhetkinen aika

            List<string> lines = new List<string>();
            lines = File.ReadAllLines(fileLocation).ToList();

            lines.Add("Myyty [" + date.ToString("dd/MM/yyyy") + "] (" + cryptoValuutta + "): " + teksti + rahaValuutta + "\n"); // Lisää listaan "Myyty [_AIKA_] (_CRYPTOVALUUTTA_): _EUROMÄÄRÄ__RAHAVALUUTTA_"
            File.WriteAllLines(fileLocation, lines);

            UpdateConfigDateTime(configPath, date); // Päivitä config-tiedostoon aika, jolloin tallennus tehtiin

            //MessageBox.Show("Myynti onnistui!", appName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //PlayCoinSound();
        }
    }
}
