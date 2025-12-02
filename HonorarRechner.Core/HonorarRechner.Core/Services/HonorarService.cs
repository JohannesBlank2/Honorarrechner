using HonorarRechner.Core.Models;
using System;
using System.Collections.Generic;

namespace HonorarRechner.Core.Services
{
    public class HonorarService
    {
        private readonly GebuehrenRechner _gebuehrenRechner = new GebuehrenRechner();

        /// <summary>
        /// Berechnet das komplette Honorar basierend auf dem aktuellen GlobalState.
        /// </summary>
        public HonorarErgebnis BerechneAlles()
        {
            var daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;
            var ergebnis = new HonorarErgebnis();

            // 1. Lohn
            // (Wird immer berechnet, wenn Mitarbeiter da sind, oder basierend auf Checkboxen, 
            //  hier vereinfacht: wenn Anzahl > 0)
            if (daten.AnzahlMitarbeiter > 0)
            {
                ergebnis.LohnBeitrag = BerechneLohn(daten.AnzahlMitarbeiter, werte);
            }

            // 2. FiBu
            // Wir prüfen hier auf die Checkbox im UI (die im GlobalState gespeichert sein sollte)
            // Falls du das noch nicht hast, rechnen wir es einfach immer aus, wenn Umsatz da ist.
            if (daten.UmsatzImJahr > 0)
            {
                ergebnis.FiBuBeitrag = BerechneFibu(daten, werte);
            }

            // 3. Jahresabschluss (JA)
            // Hier entscheidet die Logik, ob Bilanz oder EÜR (basierend auf Daten oder Auswahl)
            // Aktuell nehmen wir an: Wenn Bilanzsumme > 0 -> Bilanz, sonst EÜR (als Beispiel)
            // Oder wir nutzen deine Checkbox-Logik, die wir später verfeinern.
            // Für diesen Schritt rechnen wir den JA, wenn Umsatz oder Bilanzsumme da sind.

            if (daten.Bilanzsumme > 0 || daten.UmsatzImJahr > 0)
            {
                // Einfache Weiche: Wenn Bilanzsumme eingetragen -> Bilanz, sonst EÜR
                if (daten.Bilanzsumme > 0)
                    ergebnis.JaBeitrag = BerechneBilanz(daten, werte);
                else
                    ergebnis.JaBeitrag = BerechneEuer(daten, werte);
            }

            // 4. Selbstbucher (Beispiel: Wenn Checkbox gesetzt, dann 20% auf JA)
            if (daten.IstSelbstbucher && ergebnis.JaBeitrag > 0)
            {
                // In deinem alten Code war es ein ZUSCHLAG (+20%), wenn ich die Logik richtig lese?
                // "Selbstbucher (+20%)" -> Addieren.
                ergebnis.SelbstbucherAbschlag = ergebnis.JaBeitrag * 0.20m;
            }

            // Gesamtsumme (Jahreswert)
            ergebnis.JahresHonorar =
                ergebnis.LohnBeitrag +
                ergebnis.FiBuBeitrag +
                ergebnis.JaBeitrag +
                (daten.IstSelbstbucher ? ergebnis.SelbstbucherAbschlag : 0);

            return ergebnis;
        }

        private decimal BerechneLohn(int anzahl, TabellenWerte w)
        {
            if (anzahl <= 0) return 0m;

            decimal total = 0m;

            // 1. MA
            total += w.BeitragEins;
            int rest = anzahl - 1;

            // 2-9
            int count2to9 = Math.Max(0, Math.Min(rest, 8));
            total += count2to9 * w.BeitragZweiBisNeun;
            rest -= count2to9;

            // 10-19
            int count10to19 = Math.Max(0, Math.Min(rest, 10));
            total += count10to19 * w.BeitragZehnBisNeunzehn;
            rest -= count10to19;

            // 20-49
            int count20to49 = Math.Max(0, Math.Min(rest, 30));
            total += count20to49 * w.BeitragZwanzigBisNeunundvierzig;
            rest -= count20to49;

            // 50-100
            int count50to100 = Math.Max(0, Math.Min(rest, 51));
            total += count50to100 * w.BeitragFuenfzigBisHundert;
            rest -= count50to100;

            // 101+ (Dynamisch nach deiner Logik)
            if (rest > 0)
            {
                decimal rabatt = (rest) * 0.1m;
                decimal preisDynamic = Math.Max(20m - rabatt, 15m);
                total += rest * preisDynamic;
            }

            return total * 12; // Jahreswert
        }

