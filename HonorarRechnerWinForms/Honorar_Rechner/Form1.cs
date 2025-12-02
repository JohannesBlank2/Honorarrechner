using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Imaging;
using System.Media;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.IO;
using static Honorar_Rechner.Honorarrechner;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml.Table;
using static System.Windows.Forms.DataFormats;

namespace Honorar_Rechner
{

    // l = label; lL = link Label; cB = check Box; BTN = button; tB = text Box; txt = text; Calc = Calculate

    public partial class Honorarrechner : Form
    {
        //Daten für den rechner (Pauschalen/Rechen Satz/usw.)
        string pfadZurExcelDatei = @"G:\Honorar_Rechner\HonorarrechnerWerteTabelle.xlsx";

        int currentPage = 0;  // Verfolgt die aktuelle Seite

        string Mandatstyps = "Nix"; string UnternehmensArt = "NIX"; string GewerbeArt = "NIX";

        double CurrentMonatsHonorar; double FiBuBeitrag = 0; double JABeitrag = 0; double LohnBeitrag = 0; double SeBuBeitrag = 0;

        private void BTN_OpenExcel_Click(object sender, EventArgs e)
        {
            if (File.Exists(pfadZurExcelDatei))
            {
                try
                {
                    // Excel-Datei mit der Standardanwendung öffnen
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = pfadZurExcelDatei,
                        UseShellExecute = true // Dies sorgt dafür, dass die Standardanwendung verwendet wird
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Öffnen der Excel-Datei: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Die Datei wurde nicht gefunden. Bitte überprüfen Sie den Pfad.");
            }
        }

        public void LadeDatenAusExcel()
        {
            // Sicherstellen, dass die Lizenz akzeptiert wird
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Laden der Excel-Datei
            FileInfo fileInfo = new FileInfo(pfadZurExcelDatei);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                // Hier geben Sie den Namen des Arbeitsblattes an, das Sie lesen möchten (z.B. GebuehrenTabelle)
                ExcelWorksheet arbeitsblatt = package.Workbook.Worksheets["WerteArbeitsblatt"];

                // Debug Ob Arbeitsblatt gefunden wurde
                if (arbeitsblatt == null)
                {
                    Debug.WriteLine("Das Arbeitsblatt 'WerteArbeitsblatt' konnte nicht gefunden werden.");
                    return;
                }
                else
                    Debug.WriteLine("Das Arbeitsblatt gefunden!!!");


                #region FiBu
                ITPauschale = Convert.ToDouble(arbeitsblatt.Cells[4, 2].Value);
                AuslagenPauschaleProzentSatz = Convert.ToDouble(arbeitsblatt.Cells[4, 3].Value);
                AuslagenPauschaleMaximum = Convert.ToDouble(arbeitsblatt.Cells[4, 4].Value);

                //FiBuMinUmsatz = Convert.ToDouble(arbeitsblatt.Cells[4, 5].Value);
                minPauschaleFiBuMonatlich = Convert.ToDouble(arbeitsblatt.Cells[4, 5].Value);
                l_MinFiBuBeitrag.Text = "     min. " + minPauschaleFiBuMonatlich.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                FiBuNormalSatzTXT = arbeitsblatt.Cells[4, 6].Value?.ToString() ?? string.Empty;
                OnlineHaendlerSatzTXT = arbeitsblatt.Cells[4, 7].Value?.ToString() ?? string.Empty;
                BarGeldGewerbeSatzTXT = arbeitsblatt.Cells[4, 8].Value?.ToString() ?? string.Empty;

                FiBuNormalSatz = BruchRechnen(FiBuNormalSatzTXT);
                OnlineHaendlerSatz = BruchRechnen(OnlineHaendlerSatzTXT);
                BarGeldGewerbeSatz = BruchRechnen(BarGeldGewerbeSatzTXT);
                #endregion

                #region Lohn
                BeitragEINS = Convert.ToDouble(arbeitsblatt.Cells[9, 2].Value);
                l_LohnBeitragEINS.Text = BeitragEINS.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                BeitragZWEIBISNEUN = Convert.ToDouble(arbeitsblatt.Cells[9, 3].Value);
                l_LohnBeitragZWEIBISNEUN.Text = BeitragZWEIBISNEUN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                BeitragZEHNBISNEUNZEHN = Convert.ToDouble(arbeitsblatt.Cells[9, 4].Value);
                l_LohnBeitragZEHNBISNEUNZEHN.Text = BeitragZEHNBISNEUNZEHN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                BeitragZWANZIGBISVIEUNDNEUNZIG = Convert.ToDouble(arbeitsblatt.Cells[9, 5].Value);
                l_LohnBeitragZWANZIGBISVIEUNDNEUNZIG.Text = BeitragZWANZIGBISVIEUNDNEUNZIG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));


                BeitragFUENFZIGBISHUNDERT = Convert.ToDouble(arbeitsblatt.Cells[9, 6].Value);
                l_LohnBeitragFUENFZIGBISHUNDERT.Text = BeitragFUENFZIGBISHUNDERT.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                #endregion

                #region JA

                //EUR
                l_BEASatz.Text = Convert.ToString(arbeitsblatt.Cells[14, 3].Value);
                BetriebsEinnahmenAusgabenSatz = BruchRechnen(l_BEASatz.Text);
                BEAminBeitrag = Convert.ToDouble(arbeitsblatt.Cells[14, 4].Value);
                l_MinBAE.Text = "min. " + BEAminBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_GewerbesteuerSatz.Text = Convert.ToString(arbeitsblatt.Cells[15, 3].Value);
                GewerbesteuerSatz = BruchRechnen(l_GewerbesteuerSatz.Text);
                GewerbesteuerMinBeitrag = Convert.ToDouble(arbeitsblatt.Cells[15, 4].Value);
                l_MinGewerbesteuer.Text = "min. " + GewerbesteuerMinBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_SEzEdUdBSatz.Text = Convert.ToString(arbeitsblatt.Cells[16, 3].Value);
                UEberschussderBetriebseinnahmenSatz = BruchRechnen(l_SEzEdUdBSatz.Text);
                UEdBminBeitrag = Convert.ToDouble(arbeitsblatt.Cells[16, 4].Value);
                l_MinUEdB.Text = "min. " + UEdBminBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_UmsatzsteuererklärungSatz.Text = Convert.ToString(arbeitsblatt.Cells[17, 3].Value);
                UmsatzsteuererklaerungsSatz = BruchRechnen(l_UmsatzsteuererklärungSatz.Text);
                UmsatzsteuererlaerungMinBeitrag = Convert.ToDouble(arbeitsblatt.Cells[17, 4].Value);
                l_MinUmsatzsteuererklaerung.Text = "min. " + UmsatzsteuererlaerungMinBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_AbschlussarbeitenZS.Text = Convert.ToString(arbeitsblatt.Cells[18, 4].Value);
                PauschalefuerAbschlussarbeitenSatz = Convert.ToDouble(arbeitsblatt.Cells[18, 3].Value);

                CompleteEURminMonat = Convert.ToDouble(arbeitsblatt.Cells[20, 3].Value);
                l_EURMin.Text = "min. " + CompleteEURminMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                //Bilanz

