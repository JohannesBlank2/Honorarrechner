using HonorarRechner.Core.Models;
using System.Collections.Generic;

namespace HonorarRechner.Core.Services
{
    /// <summary>
    /// Enthält nur die statischen Daten der Gebührentabellen.
    /// </summary>
    public static class GebuehrenTabellen
    {
        public static readonly List<GebuehrEintrag> AbschlussTabelle = new List<GebuehrEintrag>()
        {
                    new GebuehrEintrag(3000, 49), new GebuehrEintrag(3500, 57), new GebuehrEintrag(4000, 68),
                    new GebuehrEintrag(4500, 76), new GebuehrEintrag(5000, 86), new GebuehrEintrag(6000, 96),
                    new GebuehrEintrag(7000, 105), new GebuehrEintrag(8000, 116), new GebuehrEintrag(9000, 121),
                    new GebuehrEintrag(10000, 127), new GebuehrEintrag(12500, 134), new GebuehrEintrag(15000, 151),
                    new GebuehrEintrag(17500, 166), new GebuehrEintrag(20000, 178), new GebuehrEintrag(22500, 191),
                    new GebuehrEintrag(25000, 201), new GebuehrEintrag(37500, 215), new GebuehrEintrag(50000, 263),
                    new GebuehrEintrag(62500, 303), new GebuehrEintrag(75000, 338), new GebuehrEintrag(87500, 353),
                    new GebuehrEintrag(100000, 369), new GebuehrEintrag(125000, 423), new GebuehrEintrag(150000, 471),
                    new GebuehrEintrag(175000, 512), new GebuehrEintrag(200000, 548), new GebuehrEintrag(225000, 582),
                    new GebuehrEintrag(250000, 613), new GebuehrEintrag(300000, 641), new GebuehrEintrag(350000, 696),
                    new GebuehrEintrag(400000, 746), new GebuehrEintrag(450000, 791), new GebuehrEintrag(500000, 832),
                    new GebuehrEintrag(625000, 871), new GebuehrEintrag(750000, 968), new GebuehrEintrag(875000, 1050),
                    new GebuehrEintrag(1000000, 1126), new GebuehrEintrag(1250000, 1194), new GebuehrEintrag(1500000, 1324),
                    new GebuehrEintrag(1750000, 1438), new GebuehrEintrag(2000000, 1542), new GebuehrEintrag(2250000, 1635),
                    new GebuehrEintrag(2500000, 1718), new GebuehrEintrag(3000000, 1797), new GebuehrEintrag(3500000, 1951),
                    new GebuehrEintrag(4000000, 2089), new GebuehrEintrag(4500000, 2214), new GebuehrEintrag(5000000, 2328),
                    new GebuehrEintrag(7500000, 2720), new GebuehrEintrag(10000000, 3162), new GebuehrEintrag(12500000, 3520),
                    new GebuehrEintrag(15000000, 3819), new GebuehrEintrag(17500000, 4074), new GebuehrEintrag(20000000, 4293),
                    new GebuehrEintrag(22500000, 4573), new GebuehrEintrag(25000000, 4831), new GebuehrEintrag(30000000, 5315),
                    new GebuehrEintrag(35000000, 5759), new GebuehrEintrag(40000000, 6172), new GebuehrEintrag(45000000, 6558),
                    new GebuehrEintrag(50000000, 6923)
                };

        public static readonly List<GebuehrEintrag> BeratungsTabelle = new List<GebuehrEintrag>()
        {
                    new GebuehrEintrag(300, 31), new GebuehrEintrag(600, 56), new GebuehrEintrag(900, 81),
                    new GebuehrEintrag(1200, 106), new GebuehrEintrag(1500, 130), new GebuehrEintrag(2000, 166),
                    new GebuehrEintrag(2500, 200), new GebuehrEintrag(3000, 235), new GebuehrEintrag(3500, 270),
                    new GebuehrEintrag(4000, 305), new GebuehrEintrag(4500, 340), new GebuehrEintrag(5000, 375),
                    new GebuehrEintrag(6000, 422), new GebuehrEintrag(7000, 467), new GebuehrEintrag(8000, 514),
                    new GebuehrEintrag(9000, 560), new GebuehrEintrag(10000, 605), new GebuehrEintrag(13000, 655),
                    new GebuehrEintrag(16000, 705), new GebuehrEintrag(19000, 755), new GebuehrEintrag(22000, 805),
                    new GebuehrEintrag(25000, 854), new GebuehrEintrag(30000, 946), new GebuehrEintrag(35000, 1036),
                    new GebuehrEintrag(40000, 1125), new GebuehrEintrag(45000, 1215), new GebuehrEintrag(50000, 1304),
                    new GebuehrEintrag(65000, 1399), new GebuehrEintrag(80000, 1496), new GebuehrEintrag(95000, 1592),
                    new GebuehrEintrag(110000, 1689), new GebuehrEintrag(125000, 1784), new GebuehrEintrag(140000, 1879),
                    new GebuehrEintrag(155000, 1976), new GebuehrEintrag(170000, 2071), new GebuehrEintrag(185000, 2168),
                    new GebuehrEintrag(200000, 2264), new GebuehrEintrag(230000, 2412), new GebuehrEintrag(260000, 2559),
                    new GebuehrEintrag(290000, 2705), new GebuehrEintrag(320000, 2859), new GebuehrEintrag(350000, 2926),
                    new GebuehrEintrag(380000, 2990), new GebuehrEintrag(410000, 3055), new GebuehrEintrag(440000, 3115),
                    new GebuehrEintrag(470000, 3175), new GebuehrEintrag(500000, 3234), new GebuehrEintrag(550000, 3320),
                    new GebuehrEintrag(600000, 3404)
                };

        public static readonly List<GebuehrEintrag> BuchfuehrungsTabelle = new List<GebuehrEintrag>()
        {
                    new GebuehrEintrag(15000, 72), new GebuehrEintrag(17500, 80), new GebuehrEintrag(20000, 88),
                    new GebuehrEintrag(22500, 93), new GebuehrEintrag(25000, 101), new GebuehrEintrag(30000, 108),
                    new GebuehrEintrag(35000, 117), new GebuehrEintrag(40000, 122), new GebuehrEintrag(45000, 129),
                    new GebuehrEintrag(50000, 138), new GebuehrEintrag(62500, 145), new GebuehrEintrag(75000, 158),
                    new GebuehrEintrag(87500, 174), new GebuehrEintrag(100000, 188), new GebuehrEintrag(125000, 209),
                    new GebuehrEintrag(150000, 230), new GebuehrEintrag(200000, 275), new GebuehrEintrag(250000, 317),
                    new GebuehrEintrag(300000, 359), new GebuehrEintrag(350000, 404), new GebuehrEintrag(400000, 441),
                    new GebuehrEintrag(450000, 475), new GebuehrEintrag(500000, 512)
                };
    }
}