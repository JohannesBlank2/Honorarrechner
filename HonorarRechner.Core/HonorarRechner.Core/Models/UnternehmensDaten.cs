namespace HonorarRechner.Core.Models
{
    public class UnternehmensDaten
    {
        public decimal UmsatzImJahr { get; set; }
        public decimal Bilanzsumme { get; set; }
        public decimal Jahresueberschuss { get; set; }
        public int AnzahlMitarbeiter { get; set; }

        public bool IstBargeldGewerbe { get; set; }
        public bool IstOnlineHaendler { get; set; }

        // Leistungen
        public bool HatFiBu { get; set; }

        public bool HatJahresabschluss { get; set; }
        public string JahresabschlussTyp { get; set; } = "NIX"; // "Bilanz" oder "EÜR"
        public string UnternehmensArt { get; set; } = "NIX"; // "EU" oder "GESELLSCHAFT"

        public bool HatUeberschussRechnung { get; set; } // Für EÜR (Checkbox UdB)

        public bool HatLohn { get; set; }
        public bool IstSelbstbucher { get; set; }
    }
}