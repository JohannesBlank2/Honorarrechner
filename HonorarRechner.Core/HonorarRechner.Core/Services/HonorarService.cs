using HonorarRechner.Core.Models;
using System;

namespace HonorarRechner.Core.Services
{
    // --- DTOs für die Detail-Anzeigen ---
    public class FibuDetailErgebnis
    {
        public decimal LaufendeMonatlich { get; set; }
        public decimal AuslagenMonatlich { get; set; }
        public decimal ItMonatlich { get; set; }
        public decimal ZwischensummeMonatlich { get; set; }
        public decimal EndsummeMonatlich { get; set; }
        public decimal JahresGesamt { get; set; }
    }

    public class LohnDetailErgebnis
    {
        public int Count1 { get; set; }
        public decimal Preis1 { get; set; }
        public decimal Sum1 { get; set; }
        public int Count2_9 { get; set; }
        public decimal Preis2_9 { get; set; }
        public decimal Sum2_9 { get; set; }
        public int Count10_19 { get; set; }
        public decimal Preis10_19 { get; set; }
        public decimal Sum10_19 { get; set; }
        public int Count20_49 { get; set; }
        public decimal Preis20_49 { get; set; }
        public decimal Sum20_49 { get; set; }
        public int Count50_100 { get; set; }
        public decimal Preis50_100 { get; set; }
        public decimal Sum50_100 { get; set; }
        public int Count101Plus { get; set; }
        public decimal Preis101Plus { get; set; }
        public decimal Sum101Plus { get; set; }
        public decimal MonatGesamt { get; set; }
        public decimal JahrGesamt { get; set; }
    }

    /// <summary>
    /// Hauptservice für die Honorarberechnung. Koordiniert die Logik.
    /// </summary>
    public class HonorarService
    {
        // Nutzt jetzt die ausgelagerte Mathe-Klasse
        private readonly GebuehrenRechner _rechner = new GebuehrenRechner();

        public HonorarErgebnis BerechneAlles()
        {
            var daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;
            var ergebnis = new HonorarErgebnis();

            // 1. Lohn
            if (daten.HatLohn && daten.AnzahlMitarbeiter > 0)
            {
                ergebnis.LohnBeitrag = BerechneLohnDetails(daten.AnzahlMitarbeiter, werte).JahrGesamt;
            }

            // 2. FiBu
            if (daten.HatFiBu && daten.UmsatzImJahr > 0)
            {
                ergebnis.FiBuBeitrag = BerechneFibuDetails(daten, werte).JahresGesamt;
            }

            // 3. Jahresabschluss
            if (daten.HatJahresabschluss)
            {
                if (daten.Bilanzsumme > 0)
                    ergebnis.JaBeitrag = BerechneBilanz(daten, werte);
                else if (daten.UmsatzImJahr > 0 || daten.Jahresueberschuss > 0)
                    ergebnis.JaBeitrag = BerechneEuer(daten, werte);
            }

            // 4. Selbstbucher (+20% auf JA)
            if (daten.IstSelbstbucher && ergebnis.JaBeitrag > 0)
            {
                ergebnis.SelbstbucherAbschlag = ergebnis.JaBeitrag * 0.20m;
            }

            // Gesamtsumme
            ergebnis.JahresHonorar =
                ergebnis.LohnBeitrag +
                ergebnis.FiBuBeitrag +
                ergebnis.JaBeitrag +
                (daten.IstSelbstbucher ? ergebnis.SelbstbucherAbschlag : 0);

            return ergebnis;
        }

        // --- Wrapper Methoden (für ViewModels, die nur den Endpreis wollen) ---

        public decimal BerechneLohn(int anzahl, TabellenWerte w)
            => BerechneLohnDetails(anzahl, w).JahrGesamt;

        public decimal BerechneFibu(UnternehmensDaten d, TabellenWerte w)
            => BerechneFibuDetails(d, w).JahresGesamt;


        // --- Detail-Berechnungen ---

        public FibuDetailErgebnis BerechneFibuDetails(UnternehmensDaten d, TabellenWerte w)
        {
            var result = new FibuDetailErgebnis();

            decimal satz = w.FibuNormalSatz;
            if (d.IstBargeldGewerbe) satz = w.BarGeldGewerbeSatz;
            if (d.IstOnlineHaendler) satz = w.OnlineHaendlerSatz;

            decimal basisGebuehr = (decimal)_rechner.BerechneVolleGebuehrBuchfuehrung((double)d.UmsatzImJahr);
            result.LaufendeMonatlich = basisGebuehr * satz;

            decimal auslagen = result.LaufendeMonatlich * w.AuslagenPauschaleProzent;
            if (auslagen > w.AuslagenPauschaleMax) auslagen = w.AuslagenPauschaleMax;
            result.AuslagenMonatlich = auslagen;

            result.ItMonatlich = w.ITPauschale;
            result.ZwischensummeMonatlich = result.LaufendeMonatlich + result.AuslagenMonatlich + result.ItMonatlich;

            result.EndsummeMonatlich = Math.Max(result.ZwischensummeMonatlich, w.FibuMinMonatlich);
            result.JahresGesamt = result.EndsummeMonatlich * 12;

            return result;
        }

