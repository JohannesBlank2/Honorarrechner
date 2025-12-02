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

            // Standardwerte
            _beaInput = "50000";
            _gewerbeInput = "50000";
            _uedbInput = "50000";
            _ustInput = "50000";
            _pauschaleInput = "1";

            Recalculate();
        }

        private string ToEuro(decimal value) => value.ToString("C", _deCulture);

        // --- 1. BEA (Betriebs Einnahmen-Ausgaben) ---
        private string _beaInput;
        public string BeaInput
        {
            get => _beaInput;
            set { if (Set(ref _beaInput, value)) Recalculate(); }
        }

        // --- 2. Gewerbesteuer ---
        private string _gewerbeInput;
        public string GewerbeInput
        {
            get => _gewerbeInput;
            set { if (Set(ref _gewerbeInput, value)) Recalculate(); }
        }

        // --- 3. Überschuss (Optional) ---
        private bool _isUeberschussSelected;
        public bool IsUeberschussSelected
        {
            get => _isUeberschussSelected;
            set { if (Set(ref _isUeberschussSelected, value)) Recalculate(); }
        }
        private string _uedbInput;
        public string UedbInput
        {
            get => _uedbInput;
            set { if (Set(ref _uedbInput, value)) Recalculate(); }
        }

        // --- 4. Umsatzsteuer ---
        private string _ustInput;
        public string UstInput
        {
            get => _ustInput;
            set { if (Set(ref _ustInput, value)) Recalculate(); }
        }

        // --- 5. Pauschale ---
        private string _pauschaleInput; // Anzahl
        public string PauschaleInput
        {
            get => _pauschaleInput;
            set { if (Set(ref _pauschaleInput, value)) Recalculate(); }
        }


        // --- Sätze ---
        public string BeaSatz => "20/10";
        public string GewerbeSatz => "5/10";
        public string UedbSatz => "10/10";
        public string UstSatz => "3/10";

        // --- Ergebnisse ---
        private decimal _beaResult;
        public string BeaResultText => ToEuro(_beaResult);

        private decimal _gewerbeResult;
        public string GewerbeResultText => ToEuro(_gewerbeResult);

        private decimal _uedbResult;
        public string UedbResultText => ToEuro(_uedbResult);

        private decimal _ustResult;
        public string UstResultText => ToEuro(_ustResult);

        private decimal _pauschaleResult;
        public string PauschaleResultText => ToEuro(_pauschaleResult);

        // Summen
        private decimal _summeJahr;
        public string JahresGesamtText => ToEuro(_summeJahr);
        public string MonatsAnteilText => ToEuro(_summeJahr / 12);


        // --- Logik ---
        private decimal ParseInput(string input)
        {
            if (decimal.TryParse(input, NumberStyles.Any, _deCulture, out decimal result))
                return result;
            return 0;
        }

        private void Recalculate()
        {
            _summeJahr = 0;

            // 1. BEA (Beispiel: 1% vom Wert * 2.0)
            decimal valBea = ParseInput(_beaInput);
            _beaResult = (valBea * 0.01m) * 2.0m;
            if (_beaResult < 25) _beaResult = 25;
            _summeJahr += _beaResult;

            // 2. Gewerbe
            decimal valGew = ParseInput(_gewerbeInput);
            _gewerbeResult = (valGew * 0.01m) * 0.5m;
            _summeJahr += _gewerbeResult;

            // 3. Überschuss
            if (IsUeberschussSelected)
            {
                decimal valUedb = ParseInput(_uedbInput);
                _uedbResult = (valUedb * 0.01m) * 1.0m;
                _summeJahr += _uedbResult;
            }
            else
            {
                _uedbResult = 0;
            }

            // 4. USt
            decimal valUst = ParseInput(_ustInput);
            _ustResult = (valUst * 0.01m) * 0.3m;
            _summeJahr += _ustResult;

            // 5. Pauschale
            if (int.TryParse(_pauschaleInput, out int count))
            {
                _pauschaleResult = count * 25m;
            }
            else _pauschaleResult = 0;
            _summeJahr += _pauschaleResult;

            // UI
            OnPropertyChanged(nameof(BeaResultText));
            OnPropertyChanged(nameof(GewerbeResultText));
            OnPropertyChanged(nameof(UedbResultText));
            OnPropertyChanged(nameof(UstResultText));
            OnPropertyChanged(nameof(PauschaleResultText));
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