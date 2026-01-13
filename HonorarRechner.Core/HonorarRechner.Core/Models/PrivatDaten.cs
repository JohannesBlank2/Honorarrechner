using System.Collections.Generic;

namespace HonorarRechner.Core.Models
{
    public class PrivatDaten
    {
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public string SteuerId { get; set; } = "";
        public string Geburtsdatum { get; set; } = "";
        public decimal EinkommenImJahr { get; set; }
        public int AnzahlKinder { get; set; }
        public bool Verheiratet { get; set; }
        public List<PrivatLeistung> Leistungen { get; set; } = new List<PrivatLeistung>();
    }
}
