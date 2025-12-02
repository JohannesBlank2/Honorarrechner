using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HonorarRechner.Core.Models;

namespace HonorarRechner.Core.Services;
/*{
    public class HonorarService
    {
        public HonorarErgebnis BerechneUnternehmensHonorar(
            UnternehmensDaten daten,
            TabellenWerte werte)
        {
            var result = new HonorarErgebnis();

            // Beispiel-Logik – hier müssen wir 1:1 deine Form1-Formeln übertragen:
            // (Pseudo! Du ersetzt das mit deinem echten Code)

            decimal fibu = 0m;

            if (daten.HatFiBu)
            {
                fibu = daten.UmsatzImJahr * werte.FibuSatzProzent / 100m;

                if (fibu < werte.FibuMindestHonorar)
                    fibu = werte.FibuMindestHonorar;
            }

            result.FiBuBeitrag = fibu;

            // Hier kommen deine ganzen weiteren Schritte:
            // - Lohn berechnen
            // - Jahresabschluss
            // - Zuschläge Bargeldgewerbe / Onlinehandel
            // - Selbstbucher-Abschlag
            // - etc.

            result.JahresHonorar =
                result.FiBuBeitrag +
                result.JaBeitrag +
                result.LohnBeitrag -
                result.SelbstbucherAbschlag;

            return result;
        }
    }
}
*/
