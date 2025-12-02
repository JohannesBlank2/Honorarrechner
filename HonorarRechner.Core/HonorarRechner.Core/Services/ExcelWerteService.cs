using HonorarRechner.Core.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonorarRechner.Core.Services;
/*{
    public class ExcelWerteService
    {
        private readonly string _pfadZurExcelDatei;

        public ExcelWerteService(string pfadZurExcelDatei)
        {
            _pfadZurExcelDatei = pfadZurExcelDatei;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public TabellenWerte LadeTabellenWerte()
        {
            if (!File.Exists(_pfadZurExcelDatei))
                throw new FileNotFoundException("Excel-Datei nicht gefunden.", _pfadZurExcelDatei);

            using var paket = new ExcelPackage(new FileInfo(_pfadZurExcelDatei));
            var arbeitsblatt = paket.Workbook.Worksheets[0]; // ggf. Blattname anpassen

            var werte = new TabellenWerte
            {
                // Beispiel: liest 1:1 das, was du jetzt in Form1 machst
                FibuSatzProzent = Convert.ToDecimal(arbeitsblatt.Cells[2, 3].Value),
                FibuMindestHonorar = Convert.ToDecimal(arbeitsblatt.Cells[2, 4].Value),

                // TODO: alle anderen Werte aus deiner bestehenden Logik übernehmen
            };

            return werte;
        }
    }
}

*/