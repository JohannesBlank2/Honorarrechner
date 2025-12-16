namespace HonorarRechner.Core.Models
{
    public class HonorarErgebnis
    {
        public decimal LohnBeitrag { get; set; }
        public decimal FiBuBeitrag { get; set; }
        public decimal JaBeitrag { get; set; }
        public decimal SelbstbucherAbschlag { get; set; }
        public decimal JahresHonorar { get; set; }
    }

    // --- Die fehlenden Klassen hier einfügen ---

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
}