using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class EuerViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public EuerViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            _beaInput = "50000"; _gewerbeInput = "50000"; _uedbInput = "50000"; _ustInput = "50000"; _pauschaleInput = "1";
            Recalculate();
        }

        // --- Shell Properties ---
        public string ViewTitle => "EÜR";
        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Data ---
        private string ToEuro(decimal value) => value.ToString("C", _deCulture);
        private decimal ParseInput(string input) => decimal.TryParse(input, NumberStyles.Any, _deCulture, out decimal result) ? result : 0;

        private string _beaInput; public string BeaInput { get => _beaInput; set { if (Set(ref _beaInput, value)) Recalculate(); } }
        private string _gewerbeInput; public string GewerbeInput { get => _gewerbeInput; set { if (Set(ref _gewerbeInput, value)) Recalculate(); } }
        private bool _isUeberschussSelected; public bool IsUeberschussSelected { get => _isUeberschussSelected; set { if (Set(ref _isUeberschussSelected, value)) Recalculate(); } }
        private string _uedbInput; public string UedbInput { get => _uedbInput; set { if (Set(ref _uedbInput, value)) Recalculate(); } }
        private string _ustInput; public string UstInput { get => _ustInput; set { if (Set(ref _ustInput, value)) Recalculate(); } }
        private string _pauschaleInput; public string PauschaleInput { get => _pauschaleInput; set { if (Set(ref _pauschaleInput, value)) Recalculate(); } }

        public string BeaSatz => "20/10";
        public string GewerbeSatz => "5/10";
        public string UedbSatz => "10/10";
        public string UstSatz => "3/10";

        private decimal _beaResult; public string BeaResultText => ToEuro(_beaResult);
        private decimal _gewerbeResult; public string GewerbeResultText => ToEuro(_gewerbeResult);
        private decimal _uedbResult; public string UedbResultText => ToEuro(_uedbResult);
        private decimal _ustResult; public string UstResultText => ToEuro(_ustResult);
        private decimal _pauschaleResult; public string PauschaleResultText => ToEuro(_pauschaleResult);

        private decimal _summeJahr;
        public string JahresGesamtText => ToEuro(_summeJahr);
        public string MonatsAnteilText => ToEuro(_summeJahr / 12);

        private void Recalculate()
        {
            _summeJahr = 0;
            _beaResult = Math.Max(25, (ParseInput(_beaInput) * 0.01m) * 2.0m); _summeJahr += _beaResult;
            _gewerbeResult = (ParseInput(_gewerbeInput) * 0.01m) * 0.5m; _summeJahr += _gewerbeResult;
            if (IsUeberschussSelected) { _uedbResult = (ParseInput(_uedbInput) * 0.01m) * 1.0m; _summeJahr += _uedbResult; } else _uedbResult = 0;
            _ustResult = (ParseInput(_ustInput) * 0.01m) * 0.3m; _summeJahr += _ustResult;
            _pauschaleResult = (int.TryParse(_pauschaleInput, out int c) ? c : 0) * 25m; _summeJahr += _pauschaleResult;

            OnPropertyChanged(nameof(BeaResultText)); OnPropertyChanged(nameof(GewerbeResultText)); OnPropertyChanged(nameof(UedbResultText));
            OnPropertyChanged(nameof(UstResultText)); OnPropertyChanged(nameof(PauschaleResultText)); OnPropertyChanged(nameof(JahresGesamtText)); OnPropertyChanged(nameof(MonatsAnteilText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private bool Set<T>(ref T field, T value, [CallerMemberName] string? name = null) { if (Equals(field, value)) return false; field = value; OnPropertyChanged(name); return true; }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}