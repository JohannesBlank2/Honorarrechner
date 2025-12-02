using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LohnViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly HonorarService _honorarService;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public LohnViewModel()
        {
            _honorarService = new HonorarService();
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            // 1. Laden beim Start
            LoadData();

            // 2. WICHTIG: Wenn sich Daten im GlobalState ändern (z.B. in UnternehmensView), hier neu laden!
            GlobalState.Instance.DataChanged += LoadData;
        }

        public string ViewTitle => "Lohnbuchhaltung";
        private decimal _jahresHonorar;
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // Keine Setter mehr hier -> Daten kommen aus GlobalState
        private int _anzahlMitarbeiter;
        public string AnzahlMitarbeiterText { get => _anzahlMitarbeiter.ToString(); }

        public int CountMa1 { get; private set; }
        public string PreisMa1_Text { get; private set; } = "0,00 €";
        public string SumMa1 { get; private set; } = "0,00 €";

        public int CountMa2_9 { get; private set; }
        public string PreisMa2_9_Text { get; private set; } = "0,00 €";
        public string SumMa2_9 { get; private set; } = "0,00 €";

        public int CountMa10_19 { get; private set; }
        public string PreisMa10_19_Text { get; private set; } = "0,00 €";
        public string SumMa10_19 { get; private set; } = "0,00 €";

        public int CountMa20_49 { get; private set; }
        public string PreisMa20_49_Text { get; private set; } = "0,00 €";
        public string SumMa20_49 { get; private set; } = "0,00 €";

        public int CountMa50_100 { get; private set; }
        public string PreisMa50_100_Text { get; private set; } = "0,00 €";
        public string SumMa50_100 { get; private set; } = "0,00 €";

        public int CountMa101Plus { get; private set; }
        public string PreisMa101PlusText { get; private set; } = "0,00 €";
        public string SumMa101Plus { get; private set; } = "0,00 €";

        public string ZwischenSummeMonat { get; private set; } = "0,00 €";
        public string ZwischenSummeJahr { get; private set; } = "0,00 €";

        private void LoadData()
        {
            var daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;

            // Anzahl holen
            _anzahlMitarbeiter = daten.AnzahlMitarbeiter;
            OnPropertyChanged(nameof(AnzahlMitarbeiterText));

            // Footer holen
            var gesamt = _honorarService.BerechneAlles();
            _jahresHonorar = gesamt.JahresHonorar;
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));

            // Details berechnen
            var details = _honorarService.BerechneLohnDetails(_anzahlMitarbeiter, werte);

            CountMa1 = details.Count1;
            PreisMa1_Text = ToEuro(details.Preis1);
            SumMa1 = ToEuro(details.Sum1);

            CountMa2_9 = details.Count2_9;
            PreisMa2_9_Text = ToEuro(details.Preis2_9);
            SumMa2_9 = ToEuro(details.Sum2_9);

            CountMa10_19 = details.Count10_19;
            PreisMa10_19_Text = ToEuro(details.Preis10_19);
            SumMa10_19 = ToEuro(details.Sum10_19);

            CountMa20_49 = details.Count20_49;
            PreisMa20_49_Text = ToEuro(details.Preis20_49);
            SumMa20_49 = ToEuro(details.Sum20_49);

            CountMa50_100 = details.Count50_100;
            PreisMa50_100_Text = ToEuro(details.Preis50_100);
            SumMa50_100 = ToEuro(details.Sum50_100);

            CountMa101Plus = details.Count101Plus;
            PreisMa101PlusText = ToEuro(details.Preis101Plus);
            SumMa101Plus = ToEuro(details.Sum101Plus);

            ZwischenSummeMonat = ToEuro(details.MonatGesamt);
            ZwischenSummeJahr = ToEuro(details.JahrGesamt);

            // Alles updaten
            OnPropertyChanged(nameof(CountMa1)); OnPropertyChanged(nameof(PreisMa1_Text)); OnPropertyChanged(nameof(SumMa1));
            OnPropertyChanged(nameof(CountMa2_9)); OnPropertyChanged(nameof(PreisMa2_9_Text)); OnPropertyChanged(nameof(SumMa2_9));
            OnPropertyChanged(nameof(CountMa10_19)); OnPropertyChanged(nameof(PreisMa10_19_Text)); OnPropertyChanged(nameof(SumMa10_19));
            OnPropertyChanged(nameof(CountMa20_49)); OnPropertyChanged(nameof(PreisMa20_49_Text)); OnPropertyChanged(nameof(SumMa20_49));
            OnPropertyChanged(nameof(CountMa50_100)); OnPropertyChanged(nameof(PreisMa50_100_Text)); OnPropertyChanged(nameof(SumMa50_100));
            OnPropertyChanged(nameof(CountMa101Plus)); OnPropertyChanged(nameof(PreisMa101PlusText)); OnPropertyChanged(nameof(SumMa101Plus));
            OnPropertyChanged(nameof(ZwischenSummeMonat)); OnPropertyChanged(nameof(ZwischenSummeJahr));
        }

        private string ToEuro(decimal d) => d.ToString("C", _deCulture);

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}