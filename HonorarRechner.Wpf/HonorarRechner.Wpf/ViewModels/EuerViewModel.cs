using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class EuerViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public EuerViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Initialwerte setzen, damit "Zahlen in den Boxen" erscheinen
            _gegenstandswert = 50000m;
            _bescheidAnzahl = "1";
            Recalculate();
        }

        private string ToEuro(decimal value) => value.ToString("C", _deCulture);

        // --- Eingaben ---
        private decimal _gegenstandswert;
        public string GegenstandswertText
        {
            get => _gegenstandswert.ToString("N2", _deCulture);
            set
            {
                if (decimal.TryParse(value, NumberStyles.Any, _deCulture, out decimal result))
                {
                    _gegenstandswert = result;
                    Recalculate();
                    OnPropertyChanged();
                }
            }
        }

        private string _bescheidAnzahl;
        public string BescheidAnzahl
        {
            get => _bescheidAnzahl;
            set { if (Set(ref _bescheidAnzahl, value)) Recalculate(); }
        }

        private bool _isUeberschussSelected;
        public bool IsUeberschussSelected
        {
            get => _isUeberschussSelected;
            set { if (Set(ref _isUeberschussSelected, value)) Recalculate(); }
        }

        private bool _isAveurSelected = true;
        public bool IsAveurSelected
        {
            get => _isAveurSelected;
            set { if (Set(ref _isAveurSelected, value)) Recalculate(); }
        }

        // --- Sätze (für die grauen Boxen) ---
        public string BeaSatz => "20/10";
        public string AveurSatz => "10/10";
        public string GewerbeSatz => "5/10";
        public string UedbSatz => "10/10";
        public string UstSatz => "3/10";

        // --- Werte ---
        private decimal _beaValue;
        public string BeaText => ToEuro(_beaValue);

        private decimal _aveurValue;
        public string AveurText => ToEuro(_aveurValue);

        private decimal _gewerbeValue;
        public string GewerbeText => ToEuro(_gewerbeValue);

        private decimal _uedbValue;
        public string UedbText => ToEuro(_uedbValue);

        private decimal _ustValue;
        public string UstText => ToEuro(_ustValue);

        private decimal _pauschaleValue;
        public string PauschaleText => ToEuro(_pauschaleValue);

        // --- Summen ---
        private decimal _zwischenSummeMonat;
        public string MonatsAnteilText => ToEuro(_zwischenSummeMonat / 12);
        public string JahresGesamtText => ToEuro(_zwischenSummeMonat);

        private void Recalculate()
        {
            decimal grundgebuehr = _gegenstandswert * 0.01m;
            if (grundgebuehr < 50) grundgebuehr = 50;

            _beaValue = grundgebuehr * 2.0m;
            _aveurValue = IsAveurSelected ? grundgebuehr * 1.0m : 0;
            _gewerbeValue = grundgebuehr * 0.5m;
            _uedbValue = IsUeberschussSelected ? grundgebuehr * 1.0m : 0;
            _ustValue = grundgebuehr * 0.3m;

            if (int.TryParse(_bescheidAnzahl, out int anzahl))
                _pauschaleValue = anzahl * 25m;
            else _pauschaleValue = 0;

            _zwischenSummeMonat = _beaValue + _aveurValue + _gewerbeValue + _uedbValue + _ustValue + _pauschaleValue;

            OnPropertyChanged(nameof(BeaText));
            OnPropertyChanged(nameof(AveurText));
            OnPropertyChanged(nameof(GewerbeText));
            OnPropertyChanged(nameof(UedbText));
            OnPropertyChanged(nameof(UstText));
            OnPropertyChanged(nameof(PauschaleText));
            OnPropertyChanged(nameof(JahresGesamtText));
            OnPropertyChanged(nameof(MonatsAnteilText));
        }

        public ICommand ZurueckCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private bool Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}