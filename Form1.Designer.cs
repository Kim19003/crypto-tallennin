
namespace Bitcoin_Sovellus
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.bitcoinLogo = new System.Windows.Forms.PictureBox();
            this.tekstiLaatikko = new System.Windows.Forms.TextBox();
            this.ostettuNappula = new System.Windows.Forms.Button();
            this.myytyNappula = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dollarLabel = new System.Windows.Forms.Label();
            this.myyntiSijaintiLabel = new System.Windows.Forms.Label();
            this.tiedostonSijaintiLabel = new System.Windows.Forms.Label();
            this.vaihdaSijaintiButton = new System.Windows.Forms.Button();
            this.paivaMaaraUpLabel = new System.Windows.Forms.Label();
            this.paivaMaaraDownLabel = new System.Windows.Forms.Label();
            this.kaytitViimeksiUpLabel = new System.Windows.Forms.Label();
            this.kaytitViimeksiDownLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.avaaTiedostoButton = new System.Windows.Forms.Button();
            this.bitcoininHintaDownLabel = new System.Windows.Forms.Label();
            this.bitcoininHintaUpLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.apiVirheLabel = new System.Windows.Forms.Label();
            this.viimeisinTapahtumasiLeftLabel = new System.Windows.Forms.Label();
            this.viimeisinTapahtumasiRightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bitcoinLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bitcoinLogo
            // 
            this.bitcoinLogo.Image = ((System.Drawing.Image)(resources.GetObject("bitcoinLogo.Image")));
            this.bitcoinLogo.Location = new System.Drawing.Point(31, 34);
            this.bitcoinLogo.Name = "bitcoinLogo";
            this.bitcoinLogo.Size = new System.Drawing.Size(85, 77);
            this.bitcoinLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bitcoinLogo.TabIndex = 0;
            this.bitcoinLogo.TabStop = false;
            // 
            // tekstiLaatikko
            // 
            this.tekstiLaatikko.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tekstiLaatikko.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tekstiLaatikko.Location = new System.Drawing.Point(9, 7);
            this.tekstiLaatikko.MaxLength = 12;
            this.tekstiLaatikko.Name = "tekstiLaatikko";
            this.tekstiLaatikko.Size = new System.Drawing.Size(132, 19);
            this.tekstiLaatikko.TabIndex = 1;
            this.tekstiLaatikko.TabStop = false;
            this.tekstiLaatikko.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tekstiLaatikko_KeyPress);
            // 
            // ostettuNappula
            // 
            this.ostettuNappula.BackColor = System.Drawing.SystemColors.Window;
            this.ostettuNappula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ostettuNappula.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.ostettuNappula.FlatAppearance.BorderSize = 2;
            this.ostettuNappula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ostettuNappula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ostettuNappula.Location = new System.Drawing.Point(30, 168);
            this.ostettuNappula.Name = "ostettuNappula";
            this.ostettuNappula.Size = new System.Drawing.Size(83, 31);
            this.ostettuNappula.TabIndex = 2;
            this.ostettuNappula.TabStop = false;
            this.ostettuNappula.Text = "Osto";
            this.ostettuNappula.UseVisualStyleBackColor = false;
            this.ostettuNappula.Click += new System.EventHandler(this.ostettuNappula_Click);
            // 
            // myytyNappula
            // 
            this.myytyNappula.BackColor = System.Drawing.SystemColors.Window;
            this.myytyNappula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myytyNappula.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.myytyNappula.FlatAppearance.BorderSize = 2;
            this.myytyNappula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myytyNappula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myytyNappula.Location = new System.Drawing.Point(120, 168);
            this.myytyNappula.Name = "myytyNappula";
            this.myytyNappula.Size = new System.Drawing.Size(83, 31);
            this.myytyNappula.TabIndex = 3;
            this.myytyNappula.TabStop = false;
            this.myytyNappula.Text = "Myynti";
            this.myytyNappula.UseVisualStyleBackColor = false;
            this.myytyNappula.Click += new System.EventHandler(this.myytyNappula_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(30, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 36);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dollarLabel);
            this.panel2.Controls.Add(this.tekstiLaatikko);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 32);
            this.panel2.TabIndex = 5;
            // 
            // dollarLabel
            // 
            this.dollarLabel.AutoSize = true;
            this.dollarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dollarLabel.Location = new System.Drawing.Point(147, 7);
            this.dollarLabel.Name = "dollarLabel";
            this.dollarLabel.Size = new System.Drawing.Size(18, 20);
            this.dollarLabel.TabIndex = 5;
            this.dollarLabel.Text = "€";
            // 
            // myyntiSijaintiLabel
            // 
            this.myyntiSijaintiLabel.AutoSize = true;
            this.myyntiSijaintiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myyntiSijaintiLabel.Location = new System.Drawing.Point(26, 279);
            this.myyntiSijaintiLabel.Name = "myyntiSijaintiLabel";
            this.myyntiSijaintiLabel.Size = new System.Drawing.Size(306, 16);
            this.myyntiSijaintiLabel.TabIndex = 5;
            this.myyntiSijaintiLabel.Text = "Tiedosto myynti- ja ostotietojen tallennusta varten: ";
            // 
            // tiedostonSijaintiLabel
            // 
            this.tiedostonSijaintiLabel.AutoSize = true;
            this.tiedostonSijaintiLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.tiedostonSijaintiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiedostonSijaintiLabel.ForeColor = System.Drawing.Color.White;
            this.tiedostonSijaintiLabel.Location = new System.Drawing.Point(29, 301);
            this.tiedostonSijaintiLabel.Name = "tiedostonSijaintiLabel";
            this.tiedostonSijaintiLabel.Size = new System.Drawing.Size(131, 16);
            this.tiedostonSijaintiLabel.TabIndex = 6;
            this.tiedostonSijaintiLabel.Text = "(tiedoston sijainti)";
            // 
            // vaihdaSijaintiButton
            // 
            this.vaihdaSijaintiButton.Location = new System.Drawing.Point(29, 326);
            this.vaihdaSijaintiButton.Name = "vaihdaSijaintiButton";
            this.vaihdaSijaintiButton.Size = new System.Drawing.Size(109, 23);
            this.vaihdaSijaintiButton.TabIndex = 7;
            this.vaihdaSijaintiButton.TabStop = false;
            this.vaihdaSijaintiButton.Text = "Vaihda tiedosto";
            this.vaihdaSijaintiButton.UseVisualStyleBackColor = true;
            this.vaihdaSijaintiButton.Click += new System.EventHandler(this.vaihdaSijaintiButton_Click);
            // 
            // paivaMaaraUpLabel
            // 
            this.paivaMaaraUpLabel.AutoSize = true;
            this.paivaMaaraUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paivaMaaraUpLabel.Location = new System.Drawing.Point(289, 125);
            this.paivaMaaraUpLabel.Name = "paivaMaaraUpLabel";
            this.paivaMaaraUpLabel.Size = new System.Drawing.Size(105, 16);
            this.paivaMaaraUpLabel.TabIndex = 8;
            this.paivaMaaraUpLabel.Text = "Päivämäärä nyt:";
            // 
            // paivaMaaraDownLabel
            // 
            this.paivaMaaraDownLabel.AutoSize = true;
            this.paivaMaaraDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paivaMaaraDownLabel.Location = new System.Drawing.Point(289, 144);
            this.paivaMaaraDownLabel.Name = "paivaMaaraDownLabel";
            this.paivaMaaraDownLabel.Size = new System.Drawing.Size(89, 16);
            this.paivaMaaraDownLabel.TabIndex = 9;
            this.paivaMaaraDownLabel.Text = "(päivämäärä)";
            // 
            // kaytitViimeksiUpLabel
            // 
            this.kaytitViimeksiUpLabel.AutoSize = true;
            this.kaytitViimeksiUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kaytitViimeksiUpLabel.Location = new System.Drawing.Point(289, 176);
            this.kaytitViimeksiUpLabel.Name = "kaytitViimeksiUpLabel";
            this.kaytitViimeksiUpLabel.Size = new System.Drawing.Size(159, 16);
            this.kaytitViimeksiUpLabel.TabIndex = 10;
            this.kaytitViimeksiUpLabel.Text = "Teit tapahtuman viimeksi:";
            // 
            // kaytitViimeksiDownLabel
            // 
            this.kaytitViimeksiDownLabel.AutoSize = true;
            this.kaytitViimeksiDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kaytitViimeksiDownLabel.Location = new System.Drawing.Point(289, 195);
            this.kaytitViimeksiDownLabel.Name = "kaytitViimeksiDownLabel";
            this.kaytitViimeksiDownLabel.Size = new System.Drawing.Size(89, 16);
            this.kaytitViimeksiDownLabel.TabIndex = 11;
            this.kaytitViimeksiDownLabel.Text = "(päivämäärä)";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(463, 363);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(49, 13);
            this.versionLabel.TabIndex = 12;
            this.versionLabel.Text = "ver. 1.04";
            // 
            // avaaTiedostoButton
            // 
            this.avaaTiedostoButton.Location = new System.Drawing.Point(144, 326);
            this.avaaTiedostoButton.Name = "avaaTiedostoButton";
            this.avaaTiedostoButton.Size = new System.Drawing.Size(109, 23);
            this.avaaTiedostoButton.TabIndex = 13;
            this.avaaTiedostoButton.TabStop = false;
            this.avaaTiedostoButton.Text = "Avaa tiedosto";
            this.avaaTiedostoButton.UseVisualStyleBackColor = true;
            this.avaaTiedostoButton.Click += new System.EventHandler(this.avaaTiedostoButton_Click);
            // 
            // bitcoininHintaDownLabel
            // 
            this.bitcoininHintaDownLabel.AutoSize = true;
            this.bitcoininHintaDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F, System.Drawing.FontStyle.Bold);
            this.bitcoininHintaDownLabel.ForeColor = System.Drawing.Color.White;
            this.bitcoininHintaDownLabel.Location = new System.Drawing.Point(13, 30);
            this.bitcoininHintaDownLabel.Name = "bitcoininHintaDownLabel";
            this.bitcoininHintaDownLabel.Size = new System.Drawing.Size(121, 18);
            this.bitcoininHintaDownLabel.TabIndex = 14;
            this.bitcoininHintaDownLabel.Text = "(bitcoinin arvo)";
            // 
            // bitcoininHintaUpLabel
            // 
            this.bitcoininHintaUpLabel.AutoSize = true;
            this.bitcoininHintaUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.bitcoininHintaUpLabel.ForeColor = System.Drawing.Color.White;
            this.bitcoininHintaUpLabel.Location = new System.Drawing.Point(14, 11);
            this.bitcoininHintaUpLabel.Name = "bitcoininHintaUpLabel";
            this.bitcoininHintaUpLabel.Size = new System.Drawing.Size(124, 18);
            this.bitcoininHintaUpLabel.TabIndex = 15;
            this.bitcoininHintaUpLabel.Text = "Bitcoinin arvo nyt:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.panel3.Controls.Add(this.bitcoininHintaUpLabel);
            this.panel3.Controls.Add(this.bitcoininHintaDownLabel);
            this.panel3.Location = new System.Drawing.Point(288, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 61);
            this.panel3.TabIndex = 16;
            // 
            // apiVirheLabel
            // 
            this.apiVirheLabel.AutoSize = true;
            this.apiVirheLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.apiVirheLabel.ForeColor = System.Drawing.Color.Red;
            this.apiVirheLabel.Location = new System.Drawing.Point(285, 27);
            this.apiVirheLabel.Name = "apiVirheLabel";
            this.apiVirheLabel.Size = new System.Drawing.Size(0, 13);
            this.apiVirheLabel.TabIndex = 16;
            // 
            // viimeisinTapahtumasiLeftLabel
            // 
            this.viimeisinTapahtumasiLeftLabel.AutoSize = true;
            this.viimeisinTapahtumasiLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.75F);
            this.viimeisinTapahtumasiLeftLabel.Location = new System.Drawing.Point(27, 244);
            this.viimeisinTapahtumasiLeftLabel.Name = "viimeisinTapahtumasiLeftLabel";
            this.viimeisinTapahtumasiLeftLabel.Size = new System.Drawing.Size(154, 18);
            this.viimeisinTapahtumasiLeftLabel.TabIndex = 17;
            this.viimeisinTapahtumasiLeftLabel.Text = "Viimeisin tapahtumasi:";
            // 
            // viimeisinTapahtumasiRightLabel
            // 
            this.viimeisinTapahtumasiRightLabel.AutoSize = true;
            this.viimeisinTapahtumasiRightLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(26)))));
            this.viimeisinTapahtumasiRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viimeisinTapahtumasiRightLabel.ForeColor = System.Drawing.Color.White;
            this.viimeisinTapahtumasiRightLabel.Location = new System.Drawing.Point(180, 244);
            this.viimeisinTapahtumasiRightLabel.Name = "viimeisinTapahtumasiRightLabel";
            this.viimeisinTapahtumasiRightLabel.Size = new System.Drawing.Size(98, 18);
            this.viimeisinTapahtumasiRightLabel.TabIndex = 18;
            this.viimeisinTapahtumasiRightLabel.Text = "(tapahtuma)";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 385);
            this.Controls.Add(this.viimeisinTapahtumasiRightLabel);
            this.Controls.Add(this.viimeisinTapahtumasiLeftLabel);
            this.Controls.Add(this.apiVirheLabel);
            this.Controls.Add(this.avaaTiedostoButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.kaytitViimeksiDownLabel);
            this.Controls.Add(this.kaytitViimeksiUpLabel);
            this.Controls.Add(this.paivaMaaraDownLabel);
            this.Controls.Add(this.paivaMaaraUpLabel);
            this.Controls.Add(this.vaihdaSijaintiButton);
            this.Controls.Add(this.tiedostonSijaintiLabel);
            this.Controls.Add(this.myyntiSijaintiLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myytyNappula);
            this.Controls.Add(this.ostettuNappula);
            this.Controls.Add(this.bitcoinLogo);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bitcoin Tallennin";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bitcoinLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bitcoinLogo;
        private System.Windows.Forms.TextBox tekstiLaatikko;
        private System.Windows.Forms.Button ostettuNappula;
        private System.Windows.Forms.Button myytyNappula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dollarLabel;
        private System.Windows.Forms.Label myyntiSijaintiLabel;
        private System.Windows.Forms.Label tiedostonSijaintiLabel;
        private System.Windows.Forms.Button vaihdaSijaintiButton;
        private System.Windows.Forms.Label paivaMaaraUpLabel;
        private System.Windows.Forms.Label paivaMaaraDownLabel;
        private System.Windows.Forms.Label kaytitViimeksiUpLabel;
        private System.Windows.Forms.Label kaytitViimeksiDownLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button avaaTiedostoButton;
        private System.Windows.Forms.Label bitcoininHintaDownLabel;
        private System.Windows.Forms.Label bitcoininHintaUpLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label apiVirheLabel;
        private System.Windows.Forms.Label viimeisinTapahtumasiLeftLabel;
        private System.Windows.Forms.Label viimeisinTapahtumasiRightLabel;
    }
}