        public LohnDetailErgebnis BerechneLohnDetails(int anzahl, TabellenWerte w)
        {
            var r = new LohnDetailErgebnis();
            if (anzahl <= 0) return r;

            int rest = anzahl;

            // 1. MA
            r.Count1 = rest > 0 ? 1 : 0; r.Preis1 = w.BeitragEins; r.Sum1 = r.Count1 * r.Preis1; rest -= r.Count1;

            // Staffel
            r.Count2_9 = Math.Max(0, Math.Min(rest, 8)); r.Preis2_9 = w.BeitragZweiBisNeun; r.Sum2_9 = r.Count2_9 * r.Preis2_9; rest -= r.Count2_9;
            r.Count10_19 = Math.Max(0, Math.Min(rest, 10)); r.Preis10_19 = w.BeitragZehnBisNeunzehn; r.Sum10_19 = r.Count10_19 * r.Preis10_19; rest -= r.Count10_19;
            r.Count20_49 = Math.Max(0, Math.Min(rest, 30)); r.Preis20_49 = w.BeitragZwanzigBisNeunundvierzig; r.Sum20_49 = r.Count20_49 * r.Preis20_49; rest -= r.Count20_49;
            r.Count50_100 = Math.Max(0, Math.Min(rest, 51)); r.Preis50_100 = w.BeitragFuenfzigBisHundert; r.Sum50_100 = r.Count50_100 * r.Preis50_100; rest -= r.Count50_100;

            // 101+
            r.Count101Plus = Math.Max(0, rest);
            if (r.Count101Plus > 0)
            {
                decimal rabatt = (anzahl - 100) * 0.1m;
                r.Preis101Plus = Math.Max(20m - rabatt, 15m);
                r.Sum101Plus = r.Count101Plus * r.Preis101Plus;
            }

            r.MonatGesamt = r.Sum1 + r.Sum2_9 + r.Sum10_19 + r.Sum20_49 + r.Sum50_100 + r.Sum101Plus;
            r.JahrGesamt = r.MonatGesamt * 12;

            return r;
        }

        // --- JA Berechnungen ---

        public decimal BerechneEuer(UnternehmensDaten d, TabellenWerte w)
        {
            decimal b = (decimal)_rechner.BerechneVolleGebuehrAbschluss((double)Math.Max(d.Jahresueberschuss, w.BeaMin)) * w.BeaSatz;
            decimal g = (decimal)_rechner.BerechneVolleGebuehrBeratung((double)Math.Max(d.Jahresueberschuss, w.GewerbeMin)) * w.GewerbeSatz;
            decimal u = (decimal)_rechner.BerechneVolleGebuehrBeratung((double)Math.Max(d.UmsatzImJahr, w.UstMin)) * w.UstSatz;
            decimal p = 3 * w.AbschlussPauschaleSatz;

            decimal uedb = 0;
            if (d.HatUeberschussRechnung)
                uedb = (decimal)_rechner.BerechneVolleGebuehrAbschluss((double)Math.Max(d.Jahresueberschuss, w.UedbMin)) * w.UedbSatz;

            return Math.Max(b + g + u + p + uedb, w.EurMinMonat * 12);
        }

        public decimal BerechneBilanz(UnternehmensDaten d, TabellenWerte w)
        {
            decimal mw = (d.UmsatzImJahr + d.Bilanzsumme) / 2m;

            decimal t1 = (decimal)_rechner.BerechneVolleGebuehrAbschluss((double)Math.Max(mw, w.AdJMin)) * w.AdJSatz;
            decimal t2 = (decimal)_rechner.BerechneVolleGebuehrAbschluss((double)Math.Max(mw, w.AntragMin)) * w.AntragSatz;
            decimal t3 = (decimal)_rechner.BerechneVolleGebuehrAbschluss((double)Math.Max(mw, w.SteuerbilanzMin)) * w.SteuerbilanzSatz;

            decimal t4 = (decimal)_rechner.BerechneVolleGebuehrBeratung((double)Math.Max(d.Jahresueberschuss, w.KoerperschaftMin)) * w.KoerperschaftSatz;
            decimal t5 = (decimal)_rechner.BerechneVolleGebuehrBeratung((double)Math.Max(d.UmsatzImJahr * 0.1m, w.UstKjMin)) * w.UstKjSatz;
            decimal t6 = (decimal)_rechner.BerechneVolleGebuehrBeratung((double)Math.Max(d.Jahresueberschuss, w.GewStErklMin)) * w.GewStErklSatz;

            decimal bescheide = 4 * w.BilanzBescheidSatz;
            decimal total = t1 + t2 + t3 + t4 + t5 + t6 + bescheide + w.E_BilanzPauschale + w.OffenlegungPauschale;

            decimal min = (d.UnternehmensArt == "GESELLSCHAFT" ? w.BilanzMinGesMonat : w.BilanzMinEuMonat) * 12;
            return Math.Max(total, min);
        }
    }
}