        private decimal BerechneFibu(UnternehmensDaten d, TabellenWerte w)
        {
            decimal satz = w.FibuNormalSatz;
            if (d.IstBargeldGewerbe) satz = w.BarGeldGewerbeSatz;
            if (d.IstOnlineHaendler) satz = w.OnlineHaendlerSatz;

            decimal gegenstandswert = d.UmsatzImJahr;

            decimal basisGebuehr = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBuchfuehrung((double)gegenstandswert);
            decimal monatsPauschale = basisGebuehr * satz;

            // Auslagen
            decimal auslagen = monatsPauschale * w.AuslagenPauschaleProzent;
            if (auslagen > w.AuslagenPauschaleMax) auslagen = w.AuslagenPauschaleMax;

            monatsPauschale += auslagen + w.ITPauschale;

            // Mindestgebühr Check
            if (monatsPauschale < w.FibuMinMonatlich) monatsPauschale = w.FibuMinMonatlich;

            return monatsPauschale * 12;
        }

        private decimal BerechneEuer(UnternehmensDaten d, TabellenWerte w)
        {
            // BEA
            decimal wertBea = Math.Max(d.Jahresueberschuss, w.BeaMin);
            decimal gebBea = (decimal)_gebuehrenRechner.BerechneVolleGebuehrAbschluss((double)wertBea) * w.BeaSatz;

            // Gewerbe
            decimal wertGew = Math.Max(d.Jahresueberschuss, w.GewerbeMin);
            decimal gebGew = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBeratung((double)wertGew) * w.GewerbeSatz;

            // UEdB (nur wenn Überschuss > 0 oder Checkbox Logik)
            decimal gebUedb = 0;
            if (d.Jahresueberschuss > 0) // Vereinfachte Logik
            {
                decimal wertUedb = Math.Max(d.Jahresueberschuss, w.UedbMin);
                gebUedb = (decimal)_gebuehrenRechner.BerechneVolleGebuehrAbschluss((double)wertUedb) * w.UedbSatz;
            }

            // USt
            decimal wertUst = Math.Max(d.UmsatzImJahr, w.UstMin);
            decimal gebUst = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBeratung((double)wertUst) * w.UstSatz;

            // Pauschale (Bescheide) - 3 Stück Standard
            decimal gebPauschale = 3 * w.AbschlussPauschaleSatz;

            decimal total = gebBea + gebGew + gebUedb + gebUst + gebPauschale;
            decimal minTotal = w.EurMinMonat * 12;

            return Math.Max(total, minTotal);
        }

        private decimal BerechneBilanz(UnternehmensDaten d, TabellenWerte w)
        {
            // Mittelwert (Umsatz + Bilanzsumme / 2)
            decimal mittelwert = (d.UmsatzImJahr + d.Bilanzsumme) / 2m;

            // 1. Aufstellung (AdJA)
            decimal wertAdja = Math.Max(mittelwert, w.AdJMin);
            decimal gebAdja = (decimal)_gebuehrenRechner.BerechneVolleGebuehrAbschluss((double)wertAdja) * w.AdJSatz;

            // 2. Antrag
            decimal wertAntrag = Math.Max(mittelwert, w.AntragMin);
            decimal gebAntrag = (decimal)_gebuehrenRechner.BerechneVolleGebuehrAbschluss((double)wertAntrag) * w.AntragSatz;

            // 3. Steuerbilanz
            decimal wertStB = Math.Max(mittelwert, w.SteuerbilanzMin);
            decimal gebStB = (decimal)_gebuehrenRechner.BerechneVolleGebuehrAbschluss((double)wertStB) * w.SteuerbilanzSatz;

            // 4. KöSt
            decimal wertKoest = Math.Max(d.Jahresueberschuss, w.KoerperschaftMin);
            decimal gebKoest = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBeratung((double)wertKoest) * w.KoerperschaftSatz;

            // 5. USt
            decimal umsatz10 = d.UmsatzImJahr * 0.1m;
            decimal wertUst = Math.Max(umsatz10, w.UstKjMin);
            decimal gebUst = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBeratung((double)wertUst) * w.UstKjSatz;

            // 6. GewSt
            decimal wertGew = Math.Max(d.Jahresueberschuss, w.GewStErklMin);
            decimal gebGew = (decimal)_gebuehrenRechner.BerechneVolleGebuehrBeratung((double)wertGew) * w.GewStErklSatz;

            // 7. Bescheide (4 Stück)
            decimal gebBescheide = 4 * w.BilanzBescheidSatz;

            decimal total = gebAdja + gebAntrag + gebStB + gebKoest + gebUst + gebGew + gebBescheide + w.E_BilanzPauschale + w.OffenlegungPauschale;

            // Minimum Check (EU vs Gesellschaft -> hier vereinfacht EU)
            // Du könntest im UI noch eine Checkbox "Gesellschaft" hinzufügen
            decimal minTotal = w.BilanzMinEuMonat * 12;

            return Math.Max(total, minTotal);
        }

        // --- Die komplette Tabelle aus Form1.cs ---
        private class GebuehrenRechner
        {
            private List<GebuehrEintrag> Abschlusstabelle;
            private List<GebuehrEintrag> beratungstabelle;
            private List<GebuehrEintrag> buchfuehrungsTabelle;

