namespace HonorarRechner.Core.Models
{
    /// <summary>
    /// Hält den aktuellen Zustand der Anwendung, damit verschiedene ViewModels darauf zugreifen können.
    /// </summary>
    public class GlobalState
    {
        private static GlobalState? _instance;
        public static GlobalState Instance => _instance ??= new GlobalState();

        // Das "Megafon": Andere können hier zuhören
        public event Action? DataChanged;

        public UnternehmensDaten Daten { get; set; } = new UnternehmensDaten();
        public TabellenWerte Werte { get; set; } = new TabellenWerte();

        // Standardwerte initialisieren, damit nicht alles 0 ist, falls Excel noch nicht geladen wurde
        private GlobalState()
        {
            // Initialisiere mit Dummy-Werten, damit es nicht abstürzt, bevor Excel geladen ist
            Werte.FibuNormalSatz = 0.7m; // 7/10
            Werte.ITPauschale = 40m;
            Werte.AuslagenPauschaleProzent = 0.2m;
            Werte.BeitragEins = 42m;
            // ... weitere Defaults können hier rein
        }

        // Diese Methode rufen wir auf, wenn sich was geändert hat
        public void NotifyDataChanged()
        {
            DataChanged?.Invoke();
        }
    }
}