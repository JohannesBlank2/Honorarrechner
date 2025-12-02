using static Honorar_Rechner.Honorarrechner;

namespace Honorar_Rechner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {
                ApplicationConfiguration.Initialize();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Honorarrechner());

                Honorarrechner excelVerbindung = new Honorarrechner();
                excelVerbindung.LadeDatenAusExcel();
            }
            catch (Exception ex)
            {
                File.WriteAllText("fehler_log.txt", ex.ToString());
                MessageBox.Show("Fehler beim Start:\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}