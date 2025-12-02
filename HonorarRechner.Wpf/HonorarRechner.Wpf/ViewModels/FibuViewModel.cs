using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class FibuViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public FibuViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Initialwerte (Platzhalter, bis echte Datenanbindung steht)
            _umsatz = 50000m;
            _satzText = "7/10";
            _itPauschale = 40m;
            _auslagenPauschaleProzent = 20; // 20%

            Recalculate();
        }

        #region Properties

        private decimal _umsatz;
        public string UmsatzText
        {
            get => _umsatz.ToString("N2");
            set
            {
                // Entfernt Währungssymbole und Tausendertrennzeichen für das Parsing
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
        public string SatzText
        {
            get => _satzText;
            set { _satzText = value; OnPropertyChanged(); }
        }

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

        #endregion

        #region Logik

        private void Recalculate()
        {
            // --- Beispiel-Logik (Simulation der Form1-Logik) ---

            // 1. Laufende Fibu Basis berechnen
            // Hier würde normalerweise der Gebührenrechner aufgerufen werden.
            // Vereinfacht: 
            decimal grundgebuehr = 138m; // Beispielwert
            decimal satzFaktor = 0.7m;   // 7/10

            // Einfache Skalierungssimulation für die Anzeige
            if (_umsatz > 0)
                _laufendeFibuMonatlich = (_umsatz / 1000m) * 2.5m + (grundgebuehr * satzFaktor);
            else
                _laufendeFibuMonatlich = 0;

            // 2. Auslagen
            _auslagenPauschaleWert = _laufendeFibuMonatlich * (_auslagenPauschaleProzent / 100m);

            // 3. Summen
            _zwischenSummeMonat = _laufendeFibuMonatlich + _itPauschale + _auslagenPauschaleWert;

            // Mindestgebühr Check (208 € aus Form1)
            if (_zwischenSummeMonat < 208m && _zwischenSummeMonat > 0)
                _zwischenSummeMonat = 208m;

            _zwischenSummeJahr = _zwischenSummeMonat * 12;

            // Alle betroffenen Properties aktualisieren
            OnPropertyChanged(nameof(LaufendeFibuMonatlich));
            OnPropertyChanged(nameof(ItPauschaleText));
            OnPropertyChanged(nameof(AuslagenPauschaleWert));
            OnPropertyChanged(nameof(ZwischenSummeMonat));
            OnPropertyChanged(nameof(ZwischenSummeJahr));
        }

        #endregion

        public ICommand ZurueckCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}