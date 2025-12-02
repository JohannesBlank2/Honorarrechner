using System;
using System.IO;
using System.Windows;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Environment.SetEnvironmentVariable("EPPlusLicenseContext", "NonCommercial");

            base.OnStartup(e);

            try
            {
                // Pfad zur Excel auf dem Desktop
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string excelFilePath = Path.Combine(desktopPath, "HonorarrechnerWerteTabelle.xlsx");

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