                l_AdJSatz.Text = Convert.ToString(arbeitsblatt.Cells[14, 7].Value);
                AdJSatz = BruchRechnen(l_AdJSatz.Text);
                AdJSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[14, 8].Value);
                l_MinAdJ.Text = "min. " + AdJSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_ErstellungDesAntragsSatz.Text = Convert.ToString(arbeitsblatt.Cells[15, 7].Value);
                ErstellungdesAntragsSatz = BruchRechnen(l_ErstellungDesAntragsSatz.Text);
                ErstellungdesAntragsSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[15, 8].Value);
                l_MinErstellungDesAntrags.Text = "min. " + ErstellungdesAntragsSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_EntwicklungEinerSteuerbilanzSatz.Text = Convert.ToString(arbeitsblatt.Cells[16, 7].Value);
                EntwicklungeinerSteuerbilanzSatz = BruchRechnen(l_EntwicklungEinerSteuerbilanzSatz.Text);
                EntwicklungeinerSteuerbilanzSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[16, 8].Value);
                l_MinEntwEinerSteuerbilanz.Text = "min. " + EntwicklungeinerSteuerbilanzSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_KoerperschaftssteuererklSatz.Text = Convert.ToString(arbeitsblatt.Cells[17, 7].Value);
                KoerperschaftssteuererklaerungsSatz = BruchRechnen(l_KoerperschaftssteuererklSatz.Text);
                KoerperschaftssteuererklaerungsSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[17, 8].Value);
                l_MinKoerperschaftssteuererkl.Text = "min. " + KoerperschaftssteuererklaerungsSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_UmsatzsteuererklFDasKJSatz.Text = Convert.ToString(arbeitsblatt.Cells[18, 7].Value);
                UmsatzsteuererklaerungfdKJSatz = BruchRechnen(l_UmsatzsteuererklFDasKJSatz.Text);
                UmsatzsteuererklaerungfdKJSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[18, 8].Value);
                l_MinUmsatzsteuererklFDasKJ.Text = "min. " + UmsatzsteuererklaerungfdKJSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_ErklZurGewerbesteuerSatz.Text = Convert.ToString(arbeitsblatt.Cells[19, 7].Value);
                ErklaerungZurGewerbesteuerSatz = BruchRechnen(l_ErklZurGewerbesteuerSatz.Text);
                ErklaerungZurGewerbesteuerSatzMIN = Convert.ToDouble(arbeitsblatt.Cells[19, 8].Value);
                l_MinErklZurGewerbersteuer.Text = "min. " + ErklaerungZurGewerbesteuerSatzMIN.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                l_BilanzBescheideSatz.Text = Convert.ToString(arbeitsblatt.Cells[20, 8].Value);
                BilanzBescheideSatz = Convert.ToDouble(arbeitsblatt.Cells[20, 7].Value);

                E_BilanzBeitrag = Convert.ToDouble(arbeitsblatt.Cells[21, 7].Value);
                l_E_Bilanz.Text = E_BilanzBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                OffenlegungsBeitrag = Convert.ToDouble(arbeitsblatt.Cells[22, 7].Value);
                l_Offenlegung.Text = OffenlegungsBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                CompleteBilanzMinEUMonat = Convert.ToDouble(arbeitsblatt.Cells[24, 7].Value);
                CompleteBilanzMinGesellschafftMonat = Convert.ToDouble(arbeitsblatt.Cells[25, 7].Value);

                /*/ Durchlaufen Sie die Zeilen und lesen Sie die Werte
                for (int zeile = 2; zeile <= arbeitsblatt.Dimension.End.Row; zeile++) // Starten Sie bei Zeile 2, wenn Zeile 1 die Überschrift ist
                {
                    // Lesen der Werte aus Spalte 1 (Gegenstandswert) und Spalte 2 (Gebühr)
                    var gegenstandswertZelle = arbeitsblatt.Cells[zeile, 1].Value;
                    var gebuehrZelle = arbeitsblatt.Cells[zeile, 2].Value;

                    if (gegenstandswertZelle != null && gebuehrZelle != null)
                    {
                        double gegenstandswert = Convert.ToDouble(gegenstandswertZelle);
                        double gebuehr = Convert.ToDouble(gebuehrZelle);

                        // Ihre Logik zur Verarbeitung der Daten hier
                        //Debug.WriteLine($"Gegenstandswert: {gegenstandswert}, Gebühr: {gebuehr}");
                    }
                    else
                    {
                        //Debug.WriteLine($"Die Zelle in Zeile {zeile} ist leer. Bitte überprüfen Sie die Excel-Datei.");
                    }
                }*/

                #endregion
            }
        }

        public double BruchRechnen(string bruchWertX)
        {
            double Ergebniss = 0; //= Convert.ToDouble(bruchWertX);
            string bruchWert = bruchWertX; // Konvertiere den Wert in einen String

            // Verwenden Sie Regex, um den Zellenwert als Bruch zu zerlegen
            Regex bruchRegex = new Regex(@"(\d+)/(\d+)");
            Match match = bruchRegex.Match(bruchWert);

            if (match.Success && double.TryParse(match.Groups[1].Value, out double zaehler) && double.TryParse(match.Groups[2].Value, out double nenner))
            {
                // Wenn der Regex erfolgreich ist, den Zähler durch den Nenner teilen
                double wertAlsDouble = zaehler / nenner;
                Ergebniss = wertAlsDouble;
            }
            else
            {
                // Falls der Wert kein Bruch ist, versuchen ihn als Double zu parsen
                if (double.TryParse(bruchWert, out double wert))
                {
                    Ergebniss = wert;
                }
                else
                {
                    Console.WriteLine("Ungültiges Format für den Wert: " + bruchWert);
                }
            }
            return Ergebniss;
        }

        public class GebuehrEintrag
        {
            public double GegenstandswertBis { get; set; }
            public double VolleGebuehr { get; set; }

            public GebuehrEintrag(double gegenstandswertBis, double volleGebuehr)
            {
                GegenstandswertBis = gegenstandswertBis;
                VolleGebuehr = volleGebuehr;
            }
        }

        public class GebuehrenRechner
        {
            private List<GebuehrEintrag> Abschlusstabelle;
            private List<GebuehrEintrag> beratungstabelle;
            private List<GebuehrEintrag> buchfuehrungsTabelle;
            public GebuehrenRechner()
            {
                // Abschlusstabelle Anlage 2 Tabelle B – aktualisiert 10.10.2024
                Abschlusstabelle = new List<GebuehrEintrag>()
{
    new GebuehrEintrag(3000, 49),
    new GebuehrEintrag(3500, 57),
    new GebuehrEintrag(4000, 68),
    new GebuehrEintrag(4500, 76),
    new GebuehrEintrag(5000, 86),
    new GebuehrEintrag(6000, 96),
    new GebuehrEintrag(7000, 105),
    new GebuehrEintrag(8000, 116),
    new GebuehrEintrag(9000, 121),
    new GebuehrEintrag(10000, 127),
    new GebuehrEintrag(12500, 134),
    new GebuehrEintrag(15000, 151),
    new GebuehrEintrag(17500, 166),
    new GebuehrEintrag(20000, 178),
    new GebuehrEintrag(22500, 191),
    new GebuehrEintrag(25000, 201),
    new GebuehrEintrag(37500, 215),
    new GebuehrEintrag(50000, 263),
    new GebuehrEintrag(62500, 303),
    new GebuehrEintrag(75000, 338),
    new GebuehrEintrag(87500, 353),
    new GebuehrEintrag(100000, 369),
    new GebuehrEintrag(125000, 423),
    new GebuehrEintrag(150000, 471),
    new GebuehrEintrag(175000, 512),
    new GebuehrEintrag(200000, 548),
    new GebuehrEintrag(225000, 582),
    new GebuehrEintrag(250000, 613),
    new GebuehrEintrag(300000, 641),
    new GebuehrEintrag(350000, 696),
    new GebuehrEintrag(400000, 746),
    new GebuehrEintrag(450000, 791),
    new GebuehrEintrag(500000, 832),
    new GebuehrEintrag(625000, 871),
    new GebuehrEintrag(750000, 968),
    new GebuehrEintrag(875000, 1050),
    new GebuehrEintrag(1000000, 1126),
    new GebuehrEintrag(1250000, 1194),
    new GebuehrEintrag(1500000, 1324),
    new GebuehrEintrag(1750000, 1438),
    new GebuehrEintrag(2000000, 1542),
    new GebuehrEintrag(2250000, 1635),
    new GebuehrEintrag(2500000, 1718),
    new GebuehrEintrag(3000000, 1797),
    new GebuehrEintrag(3500000, 1951),
    new GebuehrEintrag(4000000, 2089),
    new GebuehrEintrag(4500000, 2214),
    new GebuehrEintrag(5000000, 2328),
    new GebuehrEintrag(7500000, 2720),
    new GebuehrEintrag(10000000, 3162),
    new GebuehrEintrag(12500000, 3520),
    new GebuehrEintrag(15000000, 3819),
    new GebuehrEintrag(17500000, 4074),
    new GebuehrEintrag(20000000, 4293),
    new GebuehrEintrag(22500000, 4573),
    new GebuehrEintrag(25000000, 4831),
    new GebuehrEintrag(30000000, 5315),
    new GebuehrEintrag(35000000, 5759),
    new GebuehrEintrag(40000000, 6172),
    new GebuehrEintrag(45000000, 6558),
    new GebuehrEintrag(50000000, 6923),
};


                // Beratungskosten-Tabelle Anlage 1 Tabelle A (aktualisiert)
                beratungstabelle = new List<GebuehrEintrag>()
{
    new GebuehrEintrag(300, 31),
    new GebuehrEintrag(600, 56),
    new GebuehrEintrag(900, 81),
    new GebuehrEintrag(1200, 106),
    new GebuehrEintrag(1500, 130),
    new GebuehrEintrag(2000, 166),
    new GebuehrEintrag(2500, 200),
    new GebuehrEintrag(3000, 235),
    new GebuehrEintrag(3500, 270),
    new GebuehrEintrag(4000, 305),
    new GebuehrEintrag(4500, 340),
    new GebuehrEintrag(5000, 375),
    new GebuehrEintrag(6000, 422),
    new GebuehrEintrag(7000, 467),
    new GebuehrEintrag(8000, 514),
    new GebuehrEintrag(9000, 560),
    new GebuehrEintrag(10000, 605),
    new GebuehrEintrag(13000, 655),
    new GebuehrEintrag(16000, 705),
    new GebuehrEintrag(19000, 755),
    new GebuehrEintrag(22000, 805),
    new GebuehrEintrag(25000, 854),
    new GebuehrEintrag(30000, 946),
    new GebuehrEintrag(35000, 1036),
    new GebuehrEintrag(40000, 1125),
    new GebuehrEintrag(45000, 1215),
    new GebuehrEintrag(50000, 1304),
    new GebuehrEintrag(65000, 1399),
    new GebuehrEintrag(80000, 1496),
    new GebuehrEintrag(95000, 1592),
    new GebuehrEintrag(110000, 1689),
    new GebuehrEintrag(125000, 1784),
    new GebuehrEintrag(140000, 1879),
    new GebuehrEintrag(155000, 1976),
    new GebuehrEintrag(170000, 2071),
    new GebuehrEintrag(185000, 2168),
    new GebuehrEintrag(200000, 2264),
    new GebuehrEintrag(230000, 2412),
    new GebuehrEintrag(260000, 2559),
    new GebuehrEintrag(290000, 2705),
    new GebuehrEintrag(320000, 2859),
    new GebuehrEintrag(350000, 2926),
    new GebuehrEintrag(380000, 2990),
    new GebuehrEintrag(410000, 3055),
    new GebuehrEintrag(440000, 3115),
    new GebuehrEintrag(470000, 3175),
    new GebuehrEintrag(500000, 3234),
    new GebuehrEintrag(550000, 3320),
    new GebuehrEintrag(600000, 3404)
};

                buchfuehrungsTabelle = new List<GebuehrEintrag>()
{
    new GebuehrEintrag(15000, 72),
    new GebuehrEintrag(17500, 80),
    new GebuehrEintrag(20000, 88),
    new GebuehrEintrag(22500, 93),
    new GebuehrEintrag(25000, 101),
    new GebuehrEintrag(30000, 108),
    new GebuehrEintrag(35000, 117),
    new GebuehrEintrag(40000, 122),
    new GebuehrEintrag(45000, 129),
    new GebuehrEintrag(50000, 138),
    new GebuehrEintrag(62500, 145),
    new GebuehrEintrag(75000, 158),
    new GebuehrEintrag(87500, 174),
    new GebuehrEintrag(100000, 188),
    new GebuehrEintrag(125000, 209),
    new GebuehrEintrag(150000, 230),
    new GebuehrEintrag(200000, 275),
    new GebuehrEintrag(250000, 317),
    new GebuehrEintrag(300000, 359),
    new GebuehrEintrag(350000, 404),
    new GebuehrEintrag(400000, 441),
    new GebuehrEintrag(450000, 475),
    new GebuehrEintrag(500000, 512)
};

            }

            public double BerechneVolleGebuehrAbschluss(double gegenstandswert)
            {
                // Tabelle sortieren
                Abschlusstabelle.Sort((x, y) => x.GegenstandswertBis.CompareTo(y.GegenstandswertBis));

                // Überprüfen, ob der Gegenstandswert innerhalb der Tabelle liegt
                foreach (var eintrag in Abschlusstabelle)
                {
                    if (gegenstandswert <= eintrag.GegenstandswertBis)
                    {
                        return eintrag.VolleGebuehr;
                    }
                }

                // Berechnung für höhere Beträge
                return BerechneGebuehrFuerHoehereBetraegeAbschluss(gegenstandswert);
            }

            public double BerechneVolleGebuehrBeratung(double gegenstandswert)
            {
                // Tabelle sortieren
                beratungstabelle.Sort((x, y) => x.GegenstandswertBis.CompareTo(y.GegenstandswertBis));

                // Überprüfen, ob der Gegenstandswert innerhalb der Tabelle liegt
                foreach (var eintrag in beratungstabelle)
                {
                    if (gegenstandswert <= eintrag.GegenstandswertBis)
                    {
                        return eintrag.VolleGebuehr;
                    }
                }

                // Berechnung für höhere Beträge
                return BerechneGebuehrFuerHoehereBetraegeBeratung(gegenstandswert);
            }

            private double BerechneGebuehrFuerHoehereBetraegeAbschluss(double gegenstandswert)
            {
                double gebuehr = 6923; // Gebühr bis 50.000.000 Euro

                if (gegenstandswert <= 125000000)
                {
                    // Mehrbetrag über 50.000.000 Euro bis 125.000.000 Euro
                    double mehrbetrag = gegenstandswert - 50000000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 5000000);
                    gebuehr += abschnitte * 273;
                }
                else if (gegenstandswert <= 250000000)
                {
                    // Gebühren bis 125.000.000 Euro berechnen
                    gebuehr += ((125000000 - 50000000) / 5000000) * 273;

                    // Mehrbetrag über 125.000.000 Euro bis 250.000.000 Euro
                    double mehrbetrag = gegenstandswert - 125000000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 12500000);
                    gebuehr += abschnitte * 477;
                }
                else
                {
                    // Gebühren bis 250.000.000 Euro berechnen
                    gebuehr += ((125000000 - 50000000) / 5000000) * 273;
                    gebuehr += ((250000000 - 125000000) / 12500000) * 477;

                    // Mehrbetrag über 250.000.000 Euro
                    double mehrbetrag = gegenstandswert - 250000000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 25000000);
                    gebuehr += abschnitte * 681;
                }

                return gebuehr;
            }


            private double BerechneGebuehrFuerHoehereBetraegeBeratung(double gegenstandswert)
            {
                // Gebühr bis 600.000 Euro (entspricht dem Wert aus der Tabelle)
                double gebuehr = 3404;

                if (gegenstandswert <= 5000000)
                {
                    // Mehrbetrag über 600.000 Euro bis 5.000.000 Euro
                    double mehrbetrag = gegenstandswert - 600000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 50000);
                    gebuehr += abschnitte * 149;
                }
                else if (gegenstandswert <= 25000000)
                {
                    // Gebühren bis 5.000.000 Euro berechnen
                    gebuehr += ((5000000 - 600000) / 50000) * 149;

                    // Mehrbetrag über 5.000.000 Euro bis 25.000.000 Euro
                    double mehrbetrag = gegenstandswert - 5000000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 50000);
                    gebuehr += abschnitte * 112;
                }
                else
                {
                    // Gebühren bis 25.000.000 Euro berechnen
                    gebuehr += ((5000000 - 600000) / 50000) * 149;
                    gebuehr += ((25000000 - 5000000) / 50000) * 112;

                    // Mehrbetrag über 25.000.000 Euro
                    double mehrbetrag = gegenstandswert - 25000000;
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 50000);
                    gebuehr += abschnitte * 88;
                }

                return gebuehr;
            }

            public double BerechneVolleGebuehrBuchfuehrung(double gegenstandswert)
            {
                // Tabelle sortieren, damit sie immer aufsteigend ist
                buchfuehrungsTabelle.Sort((x, y) => x.GegenstandswertBis.CompareTo(y.GegenstandswertBis));

                // Überprüfen, ob der Gegenstandswert innerhalb der Tabelle liegt
                foreach (var eintrag in buchfuehrungsTabelle)
                {
                    if (gegenstandswert <= eintrag.GegenstandswertBis)
                    {
                        return eintrag.VolleGebuehr;
                    }
                }

                // Berechnung für höhere Beträge über 500.000 Euro
                return BerechneGebuehrFuerHoehereBetraegeBuchfuehrung(gegenstandswert);
            }

            private double BerechneGebuehrFuerHoehereBetraegeBuchfuehrung(double gegenstandswert)
            {
                double grundgebuehr = 512; // Gebühr bis 500.000 Euro

                if (gegenstandswert > 500000)
                {
                    // Mehrbetrag über 500.000 Euro berechnen
                    double mehrbetrag = gegenstandswert - 500000;

                    // Jede angefangene 50.000 Euro kostet 36 Euro zusätzlich
                    int abschnitte = (int)Math.Ceiling(mehrbetrag / 50000);
                    double zusatzgebuehr = abschnitte * 36;

                    return grundgebuehr + zusatzgebuehr;
                }

                return grundgebuehr;
            }

        }

        public Honorarrechner()
        {
            
            InitializeComponent();

            LadeDatenAusExcel();

            this.MaximizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void txtUmsatz_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(tB_Umsatz.Text, out double umsatz))
            {
                // Text in der TextBox als Währung formatieren
                tB_Umsatz.Text = umsatz.ToString("N2") + " €";
            }
        }

        private void txtBilanzsumme_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(tB_Bilanzsumme.Text, out double bilanzsumme))
            {
                // Text in der TextBox als Währung formatieren
                tB_Bilanzsumme.Text = bilanzsumme.ToString("N2") + " €";
            }
        }

        private void txtAusgaben_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(tB_Ausgaben.Text, out double ausgaben))
            {
                // Text in der TextBox als Währung formatieren
                tB_Ausgaben.Text = ausgaben.ToString("N2") + " €";
            }
        }

        private void ShowPage(int pageNumber)
        {
            panelStart.Visible = (pageNumber == 0);

            switch (Mandatstyps)
            {
                case "Privat":
                    //panelPrivat.Visible = (pageNumber == 1);
                    break;

                case "Unternehmen":
                    panelUnternehmensDaten.Visible = (pageNumber == 1);
                    panelLeistungen.Visible = (pageNumber == 2);
                    break;
                case "StartUp":
                    //panelStartUp.Visible = (pageNumber == 1);
                    break;
            }
        }

        private void BTN_Weiter_Click(object sender, EventArgs e)
        {
            currentPage++;
            ShowPage(currentPage);
            CalculateEverything();
            if (currentPage > 0)
            {
                BTN_Zurueck.Enabled = true;
            }

            if (currentPage == 1)
            {
                CalculateEverything();

                if (tB_AnzahlMitarbeiter.Text.Length > 0)
                {
                    BTN_Weiter.Enabled = true;
                }
                else
                {
                    BTN_Weiter.Enabled = false;
                }
            }

            if (currentPage == 2)
            {
                BTN_Weiter.Visible = false;
            }
        }

        private void BTN_Zurueck_Click(object sender, EventArgs e)
        {
            currentPage--;
            ShowPage(currentPage);

            if (currentPage == 0)
            {
                BTN_Zurueck.Enabled = false;
            }

            if (currentPage == 1)
            {
                BTN_Weiter.Visible = true;
            }

            if (currentPage == 2)
            {
                BTN_Weiter.Enabled = false;
                BTN_Weiter.Visible = false;
            }
            else
                BTN_Weiter.Enabled = true;
        }

        private void cB_Privat_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Privat.Checked)
            {
                Mandatstyps = "Privat";
                cB_UN.Checked = false;
                cB_StartUp.Checked = false;
            }

        }

        private void cB_UN_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_UN.Checked)
            {
                Mandatstyps = "Unternehmen";
                cB_Privat.Checked = false;
                cB_StartUp.Checked = false;
            }
        }

        private void cB_StartUp_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_StartUp.Checked)
            {
                Mandatstyps = "StartUp";
                cB_UN.Checked = false;
                cB_Privat.Checked = false;
            }
        }

        private void CalcCurrentMonatsHonorar(double AddedBeitrag, int LeistungsID)
        {
            CurrentMonatsHonorar = 0;

            if (FiBuBeitrag < minPauschaleFiBuMonatlich && FiBuBeitrag > 0)
                FiBuBeitrag = minPauschaleFiBuMonatlich;

            switch (LeistungsID)
            {
                case 1:
                    FiBuBeitrag = AddedBeitrag;
                    if (FiBuBeitrag < minPauschaleFiBuMonatlich && FiBuBeitrag > 0)
                        FiBuBeitrag = minPauschaleFiBuMonatlich;
                    break;
                case 2:
                    JABeitrag = AddedBeitrag;
                    break;
                case 3:
                    LohnBeitrag = AddedBeitrag;
                    break;
            }

            SetCurrentMonatsHonorar();

        }

        private void SetCurrentMonatsHonorar()
        {
            CurrentMonatsHonorar = 0;

            if (cB_FiBu.Checked)
                CurrentMonatsHonorar += FiBuBeitrag;

            if (cB_JA.Checked)
                CurrentMonatsHonorar += JABeitrag;

            if (cB_Lohn.Checked)
                CurrentMonatsHonorar += LohnBeitrag;

            if (cB_SeBu.Checked)
            {
                SetCurrentSeBuPauschale(JABeitrag);
                CurrentMonatsHonorar += SeBuBeitrag;
            }

            //CurrentMonatsHonorar = FiBuBeitrag + JABeitrag + LohnBeitrag;
            l_currentJahresHonorar.Text = CurrentMonatsHonorar.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_currentMonatsHonorar.Text = (CurrentMonatsHonorar / 12).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));


            //MessageBox.Show("FiBu: " + FiBuBeitrag + ", JA: " + JABeitrag + ", Lohn: " + LohnBeitrag + ", SeBu: " + SeBuBeitrag);
        }

        private void SetCurrentSeBuPauschale(double JABeitrag)
        {
            SeBuBeitrag = JABeitrag * 0.20;
            double SeBuBeitragMonat;
            SeBuBeitragMonat = SeBuBeitrag / 12;
            l_LeistungenSeBuMonatlich.Text = SeBuBeitragMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_SBZSLeistungen.Text = SeBuBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
        }

        private void cB_SeBu_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentMonatsHonorar();

            if (cB_SeBu.Checked)
            {
                cB_FiBu.Enabled = false;
            }
            else
            {
                cB_FiBu.Enabled = true;
            }
        }

        private void cB_EUBilanz_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_EUBilanz.Checked)
            {
                UnternehmensArt = "EU";
                checkBoxGes_Bilanz_new.Enabled = false;
                BTN_Weiter.Enabled = true;
                lL_ZurBilanz.Enabled = true;
                l_BilanzMin.Text = "min. " + CompleteBilanzMinEUMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            }
            else
            {
                UnternehmensArt = "NIX";
                checkBoxGes_Bilanz_new.Enabled = true;
                BTN_Weiter.Enabled = false;
                lL_ZurBilanz.Enabled = false;
                l_BilanzMin.Text = "min. " + CompleteBilanzMinGesellschafftMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            }
            CalculateEverything();
        }

        private void cB_Ges_Bilanz_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGes_Bilanz.Checked)
            {
                UnternehmensArt = "GESELLSCHAFT";
                cB_EUBilanz_new.Enabled = false;
                BTN_Weiter.Enabled = true;
                lL_ZurBilanz.Enabled = true;
                l_BilanzMin.Text = "min. " + CompleteBilanzMinGesellschafftMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            }
            else
            {
                UnternehmensArt = "NIX";
                cB_EUBilanz_new.Enabled = true;
                BTN_Weiter.Enabled = false;
                lL_ZurBilanz.Enabled = false;
                l_BilanzMin.Text = "min. " + CompleteBilanzMinEUMonat.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            }
            CalculateEverything();
        }

        private void cB_BarGeldGewerbe_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_BargeldGewerbe.Checked)
            {
                GewerbeArt = "BARGELDGEWERBE";
                cB_OnlineHaendler_new.Enabled = false;
            }
            else
            {
                GewerbeArt = "NIX";
                cB_OnlineHaendler_new.Enabled = true;
            }
            CalculateEverything();
        }

        private void cB_OnlineHaendler_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_OnlineHaendler.Checked)
            {
                GewerbeArt = "ONLINEHAENDLER";
                cB_BargeldGewerbe_new.Enabled = false;
            }
            else
            {
                GewerbeArt = "NIX";
                cB_BargeldGewerbe_new.Enabled = true;
            }
            CalculateEverything();
        }

        private void BTN_ExcelList_Click(object sender, EventArgs e)
        {
            LadeDatenAusExcel();
            CalculateEverything();
        }

        private void CalculateEverything()
        {
            LohnBeitrag = BerechneLohnBeitrag(AnzahlAnMitarbeitern);

            CalculateFibuBeitrag();


            if (cB_EUR.Checked)
            {
                if (cB_UdB.Checked)
                {
                    CalcCompleteEUR(true);
                }
                else
                {
                    CalcCompleteEUR(false);
                }
            }
            else if (cB_Bilanz.Checked)
                CalcCompleteBilanz();

            SetCurrentMonatsHonorar();
        }

        //UnternehmensDaten///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Unternehmens Daten 
        bool UmsatzAngegeben; double Umsatz;
        private void tB_Umsatz_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tB_Umsatz.Text))
            {
                string eingabe = tB_Umsatz.Text.Replace(".", "");  // Entferne bestehende Punkte
                if (double.TryParse(eingabe, out double wert))
                {
                    tB_Umsatz.TextChanged -= tB_Umsatz_TextChanged;  // Temporär das Event entfernen, um eine Endlosschleife zu verhindern
                    tB_Umsatz.Text = string.Format("{0:N0}", wert);  // Format mit Tausendertrennzeichen
                    tB_Umsatz.SelectionStart = tB_Umsatz.Text.Length;  // Cursor an das Ende setzen
                    tB_Umsatz.TextChanged += tB_Umsatz_TextChanged;  // Event wieder hinzufügen
                }
            }

            if (tB_Umsatz.Text.Length > 0)
            {
                UmsatzAngegeben = true;
            }

            if (AnzahlAnMitarbeiternAngegeben && UmsatzAngegeben)
                BTN_Weiter.Enabled = true;


            if (tB_Umsatz.Text.Length > 0)
            {
                Umsatz = Convert.ToDouble(tB_Umsatz.Text.Replace(" €", "").Trim());
            }

        }

        double Jahresueberschuss;
        private void tB_Ausgaben_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tB_Ausgaben.Text))
            {
                string eingabe = tB_Ausgaben.Text.Replace(".", "");  // Entferne bestehende Punkte
                if (double.TryParse(eingabe, out double wert))
                {
                    tB_Ausgaben.TextChanged -= tB_Ausgaben_TextChanged;  // Temporär das Event entfernen, um eine Endlosschleife zu verhindern
                    tB_Ausgaben.Text = string.Format("{0:N0}", wert);  // Format mit Tausendertrennzeichen
                    tB_Ausgaben.SelectionStart = tB_Ausgaben.Text.Length;  // Cursor an das Ende setzen
                    tB_Ausgaben.TextChanged += tB_Ausgaben_TextChanged;  // Event wieder hinzufügen
                }
            }


            if (tB_Ausgaben.Text.Length > 0)
            {
                CalcBEA();
                string text = tB_Ausgaben.Text.Replace(" €", "").Trim();
                double betrag;
                if (double.TryParse(text, out betrag))
                {
                    Jahresueberschuss = betrag;
                }
                //Jahresueberschuss = Convert.ToDouble(txtAusgaben.Text.Replace(" €", "").Trim());

            }
        }

        #endregion

        //FiBu/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region FiBu
        private void cB_FiBu_CheckedChanged(object sender, EventArgs e)
        {
            CalculateFibuBeitrag();

            if (cB_FiBu.Checked)
            {
                lL_ZurFiBu.Visible = true;
                SetCurrentMonatsHonorar();
                cB_SeBu.Enabled = false;
            }
            else
            {
                lL_ZurFiBu.Visible = false;
                SetCurrentMonatsHonorar();
                cB_SeBu.Enabled = true;
            }
        }

        double FiBuNormalSatz; string FiBuNormalSatzTXT = "";
        double BarGeldGewerbeSatz; string BarGeldGewerbeSatzTXT = "";
        double OnlineHaendlerSatz; string OnlineHaendlerSatzTXT = "";
        double BuchfuerungsSatz;
        double MonatsPauschaleFiBU; double JahresPauschaleFiBu; double ITPauschale;
        double AuslagenPauschaleProzentSatz; double AuslagenPauschaleMaximum;
        double FiBuMinUmsatz = 0; double minPauschaleFiBuMonatlich = 0;

        private void CalculateFibuBeitrag()
        {
            #region Mit Stunden Gerechnet
            /*
            if (textBoxStundenFiBu.Text.Length > 0)
            {
                
                double hours = 1.5;

                if (Convert.ToDouble(textBoxStundenFiBu.Text) > 1.5)
                    hours = Convert.ToDouble(textBoxStundenFiBu.Text);

                textBoxStundenFiBu.Text = hours.ToString();
                MonatsPauschaleFiBU = hours * BuchfuerungsSatz;
                labelBuchFuerungPauschale.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                labelITPauschale.Text = ITPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                labelPauschaleIT.Text = ITPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                labelFiBuSatz.Text = BuchfuerungsSatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                // AuslagenPauschale

                double AuslagenPauschale = MonatsPauschaleFiBU * AuslagenPauschaleProzentSatz;
                if (AuslagenPauschale >= AuslagenPauschaleMaximum)
                    AuslagenPauschale = AuslagenPauschaleMaximum;

                MonatsPauschaleFiBU += AuslagenPauschale + ITPauschale;
                JahresPauschaleFiBu = MonatsPauschaleFiBU * 12;

                string prozentString = (AuslagenPauschaleProzentSatz * 100).ToString("F0") + " %";

                labelProzentFiBu.Text = prozentString;

                FiBuZwischenSumme.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                labelFiBuZSJahr.Text = JahresPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                labelAuslagenPauschale2.Text = AuslagenPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                double minPauschaleFiBu = 208 * 12;
                double minPauschaleFiBuMonatlich = 208;

                if (MonatsPauschaleFiBU < 208)
                {
                    labelFiBuZSLeistungen.Text = minPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                    labelLeistungenFiBuMonatlich.Text = minPauschaleFiBuMonatlich.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                    CalculateCurrentMonatsHonorar((208 * 12), 1);
                }
                else
                {
                    labelFiBuZSLeistungen.Text = JahresPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                    labelLeistungenFiBuMonatlich.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                    CalculateCurrentMonatsHonorar(JahresPauschaleFiBu, 1);
                }
            }
            */
            #endregion

            switch (GewerbeArt)
            {
                case "BARGELDGEWERBE":
                    BuchfuerungsSatz = BarGeldGewerbeSatz;
                    labelFiBuSatz.Text = BarGeldGewerbeSatzTXT;
                    break;
                case "ONLINEHAENDLER":
                    BuchfuerungsSatz = OnlineHaendlerSatz;
                    labelFiBuSatz.Text = OnlineHaendlerSatzTXT;
                    break;
                case "NIX":
                    BuchfuerungsSatz = FiBuNormalSatz;
                    labelFiBuSatz.Text = FiBuNormalSatzTXT;
                    break;
            }

            double minUmsatz = FiBuMinUmsatz;

            if (Umsatz < minUmsatz)
            {
                tB_FiBuUmsatz.Text = minUmsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minUmsatz;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBuchfuehrung(gegenstandswert);
                MonatsPauschaleFiBU = volleGebuehrBeratung * BuchfuerungsSatz;
            }
            else
            {
                tB_FiBuUmsatz.Text = Umsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Umsatz;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBuchfuehrung(gegenstandswert);
                MonatsPauschaleFiBU = volleGebuehrBeratung * BuchfuerungsSatz;
            }


            labelITPauschale.Text = ITPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_PauschaleIT.Text = ITPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_BuchFuerungPauschale.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

            // AuslagenPauschale

            double AuslagenPauschale = MonatsPauschaleFiBU * AuslagenPauschaleProzentSatz;
            if (AuslagenPauschale >= AuslagenPauschaleMaximum)
                AuslagenPauschale = AuslagenPauschaleMaximum;

            MonatsPauschaleFiBU += AuslagenPauschale + ITPauschale;
            JahresPauschaleFiBu = MonatsPauschaleFiBU * 12;

            string prozentString = (AuslagenPauschaleProzentSatz * 100).ToString("F0") + " %";

            l_ProzentFiBu.Text = prozentString;

            FiBuZwischenSumme.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_FiBuZSJahr.Text = JahresPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_AuslagenPauschale2.Text = AuslagenPauschale.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

            double minPauschaleFiBu = minPauschaleFiBuMonatlich * 12;

            if (MonatsPauschaleFiBU < minPauschaleFiBuMonatlich)
            {
                l_FiBuZSLeistungen.Text = minPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                l_LeistungenFiBuMonatlich.Text = minPauschaleFiBuMonatlich.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                CalcCurrentMonatsHonorar((minPauschaleFiBuMonatlich * 12), 1);
            }
            else
            {
                l_FiBuZSLeistungen.Text = JahresPauschaleFiBu.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                l_LeistungenFiBuMonatlich.Text = MonatsPauschaleFiBU.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                CalcCurrentMonatsHonorar(JahresPauschaleFiBu, 1);
            }
        }
        private async void tB_StundenFiBu_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(1500);
            CalculateFibuBeitrag();
        }
        private void BTN_backfromFiBu_Click(object sender, EventArgs e)
        {
            panelFiBu.Visible = false;
            BTN_Zurueck.Enabled = true;
            BTN_Weiter.Enabled = true;
        }
        private void lL_ZurFiBu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelFiBu.Visible = true;
            panelFiBu.BringToFront();
            BTN_Zurueck.Enabled = false;
            BTN_Weiter.Enabled = false;
        }
        #endregion

        //Lohn Rechner/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Lohn
        bool AnzahlAnMitarbeiternAngegeben;
        int AnzahlAnMitarbeitern;
        private void cB_Lohn_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Lohn.Checked)
            {
                lL_zumLohn.Visible = true;
                LohnBeitrag = BerechneLohnBeitrag(AnzahlAnMitarbeitern);
                tB_AnzahlMitarbeiterLohn.Text = AnzahlAnMitarbeitern.ToString();
                SetCurrentMonatsHonorar();
            }
            else
            {
                lL_zumLohn.Visible = false;
                LohnBeitrag = BerechneLohnBeitrag(AnzahlAnMitarbeitern);
                tB_AnzahlMitarbeiterLohn.Text = AnzahlAnMitarbeitern.ToString();
                SetCurrentMonatsHonorar();
            }
        }

        double BeitragEINS; double BeitragZWEIBISNEUN; double BeitragZEHNBISNEUNZEHN; double BeitragZWANZIGBISVIEUNDNEUNZIG; double BeitragFUENFZIGBISHUNDERT;
        public double BerechneLohnBeitrag(int mitarbeiterAnzahl)
        {
            double completeBeitrag = 0;
            double EINSBeitrag = 0;
            double ZWEIBISNEUNBEITRAG = 0;
            double ZEHNBISNEUNZEHNBEITRAG = 0;
            double ZWANZIGBISNEUNUNDVIERZIGBEITRAG = 0;
            double FUENFZIGBISHUNDERTBEITRAG = 0;
            double ABHUNDERTEINSBEITRAG = 0;

            if (mitarbeiterAnzahl > 1)
            {
                EINSBeitrag = BeitragEINS;
                completeBeitrag += BeitragEINS; // Beitrag für den 1. Mitarbeiter
                l_1_Mitarbeiter.Text = EINSBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                l_MA1.Text = "1";
            }
            else if (mitarbeiterAnzahl == 1)
            {
                EINSBeitrag = BeitragEINS;
                completeBeitrag += BeitragEINS; // Beitrag für den 1. Mitarbeiter
                l_1_Mitarbeiter.Text = EINSBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                l_MA1.Text = "1";
                l_AnzahlZW2bis9.Text = "0";
                l_AnzahlZW10bis19.Text = "0";
                l_AnzahlZW20bis49.Text = "0";
                l_AnzahlZW50bis100.Text = "0";
                l_AnzahlAb101.Text = "0";
            }
            else
            {
                EINSBeitrag = 0;
                l_1_Mitarbeiter.Text = EINSBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                l_MA1.Text = "0";
                l_AnzahlZW2bis9.Text = "0";
                l_AnzahlZW10bis19.Text = "0";
                l_AnzahlZW20bis49.Text = "0";
                l_AnzahlZW50bis100.Text = "0";
                l_AnzahlAb101.Text = "0";
            }

            if (mitarbeiterAnzahl >= 2 && mitarbeiterAnzahl > 9)
            {
                ZWEIBISNEUNBEITRAG = 8 * BeitragZWEIBISNEUN;
                completeBeitrag += 8 * BeitragZWEIBISNEUN; // Beitrag für Mitarbeiter 2-9
                l_AnzahlZW2bis9.Text = "8";
            }
            else if (mitarbeiterAnzahl > 1)
            {
                ZWEIBISNEUNBEITRAG += (mitarbeiterAnzahl - 1) * BeitragZWEIBISNEUN;
                completeBeitrag += (mitarbeiterAnzahl - 1) * BeitragZWEIBISNEUN;
                l_AnzahlZW2bis9.Text = (mitarbeiterAnzahl - 1).ToString();
                l_AnzahlZW10bis19.Text = "0";
                l_AnzahlZW20bis49.Text = "0";
                l_AnzahlZW50bis100.Text = "0";
                l_AnzahlAb101.Text = "0";
            }

            if (mitarbeiterAnzahl >= 10 && mitarbeiterAnzahl > 19)
            {
                ZEHNBISNEUNZEHNBEITRAG = 10 * BeitragZEHNBISNEUNZEHN;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += 10 * BeitragZEHNBISNEUNZEHN;
                l_AnzahlZW10bis19.Text = "10";
            }
            else if (mitarbeiterAnzahl > 9)
            {
                ZEHNBISNEUNZEHNBEITRAG = (mitarbeiterAnzahl - 9) * BeitragZEHNBISNEUNZEHN;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += (mitarbeiterAnzahl - 9) * BeitragZEHNBISNEUNZEHN; // Beitrag für Mitarbeiter 10-19
                l_AnzahlZW10bis19.Text = (mitarbeiterAnzahl - 9).ToString();
                l_AnzahlZW20bis49.Text = "0";
                l_AnzahlZW50bis100.Text = "0";
                l_AnzahlAb101.Text = "0";
            }

            if (mitarbeiterAnzahl >= 20 && mitarbeiterAnzahl > 49)
            {
                ZWANZIGBISNEUNUNDVIERZIGBEITRAG = 30 * BeitragZWANZIGBISVIEUNDNEUNZIG;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += 30 * BeitragZWANZIGBISVIEUNDNEUNZIG;
                l_AnzahlZW20bis49.Text = "30";
            }
            else if (mitarbeiterAnzahl > 20)
            {
                ZWANZIGBISNEUNUNDVIERZIGBEITRAG = (mitarbeiterAnzahl - 19) * BeitragZWANZIGBISVIEUNDNEUNZIG;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += (mitarbeiterAnzahl - 9) * BeitragZWANZIGBISVIEUNDNEUNZIG; // Beitrag für Mitarbeiter 10-19
                l_AnzahlZW20bis49.Text = (mitarbeiterAnzahl - 19).ToString();
                l_AnzahlZW50bis100.Text = "0";
                l_AnzahlAb101.Text = "0";
            }

            if (mitarbeiterAnzahl >= 50 && mitarbeiterAnzahl > 100)
            {
                FUENFZIGBISHUNDERTBEITRAG = 51 * BeitragFUENFZIGBISHUNDERT;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += 51 * BeitragFUENFZIGBISHUNDERT;
                l_AnzahlZW50bis100.Text = "51";
            }
            else if (mitarbeiterAnzahl > 50)
            {
                FUENFZIGBISHUNDERTBEITRAG = (mitarbeiterAnzahl - 49) * BeitragFUENFZIGBISHUNDERT;
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                completeBeitrag += (mitarbeiterAnzahl - 49) * BeitragFUENFZIGBISHUNDERT; // Beitrag für Mitarbeiter 10-19
                l_AnzahlZW50bis100.Text = (mitarbeiterAnzahl - 49).ToString();
                l_AnzahlAb101.Text = "0";
            }

            if (mitarbeiterAnzahl >= 100)
            {
                //completeBeitrag += 8 * 30; // Beitrag für Mitarbeiter 2-9
                //completeBeitrag += 10 * 24; // Beitrag für Mitarbeiter 10-19

                double satzProMitarbeiter = Math.Max(20 - (mitarbeiterAnzahl - 100) * 0.1, 15); // Beitrag sinkt je mehr Mitarbeiter es gibt, mindestens jedoch 10 €
                l_SatzAb101Mitarbeiter.Text = satzProMitarbeiter.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                ABHUNDERTEINSBEITRAG = (mitarbeiterAnzahl - 100) * satzProMitarbeiter;
                completeBeitrag += (mitarbeiterAnzahl - 100) * satzProMitarbeiter;
                l_AnzahlAb101.Text = (mitarbeiterAnzahl - 100).ToString();
            }


            double completeBeitragJahr = completeBeitrag * 12;

            l_2bis9_Mitarbeiter.Text = ZWEIBISNEUNBEITRAG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_10bis19_Mitarbeiter.Text = ZEHNBISNEUNZEHNBEITRAG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_20bis49_Mitarbeiter.Text = ZWANZIGBISNEUNUNDVIERZIGBEITRAG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_50bis100_Mitarbeiter.Text = FUENFZIGBISHUNDERTBEITRAG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_ab101_Mitarbeiter.Text = ABHUNDERTEINSBEITRAG.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_ZSLohnMonat.Text = completeBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_LeistungenLohnMonatlich.Text = completeBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_ZSLohn.Text = completeBeitragJahr.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_LohnZSLeistungen.Text = completeBeitragJahr.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

            return completeBeitragJahr;
        }
        private void tB_AnzahlMitarbeiter_TextChanged(object sender, EventArgs e)
        {
            if (tB_AnzahlMitarbeiter.Text.Length > 0)
            {
                AnzahlAnMitarbeiternAngegeben = true;
                BTN_Weiter.Enabled = true;
                AnzahlAnMitarbeitern = int.Parse(tB_AnzahlMitarbeiter.Text);
                tB_AnzahlMitarbeiterLohn.Text = AnzahlAnMitarbeitern.ToString();
                LohnBeitrag = BerechneLohnBeitrag(AnzahlAnMitarbeitern);
                SetCurrentMonatsHonorar();
            }
            else
                BerechneLohnBeitrag(0);

        }
        private void tB_AnzahlMitarbeiterLohn_TextChanged(object sender, EventArgs e)
        {
            if (tB_AnzahlMitarbeiterLohn.Text.Length > 0)
            {
                tB_AnzahlMitarbeiter.Text = tB_AnzahlMitarbeiterLohn.Text;
                AnzahlAnMitarbeitern = int.Parse(tB_AnzahlMitarbeiter.Text);
                LohnBeitrag = BerechneLohnBeitrag(AnzahlAnMitarbeitern);
                SetCurrentMonatsHonorar();
            }
            else
                BerechneLohnBeitrag(0);
        }
        private void lL_zumLohn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelLohn.Visible = true;
            panelLohn.BringToFront();
            BTN_Zurueck.Enabled = false;
            BTN_Weiter.Enabled = false;
        }
        private void BTN_ZurueckLohn_Click(object sender, EventArgs e)
        {
            panelLohn.Visible = false;
            BTN_Zurueck.Enabled = true;
            BTN_Weiter.Enabled = true;
        }

        #endregion

        //Jahresabschluss//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Jahresabschluss
        //Einnamen UEberschuss Rechner
        #region EUR
        GebuehrenRechner rechner = new GebuehrenRechner();

        double BEAGebuehr;
        double BetriebsEinnahmenAusgabenSatz; double GewerbesteuerSatz; double UEberschussderBetriebseinnahmenSatz; double UmsatzsteuererklaerungsSatz; double PauschalefuerAbschlussarbeitenSatz;
        double BEAminBeitrag; double GewerbesteuerMinBeitrag; double UEdBminBeitrag; double UmsatzsteuererlaerungMinBeitrag;
        double CompleteEURminMonat;
        private void CalcCompleteEUR(bool Selbststaendig) //Einnahmen Überschuss Rechner
        {
            double CompleteEUR;
            double CompleteEURmin = CompleteEURminMonat * 12;

            if (Selbststaendig)
                CompleteEUR = CalcBEA() + CalcGewerbesteuer() + CalcUEdB() + CalcUmsatzsteuererklaerung() + CalcPauschalefuerAbschlussarbeiten();
            else
                CompleteEUR = CalcBEA() + CalcGewerbesteuer() + CalcUmsatzsteuererklaerung() + CalcPauschalefuerAbschlussarbeiten();


            if (CompleteEUR < CompleteEURmin)
            {
                CompleteEUR = CompleteEURmin;
            }

            labelEURZWJA.Text = CompleteEUR.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            if (cB_EUR.Checked)
            {
                l_JAZSLeistungen.Text = labelEURZWJA.Text;
                JABeitrag = CompleteEUR;
            }
            else
            {
                JABeitrag = 0;
            }

            l_LeistungenJAMonatlich.Text = (CompleteEUR / 12).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_EURWSMonatlich.Text = (CompleteEUR / 12).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_EURWS.Text = CompleteEUR.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

            CalcCurrentMonatsHonorar(JABeitrag, 2);
        }

        private double CalcBEA() //Betriebs Einnahmen-Ausgaben
        {
            double Gewinn = Jahresueberschuss;
            double minGewinn = BEAminBeitrag;
            if (Gewinn < minGewinn)
            {
                tB_BEA.Text = minGewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minGewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                BEAGebuehr = volleGebuehr * BetriebsEinnahmenAusgabenSatz;
            }
            else
            {
                tB_BEA.Text = Gewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Gewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                BEAGebuehr = volleGebuehr * BetriebsEinnahmenAusgabenSatz;
            }

            labelBEA.Text = BEAGebuehr.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return BEAGebuehr;
        }


        double Gewerbesteuer;
        private double CalcGewerbesteuer()
        {
            double Gewinn = Jahresueberschuss;

            double minGewinn = GewerbesteuerMinBeitrag;
            if (Gewinn < minGewinn)
            {
                tB_Gewerbesteuer.Text = minGewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                double gegenstandswert = minGewinn;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                Gewerbesteuer = volleGebuehrBeratung * GewerbesteuerSatz;
            }
            else
            {
                tB_Gewerbesteuer.Text = Gewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                double gegenstandswert = Gewinn;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                Gewerbesteuer = volleGebuehrBeratung * GewerbesteuerSatz;
            }

            l_Gewerbesteuer.Text = Gewerbesteuer.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return Gewerbesteuer;
        }


        double EUdBBeitrag;
        private double CalcUEdB() //Überschuss der Betriebseinnahmen
        {
            double Gewinn = Jahresueberschuss;
            double minGewinn = UEdBminBeitrag;
            if (Gewinn < minGewinn)
            {
                tB_UdB.Text = minGewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minGewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                EUdBBeitrag = volleGebuehr * UEberschussderBetriebseinnahmenSatz;
            }
            else
            {
                tB_UdB.Text = Gewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Gewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                EUdBBeitrag = volleGebuehr * UEberschussderBetriebseinnahmenSatz;
            }

            l_UeberschussdBetriebseinnahmen.Text = EUdBBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return EUdBBeitrag;
        }

        double UmsatzsteuererklärungsBeitrag;
        private double CalcUmsatzsteuererklaerung()
        {
            double minUmsatz = UmsatzsteuererlaerungMinBeitrag;

            if (Umsatz < minUmsatz)
            {
                tB_Umsatzsteuererklärung.Text = minUmsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minUmsatz;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                UmsatzsteuererklärungsBeitrag = volleGebuehrBeratung * UmsatzsteuererklaerungsSatz;
            }
            else
            {
                tB_Umsatzsteuererklärung.Text = Umsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Umsatz;
                double volleGebuehrBeratung = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                UmsatzsteuererklärungsBeitrag = volleGebuehrBeratung * UmsatzsteuererklaerungsSatz;
            }

            l_Umsatzsteuererklärung.Text = UmsatzsteuererklärungsBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return UmsatzsteuererklärungsBeitrag;
        }

        double PauschalefAbschlussarbeiten;
        private double CalcPauschalefuerAbschlussarbeiten()
        {
            int AnzahlPauschalen = 3;
            PauschalefAbschlussarbeiten = AnzahlPauschalen * PauschalefuerAbschlussarbeitenSatz;
            tB_PfA.Text = AnzahlPauschalen.ToString();
            l_Abschlussarbeiten.Text = PauschalefAbschlussarbeiten.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return PauschalefAbschlussarbeiten;
        }

        private void tB_BEA_TextChanged(object sender, EventArgs e)
        {
            //CalculateBEA();
        }

        private void lL_zumEUR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEUR.Visible = true;
            panelEUR.BringToFront();
            BTN_JAZurueck.Enabled = false;
        }

        private void BTN_EURZurueck_Click(object sender, EventArgs e)
        {
            panelEUR.Visible = false;
            BTN_JAZurueck.Enabled = true;
        }

        private void cB_EUR_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_EUR.Checked)
            {
                cB_Bilanz_new.Enabled = false;
                lL_zumEUR.Visible = true;
                labelEURZWJA.Visible = true;
                CalcCompleteEUR(false);
            }
            else
            {
                cB_Bilanz_new.Enabled = true;
                lL_zumEUR.Visible = false;
                labelEURZWJA.Visible = false;
                CalcCompleteEUR(false);
            }
        }

        private void l_JAZSLeistungen_TextChanged(object sender, EventArgs e)
        {
            //CalculateCurrentMonatsHonorar(Convert.ToDouble(labelJAZSLeistungen.Text.Replace(" €", "").Trim()), 2);
        }

        private void cB_UdB_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_UdB.Checked)
            {
                CalcCompleteEUR(true);
            }
            else
            {
                CalcCompleteEUR(false);
            }
        }

        #endregion

        //Bilanz Rechner
        #region Bilanz

        double Bilanzsumme;

        double AdJSatz; double ErstellungdesAntragsSatz; double EntwicklungeinerSteuerbilanzSatz; double KoerperschaftssteuererklaerungsSatz;
        double UmsatzsteuererklaerungfdKJSatz; double ErklaerungZurGewerbesteuerSatz; double BilanzBescheideSatz; double E_BilanzBeitrag; double OffenlegungsBeitrag;

        double AdJSatzMIN; double ErstellungdesAntragsSatzMIN; double EntwicklungeinerSteuerbilanzSatzMIN; double KoerperschaftssteuererklaerungsSatzMIN;
        double UmsatzsteuererklaerungfdKJSatzMIN; double ErklaerungZurGewerbesteuerSatzMIN;

        double CompleteBilanzMinEUMonat;
        double CompleteBilanzMinGesellschafftMonat;
        private void tB_Bilanzsumme_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tB_Bilanzsumme.Text))
            {
                string eingabe = tB_Bilanzsumme.Text.Replace(".", "");  // Entferne bestehende Punkte
                if (double.TryParse(eingabe, out double wert))
                {
                    tB_Bilanzsumme.TextChanged -= tB_Bilanzsumme_TextChanged;  // Temporär das Event entfernen, um eine Endlosschleife zu verhindern
                    tB_Bilanzsumme.Text = string.Format("{0:N0}", wert);  // Format mit Tausendertrennzeichen
                    tB_Bilanzsumme.SelectionStart = tB_Bilanzsumme.Text.Length;  // Cursor an das Ende setzen
                    tB_Bilanzsumme.TextChanged += tB_Bilanzsumme_TextChanged;  // Event wieder hinzufügen
                }
            }

            if (tB_Bilanzsumme.Text.Length > 0)
            {
                Bilanzsumme = Convert.ToDouble(tB_Bilanzsumme.Text.Replace(" €", "").Trim());
            }
        }

        private void lL_ZurBilanz_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelBilanz.Visible = true;
            panelBilanz.BringToFront();
        }

        private void BTN_ZurueckBilanz_Click(object sender, EventArgs e)
        {
            panelBilanz.Visible = false;
        }

        private void CalcCompleteBilanz()
        {
            double CompleteBilanz = 0;
            double CompleteBilanzMIN = 0;

            switch (UnternehmensArt)
            {
                case "EU":
                    CompleteBilanzMIN = CompleteBilanzMinEUMonat * 12;
                    break;
                case "GESELLSCHAFT":
                    CompleteBilanzMIN = CompleteBilanzMinGesellschafftMonat * 12;
                    break;
                case "NIX":
                    CompleteBilanzMIN = 0;
                    break;
            }

            double BilanzBescheide = 4 * BilanzBescheideSatz;
            l_BilanzBescheide.Text = BilanzBescheide.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

            CompleteBilanz = CalcAdJA() + CalcErstellungdesAntrags() + CalcEntwEinerSteuerbilanz() + CalcKoerperschaftssteuer()
                + CalcUmsatzsteuererklaerungfuerKJ() + CalcErklaerungzurGewerbesteuer() + E_BilanzBeitrag + OffenlegungsBeitrag + BilanzBescheide;


            if (CompleteBilanz < CompleteBilanzMIN)
            {
                CompleteBilanz = CompleteBilanzMIN;
            }
            else if (CompleteBilanzMIN == 0)
            {
                CompleteBilanz = 0;
            }


            if (cB_Bilanz.Checked)
            {
                l_JAZSLeistungen.Text = labelZSBilanzJA.Text;
                JABeitrag = CompleteBilanz;
            }
            else
            {
                JABeitrag = 0;
            }

            labelZSBilanzJA.Text = CompleteBilanz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_BilanzZS.Text = CompleteBilanz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_BilanzZSMonatlich.Text = (CompleteBilanz / 12).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_JAZSLeistungen.Text = CompleteBilanz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            l_LeistungenJAMonatlich.Text = (CompleteBilanz / 12).ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            CalcCurrentMonatsHonorar(JABeitrag, 2);
        }

        private double CalcAdJA()
        {
            double AdJA;
            double Mittelwert = (Umsatz + Bilanzsumme) / 2;
            double minMittelwert = AdJSatzMIN;

            if (Mittelwert < minMittelwert)
            {
                tB_AdJA.Text = minMittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minMittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                AdJA = volleGebuehr * AdJSatz;
            }
            else
            {
                tB_AdJA.Text = Mittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Mittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                AdJA = volleGebuehr * AdJSatz;
            }
            l_AdJA.Text = AdJA.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return AdJA;
        }

        private double CalcErstellungdesAntrags()
        {
            double ErstDesAnBeitrag;
            double Mittelwert = (Bilanzsumme + Umsatz) / 2;
            double minMittelwert = ErstellungdesAntragsSatzMIN;

            if (Mittelwert < minMittelwert)
            {
                tB_ErstellungdesAntrags.Text = minMittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minMittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                ErstDesAnBeitrag = volleGebuehr * ErstellungdesAntragsSatz;
            }
            else
            {
                tB_ErstellungdesAntrags.Text = Mittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Mittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                ErstDesAnBeitrag = volleGebuehr * ErstellungdesAntragsSatz;
            }
            l_ErstDesAntrags.Text = ErstDesAnBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return ErstDesAnBeitrag;
        }

        private double CalcEntwEinerSteuerbilanz()
        {
            double EntwESteuerbilanzBeitrag;
            double Mittelwert = (Bilanzsumme + Umsatz) / 2;
            double minMittelwert = EntwicklungeinerSteuerbilanzSatzMIN;

            if (Mittelwert < minMittelwert)
            {
                tB_EntwEinerSteuerbilanz.Text = minMittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minMittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                EntwESteuerbilanzBeitrag = volleGebuehr * EntwicklungeinerSteuerbilanzSatz;
            }
            else
            {
                tB_EntwEinerSteuerbilanz.Text = Mittelwert.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Mittelwert;
                double volleGebuehr = rechner.BerechneVolleGebuehrAbschluss(gegenstandswert);
                EntwESteuerbilanzBeitrag = volleGebuehr * EntwicklungeinerSteuerbilanzSatz;
            }
            l_EntwEinerSteuerbilanz.Text = EntwESteuerbilanzBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return EntwESteuerbilanzBeitrag;
        }

        private double CalcKoerperschaftssteuer()
        {
            double KoerperschaftssteuerBeitrag;
            double Gewinn = Jahresueberschuss;
            double minGewinn = KoerperschaftssteuererklaerungsSatzMIN;

            if (Gewinn < minGewinn)
            {
                tB_Koerperschaftssteuererklaerung.Text = minGewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minGewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                KoerperschaftssteuerBeitrag = volleGebuehr * KoerperschaftssteuererklaerungsSatz;
            }
            else
            {
                tB_Koerperschaftssteuererklaerung.Text = Gewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Gewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                KoerperschaftssteuerBeitrag = volleGebuehr * KoerperschaftssteuererklaerungsSatz;
            }
            l_KoerperschaftsST.Text = KoerperschaftssteuerBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return KoerperschaftssteuerBeitrag;
        }

        private double CalcUmsatzsteuererklaerungfuerKJ()
        {
            double UmsatzsteuererklärungfuerKJBeitrag;
            double ProzentUmsatz = 0.1 * Umsatz;
            double minProzentUmsatz = UmsatzsteuererklaerungfdKJSatzMIN;

            if (ProzentUmsatz < minProzentUmsatz)
            {
                tB_UmsatzsteuererklaerungdesKJ.Text = minProzentUmsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minProzentUmsatz;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                UmsatzsteuererklärungfuerKJBeitrag = volleGebuehr * UmsatzsteuererklaerungfdKJSatz;
            }
            else
            {
                tB_UmsatzsteuererklaerungdesKJ.Text = ProzentUmsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = ProzentUmsatz;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                UmsatzsteuererklärungfuerKJBeitrag = volleGebuehr * UmsatzsteuererklaerungfdKJSatz;
            }
            l_UmsatzsteuererklDesKJ.Text = UmsatzsteuererklärungfuerKJBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return UmsatzsteuererklärungfuerKJBeitrag;
        }

        private double CalcErklaerungzurGewerbesteuer()
        {
            double ErklZurGewerbesteuerBeitrag;
            double Gewinn = Jahresueberschuss;
            double minGewinn = ErklaerungZurGewerbesteuerSatzMIN;

            if (Gewinn < minGewinn)
            {
                tB_ErklzurGewerbesteuer.Text = minGewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = minGewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                ErklZurGewerbesteuerBeitrag = volleGebuehr * ErklaerungZurGewerbesteuerSatz;
            }
            else
            {
                tB_ErklzurGewerbesteuer.Text = Gewinn.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
                double gegenstandswert = Gewinn;
                double volleGebuehr = rechner.BerechneVolleGebuehrBeratung(gegenstandswert);
                ErklZurGewerbesteuerBeitrag = volleGebuehr * ErklaerungZurGewerbesteuerSatz;
            }
            l_ErklaerungZurGewerbesteuer.Text = ErklZurGewerbesteuerBeitrag.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
            return ErklZurGewerbesteuerBeitrag;
        }

        private void cB_Bilanz_CheckedChanged(object sender, EventArgs e)
        {
            cB_EUR_new.Enabled = !cB_Bilanz.Checked;
            lL_ZurBilanz.Visible = cB_Bilanz.Checked;
            labelZSBilanzJA.Visible = cB_Bilanz.Checked;
            labelEUBilanz.Visible = cB_Bilanz.Checked;
            l_GESBilanz.Visible = cB_Bilanz.Checked;
            checkBoxGes_Bilanz_new.Visible = cB_Bilanz.Checked;
            cB_EUBilanz_new.Visible = cB_Bilanz.Checked;

            CalcCompleteBilanz();
        }

        #endregion

        private void cB_JA_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_JA.Checked)
            {
                lL_zumJA.Visible = true;
                SetCurrentMonatsHonorar();
            }
            else
            {
                lL_zumJA.Visible = false;
                SetCurrentMonatsHonorar();
            }
        }
        private void BTN_JAZurueck_Click(object sender, EventArgs e)
        {
            panelJA1.Visible = false;
            BTN_Zurueck.Enabled = true;
            BTN_Weiter.Enabled = true;
        }
        private void lL_zumJA_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelJA1.Visible = true;
            panelJA1.BringToFront();
            BTN_Zurueck.Enabled = false;
            BTN_Weiter.Enabled = false;
        }
        #endregion

        public class Mandant
        {
            public int MandantID { get; set; }
            public string Name { get; set; } = "";
            public double AktuellesHonorar { get; set; }
            public double UmsatzImJahr { get; set; }
            public double FiBuBeitrag { get; set; }
            public double JABeitrag { get; set; }
            public double LohnBeitrag { get; set; }
            public double UnternehmensberatungsBeitrag { get; set; }
            public double Bilanzsumme { get; set; }
            public double Jahresueberschuss { get; set; }
            public int AnzahlMitarbeiter { get; set; }
            public string Gewerbeart { get; set; } = "";
            public string Unternehmensart { get; set; } = "";
            public string Jahresabschluss { get; set; } = "";// EÜR oder Bilanz
            public bool IstSelbstbucher { get; set; }
            public bool HatLohn { get; set; }
            public double FibUBeitragMandant { get; set; }
            public double JABeitragMandant { get; set; }
            public double LohnBeitragMandant { get; set; }
            public double GesamtesHonorarMandant { get; set; }
        }
        private void BTNUploudExcel_Click(object sender, EventArgs e)
        {
            // Dialog zum Hochladen der Datei öffnen
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Dateien (*.xlsx)|*.xlsx|Alle Dateien (*.*)|*.*";
                openFileDialog.Title = "Wählen Sie eine Excel-Datei mit Mandantendaten aus";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pfadZurExcelDatei = openFileDialog.FileName;

                    // Optional: Den Pfad anzeigen, um zu bestätigen, dass die Datei korrekt geladen wurde
                    //MessageBox.Show($"Excel-Datei erfolgreich geladen: {pfadZurExcelDatei}");

                    // Excel-Daten verarbeiten
                    LadeMandantenAusExcel(pfadZurExcelDatei);
                }
            }
        }
        public void LadeMandantenAusExcel(string pfadZurExcelDatei)
        {

            if (!File.Exists(pfadZurExcelDatei))
            {
                Debug.WriteLine("Die Datei wurde nicht gefunden. Überprüfen Sie den Pfad.");
                return;
            }


            var fileInfo = new FileInfo(pfadZurExcelDatei);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {


                // Annahme: Das Arbeitsblatt heißt "Mandanten"
                ExcelWorksheet arbeitsblatt = package.Workbook.Worksheets["Mandanten"];

                if (arbeitsblatt == null)
                {
                    Console.WriteLine("Das Arbeitsblatt 'Mandanten' konnte nicht gefunden werden.");
                    return;
                }
                // Liste von Mandanten erstellen
                List<Mandant> mandantenListe = new List<Mandant>();

                // ProgressBar initialisieren
                pB_Mandanten.Visible = true;
                pB_Mandanten.Minimum = 0;
                pB_Mandanten.Maximum = arbeitsblatt.Dimension.End.Row - 1; // -1, weil die erste Zeile die Kopfzeilen sind
                pB_Mandanten.Value = 0;
                l_ProgressMandantenName.Visible = true;

                // Starten Sie in Zeile 2, da Zeile 1 die Kopfzeilen enthält
                for (int zeile = 2; zeile <= arbeitsblatt.Dimension.End.Row; zeile++)
                {
                    // Update ProgressBar und Label
                    pB_Mandanten.Value = zeile - 1;
                    l_ProgressMandantenName.Text = $"Importiere Mandanten aus Excel Liste";
                    l_ProgressMandantenName.Refresh(); // Label-Update erzwingen, damit es sofort angezeigt wird

                    var mandant = new Mandant
                    {
                        MandantID = Convert.ToInt32(arbeitsblatt.Cells[zeile, 1].Value),
                        Name = arbeitsblatt.Cells[zeile, 2].Value.ToString() ?? string.Empty,
                        AktuellesHonorar = Convert.ToDouble(arbeitsblatt.Cells[zeile, 3].Value),
                        UmsatzImJahr = Convert.ToDouble(arbeitsblatt.Cells[zeile, 4].Value),
                        FiBuBeitrag = Convert.ToDouble(arbeitsblatt.Cells[zeile, 5].Value),
                        JABeitrag = Convert.ToDouble(arbeitsblatt.Cells[zeile, 6].Value),
                        LohnBeitrag = Convert.ToDouble(arbeitsblatt.Cells[zeile, 7].Value),
                        UnternehmensberatungsBeitrag = Convert.ToDouble(arbeitsblatt.Cells[zeile, 8].Value),
                        Bilanzsumme = Convert.ToDouble(arbeitsblatt.Cells[zeile, 9].Value),
                        Jahresueberschuss = Convert.ToDouble(arbeitsblatt.Cells[zeile, 10].Value),
                        AnzahlMitarbeiter = Convert.ToInt32(arbeitsblatt.Cells[zeile, 11].Value),
                        Gewerbeart = arbeitsblatt.Cells[zeile, 12].Value.ToString() ?? string.Empty,
                        Unternehmensart = arbeitsblatt.Cells[zeile, 13].Value.ToString() ?? string.Empty,
                        Jahresabschluss = arbeitsblatt.Cells[zeile, 14].Value.ToString() ?? string.Empty,
                        IstSelbstbucher = (arbeitsblatt.Cells[zeile, 15].Value.ToString() ?? string.Empty).ToLower() == "ja",
                        HatLohn = (arbeitsblatt.Cells[zeile, 16].Value.ToString() ?? string.Empty).ToLower() == "ja"
                    };
                    mandantenListe.Add(mandant);
                }

                // Vergleiche die Honorare und gebe das Ergebnis aus
                BerechneHonorareFürAlleMandanten(mandantenListe);
            }
        }
        public void BerechneHonorareFürAlleMandanten(List<Mandant> mandantenListe)
        {
            // ProgressBar initialisieren
            pB_Mandanten.Visible = true;
            pB_Mandanten.Minimum = 0;
            pB_Mandanten.Maximum = mandantenListe.Count;
            pB_Mandanten.Value = 0;
            l_ProgressMandantenName.Visible = true;

            foreach (var mandant in mandantenListe)
            {

                // Update ProgressBar und Label
                pB_Mandanten.Value++;
                l_ProgressMandantenName.Text = $"({pB_Mandanten.Value} von {mandantenListe.Count}) Berechne Honorar für: {mandant.Name}";
                l_ProgressMandantenName.Refresh(); // Label-Update erzwingen, damit es sofort angezeigt wird


                // Berechnung basierend auf den Mandantenwerten
                double honorar = 0;
                cB_FiBu.Checked = false;
                cB_Lohn.Checked = true;
                cB_FiBu.Checked = false;
                cB_Bilanz.Checked = false;
                cB_EUR.Checked = false;
                cB_JA.Checked = false;
                cB_SeBu.Checked = false;
                cB_BargeldGewerbe.Checked = false;
                cB_OnlineHaendler.Checked = false;

                // Setzen der aktuellen Werte aus der Mandantenliste
                Umsatz = mandant.UmsatzImJahr;
                tB_Umsatz.Text = Umsatz.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                Bilanzsumme = mandant.Bilanzsumme;
                tB_Bilanzsumme.Text = Bilanzsumme.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                Jahresueberschuss = mandant.Jahresueberschuss;
                tB_Ausgaben.Text = Jahresueberschuss.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("de-DE"));

                AnzahlAnMitarbeitern = mandant.AnzahlMitarbeiter;
                tB_AnzahlMitarbeiter.Text = AnzahlAnMitarbeitern.ToString();
                tB_AnzahlMitarbeiterLohn.Text = AnzahlAnMitarbeitern.ToString();

                if (mandant.FiBuBeitrag > 0)
                    cB_FiBu.Checked = true;

                if (mandant.HatLohn)
                    cB_Lohn.Checked = true;

                if (mandant.IstSelbstbucher)
                    cB_SeBu.Checked = true;

                if (mandant.Jahresabschluss == "Bilanz")
                {
                    cB_Bilanz.Checked = true;
                    cB_JA.Checked = true;
                    checkBoxGes_Bilanz.Checked = true;
                }
                else if (mandant.Jahresabschluss == "EÜR")
                {
                    cB_JA.Checked = true;
                    cB_EUR.Checked = true;
                }
                else
                    cB_JA.Checked = false;

                if (mandant.Gewerbeart == "Bargeldgewerbe")
                {
                    cB_BargeldGewerbe.Checked = true;
                }
                else if (mandant.Gewerbeart == "Onlinehändler")
                {
                    cB_OnlineHaendler.Checked = true;
                }
                else
                {
                    cB_OnlineHaendler.Checked = false;
                    cB_BargeldGewerbe.Checked = false;
                }

                CalculateEverything();

                // Weitere Berechnungen, die auf anderen Parametern beruhen, wie Gewerbeart, FiBu, Lohn usw.
                honorar = CurrentMonatsHonorar;

                mandant.GesamtesHonorarMandant = CurrentMonatsHonorar + mandant.UnternehmensberatungsBeitrag;
                mandant.FibUBeitragMandant = FiBuBeitrag;
                mandant.JABeitragMandant = JABeitrag;
                mandant.LohnBeitragMandant = LohnBeitrag;

                // Optional: Ergebnis speichern oder anzeigen
                Debug.WriteLine($"Mandant ID: {mandant.MandantID}, Name: {mandant.Name}");
                Debug.WriteLine($"Berechnetes Honorar: {honorar} €");
            }
            ErstelleExcelAusgabeMitSpeicherortAuswahl(mandantenListe);
        }
        public void ErstelleExcelAusgabeMitSpeicherortAuswahl(List<Mandant> mandantenListe)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Dateien (*.xlsx)|*.xlsx|Alle Dateien (*.*)|*.*";
                saveFileDialog.Title = "Speichern Sie die Excel-Ausgabe";
                saveFileDialog.FileName = "Auswertung.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pfadZurExcelAusgabe = saveFileDialog.FileName;

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage())
                    {
                        ExcelWorksheet arbeitsblatt = package.Workbook.Worksheets.Add("Auswertung");

                        // Kopfzeilen erstellen und formatieren
                        arbeitsblatt.Cells[1, 1].Value = "Mandanten ID";
                        arbeitsblatt.Cells[1, 2].Value = "Name des Mandanten";
                        arbeitsblatt.Cells[1, 3].Value = "Aktuelles Honorar";
                        arbeitsblatt.Cells[1, 4].Value = "Rechner Berechnung";
                        arbeitsblatt.Cells[1, 5].Value = "Differenz (€)";
                        arbeitsblatt.Cells[1, 6].Value = "Differenz (%)";
                        arbeitsblatt.Cells[1, 7].Value = "FiBu Aktuell";
                        arbeitsblatt.Cells[1, 8].Value = "FiBu Berechnung";
                        arbeitsblatt.Cells[1, 9].Value = "Jahresabschluss Aktuell";
                        arbeitsblatt.Cells[1, 10].Value = "Jahresabschluss Berechnung";
                        arbeitsblatt.Cells[1, 11].Value = "Lohn Aktuell";
                        arbeitsblatt.Cells[1, 12].Value = "Lohn Berechnung";

                        // Kopfzeilen formatieren (Hintergrundfarbe, Schriftart fett)
                        using (var headerRange = arbeitsblatt.Cells[1, 1, 1, 12])
                        {
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Font.Size = 16;
                            headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 100, 100, 100));
                            headerRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            headerRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            headerRange.AutoFitColumns(1);
                        }

                        // Daten einfügen, Start in Zeile 2
                        int zeile = 2;
                        foreach (var mandant in mandantenListe)
                        {
                            arbeitsblatt.Cells[zeile, 1].Value = mandant.MandantID;
                            arbeitsblatt.Cells[zeile, 2].Value = mandant.Name;
                            arbeitsblatt.Cells[zeile, 3].Value = mandant.AktuellesHonorar;
                            arbeitsblatt.Cells[zeile, 4].Value = mandant.GesamtesHonorarMandant;
                            arbeitsblatt.Cells[zeile, 5].Value = mandant.AktuellesHonorar - mandant.GesamtesHonorarMandant;
                            arbeitsblatt.Cells[zeile, 6].Value = (mandant.GesamtesHonorarMandant - mandant.AktuellesHonorar) / mandant.AktuellesHonorar;
                            arbeitsblatt.Cells[zeile, 7].Value = mandant.FiBuBeitrag;
                            arbeitsblatt.Cells[zeile, 8].Value = mandant.FibUBeitragMandant;
                            arbeitsblatt.Cells[zeile, 9].Value = mandant.JABeitrag;
                            arbeitsblatt.Cells[zeile, 10].Value = mandant.JABeitragMandant;
                            arbeitsblatt.Cells[zeile, 11].Value = mandant.LohnBeitrag;
                            arbeitsblatt.Cells[zeile, 12].Value = mandant.LohnBeitragMandant;

                            // Formatierung für jede Zelle in der aktuellen Zeile
                            var zeilenRange = arbeitsblatt.Cells[zeile, 1, zeile, 12];
                            foreach (var cell in zeilenRange)
                            {
                                cell.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell.Style.Font.Size = 16;
                                cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                // Hintergrundfarbe setzen
                                cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 200, 200, 200));
                            }

                            double gesamtesHonorar = mandant.GesamtesHonorarMandant;
                            double prozDiff = ((gesamtesHonorar - mandant.AktuellesHonorar) / ((mandant.AktuellesHonorar + gesamtesHonorar) / 2));
                            double positiveProzDiff;

                            if (prozDiff < 0)
                                positiveProzDiff = prozDiff * -1;
                            else
                                positiveProzDiff = prozDiff;

                            if (positiveProzDiff > 0.06)
                            {
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 255, 170, 170));
                            }
                            else if (positiveProzDiff > 0.03)
                            {
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 255, 255, 170));
                            }
                            else if (positiveProzDiff < 0.03)
                            {
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 170, 255, 170));
                            }


                            zeile++;
                        }

                        // Tabelle erstellen
                        var tableRange = arbeitsblatt.Cells[1, 1, zeile - 1, 12];
                        var table = arbeitsblatt.Tables.Add(tableRange, "MandantenTabelle");
                        table.TableStyle = TableStyles.Medium9; // Du kannst hier einen anderen Stil wählen, wenn du möchtest
                        table.ShowFilter = true; // Filter für die Tabelle anzeigen

                        // Automatische Spaltenbreite für alle verwendeten Spalten einstellen
                        arbeitsblatt.Cells[arbeitsblatt.Dimension.Address].AutoFitColumns(20, 100);

                        // Formatierung für die Zahlenspalten (als Währung darstellen)
                        using (var currencyRange = arbeitsblatt.Cells[2, 3, zeile - 1, 12])
                        {
                            currencyRange.Style.Numberformat.Format = "#,##0.00 €";
                        }

                        // Formatierung für die Prozentspalte (als Prozent darstellen)
                        using (var percentRange = arbeitsblatt.Cells[2, 6, zeile - 1, 6])
                        {
                            percentRange.Style.Numberformat.Format = "0.00%";
                        }

                        // Datei speichern
                        FileInfo fileInfo = new FileInfo(pfadZurExcelAusgabe);
                        package.SaveAs(fileInfo);

                        // Excel-Datei öffnen, nachdem sie gespeichert wurde
                        try
                        {
                            Process.Start(new ProcessStartInfo(pfadZurExcelAusgabe) { UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Die Excel-Datei konnte nicht automatisch geöffnet werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Benachrichtigung für erfolgreiche Erstellung
                        pB_Mandanten.Visible = false;
                        l_ProgressMandantenName.Visible = false;
                    }
                }
            }
            /* ALT public void ErstelleExcelAusgabeMitSpeicherortAuswahl(List<Mandant> mandantenListe) ALT
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Dateien (*.xlsx)|*.xlsx|Alle Dateien (*.*)|*.*";
                    saveFileDialog.Title = "Speichern Sie die Excel-Ausgabe";
                    saveFileDialog.FileName = "Auswertung.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string pfadZurExcelAusgabe = saveFileDialog.FileName;

                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (var package = new ExcelPackage())
                        {
                            ExcelWorksheet arbeitsblatt = package.Workbook.Worksheets.Add("Auswertung");

                            // Kopfzeilen erstellen und formatieren
                            arbeitsblatt.Cells[1, 1].Value = "Mandanten ID";
                            arbeitsblatt.Cells[1, 2].Value = "Name des Mandanten";
                            arbeitsblatt.Cells[1, 3].Value = "Aktuelles Honorar";
                            arbeitsblatt.Cells[1, 4].Value = "Rechner Berechnung";
                            arbeitsblatt.Cells[1, 5].Value = "Differenz (€)";
                            arbeitsblatt.Cells[1, 6].Value = "Differenz (%)";
                            arbeitsblatt.Cells[1, 7].Value = "FiBu Aktuell";
                            arbeitsblatt.Cells[1, 8].Value = "FiBu Berechnung";
                            arbeitsblatt.Cells[1, 9].Value = "Jahresabschluss Aktuell";
                            arbeitsblatt.Cells[1, 10].Value = "Jahresabschluss Berechnung";
                            arbeitsblatt.Cells[1, 11].Value = "Lohn Aktuell";
                            arbeitsblatt.Cells[1, 12].Value = "Lohn Berechnung";

                            // Kopfzeilen formatieren (Hintergrundfarbe, Schriftart fett)
                            using (var headerRange = arbeitsblatt.Cells[1, 1, 1, 12])
                            {
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.Font.Size = 16;
                                headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 226, 226, 226));
                                headerRange.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                headerRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                headerRange.AutoFitColumns(1);
                            }

                            // ProgressBar initialisieren
                            pB_Mandanten.Visible = true;
                            pB_Mandanten.Minimum = 0;
                            pB_Mandanten.Maximum = mandantenListe.Count;
                            pB_Mandanten.Value = 0;
                            l_ProgressMandantenName.Visible = true;

                            // Daten einfügen, Start in Zeile 2
                            int zeile = 2;
                            foreach (var mandant in mandantenListe)
                            {
                                // Update ProgressBar und Label
                                pB_Mandanten.Value = zeile - 1;
                                l_ProgressMandantenName.Text = $"({zeile - 1} von {mandantenListe.Count}) Bearbeite Mandant: {mandant.Name}";
                                l_ProgressMandantenName.Refresh(); // Label-Update erzwingen, damit es sofort angezeigt wird



                                // Berechnungen durchführen
                                double fibuBetrag = 0;

                                if (mandant.FiBuBeitrag > 0)
                                    fibuBetrag = mandant.FibUBeitragMandant;

                                double jahresabschlussBetrag = mandant.JABeitragMandant;
                                double lohnBetrag = mandant.LohnBeitragMandant;
                                double gesamtesHonorar = mandant.GesamtesHonorarMandant;
                                double differenz = mandant.AktuellesHonorar - gesamtesHonorar;
                                double prozDiff = ((gesamtesHonorar - mandant.AktuellesHonorar) / ((mandant.AktuellesHonorar + gesamtesHonorar) / 2));
                                double positiveProzDiff;

                                Debug.WriteLine(prozDiff);

                                if (prozDiff < 0)
                                    positiveProzDiff = prozDiff * -1;
                                else
                                    positiveProzDiff = prozDiff;

                                arbeitsblatt.Cells[zeile, 1].Value = mandant.MandantID;
                                arbeitsblatt.Cells[zeile, 2].Value = mandant.Name;
                                arbeitsblatt.Cells[zeile, 3].Value = mandant.AktuellesHonorar;
                                arbeitsblatt.Cells[zeile, 4].Value = gesamtesHonorar;
                                arbeitsblatt.Cells[zeile, 5].Value = differenz;
                                arbeitsblatt.Cells[zeile, 6].Value = prozDiff;
                                arbeitsblatt.Cells[zeile, 7].Value = mandant.FiBuBeitrag;
                                arbeitsblatt.Cells[zeile, 8].Value = fibuBetrag;
                                arbeitsblatt.Cells[zeile, 9].Value = mandant.JABeitrag;
                                arbeitsblatt.Cells[zeile, 10].Value = jahresabschlussBetrag;
                                arbeitsblatt.Cells[zeile, 11].Value = mandant.LohnBeitrag;
                                arbeitsblatt.Cells[zeile, 12].Value = lohnBetrag;

                                // Bedingte Formatierung für die gesamte Zeile hinzufügen
                                var zeilenRange = arbeitsblatt.Cells[zeile, 1, zeile, 12];

                                // Rahmenlinien für jede Zelle in der aktuellen Zeile
                                foreach (var cell in zeilenRange)
                                {
                                    cell.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cell.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cell.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cell.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cell.Style.Font.Size = 16;
                                    cell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    // Hintergrundfarbe setzen
                                    cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 200, 200, 200));
                                }

                                if (positiveProzDiff > 0.06)
                                {
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 255, 170, 170));
                                }
                                else if (positiveProzDiff > 0.03)
                                {
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 255, 255, 170));
                                }
                                else if (positiveProzDiff < 0.03)
                                {
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    arbeitsblatt.Cells[zeile, 6].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(255, 170, 255, 170));
                                }


                                // Zeilenhöhe erhöhen, damit es übersichtlicher ist
                                arbeitsblatt.Row(zeile).Height = 30;

                                zeile++;
                            }

                            // Automatische Spaltenbreite für alle verwendeten Spalten einstellen
                            arbeitsblatt.Cells[arbeitsblatt.Dimension.Address].AutoFitColumns(20, 100);

                            // Formatierung für die Zahlenspalten (als Währung darstellen)
                            using (var currencyRange = arbeitsblatt.Cells[2, 3, zeile - 1, 12])
                            {
                                currencyRange.Style.Numberformat.Format = "#,##0.00 €";
                            }

                            // Formatierung für die Prozentspalte (als Prozent darstellen)
                            using (var percentRange = arbeitsblatt.Cells[2, 6, zeile - 1, 6])
                            {
                                percentRange.Style.Numberformat.Format = "0.00%";
                            }

                            // Datei speichern
                            FileInfo fileInfo = new FileInfo(pfadZurExcelAusgabe);
                            package.SaveAs(fileInfo);

                            // Excel-Datei öffnen, nachdem sie gespeichert wurde
                            try
                            {
                                Process.Start(new ProcessStartInfo(pfadZurExcelAusgabe) { UseShellExecute = true });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Die Excel-Datei konnte nicht automatisch geöffnet werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            // Benachrichtigung für erfolgreiche Erstellung
                            //MessageBox.Show("Die Excel-Ausgabe wurde erfolgreich erstellt: " + pfadZurExcelAusgabe, "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pB_Mandanten.Visible = false;
                            l_ProgressMandantenName.Visible = false;
                        }
                    }
                }
            }
            */
        }


        #region Neue Checkboxen
        private void cB_UN_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_UN_new.Checked)
            {
                cB_UN.Checked = true;
            }
            else
            {
                cB_UN.Checked = false;
            }
        }

        private void cB_UdB_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_UdB_new.Checked)
            {
                cB_UdB.Checked = true;
            }
            else
            {
                cB_UdB.Checked = false;
            }
        }

        private void cB_EUR_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_EUR_new.Checked)
            {
                cB_EUR.Checked = true;
            }
            else
            {
                cB_EUR.Checked = false;
            }
        }

        private void cB_Bilanz_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Bilanz_new.Checked)
            {
                cB_Bilanz.Checked = true;
            }
            else
            {
                cB_Bilanz.Checked = false;
            }
        }

        private void cB_EUBilanz_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_EUBilanz_new.Checked)
            {
                cB_EUBilanz.Checked = true;
            }
            else
            {
                cB_EUBilanz.Checked = false;
            }
        }

        private void checkBoxGes_Bilanz_new_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGes_Bilanz_new.Checked)
            {
                checkBoxGes_Bilanz.Checked = true;
            }
            else
            {
                checkBoxGes_Bilanz.Checked = false;
            }
        }

        private void cB_BargeldGewerbe_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_BargeldGewerbe_new.Checked)
            {
                cB_BargeldGewerbe.Checked = true;
            }
            else
            {
                cB_BargeldGewerbe.Checked = false;
            }
        }

        private void cB_OnlineHaendler_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_OnlineHaendler_new.Checked)
            {
                cB_OnlineHaendler.Checked = true;
            }
            else
            {
                cB_OnlineHaendler.Checked = false;
            }
        }

        private void cB_FiBu_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_FiBu_new.Checked)
            {
                cB_FiBu.Checked = true;
            }
            else
            {
                cB_FiBu.Checked = false;
            }
        }

        private void cB_JA_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_JA_new.Checked)
            {
                cB_JA.Checked = true;
            }
            else
            {
                cB_JA.Checked = false;
            }
        }

        private void cB_Lohn_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_Lohn_new.Checked)
            {
                cB_Lohn.Checked = true;
            }
            else
            {
                cB_Lohn.Checked = false;
            }
        }

        private void cB_SeBu_new_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_SeBu_new.Checked)
            {
                cB_SeBu.Checked = true;
            }
            else
            {
                cB_SeBu.Checked = false;
            }
        }
        #endregion
    }
}




