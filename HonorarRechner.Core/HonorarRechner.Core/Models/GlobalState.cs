using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace HonorarRechner.Wpf.Models
{
    // Diese Klasse speichert den Zustand der gesamten App (Singleton Pattern)
    public class GlobalState : INotifyPropertyChanged
    {
        private static GlobalState _instance;
        public static GlobalState Instance => _instance ??= new GlobalState();

        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        private GlobalState() { }

        // --- Die "EINE VARIABLE" für das Honorar ---
        private decimal _jahresHonorar;
        public decimal JahresHonorar
        {
            get => _jahresHonorar;
            set
            {
                if (_jahresHonorar != value)
                {
                    _jahresHonorar = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(JahresHonorarText));
                    OnPropertyChanged(nameof(MonatsHonorarText));
                }
            }
        }

        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar.ToString("C", _deCulture)}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m).ToString("C", _deCulture)}";

        // Optional: Hier könnte man auch die Unternehmensdaten zentral speichern, 
        // damit sie beim Zurückgehen nicht verloren gehen!

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}