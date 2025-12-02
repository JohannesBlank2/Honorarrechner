namespace HonorarRechner.Core.Models
{
    public class GebuehrEintrag
    {
        public double GegenstandswertBis { get; set; }
        public double VolleGebuehr { get; set; }

        public GebuehrEintrag(double bis, double gebuehr)
        {
            GegenstandswertBis = bis;
            VolleGebuehr = gebuehr;
        }
    }
}