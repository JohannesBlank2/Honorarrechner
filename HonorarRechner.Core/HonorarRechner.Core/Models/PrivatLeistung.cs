using System;

namespace HonorarRechner.Core.Models
{
    public class PrivatLeistung
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public decimal Preis { get; set; }
        public decimal EingabeWert1 { get; set; }
        public decimal EingabeWert2 { get; set; }
    }
}
