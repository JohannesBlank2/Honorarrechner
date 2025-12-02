namespace HonorarRechner.Core.Models
{
    public class TabellenWerte
    {
        // --- FiBu ---
        public decimal ITPauschale { get; set; }
        public decimal AuslagenPauschaleProzent { get; set; }
        public decimal AuslagenPauschaleMax { get; set; }
        public decimal FibuMinMonatlich { get; set; }

        // Sätze als Strings ("7/10") oder Dezimalwerte, hier Dezimal für Berechnung
        public decimal FibuNormalSatz { get; set; }
        public decimal OnlineHaendlerSatz { get; set; }
        public decimal BarGeldGewerbeSatz { get; set; }

        // --- Lohn (Staffelpreise) ---
        public decimal BeitragEins { get; set; }
        public decimal BeitragZweiBisNeun { get; set; }
        public decimal BeitragZehnBisNeunzehn { get; set; }
        public decimal BeitragZwanzigBisNeunundvierzig { get; set; }
        public decimal BeitragFuenfzigBisHundert { get; set; }

        // --- JA (EÜR) ---
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

        // --- JA (Bilanz) ---
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

        public decimal BilanzBescheidSatz { get; set; } // pro Bescheid
        public decimal E_BilanzPauschale { get; set; }
        public decimal OffenlegungPauschale { get; set; }

        public decimal BilanzMinEuMonat { get; set; }
        public decimal BilanzMinGesMonat { get; set; }
    }
}