using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // später kommen hier auch die Checkboxen für FiBu / JA / Lohn usw. mit rein
        public bool HatFiBu { get; set; }
        public bool HatJahresabschluss { get; set; }
        public bool HatLohn { get; set; }
        public bool IstSelbstbucher { get; set; }
    }
}