            public GebuehrenRechner()
            {
                // Deine kompletten Werte für Anlage 2 Tabelle B
                Abschlusstabelle = new List<GebuehrEintrag>() {
                    new GebuehrEintrag(3000, 49), new GebuehrEintrag(3500, 57), new GebuehrEintrag(4000, 68),
                    new GebuehrEintrag(4500, 76), new GebuehrEintrag(5000, 86), new GebuehrEintrag(6000, 96),
                    new GebuehrEintrag(7000, 105), new GebuehrEintrag(8000, 116), new GebuehrEintrag(9000, 121),
                    new GebuehrEintrag(10000, 127), new GebuehrEintrag(12500, 134), new GebuehrEintrag(15000, 151),
                    new GebuehrEintrag(17500, 166), new GebuehrEintrag(20000, 178), new GebuehrEintrag(22500, 191),
                    new GebuehrEintrag(25000, 201), new GebuehrEintrag(37500, 215), new GebuehrEintrag(50000, 263),
                    new GebuehrEintrag(62500, 303), new GebuehrEintrag(75000, 338), new GebuehrEintrag(87500, 353),
                    new GebuehrEintrag(100000, 369), new GebuehrEintrag(125000, 423), new GebuehrEintrag(150000, 471),
                    new GebuehrEintrag(175000, 512), new GebuehrEintrag(200000, 548), new GebuehrEintrag(225000, 582),
                    new GebuehrEintrag(250000, 613), new GebuehrEintrag(300000, 641), new GebuehrEintrag(350000, 696),
                    new GebuehrEintrag(400000, 746), new GebuehrEintrag(450000, 791), new GebuehrEintrag(500000, 832),
                    new GebuehrEintrag(625000, 871), new GebuehrEintrag(750000, 968), new GebuehrEintrag(875000, 1050),
                    new GebuehrEintrag(1000000, 1126), new GebuehrEintrag(1250000, 1194), new GebuehrEintrag(1500000, 1324),
                    new GebuehrEintrag(1750000, 1438), new GebuehrEintrag(2000000, 1542), new GebuehrEintrag(2250000, 1635),
                    new GebuehrEintrag(2500000, 1718), new GebuehrEintrag(3000000, 1797), new GebuehrEintrag(3500000, 1951),
                    new GebuehrEintrag(4000000, 2089), new GebuehrEintrag(4500000, 2214), new GebuehrEintrag(5000000, 2328),
                    new GebuehrEintrag(7500000, 2720), new GebuehrEintrag(10000000, 3162), new GebuehrEintrag(12500000, 3520),
                    new GebuehrEintrag(15000000, 3819), new GebuehrEintrag(17500000, 4074), new GebuehrEintrag(20000000, 4293),
                    new GebuehrEintrag(22500000, 4573), new GebuehrEintrag(25000000, 4831), new GebuehrEintrag(30000000, 5315),
                    new GebuehrEintrag(35000000, 5759), new GebuehrEintrag(40000000, 6172), new GebuehrEintrag(45000000, 6558),
                    new GebuehrEintrag(50000000, 6923)
                };

                // Anlage 1 Tabelle A
                beratungstabelle = new List<GebuehrEintrag>() {
                    new GebuehrEintrag(300, 31), new GebuehrEintrag(600, 56), new GebuehrEintrag(900, 81),
                    new GebuehrEintrag(1200, 106), new GebuehrEintrag(1500, 130), new GebuehrEintrag(2000, 166),
                    new GebuehrEintrag(2500, 200), new GebuehrEintrag(3000, 235), new GebuehrEintrag(3500, 270),
                    new GebuehrEintrag(4000, 305), new GebuehrEintrag(4500, 340), new GebuehrEintrag(5000, 375),
                    new GebuehrEintrag(6000, 422), new GebuehrEintrag(7000, 467), new GebuehrEintrag(8000, 514),
                    new GebuehrEintrag(9000, 560), new GebuehrEintrag(10000, 605), new GebuehrEintrag(13000, 655),
                    new GebuehrEintrag(16000, 705), new GebuehrEintrag(19000, 755), new GebuehrEintrag(22000, 805),
                    new GebuehrEintrag(25000, 854), new GebuehrEintrag(30000, 946), new GebuehrEintrag(35000, 1036),
                    new GebuehrEintrag(40000, 1125), new GebuehrEintrag(45000, 1215), new GebuehrEintrag(50000, 1304),
                    new GebuehrEintrag(65000, 1399), new GebuehrEintrag(80000, 1496), new GebuehrEintrag(95000, 1592),
                    new GebuehrEintrag(110000, 1689), new GebuehrEintrag(125000, 1784), new GebuehrEintrag(140000, 1879),
                    new GebuehrEintrag(155000, 1976), new GebuehrEintrag(170000, 2071), new GebuehrEintrag(185000, 2168),
                    new GebuehrEintrag(200000, 2264), new GebuehrEintrag(230000, 2412), new GebuehrEintrag(260000, 2559),
                    new GebuehrEintrag(290000, 2705), new GebuehrEintrag(320000, 2859), new GebuehrEintrag(350000, 2926),
                    new GebuehrEintrag(380000, 2990), new GebuehrEintrag(410000, 3055), new GebuehrEintrag(440000, 3115),
                    new GebuehrEintrag(470000, 3175), new GebuehrEintrag(500000, 3234), new GebuehrEintrag(550000, 3320),
                    new GebuehrEintrag(600000, 3404)
                };

                // Buchführungstabelle
                buchfuehrungsTabelle = new List<GebuehrEintrag>() {
                    new GebuehrEintrag(15000, 72), new GebuehrEintrag(17500, 80), new GebuehrEintrag(20000, 88),
                    new GebuehrEintrag(22500, 93), new GebuehrEintrag(25000, 101), new GebuehrEintrag(30000, 108),
                    new GebuehrEintrag(35000, 117), new GebuehrEintrag(40000, 122), new GebuehrEintrag(45000, 129),
                    new GebuehrEintrag(50000, 138), new GebuehrEintrag(62500, 145), new GebuehrEintrag(75000, 158),
                    new GebuehrEintrag(87500, 174), new GebuehrEintrag(100000, 188), new GebuehrEintrag(125000, 209),
                    new GebuehrEintrag(150000, 230), new GebuehrEintrag(200000, 275), new GebuehrEintrag(250000, 317),
                    new GebuehrEintrag(300000, 359), new GebuehrEintrag(350000, 404), new GebuehrEintrag(400000, 441),
                    new GebuehrEintrag(450000, 475), new GebuehrEintrag(500000, 512)
                };
            }

