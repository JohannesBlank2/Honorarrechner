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
                // Primär auf G:\ suchen, danach als Fallback auf dem Desktop.
                string gDriveRootPath = @"G:\Honorar_Rechner";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                string[] dateiKandidaten =
                {
                    "Honorar_Rechner_Werte.xlsx",
                };

                string? excelFilePath = null;
                string[] suchPfade = { gDriveRootPath, desktopPath };

                foreach (var suchPfad in suchPfade)
                {
                    foreach (var dateiName in dateiKandidaten)
                    {
                        var kandidat = Path.Combine(suchPfad, dateiName);
                        if (!File.Exists(kandidat))
                        {
                            continue;
                        }

                        excelFilePath = kandidat;
                        break;
                    }

                    if (!string.IsNullOrWhiteSpace(excelFilePath))
                    {
                        break;
                    }
                }

                if (string.IsNullOrWhiteSpace(excelFilePath))
                {
                    throw new FileNotFoundException(
                        $"Die Datei '{dateiKandidaten[0]}' wurde weder unter '{gDriveRootPath}' noch auf dem Desktop gefunden.");
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
