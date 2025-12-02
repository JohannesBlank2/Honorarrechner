using System.Drawing.Imaging;
using System.Numerics;

namespace Honorar_Rechner
{
    partial class Honorarrechner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Honorarrechner));
            tB_Umsatz = new TextBox();
            SFSLogo = new PictureBox();
            cB_Privat = new CheckBox();
            cB_UN = new CheckBox();
            PrivatText = new Label();
            UnternemenText = new Label();
            l_32 = new Label();
            l_Ausgaben = new Label();
            tB_Ausgaben = new TextBox();
            l_AnzahlMitarbeiter = new Label();
            tB_AnzahlMitarbeiter = new TextBox();
            l_Umsatz = new Label();
            panelLeistungen = new Panel();
            cB_SeBu_new = new ColoredCheckBox();
            cB_Lohn_new = new ColoredCheckBox();
            cB_JA_new = new ColoredCheckBox();
            cB_FiBu_new = new ColoredCheckBox();
            label84 = new Label();
            l_LeistungenSeBuMonatlich = new Label();
            l_LeistungenLohnMonatlich = new Label();
            l_LeistungenJAMonatlich = new Label();
            l_LeistungenFiBuMonatlich = new Label();
            l_76 = new Label();
            lL_zumLohn = new LinkLabel();
            lL_zumJA = new LinkLabel();
            lL_ZurFiBu = new LinkLabel();
            l_SBZSLeistungen = new Label();
            l_LohnZSLeistungen = new Label();
            l_JAZSLeistungen = new Label();
            l_FiBuZSLeistungen = new Label();
            l_8 = new Label();
            cB_SeBu = new CheckBox();
            l_9 = new Label();
            cB_Lohn = new CheckBox();
            l_6 = new Label();
            cB_JA = new CheckBox();
            l_4 = new Label();
            cB_FiBu = new CheckBox();
            LeistungenTextforPanel = new Label();
            panelFiBu = new Panel();
            l_MinFiBuBeitrag = new Label();
            l_77 = new Label();
            l_66 = new Label();
            l_FiBuZSJahr = new Label();
            label23 = new Label();
            label15 = new Label();
            label22 = new Label();
            tB_FiBuUmsatz = new TextBox();
            FiBuZwischenSumme = new Label();
            label12 = new Label();
            BTN_backfromFiBu = new Button();
            l_AuslagenPauschale2 = new Label();
            l_ProzentFiBu = new Label();
            label17 = new Label();
            labelITPauschale = new Label();
            label14 = new Label();
            l_PauschaleIT = new Label();
            label13 = new Label();
            l_BuchFuerungPauschale = new Label();
            l_Laufendebuchfuerung = new Label();
            label11 = new Label();
            labelFiBuSatz = new Label();
            label10 = new Label();
            panelJA1 = new Panel();
            checkBoxGes_Bilanz_new = new ColoredCheckBox();
            cB_EUBilanz_new = new ColoredCheckBox();
            cB_Bilanz_new = new ColoredCheckBox();
            cB_EUR_new = new ColoredCheckBox();
            checkBoxGes_Bilanz = new CheckBox();
            labelZSBilanzJA = new Label();
            labelEURZWJA = new Label();
            cB_EUBilanz = new CheckBox();
            lL_ZurBilanz = new LinkLabel();
            lL_zumEUR = new LinkLabel();
            l_GESBilanz = new Label();
            label27 = new Label();
            label26 = new Label();
            labelEUBilanz = new Label();
            label25 = new Label();
            label24 = new Label();
            cB_Bilanz = new CheckBox();
            cB_EUR = new CheckBox();
            BTN_JAZurueck = new Button();
            label21 = new Label();
            panelStart = new Panel();
            cB_UN_new = new ColoredCheckBox();
            l_comingSoon2 = new Label();
            l_comingSoon = new Label();
            l_ProgressMandantenName = new Label();
            pB_Mandanten = new ProgressBar();
            BTN_UploudExcel = new Button();
            label16 = new Label();
            label7 = new Label();
            label38 = new Label();
            cB_StartUp = new CheckBox();
            StartUp = new Label();
            BTN_UpdateExcelList = new Button();
            BTN_Weiter = new Button();
            BTN_Zurueck = new Button();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            l_Leistung = new Label();
            l_Leistungen = new Label();
            l_currentJahresHonorar = new Label();
            l_AktuellesAngebot = new Label();
            l_currentMonatsHonorar = new Label();
            label5 = new Label();
            panelEUR = new Panel();
            l_EURMin = new Label();
            label19 = new Label();
            label35 = new Label();
            label39 = new Label();
            l_EURWSMonatlich = new Label();
            tB_Umsatzsteuererklärung = new TextBox();
            tB_Gewerbesteuer = new TextBox();
            tB_UdB = new TextBox();
            tB_BEA = new TextBox();
            cB_UdB = new CheckBox();
            l_AbschlussarbeitenZS = new Label();
            tB_PfA = new TextBox();
            l_Abschlussarbeiten = new Label();
            label54 = new Label();
            label55 = new Label();
            l_Umsatzsteuererklärung = new Label();
            l_UmsatzsteuererklärungSatz = new Label();
            l_MinUmsatzsteuererklaerung = new Label();
            label51 = new Label();
            l_UeberschussdBetriebseinnahmen = new Label();
            l_SEzEdUdBSatz = new Label();
            l_MinUEdB = new Label();
            label47 = new Label();
            l_Gewerbesteuer = new Label();
            l_GewerbesteuerSatz = new Label();
            l_MinGewerbesteuer = new Label();
            label42 = new Label();
            label30 = new Label();
            BTN_EURZurueck = new Button();
            label34 = new Label();
            l_EURWS = new Label();
            label36 = new Label();
            labelBEA = new Label();
            label44 = new Label();
            l_BEASatz = new Label();
            l_MinBAE = new Label();
            l_Betriebseinaus = new Label();
            label29 = new Label();
            cB_UdB_new = new ColoredCheckBox();
            panelBilanz = new Panel();
            l_BilanzMin = new Label();
            label33 = new Label();
            label20 = new Label();
            label18 = new Label();
            l_BilanzZSMonatlich = new Label();
            label79 = new Label();
            label72 = new Label();
            l_Offenlegung = new Label();
            label37 = new Label();
            l_BilanzBescheideSatz = new Label();
            tB_BilanzBescheide = new TextBox();
            l_BilanzBescheide = new Label();
            label63 = new Label();
            l_E_Bilanz = new Label();
            label82 = new Label();
            label83 = new Label();
            l_UmsatzsteuererklDesKJ = new Label();
            l_UmsatzsteuererklFDasKJSatz = new Label();
            l_MinUmsatzsteuererklFDasKJ = new Label();
            label87 = new Label();
            tB_UmsatzsteuererklaerungdesKJ = new TextBox();
            l_MinErklZurGewerbersteuer = new Label();
            l_ErklZurGewerbesteuerSatz = new Label();
            tB_ErklzurGewerbesteuer = new TextBox();
            tB_ErstellungdesAntrags = new TextBox();
            l_ErklaerungZurGewerbesteuer = new Label();
            label43 = new Label();
            l_KoerperschaftsST = new Label();
            l_KoerperschaftssteuererklSatz = new Label();
            l_MinKoerperschaftssteuererkl = new Label();
            label52 = new Label();
            tB_Koerperschaftssteuererklaerung = new TextBox();
            l_EntwEinerSteuerbilanz = new Label();
            l_EntwicklungEinerSteuerbilanzSatz = new Label();
            l_MinEntwEinerSteuerbilanz = new Label();
            label58 = new Label();
            tB_EntwEinerSteuerbilanz = new TextBox();
            l_ErstDesAntrags = new Label();
            l_ErstellungDesAntragsSatz = new Label();
            l_MinErstellungDesAntrags = new Label();
            label62 = new Label();
            l_TXTZwischensumme = new Label();
            l_BilanzZS = new Label();
            l_AdJA = new Label();
            l_AdJSatz = new Label();
            l_MinAdJ = new Label();
            label71 = new Label();
            tB_AdJA = new TextBox();
            BTN_ZurueckBilanz = new Button();
            l_BilanzUeberschrift = new Label();
            tB_Bilanzsumme = new TextBox();
            panelUnternehmensDaten = new Panel();
            cB_OnlineHaendler_new = new ColoredCheckBox();
            cB_BargeldGewerbe_new = new ColoredCheckBox();
            l_OnlineHaendlerTXT = new Label();
            cB_OnlineHaendler = new CheckBox();
            l_BarGeldGewerbeTXT = new Label();
            cB_BargeldGewerbe = new CheckBox();
            l_UnternehmensDaten = new Label();
            l_Bilanz = new Label();
            panelLohn = new Panel();
            l_AnzahlZW50bis100 = new Label();
            l_AnzahlZW20bis49 = new Label();
            l_50bis100_Mitarbeiter = new Label();
            l_20bis49_Mitarbeiter = new Label();
            l_LohnBeitragFUENFZIGBISHUNDERT = new Label();
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG = new Label();
            label41 = new Label();
            label69 = new Label();
            l_AnzahlAb101 = new Label();
            l_AnzahlZW10bis19 = new Label();
            l_AnzahlZW2bis9 = new Label();
            l_MA1 = new Label();
            label81 = new Label();
            label80 = new Label();
            label78 = new Label();
            l_ZSLohnMonat = new Label();
            label75 = new Label();
            l_ZSLohn = new Label();
            BTN_ZurueckLohn = new Button();
            l_ab101_Mitarbeiter = new Label();
            l_10bis19_Mitarbeiter = new Label();
            l_2bis9_Mitarbeiter = new Label();
            l_1_Mitarbeiter = new Label();
            label74 = new Label();
            tB_AnzahlMitarbeiterLohn = new TextBox();
            l_SatzAb101Mitarbeiter = new Label();
            l_LohnBeitragZEHNBISNEUNZEHN = new Label();
            l_LohnBeitragZWEIBISNEUN = new Label();
            l_LohnBeitragEINS = new Label();
            label65 = new Label();
            label64 = new Label();
            label59 = new Label();
            label53 = new Label();
            label45 = new Label();
            label40 = new Label();
            label31 = new Label();
            BTN_OpenExcel = new Button();
            Background = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SFSLogo).BeginInit();
            panelLeistungen.SuspendLayout();
            panelFiBu.SuspendLayout();
            panelJA1.SuspendLayout();
            panelStart.SuspendLayout();
            panelEUR.SuspendLayout();
            panelBilanz.SuspendLayout();
            panelUnternehmensDaten.SuspendLayout();
            panelLohn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Background).BeginInit();
            SuspendLayout();
            // 
            // tB_Umsatz
            // 
            tB_Umsatz.Font = new Font("Segoe UI", 15F);
            tB_Umsatz.Location = new Point(136, 168);
            tB_Umsatz.Name = "tB_Umsatz";
            tB_Umsatz.Size = new Size(199, 34);
            tB_Umsatz.TabIndex = 1;
            tB_Umsatz.TextAlign = HorizontalAlignment.Right;
            tB_Umsatz.TextChanged += tB_Umsatz_TextChanged;
            tB_Umsatz.Leave += txtUmsatz_Leave;
            // 
            // SFSLogo
            // 
            SFSLogo.Image = (Image)resources.GetObject("SFSLogo.Image");
            SFSLogo.Location = new Point(81, 75);
            SFSLogo.Name = "SFSLogo";
            SFSLogo.Size = new Size(170, 170);
            SFSLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            SFSLogo.TabIndex = 6;
            SFSLogo.TabStop = false;
            // 
            // cB_Privat
            // 
            cB_Privat.AutoSize = true;
            cB_Privat.BackColor = Color.Transparent;
            cB_Privat.Enabled = false;
            cB_Privat.ImageAlign = ContentAlignment.TopLeft;
            cB_Privat.Location = new Point(171, 270);
            cB_Privat.Name = "cB_Privat";
            cB_Privat.Size = new Size(15, 14);
            cB_Privat.TabIndex = 7;
            cB_Privat.UseVisualStyleBackColor = false;
            cB_Privat.Visible = false;
            cB_Privat.CheckedChanged += cB_Privat_CheckedChanged;
            // 
            // cB_UN
            // 
            cB_UN.AutoSize = true;
            cB_UN.ForeColor = Color.Aquamarine;
            cB_UN.Location = new Point(381, 300);
            cB_UN.MaximumSize = new Size(50, 50);
            cB_UN.Name = "cB_UN";
            cB_UN.Size = new Size(15, 14);
            cB_UN.TabIndex = 8;
            cB_UN.UseVisualStyleBackColor = true;
            cB_UN.Visible = false;
            cB_UN.CheckedChanged += cB_UN_CheckedChanged;
            // 
            // PrivatText
            // 
            PrivatText.AutoSize = true;
            PrivatText.Font = new Font("Segoe UI", 25F);
            PrivatText.ForeColor = Color.White;
            PrivatText.Location = new Point(129, 210);
            PrivatText.Name = "PrivatText";
            PrivatText.Size = new Size(104, 46);
            PrivatText.TabIndex = 9;
            PrivatText.Text = "Privat";
            PrivatText.TextAlign = ContentAlignment.TopCenter;
            // 
            // UnternemenText
            // 
            UnternemenText.AutoSize = true;
            UnternemenText.Font = new Font("Segoe UI", 25F);
            UnternemenText.ForeColor = Color.White;
            UnternemenText.Location = new Point(282, 210);
            UnternemenText.Name = "UnternemenText";
            UnternemenText.Size = new Size(226, 46);
            UnternemenText.TabIndex = 10;
            UnternemenText.Text = "Unternehmen";
            // 
            // l_32
            // 
            l_32.AutoSize = true;
            l_32.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            l_32.Location = new Point(144, 35);
            l_32.Name = "l_32";
            l_32.Size = new Size(497, 46);
            l_32.TabIndex = 11;
            l_32.Text = "Unternehmens Informationen";
            // 
            // l_Ausgaben
            // 
            l_Ausgaben.AutoSize = true;
            l_Ausgaben.Font = new Font("Segoe UI", 20F);
            l_Ausgaben.ForeColor = Color.White;
            l_Ausgaben.Location = new Point(126, 273);
            l_Ausgaben.Name = "l_Ausgaben";
            l_Ausgaben.Size = new Size(219, 37);
            l_Ausgaben.TabIndex = 10;
            l_Ausgaben.Text = "Jahresüberschuss";
            // 
            // tB_Ausgaben
            // 
            tB_Ausgaben.Font = new Font("Segoe UI", 15F);
            tB_Ausgaben.Location = new Point(136, 310);
            tB_Ausgaben.Name = "tB_Ausgaben";
            tB_Ausgaben.Size = new Size(199, 34);
            tB_Ausgaben.TabIndex = 9;
            tB_Ausgaben.TextAlign = HorizontalAlignment.Right;
            tB_Ausgaben.TextChanged += tB_Ausgaben_TextChanged;
            tB_Ausgaben.Leave += txtAusgaben_Leave;
            // 
            // l_AnzahlMitarbeiter
            // 
            l_AnzahlMitarbeiter.AutoSize = true;
            l_AnzahlMitarbeiter.Font = new Font("Segoe UI", 20F);
            l_AnzahlMitarbeiter.ForeColor = Color.White;
            l_AnzahlMitarbeiter.Location = new Point(473, 277);
            l_AnzahlMitarbeiter.Name = "l_AnzahlMitarbeiter";
            l_AnzahlMitarbeiter.Size = new Size(236, 37);
            l_AnzahlMitarbeiter.TabIndex = 8;
            l_AnzahlMitarbeiter.Text = "Anzahl Mitarbeiter";
            // 
            // tB_AnzahlMitarbeiter
            // 
            tB_AnzahlMitarbeiter.Font = new Font("Segoe UI", 15F);
            tB_AnzahlMitarbeiter.Location = new Point(487, 314);
            tB_AnzahlMitarbeiter.Name = "tB_AnzahlMitarbeiter";
            tB_AnzahlMitarbeiter.Size = new Size(199, 34);
            tB_AnzahlMitarbeiter.TabIndex = 7;
            tB_AnzahlMitarbeiter.TextAlign = HorizontalAlignment.Right;
            tB_AnzahlMitarbeiter.TextChanged += tB_AnzahlMitarbeiter_TextChanged;
            // 
            // l_Umsatz
            // 
            l_Umsatz.AutoSize = true;
            l_Umsatz.Font = new Font("Segoe UI", 20F);
            l_Umsatz.ForeColor = Color.White;
            l_Umsatz.Location = new Point(136, 134);
            l_Umsatz.Name = "l_Umsatz";
            l_Umsatz.Size = new Size(197, 37);
            l_Umsatz.TabIndex = 6;
            l_Umsatz.Text = "Umsatz im Jahr";
            // 
            // panelLeistungen
            // 
            panelLeistungen.Controls.Add(cB_SeBu_new);
            panelLeistungen.Controls.Add(cB_Lohn_new);
            panelLeistungen.Controls.Add(cB_JA_new);
            panelLeistungen.Controls.Add(cB_FiBu_new);
            panelLeistungen.Controls.Add(label84);
            panelLeistungen.Controls.Add(l_LeistungenSeBuMonatlich);
            panelLeistungen.Controls.Add(l_LeistungenLohnMonatlich);
            panelLeistungen.Controls.Add(l_LeistungenJAMonatlich);
            panelLeistungen.Controls.Add(l_LeistungenFiBuMonatlich);
            panelLeistungen.Controls.Add(l_76);
            panelLeistungen.Controls.Add(lL_zumLohn);
            panelLeistungen.Controls.Add(lL_zumJA);
            panelLeistungen.Controls.Add(lL_ZurFiBu);
            panelLeistungen.Controls.Add(l_SBZSLeistungen);
            panelLeistungen.Controls.Add(l_LohnZSLeistungen);
            panelLeistungen.Controls.Add(l_JAZSLeistungen);
            panelLeistungen.Controls.Add(l_FiBuZSLeistungen);
            panelLeistungen.Controls.Add(l_8);
            panelLeistungen.Controls.Add(cB_SeBu);
            panelLeistungen.Controls.Add(l_9);
            panelLeistungen.Controls.Add(cB_Lohn);
            panelLeistungen.Controls.Add(l_6);
            panelLeistungen.Controls.Add(cB_JA);
            panelLeistungen.Controls.Add(l_4);
            panelLeistungen.Controls.Add(cB_FiBu);
            panelLeistungen.Controls.Add(LeistungenTextforPanel);
            panelLeistungen.Location = new Point(300, 65);
            panelLeistungen.Name = "panelLeistungen";
            panelLeistungen.Size = new Size(817, 512);
            panelLeistungen.TabIndex = 31;
            panelLeistungen.Visible = false;
            // 
            // cB_SeBu_new
            // 
            cB_SeBu_new.AutoSize = true;
            cB_SeBu_new.BackColor = Color.Transparent;
            cB_SeBu_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_SeBu_new.CheckmarkColor = Color.Black;
            cB_SeBu_new.CornerRadius = 8;
            cB_SeBu_new.Location = new Point(410, 450);
            cB_SeBu_new.Name = "cB_SeBu_new";
            cB_SeBu_new.Size = new Size(29, 19);
            cB_SeBu_new.TabIndex = 28;
            cB_SeBu_new.Text = " ";
            cB_SeBu_new.UseVisualStyleBackColor = false;
            cB_SeBu_new.CheckedChanged += cB_SeBu_new_CheckedChanged;
            // 
            // cB_Lohn_new
            // 
            cB_Lohn_new.AutoSize = true;
            cB_Lohn_new.BackColor = Color.Transparent;
            cB_Lohn_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_Lohn_new.CheckmarkColor = Color.Black;
            cB_Lohn_new.CornerRadius = 8;
            cB_Lohn_new.Location = new Point(410, 350);
            cB_Lohn_new.Name = "cB_Lohn_new";
            cB_Lohn_new.Size = new Size(29, 19);
            cB_Lohn_new.TabIndex = 27;
            cB_Lohn_new.Text = " ";
            cB_Lohn_new.UseVisualStyleBackColor = false;
            cB_Lohn_new.CheckedChanged += cB_Lohn_new_CheckedChanged;
            // 
            // cB_JA_new
            // 
            cB_JA_new.AutoSize = true;
            cB_JA_new.BackColor = Color.Transparent;
            cB_JA_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_JA_new.CheckmarkColor = Color.Black;
            cB_JA_new.CornerRadius = 8;
            cB_JA_new.Location = new Point(410, 250);
            cB_JA_new.Name = "cB_JA_new";
            cB_JA_new.Size = new Size(29, 19);
            cB_JA_new.TabIndex = 26;
            cB_JA_new.Text = " ";
            cB_JA_new.UseVisualStyleBackColor = false;
            cB_JA_new.CheckedChanged += cB_JA_new_CheckedChanged;
            // 
            // cB_FiBu_new
            // 
            cB_FiBu_new.AutoSize = true;
            cB_FiBu_new.BackColor = Color.Transparent;
            cB_FiBu_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_FiBu_new.CheckmarkColor = Color.Black;
            cB_FiBu_new.CornerRadius = 8;
            cB_FiBu_new.Location = new Point(410, 150);
            cB_FiBu_new.Name = "cB_FiBu_new";
            cB_FiBu_new.Size = new Size(29, 19);
            cB_FiBu_new.TabIndex = 25;
            cB_FiBu_new.Text = " ";
            cB_FiBu_new.UseVisualStyleBackColor = false;
            cB_FiBu_new.CheckedChanged += cB_FiBu_new_CheckedChanged;
            // 
            // label84
            // 
            label84.AutoSize = true;
            label84.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            label84.ForeColor = Color.White;
            label84.Location = new Point(122, 116);
            label84.Name = "label84";
            label84.Size = new Size(79, 21);
            label84.TabIndex = 24;
            label84.Text = "Monatlich";
            // 
            // l_LeistungenSeBuMonatlich
            // 
            l_LeistungenSeBuMonatlich.AutoSize = true;
            l_LeistungenSeBuMonatlich.Font = new Font("Segoe UI", 15F);
            l_LeistungenSeBuMonatlich.ForeColor = Color.White;
            l_LeistungenSeBuMonatlich.Location = new Point(126, 446);
            l_LeistungenSeBuMonatlich.Name = "l_LeistungenSeBuMonatlich";
            l_LeistungenSeBuMonatlich.Size = new Size(60, 28);
            l_LeistungenSeBuMonatlich.TabIndex = 23;
            l_LeistungenSeBuMonatlich.Text = "0,00€";
            // 
            // l_LeistungenLohnMonatlich
            // 
            l_LeistungenLohnMonatlich.AutoSize = true;
            l_LeistungenLohnMonatlich.Font = new Font("Segoe UI", 15F);
            l_LeistungenLohnMonatlich.ForeColor = Color.White;
            l_LeistungenLohnMonatlich.Location = new Point(126, 346);
            l_LeistungenLohnMonatlich.Name = "l_LeistungenLohnMonatlich";
            l_LeistungenLohnMonatlich.Size = new Size(60, 28);
            l_LeistungenLohnMonatlich.TabIndex = 22;
            l_LeistungenLohnMonatlich.Text = "0,00€";
            // 
            // l_LeistungenJAMonatlich
            // 
            l_LeistungenJAMonatlich.AutoSize = true;
            l_LeistungenJAMonatlich.Font = new Font("Segoe UI", 15F);
            l_LeistungenJAMonatlich.ForeColor = Color.White;
            l_LeistungenJAMonatlich.Location = new Point(126, 246);
            l_LeistungenJAMonatlich.Name = "l_LeistungenJAMonatlich";
            l_LeistungenJAMonatlich.Size = new Size(60, 28);
            l_LeistungenJAMonatlich.TabIndex = 21;
            l_LeistungenJAMonatlich.Text = "0,00€";
            // 
            // l_LeistungenFiBuMonatlich
            // 
            l_LeistungenFiBuMonatlich.AutoSize = true;
            l_LeistungenFiBuMonatlich.Font = new Font("Segoe UI", 15F);
            l_LeistungenFiBuMonatlich.ForeColor = Color.White;
            l_LeistungenFiBuMonatlich.Location = new Point(126, 146);
            l_LeistungenFiBuMonatlich.Name = "l_LeistungenFiBuMonatlich";
            l_LeistungenFiBuMonatlich.Size = new Size(60, 28);
            l_LeistungenFiBuMonatlich.TabIndex = 20;
            l_LeistungenFiBuMonatlich.Text = "0,00€";
            // 
            // l_76
            // 
            l_76.AutoSize = true;
            l_76.Font = new Font("Segoe UI", 12F, FontStyle.Underline);
            l_76.ForeColor = Color.White;
            l_76.Location = new Point(252, 116);
            l_76.Name = "l_76";
            l_76.Size = new Size(63, 21);
            l_76.TabIndex = 19;
            l_76.Text = "Jährlich";
            // 
            // lL_zumLohn
            // 
            lL_zumLohn.ActiveLinkColor = Color.Salmon;
            lL_zumLohn.AutoSize = true;
            lL_zumLohn.Font = new Font("Segoe UI", 12F);
            lL_zumLohn.LinkColor = Color.Aquamarine;
            lL_zumLohn.Location = new Point(506, 348);
            lL_zumLohn.Name = "lL_zumLohn";
            lL_zumLohn.Size = new Size(79, 21);
            lL_zumLohn.TabIndex = 18;
            lL_zumLohn.TabStop = true;
            lL_zumLohn.Text = "zum Lohn";
            lL_zumLohn.Visible = false;
            lL_zumLohn.LinkClicked += lL_zumLohn_LinkClicked;
            // 
            // lL_zumJA
            // 
            lL_zumJA.ActiveLinkColor = Color.Salmon;
            lL_zumJA.AutoSize = true;
            lL_zumJA.Font = new Font("Segoe UI", 12F);
            lL_zumJA.LinkColor = Color.Aquamarine;
            lL_zumJA.Location = new Point(506, 248);
            lL_zumJA.Name = "lL_zumJA";
            lL_zumJA.Size = new Size(60, 21);
            lL_zumJA.TabIndex = 17;
            lL_zumJA.TabStop = true;
            lL_zumJA.Text = "zum JA";
            lL_zumJA.Visible = false;
            lL_zumJA.LinkClicked += lL_zumJA_LinkClicked;
            // 
            // lL_ZurFiBu
            // 
            lL_ZurFiBu.ActiveLinkColor = Color.Salmon;
            lL_ZurFiBu.AutoSize = true;
            lL_ZurFiBu.Font = new Font("Segoe UI", 12F);
            lL_ZurFiBu.LinkColor = Color.Aquamarine;
            lL_ZurFiBu.Location = new Point(506, 148);
            lL_ZurFiBu.Name = "lL_ZurFiBu";
            lL_ZurFiBu.Size = new Size(66, 21);
            lL_ZurFiBu.TabIndex = 16;
            lL_ZurFiBu.TabStop = true;
            lL_ZurFiBu.Text = "zur FiBu";
            lL_ZurFiBu.Visible = false;
            lL_ZurFiBu.LinkClicked += lL_ZurFiBu_LinkClicked;
            // 
            // l_SBZSLeistungen
            // 
            l_SBZSLeistungen.AutoSize = true;
            l_SBZSLeistungen.Font = new Font("Segoe UI", 15F);
            l_SBZSLeistungen.ForeColor = Color.White;
            l_SBZSLeistungen.Location = new Point(256, 446);
            l_SBZSLeistungen.Name = "l_SBZSLeistungen";
            l_SBZSLeistungen.Size = new Size(60, 28);
            l_SBZSLeistungen.TabIndex = 15;
            l_SBZSLeistungen.Text = "0,00€";
            // 
            // l_LohnZSLeistungen
            // 
            l_LohnZSLeistungen.AutoSize = true;
            l_LohnZSLeistungen.Font = new Font("Segoe UI", 15F);
            l_LohnZSLeistungen.ForeColor = Color.White;
            l_LohnZSLeistungen.Location = new Point(256, 346);
            l_LohnZSLeistungen.Name = "l_LohnZSLeistungen";
            l_LohnZSLeistungen.Size = new Size(60, 28);
            l_LohnZSLeistungen.TabIndex = 14;
            l_LohnZSLeistungen.Text = "0,00€";
            // 
            // l_JAZSLeistungen
            // 
            l_JAZSLeistungen.AutoSize = true;
            l_JAZSLeistungen.Font = new Font("Segoe UI", 15F);
            l_JAZSLeistungen.ForeColor = Color.White;
            l_JAZSLeistungen.Location = new Point(256, 246);
            l_JAZSLeistungen.Name = "l_JAZSLeistungen";
            l_JAZSLeistungen.Size = new Size(60, 28);
            l_JAZSLeistungen.TabIndex = 13;
            l_JAZSLeistungen.Text = "0,00€";
            l_JAZSLeistungen.TextChanged += l_JAZSLeistungen_TextChanged;
            // 
            // l_FiBuZSLeistungen
            // 
            l_FiBuZSLeistungen.AutoSize = true;
            l_FiBuZSLeistungen.Font = new Font("Segoe UI", 15F);
            l_FiBuZSLeistungen.ForeColor = Color.White;
            l_FiBuZSLeistungen.Location = new Point(256, 146);
            l_FiBuZSLeistungen.Name = "l_FiBuZSLeistungen";
            l_FiBuZSLeistungen.Size = new Size(60, 28);
            l_FiBuZSLeistungen.TabIndex = 12;
            l_FiBuZSLeistungen.Text = "0,00€";
            // 
            // l_8
            // 
            l_8.AutoSize = true;
            l_8.Font = new Font("Segoe UI", 20F);
            l_8.ForeColor = Color.White;
            l_8.Location = new Point(436, 438);
            l_8.Name = "l_8";
            l_8.Size = new Size(262, 37);
            l_8.TabIndex = 8;
            l_8.Text = "Selbstbucher (+20%)";
            // 
            // cB_SeBu
            // 
            cB_SeBu.AutoSize = true;
            cB_SeBu.Font = new Font("Segoe UI", 15F);
            cB_SeBu.Location = new Point(372, 453);
            cB_SeBu.Name = "cB_SeBu";
            cB_SeBu.Size = new Size(15, 14);
            cB_SeBu.TabIndex = 7;
            cB_SeBu.UseVisualStyleBackColor = true;
            cB_SeBu.Visible = false;
            cB_SeBu.CheckedChanged += cB_SeBu_CheckedChanged;
            // 
            // l_9
            // 
            l_9.AutoSize = true;
            l_9.Font = new Font("Segoe UI", 20F);
            l_9.ForeColor = Color.White;
            l_9.Location = new Point(436, 338);
            l_9.Name = "l_9";
            l_9.Size = new Size(76, 37);
            l_9.TabIndex = 6;
            l_9.Text = "Lohn";
            // 
            // cB_Lohn
            // 
            cB_Lohn.AutoSize = true;
            cB_Lohn.Font = new Font("Segoe UI", 15F);
            cB_Lohn.Location = new Point(372, 353);
            cB_Lohn.Name = "cB_Lohn";
            cB_Lohn.Size = new Size(15, 14);
            cB_Lohn.TabIndex = 5;
            cB_Lohn.UseVisualStyleBackColor = true;
            cB_Lohn.Visible = false;
            cB_Lohn.CheckedChanged += cB_Lohn_CheckedChanged;
            // 
            // l_6
            // 
            l_6.AutoSize = true;
            l_6.Font = new Font("Segoe UI", 20F);
            l_6.ForeColor = Color.White;
            l_6.Location = new Point(436, 238);
            l_6.Name = "l_6";
            l_6.Size = new Size(43, 37);
            l_6.TabIndex = 4;
            l_6.Text = "JA";
            // 
            // cB_JA
            // 
            cB_JA.AutoSize = true;
            cB_JA.Font = new Font("Segoe UI", 15F);
            cB_JA.Location = new Point(372, 253);
            cB_JA.Name = "cB_JA";
            cB_JA.Size = new Size(15, 14);
            cB_JA.TabIndex = 3;
            cB_JA.UseVisualStyleBackColor = true;
            cB_JA.Visible = false;
            cB_JA.CheckedChanged += cB_JA_CheckedChanged;
            // 
            // l_4
            // 
            l_4.AutoSize = true;
            l_4.Font = new Font("Segoe UI", 20F);
            l_4.ForeColor = Color.White;
            l_4.Location = new Point(436, 138);
            l_4.Name = "l_4";
            l_4.Size = new Size(67, 37);
            l_4.TabIndex = 2;
            l_4.Text = "FiBu";
            // 
            // cB_FiBu
            // 
            cB_FiBu.AutoSize = true;
            cB_FiBu.Font = new Font("Segoe UI", 15F);
            cB_FiBu.Location = new Point(372, 153);
            cB_FiBu.Name = "cB_FiBu";
            cB_FiBu.Size = new Size(15, 14);
            cB_FiBu.TabIndex = 1;
            cB_FiBu.UseVisualStyleBackColor = true;
            cB_FiBu.Visible = false;
            cB_FiBu.CheckedChanged += cB_FiBu_CheckedChanged;
            // 
            // LeistungenTextforPanel
            // 
            LeistungenTextforPanel.Anchor = AnchorStyles.Top;
            LeistungenTextforPanel.AutoSize = true;
            LeistungenTextforPanel.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            LeistungenTextforPanel.ForeColor = Color.White;
            LeistungenTextforPanel.Location = new Point(300, 10);
            LeistungenTextforPanel.Name = "LeistungenTextforPanel";
            LeistungenTextforPanel.Size = new Size(195, 46);
            LeistungenTextforPanel.TabIndex = 0;
            LeistungenTextforPanel.Text = "Leistungen";
            // 
            // panelFiBu
            // 
            panelFiBu.Controls.Add(l_MinFiBuBeitrag);
            panelFiBu.Controls.Add(l_77);
            panelFiBu.Controls.Add(l_66);
            panelFiBu.Controls.Add(l_FiBuZSJahr);
            panelFiBu.Controls.Add(label23);
            panelFiBu.Controls.Add(label15);
            panelFiBu.Controls.Add(label22);
            panelFiBu.Controls.Add(tB_FiBuUmsatz);
            panelFiBu.Controls.Add(FiBuZwischenSumme);
            panelFiBu.Controls.Add(label12);
            panelFiBu.Controls.Add(BTN_backfromFiBu);
            panelFiBu.Controls.Add(l_AuslagenPauschale2);
            panelFiBu.Controls.Add(l_ProzentFiBu);
            panelFiBu.Controls.Add(label17);
            panelFiBu.Controls.Add(labelITPauschale);
            panelFiBu.Controls.Add(label14);
            panelFiBu.Controls.Add(l_PauschaleIT);
            panelFiBu.Controls.Add(label13);
            panelFiBu.Controls.Add(l_BuchFuerungPauschale);
            panelFiBu.Controls.Add(l_Laufendebuchfuerung);
            panelFiBu.Controls.Add(label11);
            panelFiBu.Controls.Add(labelFiBuSatz);
            panelFiBu.Controls.Add(label10);
            panelFiBu.Location = new Point(300, 65);
            panelFiBu.Name = "panelFiBu";
            panelFiBu.Size = new Size(817, 512);
            panelFiBu.TabIndex = 12;
            panelFiBu.Visible = false;
            // 
            // l_MinFiBuBeitrag
            // 
            l_MinFiBuBeitrag.AutoSize = true;
            l_MinFiBuBeitrag.Font = new Font("Segoe UI", 10F);
            l_MinFiBuBeitrag.ForeColor = Color.White;
            l_MinFiBuBeitrag.Location = new Point(648, 421);
            l_MinFiBuBeitrag.Name = "l_MinFiBuBeitrag";
            l_MinFiBuBeitrag.Size = new Size(94, 19);
            l_MinFiBuBeitrag.TabIndex = 39;
            l_MinFiBuBeitrag.Text = "min. 208,00 €";
            // 
            // l_77
            // 
            l_77.AutoSize = true;
            l_77.Font = new Font("Segoe UI", 10F);
            l_77.ForeColor = Color.White;
            l_77.Location = new Point(465, 443);
            l_77.Name = "l_77";
            l_77.Size = new Size(69, 19);
            l_77.TabIndex = 38;
            l_77.Text = "monatlich";
            // 
            // l_66
            // 
            l_66.AutoSize = true;
            l_66.Font = new Font("Segoe UI", 15F);
            l_66.ForeColor = Color.White;
            l_66.Location = new Point(534, 463);
            l_66.Name = "l_66";
            l_66.Size = new Size(158, 28);
            l_66.TabIndex = 37;
            l_66.Text = "Zwischensumme:";
            // 
            // l_FiBuZSJahr
            // 
            l_FiBuZSJahr.AutoSize = true;
            l_FiBuZSJahr.Font = new Font("Segoe UI", 15F);
            l_FiBuZSJahr.ForeColor = Color.White;
            l_FiBuZSJahr.Location = new Point(687, 463);
            l_FiBuZSJahr.Name = "l_FiBuZSJahr";
            l_FiBuZSJahr.Size = new Size(60, 28);
            l_FiBuZSJahr.TabIndex = 36;
            l_FiBuZSJahr.Text = "0,00€";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 10F);
            label23.ForeColor = Color.White;
            label23.Location = new Point(484, 472);
            label23.Name = "label23";
            label23.Size = new Size(49, 19);
            label23.TabIndex = 34;
            label23.Text = "jährich";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 15F);
            label15.ForeColor = Color.White;
            label15.Location = new Point(122, 114);
            label15.Name = "label15";
            label15.Size = new Size(77, 28);
            label15.TabIndex = 18;
            label15.Text = "Umsatz";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 15F);
            label22.ForeColor = Color.White;
            label22.Location = new Point(534, 435);
            label22.Name = "label22";
            label22.Size = new Size(158, 28);
            label22.TabIndex = 33;
            label22.Text = "Zwischensumme:";
            // 
            // tB_FiBuUmsatz
            // 
            tB_FiBuUmsatz.Enabled = false;
            tB_FiBuUmsatz.Font = new Font("Segoe UI", 15F);
            tB_FiBuUmsatz.Location = new Point(40, 146);
            tB_FiBuUmsatz.Name = "tB_FiBuUmsatz";
            tB_FiBuUmsatz.Size = new Size(159, 34);
            tB_FiBuUmsatz.TabIndex = 17;
            tB_FiBuUmsatz.Text = "0";
            tB_FiBuUmsatz.TextAlign = HorizontalAlignment.Right;
            // 
            // FiBuZwischenSumme
            // 
            FiBuZwischenSumme.AutoSize = true;
            FiBuZwischenSumme.Font = new Font("Segoe UI", 15F);
            FiBuZwischenSumme.ForeColor = Color.White;
            FiBuZwischenSumme.Location = new Point(687, 435);
            FiBuZwischenSumme.Name = "FiBuZwischenSumme";
            FiBuZwischenSumme.Size = new Size(60, 28);
            FiBuZwischenSumme.TabIndex = 1;
            FiBuZwischenSumme.Text = "0,00€";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label12.ForeColor = Color.White;
            label12.Location = new Point(672, 100);
            label12.Name = "label12";
            label12.Size = new Size(100, 28);
            label12.TabIndex = 16;
            label12.Text = "Monatlich";
            // 
            // BTN_backfromFiBu
            // 
            BTN_backfromFiBu.Font = new Font("Segoe UI", 15F);
            BTN_backfromFiBu.Location = new Point(350, 450);
            BTN_backfromFiBu.Name = "BTN_backfromFiBu";
            BTN_backfromFiBu.Size = new Size(94, 41);
            BTN_backfromFiBu.TabIndex = 32;
            BTN_backfromFiBu.Text = "Zurück";
            BTN_backfromFiBu.UseVisualStyleBackColor = true;
            BTN_backfromFiBu.Click += BTN_backfromFiBu_Click;
            // 
            // l_AuslagenPauschale2
            // 
            l_AuslagenPauschale2.AutoSize = true;
            l_AuslagenPauschale2.Font = new Font("Segoe UI", 15F);
            l_AuslagenPauschale2.ForeColor = Color.White;
            l_AuslagenPauschale2.Location = new Point(700, 360);
            l_AuslagenPauschale2.Name = "l_AuslagenPauschale2";
            l_AuslagenPauschale2.Size = new Size(60, 28);
            l_AuslagenPauschale2.TabIndex = 15;
            l_AuslagenPauschale2.Text = "0,00€";
            // 
            // l_ProzentFiBu
            // 
            l_ProzentFiBu.AutoSize = true;
            l_ProzentFiBu.Font = new Font("Segoe UI", 15F);
            l_ProzentFiBu.ForeColor = Color.White;
            l_ProzentFiBu.Location = new Point(369, 350);
            l_ProzentFiBu.Name = "l_ProzentFiBu";
            l_ProzentFiBu.Size = new Size(55, 28);
            l_ProzentFiBu.TabIndex = 14;
            l_ProzentFiBu.Text = "10 %";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 16F);
            label17.ForeColor = Color.White;
            label17.Location = new Point(37, 350);
            label17.Name = "label17";
            label17.Size = new Size(196, 30);
            label17.TabIndex = 11;
            label17.Text = "Auslagenpauschale";
            // 
            // labelITPauschale
            // 
            labelITPauschale.AutoSize = true;
            labelITPauschale.Font = new Font("Segoe UI", 15F);
            labelITPauschale.ForeColor = Color.White;
            labelITPauschale.Location = new Point(700, 260);
            labelITPauschale.Name = "labelITPauschale";
            labelITPauschale.Size = new Size(71, 28);
            labelITPauschale.TabIndex = 10;
            labelITPauschale.Text = "40,00€";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 15F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(350, 235);
            label14.Name = "label14";
            label14.Size = new Size(96, 28);
            label14.TabIndex = 9;
            label14.Text = "Pauschale";
            // 
            // l_PauschaleIT
            // 
            l_PauschaleIT.AutoSize = true;
            l_PauschaleIT.Font = new Font("Segoe UI", 15F);
            l_PauschaleIT.ForeColor = Color.White;
            l_PauschaleIT.Location = new Point(360, 260);
            l_PauschaleIT.Name = "l_PauschaleIT";
            l_PauschaleIT.Size = new Size(71, 28);
            l_PauschaleIT.TabIndex = 8;
            l_PauschaleIT.Text = "40,00€";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 16F);
            label13.ForeColor = Color.White;
            label13.Location = new Point(66, 250);
            label13.Name = "label13";
            label13.Size = new Size(130, 30);
            label13.TabIndex = 7;
            label13.Text = "IT Pauschale";
            // 
            // l_BuchFuerungPauschale
            // 
            l_BuchFuerungPauschale.AutoSize = true;
            l_BuchFuerungPauschale.Font = new Font("Segoe UI", 15F);
            l_BuchFuerungPauschale.ForeColor = Color.White;
            l_BuchFuerungPauschale.Location = new Point(700, 150);
            l_BuchFuerungPauschale.Name = "l_BuchFuerungPauschale";
            l_BuchFuerungPauschale.Size = new Size(60, 28);
            l_BuchFuerungPauschale.TabIndex = 6;
            l_BuchFuerungPauschale.Text = "0,00€";
            // 
            // l_Laufendebuchfuerung
            // 
            l_Laufendebuchfuerung.AutoSize = true;
            l_Laufendebuchfuerung.Font = new Font("Segoe UI", 20F);
            l_Laufendebuchfuerung.ForeColor = Color.White;
            l_Laufendebuchfuerung.Location = new Point(10, 70);
            l_Laufendebuchfuerung.Name = "l_Laufendebuchfuerung";
            l_Laufendebuchfuerung.Size = new Size(283, 37);
            l_Laufendebuchfuerung.TabIndex = 5;
            l_Laufendebuchfuerung.Text = "Laufende Buchführung";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label11.ForeColor = Color.White;
            label11.Location = new Point(370, 100);
            label11.Name = "label11";
            label11.Size = new Size(49, 28);
            label11.TabIndex = 4;
            label11.Text = "Satz";
            // 
            // labelFiBuSatz
            // 
            labelFiBuSatz.AutoSize = true;
            labelFiBuSatz.Font = new Font("Segoe UI", 15F);
            labelFiBuSatz.ForeColor = Color.White;
            labelFiBuSatz.Location = new Point(368, 148);
            labelFiBuSatz.Name = "labelFiBuSatz";
            labelFiBuSatz.Size = new Size(53, 28);
            labelFiBuSatz.TabIndex = 2;
            labelFiBuSatz.Text = "7/10";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            label10.ForeColor = Color.White;
            label10.Location = new Point(353, 4);
            label10.Name = "label10";
            label10.Size = new Size(91, 46);
            label10.TabIndex = 0;
            label10.Text = "FiBu";
            // 
            // panelJA1
            // 
            panelJA1.Controls.Add(checkBoxGes_Bilanz_new);
            panelJA1.Controls.Add(cB_EUBilanz_new);
            panelJA1.Controls.Add(cB_Bilanz_new);
            panelJA1.Controls.Add(cB_EUR_new);
            panelJA1.Controls.Add(checkBoxGes_Bilanz);
            panelJA1.Controls.Add(labelZSBilanzJA);
            panelJA1.Controls.Add(labelEURZWJA);
            panelJA1.Controls.Add(cB_EUBilanz);
            panelJA1.Controls.Add(lL_ZurBilanz);
            panelJA1.Controls.Add(lL_zumEUR);
            panelJA1.Controls.Add(l_GESBilanz);
            panelJA1.Controls.Add(label27);
            panelJA1.Controls.Add(label26);
            panelJA1.Controls.Add(labelEUBilanz);
            panelJA1.Controls.Add(label25);
            panelJA1.Controls.Add(label24);
            panelJA1.Controls.Add(cB_Bilanz);
            panelJA1.Controls.Add(cB_EUR);
            panelJA1.Controls.Add(BTN_JAZurueck);
            panelJA1.Controls.Add(label21);
            panelJA1.Font = new Font("Segoe UI", 9F);
            panelJA1.Location = new Point(300, 65);
            panelJA1.Name = "panelJA1";
            panelJA1.Size = new Size(814, 509);
            panelJA1.TabIndex = 33;
            panelJA1.Visible = false;
            // 
            // checkBoxGes_Bilanz_new
            // 
            checkBoxGes_Bilanz_new.AutoSize = true;
            checkBoxGes_Bilanz_new.BackColor = Color.Transparent;
            checkBoxGes_Bilanz_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            checkBoxGes_Bilanz_new.CheckmarkColor = Color.Black;
            checkBoxGes_Bilanz_new.CornerRadius = 8;
            checkBoxGes_Bilanz_new.Location = new Point(675, 378);
            checkBoxGes_Bilanz_new.Name = "checkBoxGes_Bilanz_new";
            checkBoxGes_Bilanz_new.Size = new Size(29, 19);
            checkBoxGes_Bilanz_new.TabIndex = 22;
            checkBoxGes_Bilanz_new.Text = " ";
            checkBoxGes_Bilanz_new.UseVisualStyleBackColor = false;
            checkBoxGes_Bilanz_new.Visible = false;
            checkBoxGes_Bilanz_new.CheckedChanged += checkBoxGes_Bilanz_new_CheckedChanged;
            // 
            // cB_EUBilanz_new
            // 
            cB_EUBilanz_new.AutoSize = true;
            cB_EUBilanz_new.BackColor = Color.Transparent;
            cB_EUBilanz_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_EUBilanz_new.CheckmarkColor = Color.Black;
            cB_EUBilanz_new.CornerRadius = 8;
            cB_EUBilanz_new.Location = new Point(466, 377);
            cB_EUBilanz_new.Name = "cB_EUBilanz_new";
            cB_EUBilanz_new.Size = new Size(29, 19);
            cB_EUBilanz_new.TabIndex = 21;
            cB_EUBilanz_new.Text = " ";
            cB_EUBilanz_new.UseVisualStyleBackColor = false;
            cB_EUBilanz_new.Visible = false;
            cB_EUBilanz_new.CheckedChanged += cB_EUBilanz_new_CheckedChanged;
            // 
            // cB_Bilanz_new
            // 
            cB_Bilanz_new.AutoSize = true;
            cB_Bilanz_new.BackColor = Color.Transparent;
            cB_Bilanz_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_Bilanz_new.CheckmarkColor = Color.Black;
            cB_Bilanz_new.CornerRadius = 8;
            cB_Bilanz_new.Location = new Point(558, 231);
            cB_Bilanz_new.Name = "cB_Bilanz_new";
            cB_Bilanz_new.Size = new Size(29, 19);
            cB_Bilanz_new.TabIndex = 20;
            cB_Bilanz_new.Text = " ";
            cB_Bilanz_new.UseVisualStyleBackColor = false;
            cB_Bilanz_new.CheckedChanged += cB_Bilanz_new_CheckedChanged;
            // 
            // cB_EUR_new
            // 
            cB_EUR_new.AutoSize = true;
            cB_EUR_new.BackColor = Color.Transparent;
            cB_EUR_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_EUR_new.CheckmarkColor = Color.Black;
            cB_EUR_new.CornerRadius = 8;
            cB_EUR_new.Location = new Point(225, 231);
            cB_EUR_new.Name = "cB_EUR_new";
            cB_EUR_new.Size = new Size(29, 19);
            cB_EUR_new.TabIndex = 19;
            cB_EUR_new.Text = " ";
            cB_EUR_new.UseVisualStyleBackColor = false;
            cB_EUR_new.CheckedChanged += cB_EUR_new_CheckedChanged;
            // 
            // checkBoxGes_Bilanz
            // 
            checkBoxGes_Bilanz.AutoSize = true;
            checkBoxGes_Bilanz.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            checkBoxGes_Bilanz.Location = new Point(710, 383);
            checkBoxGes_Bilanz.Name = "checkBoxGes_Bilanz";
            checkBoxGes_Bilanz.Size = new Size(15, 14);
            checkBoxGes_Bilanz.TabIndex = 16;
            checkBoxGes_Bilanz.UseVisualStyleBackColor = true;
            checkBoxGes_Bilanz.Visible = false;
            checkBoxGes_Bilanz.CheckedChanged += cB_Ges_Bilanz_CheckedChanged;
            // 
            // labelZSBilanzJA
            // 
            labelZSBilanzJA.AutoSize = true;
            labelZSBilanzJA.Font = new Font("Segoe UI", 20F);
            labelZSBilanzJA.ForeColor = Color.White;
            labelZSBilanzJA.Location = new Point(527, 287);
            labelZSBilanzJA.Name = "labelZSBilanzJA";
            labelZSBilanzJA.Size = new Size(90, 37);
            labelZSBilanzJA.TabIndex = 12;
            labelZSBilanzJA.Text = "0,00 €";
            labelZSBilanzJA.Visible = false;
            // 
            // labelEURZWJA
            // 
            labelEURZWJA.AutoSize = true;
            labelEURZWJA.Font = new Font("Segoe UI", 20F);
            labelEURZWJA.ForeColor = Color.White;
            labelEURZWJA.Location = new Point(194, 289);
            labelEURZWJA.Name = "labelEURZWJA";
            labelEURZWJA.Size = new Size(90, 37);
            labelEURZWJA.TabIndex = 11;
            labelEURZWJA.Text = "0,00 €";
            labelEURZWJA.Visible = false;
            // 
            // cB_EUBilanz
            // 
            cB_EUBilanz.AutoSize = true;
            cB_EUBilanz.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cB_EUBilanz.Location = new Point(496, 381);
            cB_EUBilanz.Name = "cB_EUBilanz";
            cB_EUBilanz.Size = new Size(15, 14);
            cB_EUBilanz.TabIndex = 15;
            cB_EUBilanz.UseVisualStyleBackColor = true;
            cB_EUBilanz.Visible = false;
            cB_EUBilanz.CheckedChanged += cB_EUBilanz_CheckedChanged;
            // 
            // lL_ZurBilanz
            // 
            lL_ZurBilanz.ActiveLinkColor = Color.Salmon;
            lL_ZurBilanz.AutoSize = true;
            lL_ZurBilanz.Enabled = false;
            lL_ZurBilanz.LinkColor = Color.Aquamarine;
            lL_ZurBilanz.Location = new Point(540, 258);
            lL_ZurBilanz.Name = "lL_ZurBilanz";
            lL_ZurBilanz.Size = new Size(57, 15);
            lL_ZurBilanz.TabIndex = 10;
            lL_ZurBilanz.TabStop = true;
            lL_ZurBilanz.Text = "zur Bilanz";
            lL_ZurBilanz.Visible = false;
            lL_ZurBilanz.LinkClicked += lL_ZurBilanz_LinkClicked;
            // 
            // lL_zumEUR
            // 
            lL_zumEUR.ActiveLinkColor = Color.Salmon;
            lL_zumEUR.AutoSize = true;
            lL_zumEUR.LinkColor = Color.Aquamarine;
            lL_zumEUR.Location = new Point(210, 258);
            lL_zumEUR.Name = "lL_zumEUR";
            lL_zumEUR.Size = new Size(54, 15);
            lL_zumEUR.TabIndex = 9;
            lL_zumEUR.TabStop = true;
            lL_zumEUR.Text = "zum EÜR";
            lL_zumEUR.Visible = false;
            lL_zumEUR.LinkClicked += lL_zumEUR_LinkClicked;
            // 
            // l_GESBilanz
            // 
            l_GESBilanz.AutoSize = true;
            l_GESBilanz.Font = new Font("Segoe UI", 15F);
            l_GESBilanz.ForeColor = Color.White;
            l_GESBilanz.Location = new Point(630, 350);
            l_GESBilanz.Name = "l_GESBilanz";
            l_GESBilanz.Size = new Size(115, 28);
            l_GESBilanz.TabIndex = 18;
            l_GESBilanz.Text = "Gesellschaft";
            l_GESBilanz.Visible = false;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 15F);
            label27.ForeColor = Color.White;
            label27.Location = new Point(501, 200);
            label27.Name = "label27";
            label27.Size = new Size(149, 28);
            label27.TabIndex = 7;
            label27.Text = "(Bilanz Rechner)";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 15F);
            label26.ForeColor = Color.White;
            label26.Location = new Point(90, 200);
            label26.Name = "label26";
            label26.Size = new Size(297, 28);
            label26.TabIndex = 6;
            label26.Text = "(Einnahmen Überschuss Rechner)";
            // 
            // labelEUBilanz
            // 
            labelEUBilanz.AutoSize = true;
            labelEUBilanz.Font = new Font("Segoe UI", 15F);
            labelEUBilanz.ForeColor = Color.White;
            labelEUBilanz.Location = new Point(390, 350);
            labelEUBilanz.Name = "labelEUBilanz";
            labelEUBilanz.Size = new Size(178, 28);
            labelEUBilanz.TabIndex = 17;
            labelEUBilanz.Text = "Einzelunternehmen";
            labelEUBilanz.Visible = false;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 25F);
            label25.ForeColor = Color.White;
            label25.Location = new Point(519, 160);
            label25.Name = "label25";
            label25.Size = new Size(106, 46);
            label25.TabIndex = 5;
            label25.Text = "Bilanz";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 25F);
            label24.ForeColor = Color.White;
            label24.Location = new Point(196, 160);
            label24.Name = "label24";
            label24.Size = new Size(80, 46);
            label24.TabIndex = 4;
            label24.Text = "EÜR";
            // 
            // cB_Bilanz
            // 
            cB_Bilanz.AutoSize = true;
            cB_Bilanz.Font = new Font("Segoe UI", 20F);
            cB_Bilanz.ForeColor = Color.White;
            cB_Bilanz.Location = new Point(602, 235);
            cB_Bilanz.Name = "cB_Bilanz";
            cB_Bilanz.Size = new Size(15, 14);
            cB_Bilanz.TabIndex = 3;
            cB_Bilanz.UseVisualStyleBackColor = true;
            cB_Bilanz.Visible = false;
            cB_Bilanz.CheckedChanged += cB_Bilanz_CheckedChanged;
            // 
            // cB_EUR
            // 
            cB_EUR.AutoSize = true;
            cB_EUR.Font = new Font("Segoe UI", 20F);
            cB_EUR.ForeColor = Color.White;
            cB_EUR.Location = new Point(270, 234);
            cB_EUR.Name = "cB_EUR";
            cB_EUR.Size = new Size(15, 14);
            cB_EUR.TabIndex = 2;
            cB_EUR.UseVisualStyleBackColor = true;
            cB_EUR.Visible = false;
            cB_EUR.CheckedChanged += cB_EUR_CheckedChanged;
            // 
            // BTN_JAZurueck
            // 
            BTN_JAZurueck.Font = new Font("Segoe UI", 15F);
            BTN_JAZurueck.Location = new Point(356, 434);
            BTN_JAZurueck.Name = "BTN_JAZurueck";
            BTN_JAZurueck.Size = new Size(102, 44);
            BTN_JAZurueck.TabIndex = 1;
            BTN_JAZurueck.Text = "Zurück";
            BTN_JAZurueck.UseVisualStyleBackColor = true;
            BTN_JAZurueck.Click += BTN_JAZurueck_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            label21.ForeColor = Color.White;
            label21.Location = new Point(372, 10);
            label21.Name = "label21";
            label21.Size = new Size(58, 46);
            label21.TabIndex = 0;
            label21.Text = "JA";
            // 
            // panelStart
            // 
            panelStart.BackColor = Color.Transparent;
            panelStart.Controls.Add(cB_UN_new);
            panelStart.Controls.Add(l_comingSoon2);
            panelStart.Controls.Add(l_comingSoon);
            panelStart.Controls.Add(l_ProgressMandantenName);
            panelStart.Controls.Add(pB_Mandanten);
            panelStart.Controls.Add(BTN_UploudExcel);
            panelStart.Controls.Add(label16);
            panelStart.Controls.Add(label7);
            panelStart.Controls.Add(label38);
            panelStart.Controls.Add(cB_StartUp);
            panelStart.Controls.Add(StartUp);
            panelStart.Controls.Add(UnternemenText);
            panelStart.Controls.Add(cB_Privat);
            panelStart.Controls.Add(cB_UN);
            panelStart.Controls.Add(PrivatText);
            panelStart.Location = new Point(300, 65);
            panelStart.Name = "panelStart";
            panelStart.Size = new Size(812, 513);
            panelStart.TabIndex = 30;
            // 
            // cB_UN_new
            // 
            cB_UN_new.AutoSize = true;
            cB_UN_new.BackColor = Color.Transparent;
            cB_UN_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_UN_new.CheckmarkColor = Color.Black;
            cB_UN_new.CornerRadius = 5;
            cB_UN_new.Location = new Point(380, 265);
            cB_UN_new.Name = "cB_UN_new";
            cB_UN_new.Size = new Size(29, 19);
            cB_UN_new.TabIndex = 22;
            cB_UN_new.Text = " ";
            cB_UN_new.UseVisualStyleBackColor = false;
            cB_UN_new.CheckedChanged += cB_UN_new_CheckedChanged;
            // 
            // l_comingSoon2
            // 
            l_comingSoon2.Anchor = AnchorStyles.None;
            l_comingSoon2.AutoSize = true;
            l_comingSoon2.ForeColor = Color.White;
            l_comingSoon2.Location = new Point(600, 256);
            l_comingSoon2.Name = "l_comingSoon2";
            l_comingSoon2.Size = new Size(86, 15);
            l_comingSoon2.TabIndex = 21;
            l_comingSoon2.Text = "coming soon...";
            l_comingSoon2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // l_comingSoon
            // 
            l_comingSoon.Anchor = AnchorStyles.None;
            l_comingSoon.AutoSize = true;
            l_comingSoon.ForeColor = Color.White;
            l_comingSoon.Location = new Point(142, 253);
            l_comingSoon.Name = "l_comingSoon";
            l_comingSoon.Size = new Size(86, 15);
            l_comingSoon.TabIndex = 20;
            l_comingSoon.Text = "coming soon...";
            l_comingSoon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // l_ProgressMandantenName
            // 
            l_ProgressMandantenName.Anchor = AnchorStyles.None;
            l_ProgressMandantenName.AutoSize = true;
            l_ProgressMandantenName.ForeColor = Color.White;
            l_ProgressMandantenName.Location = new Point(256, 478);
            l_ProgressMandantenName.Name = "l_ProgressMandantenName";
            l_ProgressMandantenName.Size = new Size(92, 15);
            l_ProgressMandantenName.TabIndex = 19;
            l_ProgressMandantenName.Text = "Progress Names";
            l_ProgressMandantenName.TextAlign = ContentAlignment.MiddleCenter;
            l_ProgressMandantenName.Visible = false;
            // 
            // pB_Mandanten
            // 
            pB_Mandanten.Location = new Point(253, 447);
            pB_Mandanten.Name = "pB_Mandanten";
            pB_Mandanten.Size = new Size(285, 19);
            pB_Mandanten.TabIndex = 18;
            pB_Mandanten.Visible = false;
            // 
            // BTN_UploudExcel
            // 
            BTN_UploudExcel.Location = new Point(320, 418);
            BTN_UploudExcel.Name = "BTN_UploudExcel";
            BTN_UploudExcel.Size = new Size(141, 23);
            BTN_UploudExcel.TabIndex = 17;
            BTN_UploudExcel.Text = "Excel Liste hochladen";
            BTN_UploudExcel.UseVisualStyleBackColor = true;
            BTN_UploudExcel.Click += BTNUploudExcel_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 25F);
            label16.ForeColor = Color.White;
            label16.Location = new Point(240, 370);
            label16.Name = "label16";
            label16.Size = new Size(314, 46);
            label16.TabIndex = 16;
            label16.Text = "Liste an Mandanten";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(291, 416);
            label7.Name = "label7";
            label7.Size = new Size(0, 28);
            label7.TabIndex = 15;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            label38.ForeColor = Color.White;
            label38.Location = new Point(285, 27);
            label38.Name = "label38";
            label38.Size = new Size(211, 46);
            label38.TabIndex = 14;
            label38.Text = "Mandatstyp";
            // 
            // cB_StartUp
            // 
            cB_StartUp.AutoSize = true;
            cB_StartUp.BackColor = Color.Transparent;
            cB_StartUp.Enabled = false;
            cB_StartUp.ImageAlign = ContentAlignment.TopLeft;
            cB_StartUp.Location = new Point(635, 270);
            cB_StartUp.MaximumSize = new Size(50, 50);
            cB_StartUp.Name = "cB_StartUp";
            cB_StartUp.Size = new Size(15, 14);
            cB_StartUp.TabIndex = 13;
            cB_StartUp.UseVisualStyleBackColor = false;
            cB_StartUp.Visible = false;
            cB_StartUp.CheckedChanged += cB_StartUp_CheckedChanged;
            // 
            // StartUp
            // 
            StartUp.AutoSize = true;
            StartUp.Font = new Font("Segoe UI", 25F);
            StartUp.ForeColor = Color.White;
            StartUp.Location = new Point(573, 210);
            StartUp.Name = "StartUp";
            StartUp.Size = new Size(133, 46);
            StartUp.TabIndex = 12;
            StartUp.Text = "StartUp";
            StartUp.TextAlign = ContentAlignment.TopCenter;
            // 
            // BTN_UpdateExcelList
            // 
            BTN_UpdateExcelList.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BTN_UpdateExcelList.Location = new Point(90, 589);
            BTN_UpdateExcelList.Name = "BTN_UpdateExcelList";
            BTN_UpdateExcelList.Size = new Size(144, 40);
            BTN_UpdateExcelList.TabIndex = 15;
            BTN_UpdateExcelList.Text = "Update Excel";
            BTN_UpdateExcelList.UseVisualStyleBackColor = true;
            BTN_UpdateExcelList.Click += BTN_ExcelList_Click;
            // 
            // BTN_Weiter
            // 
            BTN_Weiter.BackColor = Color.FromArgb(0, 116, 189);
            BTN_Weiter.BackgroundImageLayout = ImageLayout.Stretch;
            BTN_Weiter.Font = new Font("Segoe UI", 15F);
            BTN_Weiter.ForeColor = Color.White;
            BTN_Weiter.ImageAlign = ContentAlignment.TopLeft;
            BTN_Weiter.Location = new Point(1005, 607);
            BTN_Weiter.Name = "BTN_Weiter";
            BTN_Weiter.Size = new Size(116, 52);
            BTN_Weiter.TabIndex = 14;
            BTN_Weiter.Text = "Weiter";
            BTN_Weiter.UseVisualStyleBackColor = false;
            BTN_Weiter.Click += BTN_Weiter_Click;
            // 
            // BTN_Zurueck
            // 
            BTN_Zurueck.BackColor = Color.FromArgb(0, 116, 189);
            BTN_Zurueck.Enabled = false;
            BTN_Zurueck.Font = new Font("Segoe UI", 15F);
            BTN_Zurueck.ForeColor = Color.White;
            BTN_Zurueck.Location = new Point(296, 607);
            BTN_Zurueck.Name = "BTN_Zurueck";
            BTN_Zurueck.Size = new Size(119, 50);
            BTN_Zurueck.TabIndex = 17;
            BTN_Zurueck.Text = "Zurück";
            BTN_Zurueck.UseVisualStyleBackColor = false;
            BTN_Zurueck.Click += BTN_Zurueck_Click;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // label3
            // 
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // l_Leistung
            // 
            l_Leistung.Location = new Point(0, 0);
            l_Leistung.Name = "l_Leistung";
            l_Leistung.Size = new Size(100, 23);
            l_Leistung.TabIndex = 0;
            // 
            // l_Leistungen
            // 
            l_Leistungen.Location = new Point(0, 0);
            l_Leistungen.Name = "l_Leistungen";
            l_Leistungen.Size = new Size(100, 23);
            l_Leistungen.TabIndex = 0;
            // 
            // l_currentJahresHonorar
            // 
            l_currentJahresHonorar.AutoSize = true;
            l_currentJahresHonorar.BackColor = Color.Transparent;
            l_currentJahresHonorar.Font = new Font("Segoe UI", 25F);
            l_currentJahresHonorar.ForeColor = Color.White;
            l_currentJahresHonorar.Location = new Point(767, 595);
            l_currentJahresHonorar.Name = "l_currentJahresHonorar";
            l_currentJahresHonorar.Size = new Size(108, 46);
            l_currentJahresHonorar.TabIndex = 18;
            l_currentJahresHonorar.Text = "0,00 €";
            // 
            // l_AktuellesAngebot
            // 
            l_AktuellesAngebot.AutoSize = true;
            l_AktuellesAngebot.BackColor = Color.Transparent;
            l_AktuellesAngebot.Font = new Font("Segoe UI", 25F);
            l_AktuellesAngebot.ForeColor = Color.White;
            l_AktuellesAngebot.Location = new Point(520, 595);
            l_AktuellesAngebot.Name = "l_AktuellesAngebot";
            l_AktuellesAngebot.Size = new Size(252, 46);
            l_AktuellesAngebot.TabIndex = 19;
            l_AktuellesAngebot.Text = "Jahres Honorar:";
            // 
            // l_currentMonatsHonorar
            // 
            l_currentMonatsHonorar.AutoSize = true;
            l_currentMonatsHonorar.BackColor = Color.Transparent;
            l_currentMonatsHonorar.Font = new Font("Segoe UI", 15F);
            l_currentMonatsHonorar.ForeColor = Color.White;
            l_currentMonatsHonorar.Location = new Point(772, 641);
            l_currentMonatsHonorar.Name = "l_currentMonatsHonorar";
            l_currentMonatsHonorar.Size = new Size(65, 28);
            l_currentMonatsHonorar.TabIndex = 20;
            l_currentMonatsHonorar.Text = "0,00 €";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(601, 641);
            label5.Name = "label5";
            label5.Size = new Size(160, 28);
            label5.TabIndex = 21;
            label5.Text = "Monats Honorar:";
            // 
            // panelEUR
            // 
            panelEUR.Controls.Add(l_EURMin);
            panelEUR.Controls.Add(label19);
            panelEUR.Controls.Add(label35);
            panelEUR.Controls.Add(label39);
            panelEUR.Controls.Add(l_EURWSMonatlich);
            panelEUR.Controls.Add(tB_Umsatzsteuererklärung);
            panelEUR.Controls.Add(tB_Gewerbesteuer);
            panelEUR.Controls.Add(tB_UdB);
            panelEUR.Controls.Add(tB_BEA);
            panelEUR.Controls.Add(cB_UdB);
            panelEUR.Controls.Add(l_AbschlussarbeitenZS);
            panelEUR.Controls.Add(tB_PfA);
            panelEUR.Controls.Add(l_Abschlussarbeiten);
            panelEUR.Controls.Add(label54);
            panelEUR.Controls.Add(label55);
            panelEUR.Controls.Add(l_Umsatzsteuererklärung);
            panelEUR.Controls.Add(l_UmsatzsteuererklärungSatz);
            panelEUR.Controls.Add(l_MinUmsatzsteuererklaerung);
            panelEUR.Controls.Add(label51);
            panelEUR.Controls.Add(l_UeberschussdBetriebseinnahmen);
            panelEUR.Controls.Add(l_SEzEdUdBSatz);
            panelEUR.Controls.Add(l_MinUEdB);
            panelEUR.Controls.Add(label47);
            panelEUR.Controls.Add(l_Gewerbesteuer);
            panelEUR.Controls.Add(l_GewerbesteuerSatz);
            panelEUR.Controls.Add(l_MinGewerbesteuer);
            panelEUR.Controls.Add(label42);
            panelEUR.Controls.Add(label30);
            panelEUR.Controls.Add(BTN_EURZurueck);
            panelEUR.Controls.Add(label34);
            panelEUR.Controls.Add(l_EURWS);
            panelEUR.Controls.Add(label36);
            panelEUR.Controls.Add(labelBEA);
            panelEUR.Controls.Add(label44);
            panelEUR.Controls.Add(l_BEASatz);
            panelEUR.Controls.Add(l_MinBAE);
            panelEUR.Controls.Add(l_Betriebseinaus);
            panelEUR.Controls.Add(label29);
            panelEUR.Controls.Add(cB_UdB_new);
            panelEUR.Location = new Point(300, 65);
            panelEUR.Name = "panelEUR";
            panelEUR.Size = new Size(876, 506);
            panelEUR.TabIndex = 11;
            panelEUR.Visible = false;
            // 
            // l_EURMin
            // 
            l_EURMin.AutoSize = true;
            l_EURMin.Font = new Font("Segoe UI", 10F);
            l_EURMin.ForeColor = Color.White;
            l_EURMin.Location = new Point(704, 434);
            l_EURMin.Name = "l_EURMin";
            l_EURMin.Size = new Size(94, 19);
            l_EURMin.TabIndex = 135;
            l_EURMin.Text = "min. 110,00 €";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F);
            label19.ForeColor = Color.White;
            label19.Location = new Point(501, 478);
            label19.Name = "label19";
            label19.Size = new Size(64, 21);
            label19.TabIndex = 134;
            label19.Text = "jährlich:";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Segoe UI", 12F);
            label35.ForeColor = Color.White;
            label35.Location = new Point(483, 450);
            label35.Name = "label35";
            label35.Size = new Size(82, 21);
            label35.TabIndex = 133;
            label35.Text = "monatlich:";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Segoe UI", 15F);
            label39.ForeColor = Color.White;
            label39.Location = new Point(566, 444);
            label39.Name = "label39";
            label39.Size = new Size(158, 28);
            label39.TabIndex = 132;
            label39.Text = "Zwischensumme:";
            // 
            // l_EURWSMonatlich
            // 
            l_EURWSMonatlich.AutoSize = true;
            l_EURWSMonatlich.Font = new Font("Segoe UI", 15F);
            l_EURWSMonatlich.ForeColor = Color.White;
            l_EURWSMonatlich.Location = new Point(723, 444);
            l_EURWSMonatlich.Name = "l_EURWSMonatlich";
            l_EURWSMonatlich.Size = new Size(60, 28);
            l_EURWSMonatlich.TabIndex = 131;
            l_EURWSMonatlich.Text = "0,00€";
            // 
            // tB_Umsatzsteuererklärung
            // 
            tB_Umsatzsteuererklärung.Enabled = false;
            tB_Umsatzsteuererklärung.Location = new Point(180, 330);
            tB_Umsatzsteuererklärung.Name = "tB_Umsatzsteuererklärung";
            tB_Umsatzsteuererklärung.Size = new Size(100, 23);
            tB_Umsatzsteuererklärung.TabIndex = 58;
            tB_Umsatzsteuererklärung.Text = "17.500 €";
            tB_Umsatzsteuererklärung.TextAlign = HorizontalAlignment.Right;
            // 
            // tB_Gewerbesteuer
            // 
            tB_Gewerbesteuer.Enabled = false;
            tB_Gewerbesteuer.Location = new Point(180, 190);
            tB_Gewerbesteuer.Name = "tB_Gewerbesteuer";
            tB_Gewerbesteuer.Size = new Size(100, 23);
            tB_Gewerbesteuer.TabIndex = 47;
            tB_Gewerbesteuer.Text = "8000 €";
            tB_Gewerbesteuer.TextAlign = HorizontalAlignment.Right;
            // 
            // tB_UdB
            // 
            tB_UdB.Enabled = false;
            tB_UdB.Location = new Point(180, 260);
            tB_UdB.Name = "tB_UdB";
            tB_UdB.Size = new Size(100, 23);
            tB_UdB.TabIndex = 53;
            tB_UdB.Text = "17.500 €";
            tB_UdB.TextAlign = HorizontalAlignment.Right;
            // 
            // tB_BEA
            // 
            tB_BEA.Enabled = false;
            tB_BEA.Location = new Point(180, 120);
            tB_BEA.Name = "tB_BEA";
            tB_BEA.Size = new Size(100, 23);
            tB_BEA.TabIndex = 9;
            tB_BEA.Text = "17.500 €";
            tB_BEA.TextAlign = HorizontalAlignment.Right;
            tB_BEA.TextChanged += tB_BEA_TextChanged;
            // 
            // cB_UdB
            // 
            cB_UdB.AutoSize = true;
            cB_UdB.Location = new Point(10, 263);
            cB_UdB.Name = "cB_UdB";
            cB_UdB.Size = new Size(15, 14);
            cB_UdB.TabIndex = 70;
            cB_UdB.UseVisualStyleBackColor = true;
            cB_UdB.Visible = false;
            cB_UdB.CheckedChanged += cB_UdB_CheckedChanged;
            // 
            // l_AbschlussarbeitenZS
            // 
            l_AbschlussarbeitenZS.AutoSize = true;
            l_AbschlussarbeitenZS.Font = new Font("Segoe UI", 12F);
            l_AbschlussarbeitenZS.ForeColor = Color.White;
            l_AbschlussarbeitenZS.Location = new Point(400, 400);
            l_AbschlussarbeitenZS.Name = "l_AbschlussarbeitenZS";
            l_AbschlussarbeitenZS.Size = new Size(130, 21);
            l_AbschlussarbeitenZS.TabIndex = 68;
            l_AbschlussarbeitenZS.Text = "Pro Bescheid 25€";
            // 
            // tB_PfA
            // 
            tB_PfA.Enabled = false;
            tB_PfA.Location = new Point(180, 400);
            tB_PfA.Name = "tB_PfA";
            tB_PfA.Size = new Size(100, 23);
            tB_PfA.TabIndex = 63;
            tB_PfA.Text = "1";
            tB_PfA.TextAlign = HorizontalAlignment.Right;
            // 
            // l_Abschlussarbeiten
            // 
            l_Abschlussarbeiten.AutoSize = true;
            l_Abschlussarbeiten.Font = new Font("Segoe UI", 12F);
            l_Abschlussarbeiten.ForeColor = Color.White;
            l_Abschlussarbeiten.Location = new Point(675, 400);
            l_Abschlussarbeiten.Name = "l_Abschlussarbeiten";
            l_Abschlussarbeiten.Size = new Size(49, 21);
            l_Abschlussarbeiten.TabIndex = 67;
            l_Abschlussarbeiten.Text = "0,00€";
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Font = new Font("Segoe UI", 7F);
            label54.ForeColor = Color.White;
            label54.Location = new Point(179, 422);
            label54.Name = "label54";
            label54.Size = new Size(102, 12);
            label54.TabIndex = 65;
            label54.Text = "Anzahl an Bescheiden";
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Font = new Font("Segoe UI", 12F);
            label55.ForeColor = Color.White;
            label55.Location = new Point(53, 375);
            label55.Name = "label55";
            label55.Size = new Size(232, 21);
            label55.TabIndex = 64;
            label55.Text = "Pauschale für Abschlussarbeiten";
            // 
            // l_Umsatzsteuererklärung
            // 
            l_Umsatzsteuererklärung.AutoSize = true;
            l_Umsatzsteuererklärung.Font = new Font("Segoe UI", 12F);
            l_Umsatzsteuererklärung.ForeColor = Color.White;
            l_Umsatzsteuererklärung.Location = new Point(675, 330);
            l_Umsatzsteuererklärung.Name = "l_Umsatzsteuererklärung";
            l_Umsatzsteuererklärung.Size = new Size(49, 21);
            l_Umsatzsteuererklärung.TabIndex = 62;
            l_Umsatzsteuererklärung.Text = "0,00€";
            // 
            // l_UmsatzsteuererklärungSatz
            // 
            l_UmsatzsteuererklärungSatz.AutoSize = true;
            l_UmsatzsteuererklärungSatz.Font = new Font("Segoe UI", 12F);
            l_UmsatzsteuererklärungSatz.ForeColor = Color.White;
            l_UmsatzsteuererklärungSatz.Location = new Point(400, 330);
            l_UmsatzsteuererklärungSatz.Name = "l_UmsatzsteuererklärungSatz";
            l_UmsatzsteuererklärungSatz.Size = new Size(43, 21);
            l_UmsatzsteuererklärungSatz.TabIndex = 61;
            l_UmsatzsteuererklärungSatz.Text = "3/10";
            // 
            // l_MinUmsatzsteuererklaerung
            // 
            l_MinUmsatzsteuererklaerung.AutoSize = true;
            l_MinUmsatzsteuererklaerung.Font = new Font("Segoe UI", 7F);
            l_MinUmsatzsteuererklaerung.ForeColor = Color.White;
            l_MinUmsatzsteuererklaerung.Location = new Point(210, 353);
            l_MinUmsatzsteuererklaerung.Name = "l_MinUmsatzsteuererklaerung";
            l_MinUmsatzsteuererklaerung.Size = new Size(69, 12);
            l_MinUmsatzsteuererklaerung.TabIndex = 60;
            l_MinUmsatzsteuererklaerung.Text = "min. 8.000,00 €";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Font = new Font("Segoe UI", 12F);
            label51.ForeColor = Color.White;
            label51.Location = new Point(114, 305);
            label51.Name = "label51";
            label51.Size = new Size(172, 21);
            label51.TabIndex = 59;
            label51.Text = "Umsatzsteuererklärung";
            // 
            // l_UeberschussdBetriebseinnahmen
            // 
            l_UeberschussdBetriebseinnahmen.AutoSize = true;
            l_UeberschussdBetriebseinnahmen.Font = new Font("Segoe UI", 12F);
            l_UeberschussdBetriebseinnahmen.ForeColor = Color.White;
            l_UeberschussdBetriebseinnahmen.Location = new Point(675, 260);
            l_UeberschussdBetriebseinnahmen.Name = "l_UeberschussdBetriebseinnahmen";
            l_UeberschussdBetriebseinnahmen.Size = new Size(49, 21);
            l_UeberschussdBetriebseinnahmen.TabIndex = 57;
            l_UeberschussdBetriebseinnahmen.Text = "0,00€";
            // 
            // l_SEzEdUdBSatz
            // 
            l_SEzEdUdBSatz.AutoSize = true;
            l_SEzEdUdBSatz.Font = new Font("Segoe UI", 12F);
            l_SEzEdUdBSatz.ForeColor = Color.White;
            l_SEzEdUdBSatz.Location = new Point(400, 260);
            l_SEzEdUdBSatz.Name = "l_SEzEdUdBSatz";
            l_SEzEdUdBSatz.Size = new Size(43, 21);
            l_SEzEdUdBSatz.TabIndex = 56;
            l_SEzEdUdBSatz.Text = "7/10";
            // 
            // l_MinUEdB
            // 
            l_MinUEdB.AutoSize = true;
            l_MinUEdB.Font = new Font("Segoe UI", 7F);
            l_MinUEdB.ForeColor = Color.White;
            l_MinUEdB.Location = new Point(205, 283);
            l_MinUEdB.Name = "l_MinUEdB";
            l_MinUEdB.Size = new Size(74, 12);
            l_MinUEdB.TabIndex = 55;
            l_MinUEdB.Text = "min. 17.500,00 €";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Font = new Font("Segoe UI", 12F);
            label47.ForeColor = Color.White;
            label47.Location = new Point(30, 235);
            label47.Name = "label47";
            label47.Size = new Size(255, 21);
            label47.TabIndex = 54;
            label47.Text = "Überschuss der Betriebseinnahmen";
            // 
            // l_Gewerbesteuer
            // 
            l_Gewerbesteuer.AutoSize = true;
            l_Gewerbesteuer.Font = new Font("Segoe UI", 12F);
            l_Gewerbesteuer.ForeColor = Color.White;
            l_Gewerbesteuer.Location = new Point(675, 190);
            l_Gewerbesteuer.Name = "l_Gewerbesteuer";
            l_Gewerbesteuer.Size = new Size(49, 21);
            l_Gewerbesteuer.TabIndex = 52;
            l_Gewerbesteuer.Text = "0,00€";
            // 
            // l_GewerbesteuerSatz
            // 
            l_GewerbesteuerSatz.AutoSize = true;
            l_GewerbesteuerSatz.Font = new Font("Segoe UI", 12F);
            l_GewerbesteuerSatz.ForeColor = Color.White;
            l_GewerbesteuerSatz.Location = new Point(400, 190);
            l_GewerbesteuerSatz.Name = "l_GewerbesteuerSatz";
            l_GewerbesteuerSatz.Size = new Size(43, 21);
            l_GewerbesteuerSatz.TabIndex = 50;
            l_GewerbesteuerSatz.Text = "3/10";
            // 
            // l_MinGewerbesteuer
            // 
            l_MinGewerbesteuer.AutoSize = true;
            l_MinGewerbesteuer.Font = new Font("Segoe UI", 7F);
            l_MinGewerbesteuer.ForeColor = Color.White;
            l_MinGewerbesteuer.Location = new Point(212, 213);
            l_MinGewerbesteuer.Name = "l_MinGewerbesteuer";
            l_MinGewerbesteuer.Size = new Size(67, 12);
            l_MinGewerbesteuer.TabIndex = 49;
            l_MinGewerbesteuer.Text = "min. 8000,00 €";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Segoe UI", 12F);
            label42.ForeColor = Color.White;
            label42.Location = new Point(170, 165);
            label42.Name = "label42";
            label42.Size = new Size(115, 21);
            label42.TabIndex = 48;
            label42.Text = "Gewerbesteuer";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            label30.ForeColor = Color.White;
            label30.Location = new Point(336, 0);
            label30.Name = "label30";
            label30.Size = new Size(85, 46);
            label30.TabIndex = 7;
            label30.Text = "EÜR";
            // 
            // BTN_EURZurueck
            // 
            BTN_EURZurueck.Font = new Font("Segoe UI", 15F);
            BTN_EURZurueck.Location = new Point(330, 445);
            BTN_EURZurueck.Name = "BTN_EURZurueck";
            BTN_EURZurueck.Size = new Size(102, 44);
            BTN_EURZurueck.TabIndex = 46;
            BTN_EURZurueck.Text = "Zurück";
            BTN_EURZurueck.UseVisualStyleBackColor = true;
            BTN_EURZurueck.Click += BTN_EURZurueck_Click;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI", 15F);
            label34.ForeColor = Color.White;
            label34.Location = new Point(566, 473);
            label34.Name = "label34";
            label34.Size = new Size(158, 28);
            label34.TabIndex = 45;
            label34.Text = "Zwischensumme:";
            // 
            // l_EURWS
            // 
            l_EURWS.AutoSize = true;
            l_EURWS.Font = new Font("Segoe UI", 15F);
            l_EURWS.ForeColor = Color.White;
            l_EURWS.Location = new Point(723, 473);
            l_EURWS.Name = "l_EURWS";
            l_EURWS.Size = new Size(60, 28);
            l_EURWS.TabIndex = 34;
            l_EURWS.Text = "0,00€";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label36.ForeColor = Color.White;
            label36.Location = new Point(650, 80);
            label36.Name = "label36";
            label36.Size = new Size(81, 28);
            label36.TabIndex = 44;
            label36.Text = "Jährlich:";
            // 
            // labelBEA
            // 
            labelBEA.AutoSize = true;
            labelBEA.Font = new Font("Segoe UI", 12F);
            labelBEA.ForeColor = Color.White;
            labelBEA.Location = new Point(675, 120);
            labelBEA.Name = "labelBEA";
            labelBEA.Size = new Size(49, 21);
            labelBEA.TabIndex = 37;
            labelBEA.Text = "0,00€";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label44.ForeColor = Color.White;
            label44.Location = new Point(400, 80);
            label44.Name = "label44";
            label44.Size = new Size(49, 28);
            label44.TabIndex = 36;
            label44.Text = "Satz";
            // 
            // l_BEASatz
            // 
            l_BEASatz.AutoSize = true;
            l_BEASatz.Font = new Font("Segoe UI", 12F);
            l_BEASatz.ForeColor = Color.White;
            l_BEASatz.Location = new Point(400, 120);
            l_BEASatz.Name = "l_BEASatz";
            l_BEASatz.Size = new Size(52, 21);
            l_BEASatz.TabIndex = 35;
            l_BEASatz.Text = "15/10";
            // 
            // l_MinBAE
            // 
            l_MinBAE.AutoSize = true;
            l_MinBAE.Font = new Font("Segoe UI", 7F);
            l_MinBAE.ForeColor = Color.White;
            l_MinBAE.Location = new Point(205, 143);
            l_MinBAE.Name = "l_MinBAE";
            l_MinBAE.Size = new Size(74, 12);
            l_MinBAE.TabIndex = 11;
            l_MinBAE.Text = "min. 17.500,00 €";
            // 
            // l_Betriebseinaus
            // 
            l_Betriebseinaus.AutoSize = true;
            l_Betriebseinaus.Font = new Font("Segoe UI", 12F);
            l_Betriebseinaus.ForeColor = Color.White;
            l_Betriebseinaus.Location = new Point(60, 95);
            l_Betriebseinaus.Name = "l_Betriebseinaus";
            l_Betriebseinaus.Size = new Size(223, 21);
            l_Betriebseinaus.TabIndex = 10;
            l_Betriebseinaus.Text = "Betriebs Einnahmen-Ausgaben";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 15F);
            label29.ForeColor = Color.White;
            label29.Location = new Point(236, 40);
            label29.Name = "label29";
            label29.Size = new Size(297, 28);
            label29.TabIndex = 8;
            label29.Text = "(Einnahmen Überschuss Rechner)\r\n";
            // 
            // cB_UdB_new
            // 
            cB_UdB_new.AutoSize = true;
            cB_UdB_new.BackColor = Color.Transparent;
            cB_UdB_new.CheckedBoxColor = Color.Aquamarine;
            cB_UdB_new.CheckmarkColor = Color.Black;
            cB_UdB_new.CornerRadius = 8;
            cB_UdB_new.Location = new Point(10, 235);
            cB_UdB_new.Name = "cB_UdB_new";
            cB_UdB_new.Size = new Size(29, 19);
            cB_UdB_new.TabIndex = 136;
            cB_UdB_new.Text = " ";
            cB_UdB_new.UseVisualStyleBackColor = false;
            cB_UdB_new.CheckedChanged += cB_UdB_new_CheckedChanged;
            // 
            // panelBilanz
            // 
            panelBilanz.Controls.Add(l_BilanzMin);
            panelBilanz.Controls.Add(label33);
            panelBilanz.Controls.Add(label20);
            panelBilanz.Controls.Add(label18);
            panelBilanz.Controls.Add(l_BilanzZSMonatlich);
            panelBilanz.Controls.Add(label79);
            panelBilanz.Controls.Add(label72);
            panelBilanz.Controls.Add(l_Offenlegung);
            panelBilanz.Controls.Add(label37);
            panelBilanz.Controls.Add(l_BilanzBescheideSatz);
            panelBilanz.Controls.Add(tB_BilanzBescheide);
            panelBilanz.Controls.Add(l_BilanzBescheide);
            panelBilanz.Controls.Add(label63);
            panelBilanz.Controls.Add(l_E_Bilanz);
            panelBilanz.Controls.Add(label82);
            panelBilanz.Controls.Add(label83);
            panelBilanz.Controls.Add(l_UmsatzsteuererklDesKJ);
            panelBilanz.Controls.Add(l_UmsatzsteuererklFDasKJSatz);
            panelBilanz.Controls.Add(l_MinUmsatzsteuererklFDasKJ);
            panelBilanz.Controls.Add(label87);
            panelBilanz.Controls.Add(tB_UmsatzsteuererklaerungdesKJ);
            panelBilanz.Controls.Add(l_MinErklZurGewerbersteuer);
            panelBilanz.Controls.Add(l_ErklZurGewerbesteuerSatz);
            panelBilanz.Controls.Add(tB_ErklzurGewerbesteuer);
            panelBilanz.Controls.Add(tB_ErstellungdesAntrags);
            panelBilanz.Controls.Add(l_ErklaerungZurGewerbesteuer);
            panelBilanz.Controls.Add(label43);
            panelBilanz.Controls.Add(l_KoerperschaftsST);
            panelBilanz.Controls.Add(l_KoerperschaftssteuererklSatz);
            panelBilanz.Controls.Add(l_MinKoerperschaftssteuererkl);
            panelBilanz.Controls.Add(label52);
            panelBilanz.Controls.Add(tB_Koerperschaftssteuererklaerung);
            panelBilanz.Controls.Add(l_EntwEinerSteuerbilanz);
            panelBilanz.Controls.Add(l_EntwicklungEinerSteuerbilanzSatz);
            panelBilanz.Controls.Add(l_MinEntwEinerSteuerbilanz);
            panelBilanz.Controls.Add(label58);
            panelBilanz.Controls.Add(tB_EntwEinerSteuerbilanz);
            panelBilanz.Controls.Add(l_ErstDesAntrags);
            panelBilanz.Controls.Add(l_ErstellungDesAntragsSatz);
            panelBilanz.Controls.Add(l_MinErstellungDesAntrags);
            panelBilanz.Controls.Add(label62);
            panelBilanz.Controls.Add(l_TXTZwischensumme);
            panelBilanz.Controls.Add(l_BilanzZS);
            panelBilanz.Controls.Add(l_AdJA);
            panelBilanz.Controls.Add(l_AdJSatz);
            panelBilanz.Controls.Add(l_MinAdJ);
            panelBilanz.Controls.Add(label71);
            panelBilanz.Controls.Add(tB_AdJA);
            panelBilanz.Controls.Add(BTN_ZurueckBilanz);
            panelBilanz.Controls.Add(l_BilanzUeberschrift);
            panelBilanz.Location = new Point(300, 65);
            panelBilanz.Name = "panelBilanz";
            panelBilanz.Size = new Size(890, 503);
            panelBilanz.TabIndex = 71;
            panelBilanz.Visible = false;
            // 
            // l_BilanzMin
            // 
            l_BilanzMin.AutoSize = true;
            l_BilanzMin.Font = new Font("Segoe UI", 10F);
            l_BilanzMin.ForeColor = Color.White;
            l_BilanzMin.Location = new Point(700, 435);
            l_BilanzMin.Name = "l_BilanzMin";
            l_BilanzMin.Size = new Size(94, 19);
            l_BilanzMin.TabIndex = 131;
            l_BilanzMin.Text = "min. 220,00 €";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI", 12F);
            label33.ForeColor = Color.White;
            label33.Location = new Point(496, 479);
            label33.Name = "label33";
            label33.Size = new Size(64, 21);
            label33.TabIndex = 130;
            label33.Text = "jährlich:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.ForeColor = Color.White;
            label20.Location = new Point(478, 451);
            label20.Name = "label20";
            label20.Size = new Size(82, 21);
            label20.TabIndex = 129;
            label20.Text = "monatlich:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 15F);
            label18.ForeColor = Color.White;
            label18.Location = new Point(561, 445);
            label18.Name = "label18";
            label18.Size = new Size(158, 28);
            label18.TabIndex = 128;
            label18.Text = "Zwischensumme:";
            // 
            // l_BilanzZSMonatlich
            // 
            l_BilanzZSMonatlich.AutoSize = true;
            l_BilanzZSMonatlich.Font = new Font("Segoe UI", 15F);
            l_BilanzZSMonatlich.ForeColor = Color.White;
            l_BilanzZSMonatlich.Location = new Point(718, 445);
            l_BilanzZSMonatlich.Name = "l_BilanzZSMonatlich";
            l_BilanzZSMonatlich.Size = new Size(60, 28);
            l_BilanzZSMonatlich.TabIndex = 127;
            l_BilanzZSMonatlich.Text = "0,00€";
            // 
            // label79
            // 
            label79.AutoSize = true;
            label79.Font = new Font("Segoe UI", 12F);
            label79.ForeColor = Color.White;
            label79.Location = new Point(600, 373);
            label79.Name = "label79";
            label79.Size = new Size(100, 21);
            label79.TabIndex = 109;
            label79.Text = "Offenlegung:";
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Font = new Font("Segoe UI", 7F);
            label72.ForeColor = Color.White;
            label72.Location = new Point(650, 392);
            label72.Name = "label72";
            label72.Size = new Size(45, 12);
            label72.TabIndex = 126;
            label72.Text = "Fixbetrag";
            // 
            // l_Offenlegung
            // 
            l_Offenlegung.AutoSize = true;
            l_Offenlegung.Font = new Font("Segoe UI", 12F);
            l_Offenlegung.ForeColor = Color.White;
            l_Offenlegung.Location = new Point(700, 373);
            l_Offenlegung.Name = "l_Offenlegung";
            l_Offenlegung.Size = new Size(71, 21);
            l_Offenlegung.TabIndex = 125;
            l_Offenlegung.Text = "110,00 €";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Segoe UI", 7F);
            label37.ForeColor = Color.White;
            label37.Location = new Point(643, 325);
            label37.Name = "label37";
            label37.Size = new Size(33, 12);
            label37.TabIndex = 119;
            label37.Text = "i.d.R. 4";
            // 
            // l_BilanzBescheideSatz
            // 
            l_BilanzBescheideSatz.AutoSize = true;
            l_BilanzBescheideSatz.Font = new Font("Segoe UI", 12F);
            l_BilanzBescheideSatz.ForeColor = Color.White;
            l_BilanzBescheideSatz.Location = new Point(439, 300);
            l_BilanzBescheideSatz.Name = "l_BilanzBescheideSatz";
            l_BilanzBescheideSatz.Size = new Size(130, 21);
            l_BilanzBescheideSatz.TabIndex = 122;
            l_BilanzBescheideSatz.Text = "pro Bescheid 25€";
            // 
            // tB_BilanzBescheide
            // 
            tB_BilanzBescheide.Enabled = false;
            tB_BilanzBescheide.Location = new Point(577, 300);
            tB_BilanzBescheide.Name = "tB_BilanzBescheide";
            tB_BilanzBescheide.Size = new Size(100, 23);
            tB_BilanzBescheide.TabIndex = 117;
            tB_BilanzBescheide.Text = "4";
            tB_BilanzBescheide.TextAlign = HorizontalAlignment.Right;
            // 
            // l_BilanzBescheide
            // 
            l_BilanzBescheide.AutoSize = true;
            l_BilanzBescheide.Font = new Font("Segoe UI", 12F);
            l_BilanzBescheide.ForeColor = Color.White;
            l_BilanzBescheide.Location = new Point(700, 300);
            l_BilanzBescheide.Name = "l_BilanzBescheide";
            l_BilanzBescheide.Size = new Size(71, 21);
            l_BilanzBescheide.TabIndex = 121;
            l_BilanzBescheide.Text = "100,00 €";
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Font = new Font("Segoe UI", 12F);
            label63.ForeColor = Color.White;
            label63.Location = new Point(600, 275);
            label63.Name = "label63";
            label63.Size = new Size(79, 21);
            label63.TabIndex = 120;
            label63.Text = "Bescheide";
            // 
            // l_E_Bilanz
            // 
            l_E_Bilanz.AutoSize = true;
            l_E_Bilanz.Font = new Font("Segoe UI", 12F);
            l_E_Bilanz.ForeColor = Color.White;
            l_E_Bilanz.Location = new Point(504, 373);
            l_E_Bilanz.Name = "l_E_Bilanz";
            l_E_Bilanz.Size = new Size(71, 21);
            l_E_Bilanz.TabIndex = 107;
            l_E_Bilanz.Text = "160,00 €";
            // 
            // label82
            // 
            label82.AutoSize = true;
            label82.Font = new Font("Segoe UI", 7F);
            label82.ForeColor = Color.White;
            label82.Location = new Point(459, 393);
            label82.Name = "label82";
            label82.Size = new Size(45, 12);
            label82.TabIndex = 105;
            label82.Text = "Fixbetrag";
            // 
            // label83
            // 
            label83.AutoSize = true;
            label83.Font = new Font("Segoe UI", 12F);
            label83.ForeColor = Color.White;
            label83.Location = new Point(439, 373);
            label83.Name = "label83";
            label83.Size = new Size(68, 21);
            label83.TabIndex = 104;
            label83.Text = "E-Bilanz:";
            // 
            // l_UmsatzsteuererklDesKJ
            // 
            l_UmsatzsteuererklDesKJ.AutoSize = true;
            l_UmsatzsteuererklDesKJ.Font = new Font("Segoe UI", 12F);
            l_UmsatzsteuererklDesKJ.ForeColor = Color.White;
            l_UmsatzsteuererklDesKJ.Location = new Point(700, 120);
            l_UmsatzsteuererklDesKJ.Name = "l_UmsatzsteuererklDesKJ";
            l_UmsatzsteuererklDesKJ.Size = new Size(49, 21);
            l_UmsatzsteuererklDesKJ.TabIndex = 102;
            l_UmsatzsteuererklDesKJ.Text = "0,00€";
            // 
            // l_UmsatzsteuererklFDasKJSatz
            // 
            l_UmsatzsteuererklFDasKJSatz.AutoSize = true;
            l_UmsatzsteuererklFDasKJSatz.Font = new Font("Segoe UI", 12F);
            l_UmsatzsteuererklFDasKJSatz.ForeColor = Color.White;
            l_UmsatzsteuererklFDasKJSatz.Location = new Point(450, 120);
            l_UmsatzsteuererklFDasKJSatz.Name = "l_UmsatzsteuererklFDasKJSatz";
            l_UmsatzsteuererklFDasKJSatz.Size = new Size(43, 21);
            l_UmsatzsteuererklFDasKJSatz.TabIndex = 101;
            l_UmsatzsteuererklFDasKJSatz.Text = "3/10";
            // 
            // l_MinUmsatzsteuererklFDasKJ
            // 
            l_MinUmsatzsteuererklFDasKJ.AutoSize = true;
            l_MinUmsatzsteuererklFDasKJ.Font = new Font("Segoe UI", 7F);
            l_MinUmsatzsteuererklFDasKJ.ForeColor = Color.White;
            l_MinUmsatzsteuererklFDasKJ.Location = new Point(612, 146);
            l_MinUmsatzsteuererklFDasKJ.Name = "l_MinUmsatzsteuererklFDasKJ";
            l_MinUmsatzsteuererklFDasKJ.Size = new Size(54, 12);
            l_MinUmsatzsteuererklFDasKJ.TabIndex = 100;
            l_MinUmsatzsteuererklFDasKJ.Text = "min. 8.000€";
            // 
            // label87
            // 
            label87.AutoSize = true;
            label87.Font = new Font("Segoe UI", 12F);
            label87.ForeColor = Color.White;
            label87.Location = new Point(435, 95);
            label87.Name = "label87";
            label87.Size = new Size(244, 21);
            label87.TabIndex = 99;
            label87.Text = "Umsatzsteuererklärung für das KJ";
            // 
            // tB_UmsatzsteuererklaerungdesKJ
            // 
            tB_UmsatzsteuererklaerungdesKJ.Enabled = false;
            tB_UmsatzsteuererklaerungdesKJ.Location = new Point(578, 120);
            tB_UmsatzsteuererklaerungdesKJ.Name = "tB_UmsatzsteuererklaerungdesKJ";
            tB_UmsatzsteuererklaerungdesKJ.Size = new Size(100, 23);
            tB_UmsatzsteuererklaerungdesKJ.TabIndex = 98;
            tB_UmsatzsteuererklaerungdesKJ.Text = "8.000,00 €";
            tB_UmsatzsteuererklaerungdesKJ.TextAlign = HorizontalAlignment.Right;
            // 
            // l_MinErklZurGewerbersteuer
            // 
            l_MinErklZurGewerbersteuer.AutoSize = true;
            l_MinErklZurGewerbersteuer.Font = new Font("Segoe UI", 7F);
            l_MinErklZurGewerbersteuer.ForeColor = Color.White;
            l_MinErklZurGewerbersteuer.Location = new Point(612, 246);
            l_MinErklZurGewerbersteuer.Name = "l_MinErklZurGewerbersteuer";
            l_MinErklZurGewerbersteuer.Size = new Size(54, 12);
            l_MinErklZurGewerbersteuer.TabIndex = 92;
            l_MinErklZurGewerbersteuer.Text = "min. 8.000€";
            // 
            // l_ErklZurGewerbesteuerSatz
            // 
            l_ErklZurGewerbesteuerSatz.AutoSize = true;
            l_ErklZurGewerbesteuerSatz.Font = new Font("Segoe UI", 12F);
            l_ErklZurGewerbesteuerSatz.ForeColor = Color.White;
            l_ErklZurGewerbesteuerSatz.Location = new Point(450, 220);
            l_ErklZurGewerbesteuerSatz.Name = "l_ErklZurGewerbesteuerSatz";
            l_ErklZurGewerbesteuerSatz.Size = new Size(43, 21);
            l_ErklZurGewerbesteuerSatz.TabIndex = 97;
            l_ErklZurGewerbesteuerSatz.Text = "3/10";
            // 
            // tB_ErklzurGewerbesteuer
            // 
            tB_ErklzurGewerbesteuer.Enabled = false;
            tB_ErklzurGewerbesteuer.Location = new Point(578, 220);
            tB_ErklzurGewerbesteuer.Name = "tB_ErklzurGewerbesteuer";
            tB_ErklzurGewerbesteuer.Size = new Size(100, 23);
            tB_ErklzurGewerbesteuer.TabIndex = 91;
            tB_ErklzurGewerbesteuer.Text = "16.000,00 €";
            tB_ErklzurGewerbesteuer.TextAlign = HorizontalAlignment.Right;
            // 
            // tB_ErstellungdesAntrags
            // 
            tB_ErstellungdesAntrags.Enabled = false;
            tB_ErstellungdesAntrags.Location = new Point(160, 210);
            tB_ErstellungdesAntrags.Name = "tB_ErstellungdesAntrags";
            tB_ErstellungdesAntrags.Size = new Size(100, 23);
            tB_ErstellungdesAntrags.TabIndex = 78;
            tB_ErstellungdesAntrags.Text = "3.000,00 €";
            tB_ErstellungdesAntrags.TextAlign = HorizontalAlignment.Right;
            // 
            // l_ErklaerungZurGewerbesteuer
            // 
            l_ErklaerungZurGewerbesteuer.AutoSize = true;
            l_ErklaerungZurGewerbesteuer.Font = new Font("Segoe UI", 12F);
            l_ErklaerungZurGewerbesteuer.ForeColor = Color.White;
            l_ErklaerungZurGewerbesteuer.Location = new Point(700, 220);
            l_ErklaerungZurGewerbesteuer.Name = "l_ErklaerungZurGewerbesteuer";
            l_ErklaerungZurGewerbesteuer.Size = new Size(49, 21);
            l_ErklaerungZurGewerbesteuer.TabIndex = 96;
            l_ErklaerungZurGewerbesteuer.Text = "0,00€";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Segoe UI", 12F);
            label43.ForeColor = Color.White;
            label43.Location = new Point(465, 195);
            label43.Name = "label43";
            label43.Size = new Size(212, 21);
            label43.TabIndex = 94;
            label43.Text = "Erklärung zur Gewerbesteuer";
            // 
            // l_KoerperschaftsST
            // 
            l_KoerperschaftsST.AutoSize = true;
            l_KoerperschaftsST.Font = new Font("Segoe UI", 12F);
            l_KoerperschaftsST.ForeColor = Color.White;
            l_KoerperschaftsST.Location = new Point(287, 390);
            l_KoerperschaftsST.Name = "l_KoerperschaftsST";
            l_KoerperschaftsST.Size = new Size(49, 21);
            l_KoerperschaftsST.TabIndex = 92;
            l_KoerperschaftsST.Text = "0,00€";
            // 
            // l_KoerperschaftssteuererklSatz
            // 
            l_KoerperschaftssteuererklSatz.AutoSize = true;
            l_KoerperschaftssteuererklSatz.Font = new Font("Segoe UI", 12F);
            l_KoerperschaftssteuererklSatz.ForeColor = Color.White;
            l_KoerperschaftssteuererklSatz.Location = new Point(40, 390);
            l_KoerperschaftssteuererklSatz.Name = "l_KoerperschaftssteuererklSatz";
            l_KoerperschaftssteuererklSatz.Size = new Size(43, 21);
            l_KoerperschaftssteuererklSatz.TabIndex = 91;
            l_KoerperschaftssteuererklSatz.Text = "3/10";
            // 
            // l_MinKoerperschaftssteuererkl
            // 
            l_MinKoerperschaftssteuererkl.AutoSize = true;
            l_MinKoerperschaftssteuererkl.Font = new Font("Segoe UI", 7F);
            l_MinKoerperschaftssteuererkl.ForeColor = Color.White;
            l_MinKoerperschaftssteuererkl.Location = new Point(189, 416);
            l_MinKoerperschaftssteuererkl.Name = "l_MinKoerperschaftssteuererkl";
            l_MinKoerperschaftssteuererkl.Size = new Size(59, 12);
            l_MinKoerperschaftssteuererkl.TabIndex = 90;
            l_MinKoerperschaftssteuererkl.Text = "min. 16.000€";
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Font = new Font("Segoe UI", 12F);
            label52.ForeColor = Color.White;
            label52.Location = new Point(48, 365);
            label52.Name = "label52";
            label52.Size = new Size(215, 21);
            label52.TabIndex = 89;
            label52.Text = "Körperschaftssteuererklärung";
            // 
            // tB_Koerperschaftssteuererklaerung
            // 
            tB_Koerperschaftssteuererklaerung.Enabled = false;
            tB_Koerperschaftssteuererklaerung.Location = new Point(160, 390);
            tB_Koerperschaftssteuererklaerung.Name = "tB_Koerperschaftssteuererklaerung";
            tB_Koerperschaftssteuererklaerung.Size = new Size(100, 23);
            tB_Koerperschaftssteuererklaerung.TabIndex = 88;
            tB_Koerperschaftssteuererklaerung.Text = "16.000,00 €";
            tB_Koerperschaftssteuererklaerung.TextAlign = HorizontalAlignment.Right;
            // 
            // l_EntwEinerSteuerbilanz
            // 
            l_EntwEinerSteuerbilanz.AutoSize = true;
            l_EntwEinerSteuerbilanz.Font = new Font("Segoe UI", 12F);
            l_EntwEinerSteuerbilanz.ForeColor = Color.White;
            l_EntwEinerSteuerbilanz.Location = new Point(285, 300);
            l_EntwEinerSteuerbilanz.Name = "l_EntwEinerSteuerbilanz";
            l_EntwEinerSteuerbilanz.Size = new Size(49, 21);
            l_EntwEinerSteuerbilanz.TabIndex = 87;
            l_EntwEinerSteuerbilanz.Text = "0,00€";
            // 
            // l_EntwicklungEinerSteuerbilanzSatz
            // 
            l_EntwicklungEinerSteuerbilanzSatz.AutoSize = true;
            l_EntwicklungEinerSteuerbilanzSatz.Font = new Font("Segoe UI", 12F);
            l_EntwicklungEinerSteuerbilanzSatz.ForeColor = Color.White;
            l_EntwicklungEinerSteuerbilanzSatz.Location = new Point(40, 300);
            l_EntwicklungEinerSteuerbilanzSatz.Name = "l_EntwicklungEinerSteuerbilanzSatz";
            l_EntwicklungEinerSteuerbilanzSatz.Size = new Size(43, 21);
            l_EntwicklungEinerSteuerbilanzSatz.TabIndex = 86;
            l_EntwicklungEinerSteuerbilanzSatz.Text = "5/10";
            // 
            // l_MinEntwEinerSteuerbilanz
            // 
            l_MinEntwEinerSteuerbilanz.AutoSize = true;
            l_MinEntwEinerSteuerbilanz.Font = new Font("Segoe UI", 7F);
            l_MinEntwEinerSteuerbilanz.ForeColor = Color.White;
            l_MinEntwEinerSteuerbilanz.Location = new Point(194, 326);
            l_MinEntwEinerSteuerbilanz.Name = "l_MinEntwEinerSteuerbilanz";
            l_MinEntwEinerSteuerbilanz.Size = new Size(54, 12);
            l_MinEntwEinerSteuerbilanz.TabIndex = 85;
            l_MinEntwEinerSteuerbilanz.Text = "min. 3.000€";
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Font = new Font("Segoe UI", 12F);
            label58.ForeColor = Color.White;
            label58.Location = new Point(31, 275);
            label58.Name = "label58";
            label58.Size = new Size(231, 21);
            label58.TabIndex = 84;
            label58.Text = "Entwicklung einer Stueuerbilanz";
            // 
            // tB_EntwEinerSteuerbilanz
            // 
            tB_EntwEinerSteuerbilanz.Enabled = false;
            tB_EntwEinerSteuerbilanz.Location = new Point(160, 300);
            tB_EntwEinerSteuerbilanz.Name = "tB_EntwEinerSteuerbilanz";
            tB_EntwEinerSteuerbilanz.Size = new Size(100, 23);
            tB_EntwEinerSteuerbilanz.TabIndex = 83;
            tB_EntwEinerSteuerbilanz.Text = "3.000,00 €";
            tB_EntwEinerSteuerbilanz.TextAlign = HorizontalAlignment.Right;
            // 
            // l_ErstDesAntrags
            // 
            l_ErstDesAntrags.AutoSize = true;
            l_ErstDesAntrags.Font = new Font("Segoe UI", 12F);
            l_ErstDesAntrags.ForeColor = Color.White;
            l_ErstDesAntrags.Location = new Point(284, 210);
            l_ErstDesAntrags.Name = "l_ErstDesAntrags";
            l_ErstDesAntrags.Size = new Size(49, 21);
            l_ErstDesAntrags.TabIndex = 82;
            l_ErstDesAntrags.Text = "0,00€";
            // 
            // l_ErstellungDesAntragsSatz
            // 
            l_ErstellungDesAntragsSatz.AutoSize = true;
            l_ErstellungDesAntragsSatz.Font = new Font("Segoe UI", 12F);
            l_ErstellungDesAntragsSatz.ForeColor = Color.White;
            l_ErstellungDesAntragsSatz.Location = new Point(40, 210);
            l_ErstellungDesAntragsSatz.Name = "l_ErstellungDesAntragsSatz";
            l_ErstellungDesAntragsSatz.Size = new Size(43, 21);
            l_ErstellungDesAntragsSatz.TabIndex = 81;
            l_ErstellungDesAntragsSatz.Text = "5/10";
            // 
            // l_MinErstellungDesAntrags
            // 
            l_MinErstellungDesAntrags.AutoSize = true;
            l_MinErstellungDesAntrags.Font = new Font("Segoe UI", 7F);
            l_MinErstellungDesAntrags.ForeColor = Color.White;
            l_MinErstellungDesAntrags.Location = new Point(194, 236);
            l_MinErstellungDesAntrags.Name = "l_MinErstellungDesAntrags";
            l_MinErstellungDesAntrags.Size = new Size(54, 12);
            l_MinErstellungDesAntrags.TabIndex = 80;
            l_MinErstellungDesAntrags.Text = "min. 3.000€";
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Font = new Font("Segoe UI", 12F);
            label62.ForeColor = Color.White;
            label62.Location = new Point(97, 185);
            label62.Name = "label62";
            label62.Size = new Size(165, 21);
            label62.TabIndex = 79;
            label62.Text = "Erstellung des Antrags";
            // 
            // l_TXTZwischensumme
            // 
            l_TXTZwischensumme.AutoSize = true;
            l_TXTZwischensumme.Font = new Font("Segoe UI", 15F);
            l_TXTZwischensumme.ForeColor = Color.White;
            l_TXTZwischensumme.Location = new Point(561, 473);
            l_TXTZwischensumme.Name = "l_TXTZwischensumme";
            l_TXTZwischensumme.Size = new Size(158, 28);
            l_TXTZwischensumme.TabIndex = 77;
            l_TXTZwischensumme.Text = "Zwischensumme:";
            // 
            // l_BilanzZS
            // 
            l_BilanzZS.AutoSize = true;
            l_BilanzZS.Font = new Font("Segoe UI", 15F);
            l_BilanzZS.ForeColor = Color.White;
            l_BilanzZS.Location = new Point(718, 473);
            l_BilanzZS.Name = "l_BilanzZS";
            l_BilanzZS.Size = new Size(60, 28);
            l_BilanzZS.TabIndex = 72;
            l_BilanzZS.Text = "0,00€";
            // 
            // l_AdJA
            // 
            l_AdJA.AutoSize = true;
            l_AdJA.Font = new Font("Segoe UI", 12F);
            l_AdJA.ForeColor = Color.White;
            l_AdJA.Location = new Point(286, 120);
            l_AdJA.Name = "l_AdJA";
            l_AdJA.Size = new Size(49, 21);
            l_AdJA.TabIndex = 75;
            l_AdJA.Text = "0,00€";
            // 
            // l_AdJSatz
            // 
            l_AdJSatz.AutoSize = true;
            l_AdJSatz.Font = new Font("Segoe UI", 12F);
            l_AdJSatz.ForeColor = Color.White;
            l_AdJSatz.Location = new Point(40, 120);
            l_AdJSatz.Name = "l_AdJSatz";
            l_AdJSatz.Size = new Size(52, 21);
            l_AdJSatz.TabIndex = 73;
            l_AdJSatz.Text = "30/10";
            // 
            // l_MinAdJ
            // 
            l_MinAdJ.AutoSize = true;
            l_MinAdJ.Font = new Font("Segoe UI", 7F);
            l_MinAdJ.ForeColor = Color.White;
            l_MinAdJ.Location = new Point(194, 146);
            l_MinAdJ.Name = "l_MinAdJ";
            l_MinAdJ.Size = new Size(54, 12);
            l_MinAdJ.TabIndex = 71;
            l_MinAdJ.Text = "min. 3.000€";
            // 
            // label71
            // 
            label71.AutoSize = true;
            label71.Font = new Font("Segoe UI", 12F);
            label71.ForeColor = Color.White;
            label71.Location = new Point(15, 95);
            label71.Name = "label71";
            label71.Size = new Size(247, 21);
            label71.TabIndex = 70;
            label71.Text = "Aufstellung des Jahresabschlusses";
            // 
            // tB_AdJA
            // 
            tB_AdJA.Enabled = false;
            tB_AdJA.Location = new Point(160, 120);
            tB_AdJA.Name = "tB_AdJA";
            tB_AdJA.Size = new Size(100, 23);
            tB_AdJA.TabIndex = 69;
            tB_AdJA.Text = "3.000,00 €";
            tB_AdJA.TextAlign = HorizontalAlignment.Right;
            // 
            // BTN_ZurueckBilanz
            // 
            BTN_ZurueckBilanz.Font = new Font("Segoe UI", 15F);
            BTN_ZurueckBilanz.Location = new Point(348, 450);
            BTN_ZurueckBilanz.Name = "BTN_ZurueckBilanz";
            BTN_ZurueckBilanz.Size = new Size(94, 41);
            BTN_ZurueckBilanz.TabIndex = 33;
            BTN_ZurueckBilanz.Text = "Zurück";
            BTN_ZurueckBilanz.UseVisualStyleBackColor = true;
            BTN_ZurueckBilanz.Click += BTN_ZurueckBilanz_Click;
            // 
            // l_BilanzUeberschrift
            // 
            l_BilanzUeberschrift.AutoSize = true;
            l_BilanzUeberschrift.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            l_BilanzUeberschrift.ForeColor = Color.White;
            l_BilanzUeberschrift.Location = new Point(334, 22);
            l_BilanzUeberschrift.Name = "l_BilanzUeberschrift";
            l_BilanzUeberschrift.Size = new Size(117, 46);
            l_BilanzUeberschrift.TabIndex = 0;
            l_BilanzUeberschrift.Text = "Bilanz";
            // 
            // tB_Bilanzsumme
            // 
            tB_Bilanzsumme.Font = new Font("Segoe UI", 15F);
            tB_Bilanzsumme.Location = new Point(483, 177);
            tB_Bilanzsumme.Name = "tB_Bilanzsumme";
            tB_Bilanzsumme.Size = new Size(199, 34);
            tB_Bilanzsumme.TabIndex = 12;
            tB_Bilanzsumme.TextAlign = HorizontalAlignment.Right;
            tB_Bilanzsumme.TextChanged += tB_Bilanzsumme_TextChanged;
            tB_Bilanzsumme.Leave += txtBilanzsumme_Leave;
            // 
            // panelUnternehmensDaten
            // 
            panelUnternehmensDaten.Controls.Add(cB_OnlineHaendler_new);
            panelUnternehmensDaten.Controls.Add(cB_BargeldGewerbe_new);
            panelUnternehmensDaten.Controls.Add(l_OnlineHaendlerTXT);
            panelUnternehmensDaten.Controls.Add(cB_OnlineHaendler);
            panelUnternehmensDaten.Controls.Add(l_BarGeldGewerbeTXT);
            panelUnternehmensDaten.Controls.Add(cB_BargeldGewerbe);
            panelUnternehmensDaten.Controls.Add(l_UnternehmensDaten);
            panelUnternehmensDaten.Controls.Add(l_Bilanz);
            panelUnternehmensDaten.Controls.Add(tB_Umsatz);
            panelUnternehmensDaten.Controls.Add(tB_AnzahlMitarbeiter);
            panelUnternehmensDaten.Controls.Add(tB_Ausgaben);
            panelUnternehmensDaten.Controls.Add(tB_Bilanzsumme);
            panelUnternehmensDaten.Controls.Add(l_Umsatz);
            panelUnternehmensDaten.Controls.Add(l_AnzahlMitarbeiter);
            panelUnternehmensDaten.Controls.Add(l_Ausgaben);
            panelUnternehmensDaten.Location = new Point(300, 65);
            panelUnternehmensDaten.Name = "panelUnternehmensDaten";
            panelUnternehmensDaten.Size = new Size(821, 516);
            panelUnternehmensDaten.TabIndex = 19;
            panelUnternehmensDaten.Visible = false;
            // 
            // cB_OnlineHaendler_new
            // 
            cB_OnlineHaendler_new.AutoSize = true;
            cB_OnlineHaendler_new.BackColor = Color.Transparent;
            cB_OnlineHaendler_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_OnlineHaendler_new.CheckmarkColor = Color.Black;
            cB_OnlineHaendler_new.CornerRadius = 8;
            cB_OnlineHaendler_new.Location = new Point(577, 423);
            cB_OnlineHaendler_new.Name = "cB_OnlineHaendler_new";
            cB_OnlineHaendler_new.Size = new Size(29, 19);
            cB_OnlineHaendler_new.TabIndex = 23;
            cB_OnlineHaendler_new.Text = " ";
            cB_OnlineHaendler_new.UseVisualStyleBackColor = false;
            cB_OnlineHaendler_new.CheckedChanged += cB_OnlineHaendler_new_CheckedChanged;
            // 
            // cB_BargeldGewerbe_new
            // 
            cB_BargeldGewerbe_new.AutoSize = true;
            cB_BargeldGewerbe_new.BackColor = Color.Transparent;
            cB_BargeldGewerbe_new.CheckedBoxColor = Color.FromArgb(38, 209, 222);
            cB_BargeldGewerbe_new.CheckmarkColor = Color.Black;
            cB_BargeldGewerbe_new.CornerRadius = 8;
            cB_BargeldGewerbe_new.Location = new Point(221, 430);
            cB_BargeldGewerbe_new.Name = "cB_BargeldGewerbe_new";
            cB_BargeldGewerbe_new.Size = new Size(29, 19);
            cB_BargeldGewerbe_new.TabIndex = 22;
            cB_BargeldGewerbe_new.Text = " ";
            cB_BargeldGewerbe_new.UseVisualStyleBackColor = false;
            cB_BargeldGewerbe_new.CheckedChanged += cB_BargeldGewerbe_new_CheckedChanged;
            // 
            // l_OnlineHaendlerTXT
            // 
            l_OnlineHaendlerTXT.AutoSize = true;
            l_OnlineHaendlerTXT.Font = new Font("Segoe UI", 15F);
            l_OnlineHaendlerTXT.ForeColor = Color.White;
            l_OnlineHaendlerTXT.Location = new Point(519, 396);
            l_OnlineHaendlerTXT.Name = "l_OnlineHaendlerTXT";
            l_OnlineHaendlerTXT.Size = new Size(135, 28);
            l_OnlineHaendlerTXT.TabIndex = 18;
            l_OnlineHaendlerTXT.Text = "Onlinehändler";
            // 
            // cB_OnlineHaendler
            // 
            cB_OnlineHaendler.AutoSize = true;
            cB_OnlineHaendler.Location = new Point(577, 453);
            cB_OnlineHaendler.Name = "cB_OnlineHaendler";
            cB_OnlineHaendler.Size = new Size(15, 14);
            cB_OnlineHaendler.TabIndex = 17;
            cB_OnlineHaendler.UseVisualStyleBackColor = true;
            cB_OnlineHaendler.Visible = false;
            cB_OnlineHaendler.CheckedChanged += cB_OnlineHaendler_CheckedChanged;
            // 
            // l_BarGeldGewerbeTXT
            // 
            l_BarGeldGewerbeTXT.AutoSize = true;
            l_BarGeldGewerbeTXT.Font = new Font("Segoe UI", 15F);
            l_BarGeldGewerbeTXT.ForeColor = Color.White;
            l_BarGeldGewerbeTXT.Location = new Point(157, 396);
            l_BarGeldGewerbeTXT.Name = "l_BarGeldGewerbeTXT";
            l_BarGeldGewerbeTXT.Size = new Size(154, 28);
            l_BarGeldGewerbeTXT.TabIndex = 16;
            l_BarGeldGewerbeTXT.Text = "Bargeldgewerbe";
            // 
            // cB_BargeldGewerbe
            // 
            cB_BargeldGewerbe.AutoSize = true;
            cB_BargeldGewerbe.Location = new Point(225, 458);
            cB_BargeldGewerbe.Name = "cB_BargeldGewerbe";
            cB_BargeldGewerbe.Size = new Size(15, 14);
            cB_BargeldGewerbe.TabIndex = 15;
            cB_BargeldGewerbe.UseVisualStyleBackColor = true;
            cB_BargeldGewerbe.Visible = false;
            cB_BargeldGewerbe.CheckedChanged += cB_BarGeldGewerbe_CheckedChanged;
            // 
            // l_UnternehmensDaten
            // 
            l_UnternehmensDaten.AutoSize = true;
            l_UnternehmensDaten.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            l_UnternehmensDaten.ForeColor = Color.White;
            l_UnternehmensDaten.Location = new Point(237, 26);
            l_UnternehmensDaten.Name = "l_UnternehmensDaten";
            l_UnternehmensDaten.Size = new Size(346, 46);
            l_UnternehmensDaten.TabIndex = 14;
            l_UnternehmensDaten.Text = "Unternehmensdaten";
            // 
            // l_Bilanz
            // 
            l_Bilanz.AutoSize = true;
            l_Bilanz.Font = new Font("Segoe UI", 20F);
            l_Bilanz.ForeColor = Color.White;
            l_Bilanz.Location = new Point(495, 138);
            l_Bilanz.Name = "l_Bilanz";
            l_Bilanz.Size = new Size(173, 37);
            l_Bilanz.TabIndex = 13;
            l_Bilanz.Text = "Bilanzsumme";
            // 
            // panelLohn
            // 
            panelLohn.Controls.Add(l_AnzahlZW50bis100);
            panelLohn.Controls.Add(l_AnzahlZW20bis49);
            panelLohn.Controls.Add(l_50bis100_Mitarbeiter);
            panelLohn.Controls.Add(l_20bis49_Mitarbeiter);
            panelLohn.Controls.Add(l_LohnBeitragFUENFZIGBISHUNDERT);
            panelLohn.Controls.Add(l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG);
            panelLohn.Controls.Add(label41);
            panelLohn.Controls.Add(label69);
            panelLohn.Controls.Add(l_AnzahlAb101);
            panelLohn.Controls.Add(l_AnzahlZW10bis19);
            panelLohn.Controls.Add(l_AnzahlZW2bis9);
            panelLohn.Controls.Add(l_MA1);
            panelLohn.Controls.Add(label81);
            panelLohn.Controls.Add(label80);
            panelLohn.Controls.Add(label78);
            panelLohn.Controls.Add(l_ZSLohnMonat);
            panelLohn.Controls.Add(label75);
            panelLohn.Controls.Add(l_ZSLohn);
            panelLohn.Controls.Add(BTN_ZurueckLohn);
            panelLohn.Controls.Add(l_ab101_Mitarbeiter);
            panelLohn.Controls.Add(l_10bis19_Mitarbeiter);
            panelLohn.Controls.Add(l_2bis9_Mitarbeiter);
            panelLohn.Controls.Add(l_1_Mitarbeiter);
            panelLohn.Controls.Add(label74);
            panelLohn.Controls.Add(tB_AnzahlMitarbeiterLohn);
            panelLohn.Controls.Add(l_SatzAb101Mitarbeiter);
            panelLohn.Controls.Add(l_LohnBeitragZEHNBISNEUNZEHN);
            panelLohn.Controls.Add(l_LohnBeitragZWEIBISNEUN);
            panelLohn.Controls.Add(l_LohnBeitragEINS);
            panelLohn.Controls.Add(label65);
            panelLohn.Controls.Add(label64);
            panelLohn.Controls.Add(label59);
            panelLohn.Controls.Add(label53);
            panelLohn.Controls.Add(label45);
            panelLohn.Controls.Add(label40);
            panelLohn.Controls.Add(label31);
            panelLohn.Location = new Point(300, 65);
            panelLohn.Name = "panelLohn";
            panelLohn.Size = new Size(817, 513);
            panelLohn.TabIndex = 72;
            panelLohn.Visible = false;
            // 
            // l_AnzahlZW50bis100
            // 
            l_AnzahlZW50bis100.AutoSize = true;
            l_AnzahlZW50bis100.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_AnzahlZW50bis100.ForeColor = Color.White;
            l_AnzahlZW50bis100.Location = new Point(232, 322);
            l_AnzahlZW50bis100.Name = "l_AnzahlZW50bis100";
            l_AnzahlZW50bis100.Size = new Size(21, 28);
            l_AnzahlZW50bis100.TabIndex = 96;
            l_AnzahlZW50bis100.Text = "?";
            l_AnzahlZW50bis100.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_AnzahlZW20bis49
            // 
            l_AnzahlZW20bis49.AutoSize = true;
            l_AnzahlZW20bis49.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_AnzahlZW20bis49.ForeColor = Color.White;
            l_AnzahlZW20bis49.Location = new Point(232, 278);
            l_AnzahlZW20bis49.Name = "l_AnzahlZW20bis49";
            l_AnzahlZW20bis49.Size = new Size(21, 28);
            l_AnzahlZW20bis49.TabIndex = 95;
            l_AnzahlZW20bis49.Text = "?";
            l_AnzahlZW20bis49.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_50bis100_Mitarbeiter
            // 
            l_50bis100_Mitarbeiter.AutoSize = true;
            l_50bis100_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_50bis100_Mitarbeiter.ForeColor = Color.White;
            l_50bis100_Mitarbeiter.Location = new Point(642, 322);
            l_50bis100_Mitarbeiter.Name = "l_50bis100_Mitarbeiter";
            l_50bis100_Mitarbeiter.Size = new Size(32, 28);
            l_50bis100_Mitarbeiter.TabIndex = 94;
            l_50bis100_Mitarbeiter.Text = "?€";
            l_50bis100_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_20bis49_Mitarbeiter
            // 
            l_20bis49_Mitarbeiter.AutoSize = true;
            l_20bis49_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_20bis49_Mitarbeiter.ForeColor = Color.White;
            l_20bis49_Mitarbeiter.Location = new Point(642, 278);
            l_20bis49_Mitarbeiter.Name = "l_20bis49_Mitarbeiter";
            l_20bis49_Mitarbeiter.Size = new Size(32, 28);
            l_20bis49_Mitarbeiter.TabIndex = 93;
            l_20bis49_Mitarbeiter.Text = "?€";
            l_20bis49_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_LohnBeitragFUENFZIGBISHUNDERT
            // 
            l_LohnBeitragFUENFZIGBISHUNDERT.AutoSize = true;
            l_LohnBeitragFUENFZIGBISHUNDERT.Font = new Font("Segoe UI", 15F);
            l_LohnBeitragFUENFZIGBISHUNDERT.ForeColor = Color.White;
            l_LohnBeitragFUENFZIGBISHUNDERT.Location = new Point(371, 323);
            l_LohnBeitragFUENFZIGBISHUNDERT.Name = "l_LohnBeitragFUENFZIGBISHUNDERT";
            l_LohnBeitragFUENFZIGBISHUNDERT.Size = new Size(45, 28);
            l_LohnBeitragFUENFZIGBISHUNDERT.TabIndex = 92;
            l_LohnBeitragFUENFZIGBISHUNDERT.Text = "20€";
            l_LohnBeitragFUENFZIGBISHUNDERT.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG
            // 
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.AutoSize = true;
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Font = new Font("Segoe UI", 15F);
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.ForeColor = Color.White;
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Location = new Point(371, 279);
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Name = "l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG";
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Size = new Size(45, 28);
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.TabIndex = 91;
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Text = "22€";
            l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.TextAlign = ContentAlignment.TopCenter;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 15F);
            label41.ForeColor = Color.White;
            label41.Location = new Point(52, 322);
            label41.Name = "label41";
            label41.Size = new Size(110, 28);
            label41.TabIndex = 90;
            label41.Text = "50. bis 100.";
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Font = new Font("Segoe UI", 15F);
            label69.ForeColor = Color.White;
            label69.Location = new Point(52, 278);
            label69.Name = "label69";
            label69.Size = new Size(99, 28);
            label69.TabIndex = 89;
            label69.Text = "20. bis 49.";
            // 
            // l_AnzahlAb101
            // 
            l_AnzahlAb101.AutoSize = true;
            l_AnzahlAb101.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_AnzahlAb101.ForeColor = Color.White;
            l_AnzahlAb101.Location = new Point(232, 366);
            l_AnzahlAb101.Name = "l_AnzahlAb101";
            l_AnzahlAb101.Size = new Size(21, 28);
            l_AnzahlAb101.TabIndex = 88;
            l_AnzahlAb101.Text = "?";
            l_AnzahlAb101.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_AnzahlZW10bis19
            // 
            l_AnzahlZW10bis19.AutoSize = true;
            l_AnzahlZW10bis19.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_AnzahlZW10bis19.ForeColor = Color.White;
            l_AnzahlZW10bis19.Location = new Point(230, 234);
            l_AnzahlZW10bis19.Name = "l_AnzahlZW10bis19";
            l_AnzahlZW10bis19.Size = new Size(21, 28);
            l_AnzahlZW10bis19.TabIndex = 87;
            l_AnzahlZW10bis19.Text = "?";
            l_AnzahlZW10bis19.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_AnzahlZW2bis9
            // 
            l_AnzahlZW2bis9.AutoSize = true;
            l_AnzahlZW2bis9.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_AnzahlZW2bis9.ForeColor = Color.White;
            l_AnzahlZW2bis9.Location = new Point(230, 186);
            l_AnzahlZW2bis9.Name = "l_AnzahlZW2bis9";
            l_AnzahlZW2bis9.Size = new Size(21, 28);
            l_AnzahlZW2bis9.TabIndex = 86;
            l_AnzahlZW2bis9.Text = "?";
            l_AnzahlZW2bis9.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_MA1
            // 
            l_MA1.AutoSize = true;
            l_MA1.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            l_MA1.ForeColor = Color.White;
            l_MA1.Location = new Point(229, 139);
            l_MA1.Name = "l_MA1";
            l_MA1.Size = new Size(23, 28);
            l_MA1.TabIndex = 85;
            l_MA1.Text = "1";
            l_MA1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label81
            // 
            label81.AutoSize = true;
            label81.Font = new Font("Segoe UI", 9F);
            label81.ForeColor = Color.White;
            label81.Location = new Point(491, 455);
            label81.Name = "label81";
            label81.Size = new Size(49, 15);
            label81.TabIndex = 84;
            label81.Text = "jährlich:";
            // 
            // label80
            // 
            label80.AutoSize = true;
            label80.Font = new Font("Segoe UI", 9F);
            label80.ForeColor = Color.White;
            label80.Location = new Point(476, 431);
            label80.Name = "label80";
            label80.Size = new Size(64, 15);
            label80.TabIndex = 83;
            label80.Text = "monatlich:";
            // 
            // label78
            // 
            label78.AutoSize = true;
            label78.Font = new Font("Segoe UI", 15F);
            label78.ForeColor = Color.White;
            label78.Location = new Point(540, 423);
            label78.Name = "label78";
            label78.Size = new Size(158, 28);
            label78.TabIndex = 82;
            label78.Text = "Zwischensumme:";
            // 
            // l_ZSLohnMonat
            // 
            l_ZSLohnMonat.AutoSize = true;
            l_ZSLohnMonat.Font = new Font("Segoe UI", 15F);
            l_ZSLohnMonat.ForeColor = Color.White;
            l_ZSLohnMonat.Location = new Point(697, 423);
            l_ZSLohnMonat.Name = "l_ZSLohnMonat";
            l_ZSLohnMonat.Size = new Size(60, 28);
            l_ZSLohnMonat.TabIndex = 81;
            l_ZSLohnMonat.Text = "0,00€";
            // 
            // label75
            // 
            label75.AutoSize = true;
            label75.Font = new Font("Segoe UI", 15F);
            label75.ForeColor = Color.White;
            label75.Location = new Point(540, 446);
            label75.Name = "label75";
            label75.Size = new Size(158, 28);
            label75.TabIndex = 80;
            label75.Text = "Zwischensumme:";
            // 
            // l_ZSLohn
            // 
            l_ZSLohn.AutoSize = true;
            l_ZSLohn.Font = new Font("Segoe UI", 15F);
            l_ZSLohn.ForeColor = Color.White;
            l_ZSLohn.Location = new Point(697, 446);
            l_ZSLohn.Name = "l_ZSLohn";
            l_ZSLohn.Size = new Size(60, 28);
            l_ZSLohn.TabIndex = 79;
            l_ZSLohn.Text = "0,00€";
            // 
            // BTN_ZurueckLohn
            // 
            BTN_ZurueckLohn.Font = new Font("Segoe UI", 15F);
            BTN_ZurueckLohn.Location = new Point(356, 430);
            BTN_ZurueckLohn.Name = "BTN_ZurueckLohn";
            BTN_ZurueckLohn.Size = new Size(94, 41);
            BTN_ZurueckLohn.TabIndex = 78;
            BTN_ZurueckLohn.Text = "Zurück";
            BTN_ZurueckLohn.UseVisualStyleBackColor = true;
            BTN_ZurueckLohn.Click += BTN_ZurueckLohn_Click;
            // 
            // l_ab101_Mitarbeiter
            // 
            l_ab101_Mitarbeiter.AutoSize = true;
            l_ab101_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_ab101_Mitarbeiter.ForeColor = Color.White;
            l_ab101_Mitarbeiter.Location = new Point(642, 366);
            l_ab101_Mitarbeiter.Name = "l_ab101_Mitarbeiter";
            l_ab101_Mitarbeiter.Size = new Size(32, 28);
            l_ab101_Mitarbeiter.TabIndex = 16;
            l_ab101_Mitarbeiter.Text = "?€";
            l_ab101_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_10bis19_Mitarbeiter
            // 
            l_10bis19_Mitarbeiter.AutoSize = true;
            l_10bis19_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_10bis19_Mitarbeiter.ForeColor = Color.White;
            l_10bis19_Mitarbeiter.Location = new Point(640, 234);
            l_10bis19_Mitarbeiter.Name = "l_10bis19_Mitarbeiter";
            l_10bis19_Mitarbeiter.Size = new Size(32, 28);
            l_10bis19_Mitarbeiter.TabIndex = 15;
            l_10bis19_Mitarbeiter.Text = "?€";
            l_10bis19_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_2bis9_Mitarbeiter
            // 
            l_2bis9_Mitarbeiter.AutoSize = true;
            l_2bis9_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_2bis9_Mitarbeiter.ForeColor = Color.White;
            l_2bis9_Mitarbeiter.Location = new Point(640, 186);
            l_2bis9_Mitarbeiter.Name = "l_2bis9_Mitarbeiter";
            l_2bis9_Mitarbeiter.Size = new Size(32, 28);
            l_2bis9_Mitarbeiter.TabIndex = 14;
            l_2bis9_Mitarbeiter.Text = "?€";
            l_2bis9_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_1_Mitarbeiter
            // 
            l_1_Mitarbeiter.AutoSize = true;
            l_1_Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_1_Mitarbeiter.ForeColor = Color.White;
            l_1_Mitarbeiter.Location = new Point(639, 139);
            l_1_Mitarbeiter.Name = "l_1_Mitarbeiter";
            l_1_Mitarbeiter.Size = new Size(45, 28);
            l_1_Mitarbeiter.TabIndex = 13;
            l_1_Mitarbeiter.Text = "42€";
            l_1_Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // label74
            // 
            label74.AutoSize = true;
            label74.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label74.ForeColor = Color.White;
            label74.Location = new Point(628, 100);
            label74.Name = "label74";
            label74.Size = new Size(100, 28);
            label74.TabIndex = 12;
            label74.Text = "Monatlich";
            // 
            // tB_AnzahlMitarbeiterLohn
            // 
            tB_AnzahlMitarbeiterLohn.Font = new Font("Segoe UI", 15F);
            tB_AnzahlMitarbeiterLohn.Location = new Point(207, 91);
            tB_AnzahlMitarbeiterLohn.Name = "tB_AnzahlMitarbeiterLohn";
            tB_AnzahlMitarbeiterLohn.Size = new Size(100, 34);
            tB_AnzahlMitarbeiterLohn.TabIndex = 11;
            tB_AnzahlMitarbeiterLohn.TextChanged += tB_AnzahlMitarbeiterLohn_TextChanged;
            // 
            // l_SatzAb101Mitarbeiter
            // 
            l_SatzAb101Mitarbeiter.AutoSize = true;
            l_SatzAb101Mitarbeiter.Font = new Font("Segoe UI", 15F);
            l_SatzAb101Mitarbeiter.ForeColor = Color.White;
            l_SatzAb101Mitarbeiter.Location = new Point(371, 367);
            l_SatzAb101Mitarbeiter.Name = "l_SatzAb101Mitarbeiter";
            l_SatzAb101Mitarbeiter.Size = new Size(34, 28);
            l_SatzAb101Mitarbeiter.TabIndex = 10;
            l_SatzAb101Mitarbeiter.Text = "0€";
            l_SatzAb101Mitarbeiter.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_LohnBeitragZEHNBISNEUNZEHN
            // 
            l_LohnBeitragZEHNBISNEUNZEHN.AutoSize = true;
            l_LohnBeitragZEHNBISNEUNZEHN.Font = new Font("Segoe UI", 15F);
            l_LohnBeitragZEHNBISNEUNZEHN.ForeColor = Color.White;
            l_LohnBeitragZEHNBISNEUNZEHN.Location = new Point(369, 235);
            l_LohnBeitragZEHNBISNEUNZEHN.Name = "l_LohnBeitragZEHNBISNEUNZEHN";
            l_LohnBeitragZEHNBISNEUNZEHN.Size = new Size(45, 28);
            l_LohnBeitragZEHNBISNEUNZEHN.TabIndex = 9;
            l_LohnBeitragZEHNBISNEUNZEHN.Text = "24€";
            l_LohnBeitragZEHNBISNEUNZEHN.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_LohnBeitragZWEIBISNEUN
            // 
            l_LohnBeitragZWEIBISNEUN.AutoSize = true;
            l_LohnBeitragZWEIBISNEUN.Font = new Font("Segoe UI", 15F);
            l_LohnBeitragZWEIBISNEUN.ForeColor = Color.White;
            l_LohnBeitragZWEIBISNEUN.Location = new Point(369, 187);
            l_LohnBeitragZWEIBISNEUN.Name = "l_LohnBeitragZWEIBISNEUN";
            l_LohnBeitragZWEIBISNEUN.Size = new Size(45, 28);
            l_LohnBeitragZWEIBISNEUN.TabIndex = 8;
            l_LohnBeitragZWEIBISNEUN.Text = "30€";
            l_LohnBeitragZWEIBISNEUN.TextAlign = ContentAlignment.TopCenter;
            // 
            // l_LohnBeitragEINS
            // 
            l_LohnBeitragEINS.AutoSize = true;
            l_LohnBeitragEINS.Font = new Font("Segoe UI", 15F);
            l_LohnBeitragEINS.ForeColor = Color.White;
            l_LohnBeitragEINS.Location = new Point(368, 140);
            l_LohnBeitragEINS.Name = "l_LohnBeitragEINS";
            l_LohnBeitragEINS.Size = new Size(45, 28);
            l_LohnBeitragEINS.TabIndex = 7;
            l_LohnBeitragEINS.Text = "42€";
            l_LohnBeitragEINS.TextAlign = ContentAlignment.TopCenter;
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Font = new Font("Segoe UI", 15F);
            label65.ForeColor = Color.White;
            label65.Location = new Point(52, 366);
            label65.Name = "label65";
            label65.Size = new Size(63, 28);
            label65.TabIndex = 6;
            label65.Text = "101.+";
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Font = new Font("Segoe UI", 15F);
            label64.ForeColor = Color.White;
            label64.Location = new Point(50, 234);
            label64.Name = "label64";
            label64.Size = new Size(99, 28);
            label64.TabIndex = 5;
            label64.Text = "10. bis 19.";
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Font = new Font("Segoe UI", 15F);
            label59.ForeColor = Color.White;
            label59.Location = new Point(50, 186);
            label59.Name = "label59";
            label59.Size = new Size(77, 28);
            label59.TabIndex = 4;
            label59.Text = "2. bis 9.";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Font = new Font("Segoe UI", 15F);
            label53.ForeColor = Color.White;
            label53.Location = new Point(49, 139);
            label53.Name = "label53";
            label53.Size = new Size(27, 28);
            label53.TabIndex = 3;
            label53.Text = "1.";
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label45.ForeColor = Color.White;
            label45.Location = new Point(363, 97);
            label45.Name = "label45";
            label45.Size = new Size(74, 28);
            label45.TabIndex = 2;
            label45.Text = "Beitrag";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Segoe UI", 15F, FontStyle.Underline);
            label40.ForeColor = Color.White;
            label40.Location = new Point(30, 97);
            label40.Name = "label40";
            label40.Size = new Size(178, 28);
            label40.TabIndex = 1;
            label40.Text = "Anzahl Mitarbeiter:";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 25F, FontStyle.Bold | FontStyle.Underline);
            label31.ForeColor = Color.White;
            label31.Location = new Point(352, 23);
            label31.Name = "label31";
            label31.Size = new Size(99, 46);
            label31.TabIndex = 0;
            label31.Text = "Lohn";
            // 
            // BTN_OpenExcel
            // 
            BTN_OpenExcel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BTN_OpenExcel.Location = new Point(90, 543);
            BTN_OpenExcel.Name = "BTN_OpenExcel";
            BTN_OpenExcel.Size = new Size(144, 40);
            BTN_OpenExcel.TabIndex = 73;
            BTN_OpenExcel.Text = "Open Excel";
            BTN_OpenExcel.UseVisualStyleBackColor = true;
            BTN_OpenExcel.Click += BTN_OpenExcel_Click;
            // 
            // Background
            // 
            Background.Image = (Image)resources.GetObject("Background.Image");
            Background.Location = new Point(-9, -5);
            Background.Name = "Background";
            Background.Size = new Size(1306, 736);
            Background.SizeMode = PictureBoxSizeMode.StretchImage;
            Background.TabIndex = 74;
            Background.TabStop = false;
            // 
            // Honorarrechner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 116, 189);
            ClientSize = new Size(1291, 725);
            Controls.Add(BTN_OpenExcel);
            Controls.Add(BTN_UpdateExcelList);
            Controls.Add(l_currentMonatsHonorar);
            Controls.Add(label5);
            Controls.Add(l_currentJahresHonorar);
            Controls.Add(l_AktuellesAngebot);
            Controls.Add(BTN_Zurueck);
            Controls.Add(BTN_Weiter);
            Controls.Add(SFSLogo);
            Controls.Add(panelStart);
            Controls.Add(panelBilanz);
            Controls.Add(panelEUR);
            Controls.Add(panelJA1);
            Controls.Add(panelFiBu);
            Controls.Add(panelUnternehmensDaten);
            Controls.Add(panelLohn);
            Controls.Add(panelLeistungen);
            Controls.Add(Background);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Honorarrechner";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)SFSLogo).EndInit();
            panelLeistungen.ResumeLayout(false);
            panelLeistungen.PerformLayout();
            panelFiBu.ResumeLayout(false);
            panelFiBu.PerformLayout();
            panelJA1.ResumeLayout(false);
            panelJA1.PerformLayout();
            panelStart.ResumeLayout(false);
            panelStart.PerformLayout();
            panelEUR.ResumeLayout(false);
            panelEUR.PerformLayout();
            panelBilanz.ResumeLayout(false);
            panelBilanz.PerformLayout();
            panelUnternehmensDaten.ResumeLayout(false);
            panelUnternehmensDaten.PerformLayout();
            panelLohn.ResumeLayout(false);
            panelLohn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Background).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tB_Umsatz;
        private PictureBox SFSLogo;
        private CheckBox cB_Privat;
        private CheckBox cB_UN;
        private Label PrivatText;
        private Label UnternemenText;
        private Panel panelStart;
        private Label StartUp;
        private CheckBox cB_StartUp;
        private Button BTN_Weiter;
        private Button BTN_Zurueck;
        private Label l_Umsatz;
        private Label l_Leistungen;
        private Label label2;
        private Label label3;
        private Label label1;
        private Label l_Leistung;
        private TextBox tB_UdB;
        private Label l_currentJahresHonorar;
        private Label l_AktuellesAngebot;
        private Label l_currentMonatsHonorar;
        private Label label5;
        private Panel panelLeistungen;
        private Label LeistungenTextforPanel;
        private CheckBox cB_FiBu;
        private Label l_4;
        private Label l_6;
        private CheckBox cB_JA;
        private Label l_8;
        private CheckBox cB_SeBu;
        private Label l_9;
        private CheckBox cB_Lohn;
        private Panel panelFiBu;
        private Label labelFiBuSatz;
        private Label label10;
        private Label labelITPauschale;
        private Label label14;
        private Label l_PauschaleIT;
        private Label label13;
        private Label l_BuchFuerungPauschale;
        private Label l_Laufendebuchfuerung;
        private Label label11;
        private Label l_AuslagenPauschale2;
        private Label l_ProzentFiBu;
        private Label label17;
        private Label label12;
        private Label label15;
        private TextBox tB_FiBuUmsatz;
        private Button BTN_backfromFiBu;
        private Label l_AnzahlMitarbeiter;
        private TextBox tB_AnzahlMitarbeiter;
        private Panel panelJA1;
        private Label label21;
        private Label FiBuZwischenSumme;
        private Label label23;
        private Label label22;
        private Label l_FiBuZSLeistungen;
        private Label l_SBZSLeistungen;
        private Label l_LohnZSLeistungen;
        private Label l_JAZSLeistungen;
        private Button BTN_JAZurueck;
        private Label label25;
        private Label label24;
        private CheckBox cB_Bilanz;
        private CheckBox cB_EUR;
        private Label label26;
        private LinkLabel lL_ZurBilanz;
        private LinkLabel lL_zumEUR;
        private LinkLabel lL_ZurFiBu;
        private LinkLabel lL_zumLohn;
        private LinkLabel lL_zumJA;
        private Panel panelEUR;
        private Label l_Betriebseinaus;
        private TextBox tB_BEA;
        private Label label29;
        private Label label30;
        private Label l_Ausgaben;
        private TextBox tB_Ausgaben;
        private Label l_32;
        private Label label34;
        private Label l_EURWS;
        private Label label36;
        private Label labelBEA;
        private Label label44;
        private Label l_BEASatz;
        private Button BTN_EURZurueck;
        private Label labelEURZWJA;
        private Label label38;
        private Label l_Umsatzsteuererklärung;
        private Label l_UmsatzsteuererklärungSatz;
        private Label l_MinUmsatzsteuererklaerung;
        private Label label51;
        private TextBox tB_Umsatzsteuererklärung;
        private Label l_UeberschussdBetriebseinnahmen;
        private Label l_SEzEdUdBSatz;
        private Label l_MinUEdB;
        private Label label47;
        private Label l_Gewerbesteuer;
        private Label l_GewerbesteuerSatz;
        private Label label42;
        private TextBox tB_Gewerbesteuer;
        private Label l_Abschlussarbeiten;
        private Label label54;
        private Label label55;
        private TextBox tB_PfA;
        private Label l_AbschlussarbeitenZS;
        private CheckBox cB_UdB;
        private Label l_MinErklZurGewerbersteuer;
        private TextBox tB_ErklzurGewerbesteuer;
        private Label label37;
        private TextBox tB_BilanzBescheide;
        private Label l_BilanzBescheideSatz;
        private TextBox tB_Bilanzsumme;
        private Panel panelBilanz;
        private Label l_BilanzUeberschrift;
        private Panel panelUnternehmensDaten;
        private Label l_Bilanz;
        private Label l_UnternehmensDaten;
        private Button BTN_ZurueckBilanz;
        private Label labelZSBilanzJA;
        private Label l_ErklZurGewerbesteuerSatz;
        private TextBox tB_ErstellungdesAntrags;
        private Label l_ErklaerungZurGewerbesteuer;
        private Label label43;
        private Label l_KoerperschaftsST;
        private Label l_KoerperschaftssteuererklSatz;
        private Label l_MinKoerperschaftssteuererkl;
        private Label label52;
        private TextBox tB_Koerperschaftssteuererklaerung;
        private Label l_EntwEinerSteuerbilanz;
        private Label l_EntwicklungEinerSteuerbilanzSatz;
        private Label l_MinEntwEinerSteuerbilanz;
        private Label label58;
        private TextBox tB_EntwEinerSteuerbilanz;
        private Label l_ErstDesAntrags;
        private Label l_ErstellungDesAntragsSatz;
        private Label l_MinErstellungDesAntrags;
        private Label label62;
        private Label l_TXTZwischensumme;
        private Label l_BilanzZS;
        private Label l_AdJA;
        private Label l_AdJSatz;
        private Label l_MinAdJ;
        private Label label71;
        private TextBox tB_AdJA;
        private Label label72;
        private Label l_Offenlegung;
        private Label l_BilanzBescheide;
        private Label label63;
        private Label label79;
        private Label l_E_Bilanz;
        private Label label82;
        private Label label83;
        private Label l_UmsatzsteuererklDesKJ;
        private Label l_UmsatzsteuererklFDasKJSatz;
        private Label l_MinUmsatzsteuererklFDasKJ;
        private Label label87;
        private TextBox tB_UmsatzsteuererklaerungdesKJ;
        private Panel panelLohn;
        private Label label31;
        private Label l_SatzAb101Mitarbeiter;
        private Label l_LohnBeitragZEHNBISNEUNZEHN;
        private Label l_LohnBeitragZWEIBISNEUN;
        private Label l_LohnBeitragEINS;
        private Label label65;
        private Label label64;
        private Label label59;
        private Label label53;
        private Label label45;
        private Label label40;
        private Label l_ab101_Mitarbeiter;
        private Label l_10bis19_Mitarbeiter;
        private Label l_2bis9_Mitarbeiter;
        private Label l_1_Mitarbeiter;
        private Label label74;
        private TextBox tB_AnzahlMitarbeiterLohn;
        private Label label75;
        private Label l_ZSLohn;
        private Button BTN_ZurueckLohn;
        private Label l_77;
        private Label l_66;
        private Label l_FiBuZSJahr;
        private Label l_76;
        private Label l_MinFiBuBeitrag;
        private Label label78;
        private Label l_ZSLohnMonat;
        private Label label81;
        private Label label80;
        private Label label84;
        private Label l_LeistungenSeBuMonatlich;
        private Label l_LeistungenLohnMonatlich;
        private Label l_LeistungenJAMonatlich;
        private Label l_LeistungenFiBuMonatlich;
        private Label l_AnzahlZW2bis9;
        private Label l_MA1;
        private Label l_AnzahlAb101;
        private Label l_AnzahlZW10bis19;
        private Button BTN_UpdateExcelList;
        private Label l_MinGewerbesteuer;
        private Label l_MinBAE;
        private Button BTN_OpenExcel;
        private Label l_AnzahlZW50bis100;
        private Label l_AnzahlZW20bis49;
        private Label l_50bis100_Mitarbeiter;
        private Label l_20bis49_Mitarbeiter;
        private Label l_LohnBeitragFUENFZIGBISHUNDERT;
        private Label l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG;
        private Label label41;
        private Label label69;
        private Label label20;
        private Label label18;
        private Label l_BilanzZSMonatlich;
        private Label label33;
        private Label label19;
        private Label label35;
        private Label label39;
        private Label l_EURWSMonatlich;
        private CheckBox checkBoxGes_Bilanz;
        private CheckBox cB_EUBilanz;
        private Label l_GESBilanz;
        private Label labelEUBilanz;
        private Label label27;
        private Label l_BilanzMin;
        private Label l_EURMin;
        private Label l_OnlineHaendlerTXT;
        private CheckBox cB_OnlineHaendler;
        private Label l_BarGeldGewerbeTXT;
        private CheckBox cB_BargeldGewerbe;
        private Button BTN_UploudExcel;
        private Label label16;
        private Label label7;
        private Label l_ProgressMandantenName;
        private ProgressBar pB_Mandanten;
        private Label l_comingSoon2;
        private Label l_comingSoon;
        private PictureBox Background;
        private ColoredCheckBox cB_UN_new;
        private ColoredCheckBox cB_UdB_new;
        private ColoredCheckBox cB_EUR_new;
        private ColoredCheckBox cB_Bilanz_new;
        private ColoredCheckBox cB_EUBilanz_new;
        private ColoredCheckBox checkBoxGes_Bilanz_new;
        private ColoredCheckBox cB_BargeldGewerbe_new;
        private ColoredCheckBox cB_OnlineHaendler_new;
        private ColoredCheckBox cB_FiBu_new;
        private ColoredCheckBox cB_SeBu_new;
        private ColoredCheckBox cB_Lohn_new;
        private ColoredCheckBox cB_JA_new;
    }
}