            public double BerechneVolleGebuehrAbschluss(double gegenstandswert)
            {
                foreach (var e in Abschlusstabelle) if (gegenstandswert <= e.GegenstandswertBis) return e.VolleGebuehr;

                // Mehrbetrag Berechnung (aus deiner Form1 übernommen)
                double gebuehr = 6923;
                if (gegenstandswert <= 125000000)
                {
                    double mehr = gegenstandswert - 50000000;
                    gebuehr += Math.Ceiling(mehr / 5000000) * 273;
                }
                else if (gegenstandswert <= 250000000)
                {
                    gebuehr += ((125000000 - 50000000) / 5000000) * 273;
                    double mehr = gegenstandswert - 125000000;
                    gebuehr += Math.Ceiling(mehr / 12500000) * 477;
                }
                else
                {
                    gebuehr += ((125000000 - 50000000) / 5000000) * 273;
                    gebuehr += ((250000000 - 125000000) / 12500000) * 477;
                    double mehr = gegenstandswert - 250000000;
                    gebuehr += Math.Ceiling(mehr / 25000000) * 681;
                }
                return gebuehr;
            }

            public double BerechneVolleGebuehrBeratung(double gegenstandswert)
            {
                foreach (var e in beratungstabelle) if (gegenstandswert <= e.GegenstandswertBis) return e.VolleGebuehr;

                double gebuehr = 3404;
                if (gegenstandswert <= 5000000)
                {
                    double mehr = gegenstandswert - 600000;
                    gebuehr += Math.Ceiling(mehr / 50000) * 149;
                }
                else if (gegenstandswert <= 25000000)
                {
                    gebuehr += ((5000000 - 600000) / 50000) * 149;
                    double mehr = gegenstandswert - 5000000;
                    gebuehr += Math.Ceiling(mehr / 50000) * 112;
                }
                else
                {
                    gebuehr += ((5000000 - 600000) / 50000) * 149;
                    gebuehr += ((25000000 - 5000000) / 50000) * 112;
                    double mehr = gegenstandswert - 25000000;
                    gebuehr += Math.Ceiling(mehr / 50000) * 88;
                }
                return gebuehr;
            }

            public double BerechneVolleGebuehrBuchfuehrung(double gegenstandswert)
            {
                foreach (var e in buchfuehrungsTabelle) if (gegenstandswert <= e.GegenstandswertBis) return e.VolleGebuehr;

                if (gegenstandswert > 500000)
                {
                    double mehr = gegenstandswert - 500000;
                    int steps = (int)Math.Ceiling(mehr / 50000);
                    return 512 + (steps * 36);
                }
                return 512;
            }

            private class GebuehrEintrag
            {
                public double GegenstandswertBis;
                public double VolleGebuehr;
                public GebuehrEintrag(double bis, double geb) { GegenstandswertBis = bis; VolleGebuehr = geb; }
            }
        }
    }
}