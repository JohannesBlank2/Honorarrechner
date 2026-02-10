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
        public decimal SummePositiveEinkuenfte { get; set; }
        public decimal KapitalvermoegenEinnahmen { get; set; }
        public decimal KapitalvermoegenWerbungskosten { get; set; }
        public decimal NichtselbstEinnahmen { get; set; }
        public decimal NichtselbstWerbungskosten { get; set; }
        public decimal SonstigeEinnahmen { get; set; }
        public decimal SonstigeWerbungskosten { get; set; }
        public decimal VermietungEinnahmen { get; set; }
        public decimal VermietungWerbungskosten { get; set; }
        public decimal Werbungskosten { get; set; }
        public decimal SummeBetriebseinnahmen { get; set; }
        public decimal SummeBetriebsausgaben { get; set; }
        public decimal UstConsultingGesamtbetragEntgelte { get; set; }
        public decimal UstConsultingEntgelteLeistungsempfaenger { get; set; }
        public List<PrivatLeistung> Leistungen { get; set; } = new List<PrivatLeistung>();
    }
}
