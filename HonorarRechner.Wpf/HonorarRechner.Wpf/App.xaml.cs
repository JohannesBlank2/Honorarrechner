using System;
using System.IO;
using System.Globalization;
using System.Windows;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var culture = CultureInfo.GetCultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Environment.SetEnvironmentVariable("EPPlusLicenseContext", "NonCommercial");

            base.OnStartup(e);

            try
            {
                // Pfad zur Excel auf G:\
                string excelRootPath = @"G:\Honorar_Rechner";

                string[] dateiKandidaten =
                {
                    "Honorar_Rechner_Werte.xlsx",
                };

                string excelFilePath = "Honorar_Rechner_Werte.xlsx";
                foreach (var dateiName in dateiKandidaten)
                {
                    var kandidat = Path.Combine(excelRootPath, dateiName);
                    if (!File.Exists(kandidat))
                    {
                        continue;
                    }

                    excelFilePath = kandidat;
                    break;
                }

                if (string.IsNullOrWhiteSpace(excelFilePath))
                {
                    excelFilePath = Path.Combine(excelRootPath, dateiKandidaten[0]);
                }

                // Laden versuchen
                var loader = new ExcelWerteService(); // Hier wird jetzt die Lizenz im Konstruktor gesetzt
                loader.LadeWerte(excelFilePath);
            }
            catch (Exception ex)
            {
                // Zeigt den Fehler an, falls etwas schiefgeht (z.B. Datei nicht da)
                MessageBox.Show($"Excel konnte nicht geladen werden:\n{ex.Message}",
                                "Hinweis", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
