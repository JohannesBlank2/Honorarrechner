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
                // Pfad zur Excel auf dem Desktop
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string[] dateiKandidaten =
                {
                    "Honorar_Rechner_Werte.xlsx",
                };

                string excelFilePath = "Honorar_Rechner_Werte.xlsx";
                foreach (var dateiName in dateiKandidaten)
                {
                    var kandidat = Path.Combine(desktopPath, dateiName);
                    if (!File.Exists(kandidat))
                    {
                        continue;
                    }

                    excelFilePath = kandidat;
                    break;
                }

                if (string.IsNullOrWhiteSpace(excelFilePath))
                {
                    excelFilePath = Path.Combine(desktopPath, dateiKandidaten[0]);
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
