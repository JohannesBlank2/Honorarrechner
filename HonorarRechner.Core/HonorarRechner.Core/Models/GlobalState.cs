namespace HonorarRechner.Core.Models
{
    /// <summary>
    /// Holds app-wide state so multiple view models can share data.
    /// </summary>
    public class GlobalState
    {
        private static GlobalState? _instance;
        public static GlobalState Instance => _instance ??= new GlobalState();

        // Signal for view models that data changed.
        public event Action? DataChanged;

        public UnternehmensDaten Daten { get; set; } = new UnternehmensDaten();
        public PrivatDaten PrivatDaten { get; set; } = new PrivatDaten();
        public TabellenWerte Werte { get; set; } = new TabellenWerte();

        private GlobalState()
        {
            // Default values so the app does not crash before Excel loads.
            Werte.FibuNormalSatz = 0.7m; // 7/10
            Werte.ITPauschale = 40m;
            Werte.AuslagenPauschaleProzent = 0.2m;
            Werte.BeitragEins = 42m;
        }

        public void NotifyDataChanged()
        {
            DataChanged?.Invoke();
        }
    }
}
