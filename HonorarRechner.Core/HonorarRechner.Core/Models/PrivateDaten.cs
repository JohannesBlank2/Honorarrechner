namespace HonorarRechner.Core.Models
{
    public class PrivateDaten
    {
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";

        // Wichtigster Wert für die Einkommensteuererklärung (§ 24 StBVV)
        public decimal SummePositiveEinkuenfte { get; set; }

        public bool IstZusammenVeranlagung { get; set; }
    }
}