namespace HonorarRechner.Core.Models
{
    public class TabellenWerte
    {
        // Konstruktor mit Standardwerten (Fallback, falls Excel nicht lädt)
        public TabellenWerte()
        {
            // --- FiBu Defaults ---
            ITPauschale = 45m;
            AuslagenPauschaleProzent = 0.1m; // 10%
            AuslagenPauschaleMax = 40m;
            FibuMinMonatlich = 208m;
            FibuNormalSatz = 0.7m;       // 7/10
            OnlineHaendlerSatz = 0.5m;   // 5/10
            BarGeldGewerbeSatz = 0.8m;   // 8/10

            // --- Lohn Defaults ---
            BeitragEins = 42m;
            BeitragZweiBisNeun = 30m;
            BeitragZehnBisNeunzehn = 24m;
            BeitragZwanzigBisNeunundvierzig = 22m;
            BeitragFuenfzigBisHundert = 20m;

            // --- JA (EÜR) Defaults ---
            BeaSatz = 1.5m;    // 15/10
            BeaMin = 17500m;
            GewerbeSatz = 0.3m; // 3/10
            GewerbeMin = 8000m;
            UedbSatz = 0.7m;    // 7/10
            UedbMin = 17500m;
            UstSatz = 0.3m;     // 3/10
            UstMin = 8000m;
            AbschlussPauschaleSatz = 25m;
            EurMinMonat = 100m; // Geschätzt, da nicht in CSV Snippet sichtbar

            // --- JA (Bilanz) Defaults ---
            AdJSatz = 3.0m;     // 30/10
            AdJMin = 3000m;
            AntragSatz = 0.5m;  // 5/10
            AntragMin = 3000m;
            SteuerbilanzSatz = 0.5m; // 5/10
            SteuerbilanzMin = 3000m;
            KoerperschaftSatz = 0.3m; // 3/10
            KoerperschaftMin = 16000m;
            UstKjSatz = 0.3m;   // 3/10
            UstKjMin = 8000m;
            GewStErklSatz = 0.3m; // 3/10 (Annahme)
            GewStErklMin = 8000m; // Annahme

            BilanzBescheidSatz = 25m;
            E_BilanzPauschale = 160m;  // Beispielwerte
            OffenlegungPauschale = 110m;
            BilanzMinEuMonat = 150m;
            BilanzMinGesMonat = 250m;

            // --- Private Leistungen Defaults ---
            PruefungSteuerbescheidPauschale = 0m;
            EinkommensteuerErklaerungSatz = 0m;
            EinkommensteuerErklaerungMin = 0m;
        }

        // --- Properties ---

        // FiBu
        public decimal ITPauschale { get; set; }
        public decimal AuslagenPauschaleProzent { get; set; }
        public decimal AuslagenPauschaleMax { get; set; }
        public decimal FibuMinMonatlich { get; set; }
        public decimal FibuNormalSatz { get; set; }
        public decimal OnlineHaendlerSatz { get; set; }
        public decimal BarGeldGewerbeSatz { get; set; }

        // Lohn
        public decimal BeitragEins { get; set; }
        public decimal BeitragZweiBisNeun { get; set; }
        public decimal BeitragZehnBisNeunzehn { get; set; }
        public decimal BeitragZwanzigBisNeunundvierzig { get; set; }
        public decimal BeitragFuenfzigBisHundert { get; set; }

        // JA EÜR
        public decimal BeaSatz { get; set; }
        public decimal BeaMin { get; set; }
        public decimal GewerbeSatz { get; set; }
        public decimal GewerbeMin { get; set; }
        public decimal UedbSatz { get; set; }
        public decimal UedbMin { get; set; }
        public decimal UstSatz { get; set; }
        public decimal UstMin { get; set; }
        public decimal AbschlussPauschaleSatz { get; set; }
        public decimal EurMinMonat { get; set; }

        // JA Bilanz
        public decimal AdJSatz { get; set; }
        public decimal AdJMin { get; set; }
        public decimal AntragSatz { get; set; }
        public decimal AntragMin { get; set; }
        public decimal SteuerbilanzSatz { get; set; }
        public decimal SteuerbilanzMin { get; set; }
        public decimal KoerperschaftSatz { get; set; }
        public decimal KoerperschaftMin { get; set; }
        public decimal UstKjSatz { get; set; }
        public decimal UstKjMin { get; set; }
        public decimal GewStErklSatz { get; set; }
        public decimal GewStErklMin { get; set; }
        public decimal BilanzBescheidSatz { get; set; }
        public decimal E_BilanzPauschale { get; set; }
        public decimal OffenlegungPauschale { get; set; }
        public decimal BilanzMinEuMonat { get; set; }
        public decimal BilanzMinGesMonat { get; set; }

        // Private Leistungen
        public decimal PruefungSteuerbescheidPauschale { get; set; }
        public decimal EinkommensteuerErklaerungSatz { get; set; }
        public decimal EinkommensteuerErklaerungMin { get; set; }
    }
}
