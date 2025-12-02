using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LohnViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public LohnViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            AnzahlMitarbeiterText = "10";
        }

        // --- Shell Properties ---
        public string ViewTitle => "Lohnbuchhaltung";
        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Data ---
        private int _anzahlMitarbeiter;
        public string AnzahlMitarbeiterText
        {
            get => _anzahlMitarbeiter.ToString();
            set
            {
                _anzahlMitarbeiter = int.TryParse(value, out int result) ? result : 0;
                Recalculate();
                OnPropertyChanged();
                OnPropertyChanged(nameof(CountMa1)); OnPropertyChanged(nameof(CountMa2_9)); OnPropertyChanged(nameof(CountMa10_19));
                OnPropertyChanged(nameof(CountMa20_49)); OnPropertyChanged(nameof(CountMa50_100)); OnPropertyChanged(nameof(CountMa101Plus));
                OnPropertyChanged(nameof(SumMa1)); OnPropertyChanged(nameof(SumMa2_9)); OnPropertyChanged(nameof(SumMa10_19));
                OnPropertyChanged(nameof(SumMa20_49)); OnPropertyChanged(nameof(SumMa50_100)); OnPropertyChanged(nameof(SumMa101Plus));
                OnPropertyChanged(nameof(PreisMa101PlusText)); OnPropertyChanged(nameof(ZwischenSummeMonat)); OnPropertyChanged(nameof(ZwischenSummeJahr));
            }
        }

        private string ToEuro(decimal value) => value.ToString("C", _deCulture);
        public decimal PreisMa1_Base => 42.00m; public string PreisMa1_Text => ToEuro(PreisMa1_Base);
        public decimal PreisMa2_9_Base => 30.00m; public string PreisMa2_9_Text => ToEuro(PreisMa2_9_Base);
        public decimal PreisMa10_19_Base => 24.00m; public string PreisMa10_19_Text => ToEuro(PreisMa10_19_Base);
        public decimal PreisMa20_49_Base => 22.00m; public string PreisMa20_49_Text => ToEuro(PreisMa20_49_Base);
        public decimal PreisMa50_100_Base => 20.00m; public string PreisMa50_100_Text => ToEuro(PreisMa50_100_Base);
        private decimal _preisMa101PlusDynamic; public string PreisMa101PlusText => ToEuro(_preisMa101PlusDynamic);

        public int CountMa1 { get; private set; }
        public int CountMa2_9 { get; private set; }
        public int CountMa10_19 { get; private set; }
        public int CountMa20_49 { get; private set; }
        public int CountMa50_100 { get; private set; }
        public int CountMa101Plus { get; private set; }

        public string SumMa1 => ToEuro(CountMa1 * PreisMa1_Base);
        public string SumMa2_9 => ToEuro(CountMa2_9 * PreisMa2_9_Base);
        public string SumMa10_19 => ToEuro(CountMa10_19 * PreisMa10_19_Base);
        public string SumMa20_49 => ToEuro(CountMa20_49 * PreisMa20_49_Base);
        public string SumMa50_100 => ToEuro(CountMa50_100 * PreisMa50_100_Base);
        private decimal _sumMa101PlusValue; public string SumMa101Plus => ToEuro(_sumMa101PlusValue);

        private decimal _zwischenSummeMonatValue;
        public string ZwischenSummeMonat => ToEuro(_zwischenSummeMonatValue);
        public string ZwischenSummeJahr => ToEuro(_zwischenSummeMonatValue * 12);

        private void Recalculate()
        {
            int rest = _anzahlMitarbeiter;
            CountMa1 = rest > 0 ? 1 : 0; rest -= CountMa1;
            CountMa2_9 = Math.Min(rest, 8); rest -= CountMa2_9;
            CountMa10_19 = Math.Min(rest, 10); rest -= CountMa10_19;
            CountMa20_49 = Math.Min(rest, 30); rest -= CountMa20_49;
            CountMa50_100 = Math.Min(rest, 51); rest -= CountMa50_100;
            CountMa101Plus = Math.Max(0, rest);

            decimal total = (CountMa1 * PreisMa1_Base) + (CountMa2_9 * PreisMa2_9_Base) + (CountMa10_19 * PreisMa10_19_Base) + (CountMa20_49 * PreisMa20_49_Base) + (CountMa50_100 * PreisMa50_100_Base);

            if (CountMa101Plus > 0)
            {
                decimal rabatt = (decimal)((_anzahlMitarbeiter - 100) * 0.1);
                _preisMa101PlusDynamic = Math.Max(20m - rabatt, 15m);
                _sumMa101PlusValue = CountMa101Plus * _preisMa101PlusDynamic;
                total += _sumMa101PlusValue;
            }
            else { _preisMa101PlusDynamic = 0m; _sumMa101PlusValue = 0m; }

            _zwischenSummeMonatValue = total;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}