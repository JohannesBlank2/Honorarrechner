using HonorarRechner.Core.Models;
using OfficeOpenXml; // Nuget: EPPlus
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HonorarRechner.Core.Services
{
    public class ExcelWerteService
    {
        public ExcelWerteService()
        {
            // -----------------------------------------------------------
            // OPTION B (Die sichere Variante): Lizenz direkt hier setzen
            // -----------------------------------------------------------
            ExcelPackage.License.SetNonCommercialPersonal("SFS");
        }

        public void LadeWerte(string filePath)
        {
            // 1. Prüfung: Existiert die Datei überhaupt?
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Die Excel-Datei wurde nicht gefunden:\n{filePath}");
            }

            // 2. Datei öffnen
            using var package = new ExcelPackage(new FileInfo(filePath));

            // 3. Arbeitsblatt holen (Name muss exakt stimmen!)
            var sheet = package.Workbook.Worksheets["WerteArbeitsblatt"];
            if (sheet == null)
            {
                // Fallback: Falls der Name falsch ist, nimm das erste Blatt
                sheet = package.Workbook.Worksheets[0];
            }

            var w = GlobalState.Instance.Werte;

            // --- FiBu ---
            w.ITPauschale = ConvertDec(sheet.Cells[4, 2].Value);
            w.AuslagenPauschaleProzent = ConvertDec(sheet.Cells[4, 3].Value);
            w.AuslagenPauschaleMax = ConvertDec(sheet.Cells[4, 4].Value);
            w.FibuMinMonatlich = ConvertDec(sheet.Cells[4, 5].Value);

            w.FibuNormalSatz = ParseBruch(sheet.Cells[4, 6].Value?.ToString());
            w.OnlineHaendlerSatz = ParseBruch(sheet.Cells[4, 7].Value?.ToString());
            w.BarGeldGewerbeSatz = ParseBruch(sheet.Cells[4, 8].Value?.ToString());

            // --- Lohn ---
            w.BeitragEins = ConvertDec(sheet.Cells[9, 2].Value);
            w.BeitragZweiBisNeun = ConvertDec(sheet.Cells[9, 3].Value);
            w.BeitragZehnBisNeunzehn = ConvertDec(sheet.Cells[9, 4].Value);
            w.BeitragZwanzigBisNeunundvierzig = ConvertDec(sheet.Cells[9, 5].Value);
            w.BeitragFuenfzigBisHundert = ConvertDec(sheet.Cells[9, 6].Value);

            // --- JA (EUR) ---
            w.BeaSatz = ParseBruch(sheet.Cells[14, 3].Value?.ToString());
            w.BeaMin = ConvertDec(sheet.Cells[14, 4].Value);

            w.GewerbeSatz = ParseBruch(sheet.Cells[15, 3].Value?.ToString());
            w.GewerbeMin = ConvertDec(sheet.Cells[15, 4].Value);

            w.UedbSatz = ParseBruch(sheet.Cells[16, 3].Value?.ToString());
            w.UedbMin = ConvertDec(sheet.Cells[16, 4].Value);

            w.UstSatz = ParseBruch(sheet.Cells[17, 3].Value?.ToString());
            w.UstMin = ConvertDec(sheet.Cells[17, 4].Value);

            w.AbschlussPauschaleSatz = ConvertDec(sheet.Cells[18, 3].Value);
            w.EurMinMonat = ConvertDec(sheet.Cells[20, 3].Value);

            // --- JA (Bilanz) ---
            w.AdJSatz = ParseBruch(sheet.Cells[14, 7].Value?.ToString());
            w.AdJMin = ConvertDec(sheet.Cells[14, 8].Value);

            w.AntragSatz = ParseBruch(sheet.Cells[15, 7].Value?.ToString());
            w.AntragMin = ConvertDec(sheet.Cells[15, 8].Value);

            w.SteuerbilanzSatz = ParseBruch(sheet.Cells[16, 7].Value?.ToString());
            w.SteuerbilanzMin = ConvertDec(sheet.Cells[16, 8].Value);

            w.KoerperschaftSatz = ParseBruch(sheet.Cells[17, 7].Value?.ToString());
            w.KoerperschaftMin = ConvertDec(sheet.Cells[17, 8].Value);

            w.UstKjSatz = ParseBruch(sheet.Cells[18, 7].Value?.ToString());
            w.UstKjMin = ConvertDec(sheet.Cells[18, 8].Value);

            w.GewStErklSatz = ParseBruch(sheet.Cells[19, 7].Value?.ToString());
            w.GewStErklMin = ConvertDec(sheet.Cells[19, 8].Value);

            w.BilanzBescheidSatz = ConvertDec(sheet.Cells[20, 7].Value);
            w.E_BilanzPauschale = ConvertDec(sheet.Cells[21, 7].Value);
            w.OffenlegungPauschale = ConvertDec(sheet.Cells[22, 7].Value);

            w.BilanzMinEuMonat = ConvertDec(sheet.Cells[24, 7].Value);
            w.BilanzMinGesMonat = ConvertDec(sheet.Cells[25, 7].Value);

            // --- Private Leistungen ---
            w.EinkommensteuerErklaerungSatz = ParseBruch(sheet.Cells[35, 3].Value?.ToString());
            w.EinkommensteuerErklaerungMin = ConvertDec(sheet.Cells[35, 4].Value);

            w.UeberschussKapitalvermoegenSatz = ParseBruch(sheet.Cells[36, 3].Value?.ToString());
            w.UeberschussKapitalvermoegenMin = ConvertDec(sheet.Cells[36, 4].Value);

            w.UeberschussNichtselbstSatz = ParseBruch(sheet.Cells[37, 3].Value?.ToString());
            w.UeberschussNichtselbstMin = ConvertDec(sheet.Cells[37, 4].Value);

            w.UeberschussGewerbeSatz = ParseBruch(sheet.Cells[38, 3].Value?.ToString());
            w.UeberschussGewerbeMin = ConvertDec(sheet.Cells[38, 4].Value);

            w.UeberschussSonstigeSatz = ParseBruch(sheet.Cells[39, 3].Value?.ToString());
            w.UeberschussSonstigeMin = ConvertDec(sheet.Cells[39, 4].Value);

            w.UeberschussVermietungSatz = ParseBruch(sheet.Cells[40, 3].Value?.ToString());
            w.UeberschussVermietungMin = ConvertDec(sheet.Cells[40, 4].Value);

            w.UstErklaerungConsultingSatz = ParseBruch(sheet.Cells[41, 3].Value?.ToString());
            w.UstErklaerungConsultingMin = ConvertDec(sheet.Cells[41, 4].Value);

            w.PruefungSteuerbescheidPauschale = ConvertDec(sheet.Cells[42, 3].Value);
        }

        // Hilfsmethode: Sicher in Decimal wandeln (fängt Fehler ab)
        private decimal ConvertDec(object? val)
        {
            if (val == null) return 0m;
            string s = val.ToString() ?? "";
            // Entfernt Währungszeichen und tauscht Punkte/Kommas falls nötig
            s = s.Replace("€", "").Trim();

            if (decimal.TryParse(s, out decimal result)) return result;
            return 0m;
        }

        // Hilfsmethode: Brüche wie "7/10" parsen
        private decimal ParseBruch(string? input)
        {
            if (string.IsNullOrEmpty(input)) return 0m;
            // Versuch 1: Ist es ein Bruch?
            var match = Regex.Match(input, @"(\d+)/(\d+)");
            if (match.Success)
            {
                decimal z = decimal.Parse(match.Groups[1].Value);
                decimal n = decimal.Parse(match.Groups[2].Value);
                if (n != 0) return z / n;
            }
            // Versuch 2: Ist es eine normale Zahl?
            if (decimal.TryParse(input, out decimal res)) return res;
            return 0m;
        }
    }
}
