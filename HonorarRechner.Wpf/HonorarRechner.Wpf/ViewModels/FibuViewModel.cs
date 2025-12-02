using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class FibuViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public FibuViewModel()
        {
            // Commands initialisieren
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            // Standardwerte
            _umsatz = 50000m;
            _satzText = "7/10";
            _itPauschale = 40m;
            _auslagenPauschaleProzent = 20;
            Recalculate();
        }

        // --- Shell Properties ---
        public string ViewTitle => "FiBu - Finanzbuchhaltung";
        // Platzhalter für Gesamtsumme
        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null; // Kein Weiter-Button in Detail-Ansicht

        // --- Logic ---
        private decimal _umsatz;
        public string UmsatzText
        {
            get => _umsatz.ToString("N2");
            set
            {
                string cleanInput = value.Replace("€", "").Replace(".", "").Trim();
                if (decimal.TryParse(cleanInput, out decimal result))
                {
                    _umsatz = result;
                    Recalculate();
                    OnPropertyChanged();
                }
            }
        }

        private string _satzText;
        public string SatzText { get => _satzText; set { _satzText = value; OnPropertyChanged(); } }

        private decimal _laufendeFibuMonatlich;
        public string LaufendeFibuMonatlich => $"{_laufendeFibuMonatlich:C}";

        private decimal _itPauschale;
        public string ItPauschaleText => $"{_itPauschale:C}";

        private decimal _auslagenPauschaleProzent;
        public string AuslagenPauschaleProzentText => $"{_auslagenPauschaleProzent} %";

        private decimal _auslagenPauschaleWert;
        public string AuslagenPauschaleWert => $"{_auslagenPauschaleWert:C}";

        private decimal _zwischenSummeMonat;
        public string ZwischenSummeMonat => $"{_zwischenSummeMonat:C}";

        private decimal _zwischenSummeJahr;
        public string ZwischenSummeJahr => $"{_zwischenSummeJahr:C}";

        private void Recalculate()
        {
            decimal grundgebuehr = 138m;
            decimal satzFaktor = 0.7m;
            _laufendeFibuMonatlich = _umsatz > 0 ? (_umsatz / 1000m) * 2.5m + (grundgebuehr * satzFaktor) : 0;
            _auslagenPauschaleWert = _laufendeFibuMonatlich * (_auslagenPauschaleProzent / 100m);
            _zwischenSummeMonat = _laufendeFibuMonatlich + _itPauschale + _auslagenPauschaleWert;
            if (_zwischenSummeMonat < 208m && _zwischenSummeMonat > 0) _zwischenSummeMonat = 208m;
            _zwischenSummeJahr = _zwischenSummeMonat * 12;

            OnPropertyChanged(nameof(LaufendeFibuMonatlich));
            OnPropertyChanged(nameof(ItPauschaleText));
            OnPropertyChanged(nameof(AuslagenPauschaleWert));
            OnPropertyChanged(nameof(ZwischenSummeMonat));
            OnPropertyChanged(nameof(ZwischenSummeJahr));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}