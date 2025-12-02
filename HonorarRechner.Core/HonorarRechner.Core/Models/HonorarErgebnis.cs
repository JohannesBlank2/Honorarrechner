using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonorarRechner.Core.Models
{
    public class HonorarErgebnis
    {
        public decimal JahresHonorar { get; set; }
        public decimal MonatsHonorar => JahresHonorar / 12m;

        public decimal FiBuBeitrag { get; set; }
        public decimal JaBeitrag { get; set; }
        public decimal LohnBeitrag { get; set; }
        public decimal SelbstbucherAbschlag { get; set; }

        public string DebugInfo { get; set; } = string.Empty; // für dich zum Prüfen
    }
}

