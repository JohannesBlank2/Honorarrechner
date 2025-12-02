using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LohnViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        // WICHTIG: Erzwingt deutsche Formatierung (Euro, Komma statt Punkt)
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public LohnViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Startwert
            AnzahlMitarbeiterText = "10";
        }

        // Helfer für Euro-Formatierung
        private string ToEuro(decimal value) => value.ToString("C", _deCulture);

        #region Eingaben

        private int _anzahlMitarbeiter;
        public string AnzahlMitarbeiterText
        {
            get => _anzahlMitarbeiter.ToString();
            set
            {
                if (int.TryParse(value, out int result))
                {
                    _anzahlMitarbeiter = result;
                }
                else
                {
                    _anzahlMitarbeiter = 0;
                }

                Recalculate();
                OnPropertyChanged();

                // Alle UI-Werte aktualisieren
                OnPropertyChanged(nameof(CountMa1));
                OnPropertyChanged(nameof(CountMa2_9));
                OnPropertyChanged(nameof(CountMa10_19));
                OnPropertyChanged(nameof(CountMa20_49));
                OnPropertyChanged(nameof(CountMa50_100));
                OnPropertyChanged(nameof(CountMa101Plus));

                OnPropertyChanged(nameof(SumMa1));
                OnPropertyChanged(nameof(SumMa2_9));
                OnPropertyChanged(nameof(SumMa10_19));
                OnPropertyChanged(nameof(SumMa20_49));
                OnPropertyChanged(nameof(SumMa50_100));
                OnPropertyChanged(nameof(SumMa101Plus));

                OnPropertyChanged(nameof(PreisMa101PlusText));

                OnPropertyChanged(nameof(ZwischenSummeMonat));
                OnPropertyChanged(nameof(ZwischenSummeJahr));
            }
        }

        #endregion

        #region Preise (Logik & Anzeige)

        // Basis-Preise (Logik)
        public decimal PreisMa1_Base => 42.00m;
        public decimal PreisMa2_9_Base => 30.00m;
        public decimal PreisMa10_19_Base => 24.00m;
        public decimal PreisMa20_49_Base => 22.00m;
        public decimal PreisMa50_100_Base => 20.00m;

        // Formatierte Preise für die Anzeige (damit im XAML kein Dollar auftaucht)
        public string PreisMa1_Text => ToEuro(PreisMa1_Base);
        public string PreisMa2_9_Text => ToEuro(PreisMa2_9_Base);
        public string PreisMa10_19_Text => ToEuro(PreisMa10_19_Base);
        public string PreisMa20_49_Text => ToEuro(PreisMa20_49_Base);
        public string PreisMa50_100_Text => ToEuro(PreisMa50_100_Base);

        // Dynamischer Preis für 101+
        private decimal _preisMa101PlusDynamic;
        public string PreisMa101PlusText => ToEuro(_preisMa101PlusDynamic);

        #endregion

        #region Berechnete Properties für die View

        // --- Anzahl pro Staffel ---
        public int CountMa1 { get; private set; }
        public int CountMa2_9 { get; private set; }
        public int CountMa10_19 { get; private set; }
        public int CountMa20_49 { get; private set; }
        public int CountMa50_100 { get; private set; }
        public int CountMa101Plus { get; private set; }

        // --- Summen pro Staffel (Formatiert in Euro) ---
        public string SumMa1 => ToEuro(CountMa1 * PreisMa1_Base);
        public string SumMa2_9 => ToEuro(CountMa2_9 * PreisMa2_9_Base);
        public string SumMa10_19 => ToEuro(CountMa10_19 * PreisMa10_19_Base);
        public string SumMa20_49 => ToEuro(CountMa20_49 * PreisMa20_49_Base);
        public string SumMa50_100 => ToEuro(CountMa50_100 * PreisMa50_100_Base);

        private decimal _sumMa101PlusValue;
        public string SumMa101Plus => ToEuro(_sumMa101PlusValue);

        // --- Gesamtsummen ---
        private decimal _zwischenSummeMonatValue;
        public string ZwischenSummeMonat => ToEuro(_zwischenSummeMonatValue);
        public string ZwischenSummeJahr => ToEuro(_zwischenSummeMonatValue * 12);

        #endregion

        #region Logik

        private void Recalculate()
        {
            int rest = _anzahlMitarbeiter;

            // Staffel-Logik
            CountMa1 = rest > 0 ? 1 : 0;
            rest -= CountMa1;

            CountMa2_9 = Math.Min(rest, 8);
            rest -= CountMa2_9;

            CountMa10_19 = Math.Min(rest, 10);
            rest -= CountMa10_19;

            CountMa20_49 = Math.Min(rest, 30);
            rest -= CountMa20_49;

            CountMa50_100 = Math.Min(rest, 51);
            rest -= CountMa50_100;

            CountMa101Plus = Math.Max(0, rest);

            // Summen berechnen
            decimal total = 0;
            total += CountMa1 * PreisMa1_Base;
            total += CountMa2_9 * PreisMa2_9_Base;
            total += CountMa10_19 * PreisMa10_19_Base;
            total += CountMa20_49 * PreisMa20_49_Base;
            total += CountMa50_100 * PreisMa50_100_Base;

            // Spezial-Logik 101+
            if (CountMa101Plus > 0)
            {
                decimal rabatt = (decimal)((_anzahlMitarbeiter - 100) * 0.1);
                _preisMa101PlusDynamic = Math.Max(20m - rabatt, 15m);

                _sumMa101PlusValue = CountMa101Plus * _preisMa101PlusDynamic;
                total += _sumMa101PlusValue;
            }
            else
            {
                _preisMa101PlusDynamic = 0m;
                _sumMa101PlusValue = 0m;
            }

            _zwischenSummeMonatValue = total;
        }

        #endregion

        public ICommand ZurueckCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}