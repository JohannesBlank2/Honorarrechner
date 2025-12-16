using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LeistungenViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;
        public event Action? NavigateToFibuRequested;
        public event Action? NavigateToJaRequested;
        public event Action? NavigateToLohnRequested;

        private readonly HonorarService _honorarService;

        public LeistungenViewModel()
        {
            _honorarService = new HonorarService();
            var d = GlobalState.Instance.Daten;

            // Checkbox-Status laden
            _fiBu = d.HatFiBu;
            _ja = d.HatJahresabschluss;
            _lohn = d.HatLohn;
            _selbstbucher = d.IstSelbstbucher;

            // Commands initialisieren
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());

            NavigateToFibuCommand = new RelayCommand(_ => NavigateToFibuRequested?.Invoke());
            NavigateToJaCommand = new RelayCommand(_ => NavigateToJaRequested?.Invoke());
            NavigateToLohnCommand = new RelayCommand(_ => NavigateToLohnRequested?.Invoke());

            // Sofort rechnen
            Recalculate();
        }

        // --- Shell Header/Footer ---
        public string ViewTitle => "Leistungen";

        private decimal _jahresHonorar;
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        // --- Checkbox Properties ---
        private bool _fiBu;
        public bool FiBu
        {
            get => _fiBu;
            set { if (Set(ref _fiBu, value)) { GlobalState.Instance.Daten.HatFiBu = value; Recalculate(); } }
        }

        private bool _ja;
        public bool JA
        {
            get => _ja;
            set { if (Set(ref _ja, value)) { GlobalState.Instance.Daten.HatJahresabschluss = value; Recalculate(); } }
        }

        private bool _lohn;
        public bool Lohn
        {
            get => _lohn;
            set { if (Set(ref _lohn, value)) { GlobalState.Instance.Daten.HatLohn = value; Recalculate(); } }
        }

        private bool _selbstbucher;
        public bool Selbstbucher
        {
            get => _selbstbucher;
            set { if (Set(ref _selbstbucher, value)) { GlobalState.Instance.Daten.IstSelbstbucher = value; Recalculate(); } }
        }

        // --- Anzeige-Werte (Spalten) ---
        // FiBu
        public string FiBuMonatlichFormatted { get => _fiBuMonatlichFormatted; private set => Set(ref _fiBuMonatlichFormatted, value); }
        private string _fiBuMonatlichFormatted = "0,00 €";

        public string FiBuJaehrlichFormatted { get => _fiBuJaehrlichFormatted; private set => Set(ref _fiBuJaehrlichFormatted, value); }
        private string _fiBuJaehrlichFormatted = "0,00 €";

        // JA (Jahresabschluss)
        public string JAMonatlichFormatted { get => _jaMonatlichFormatted; private set => Set(ref _jaMonatlichFormatted, value); }
        private string _jaMonatlichFormatted = "0,00 €";

        public string JAJaehrlichFormatted { get => _jaJaehrlichFormatted; private set => Set(ref _jaJaehrlichFormatted, value); }
        private string _jaJaehrlichFormatted = "0,00 €";

        // Lohn
        public string LohnMonatlichFormatted { get => _lohnMonatlichFormatted; private set => Set(ref _lohnMonatlichFormatted, value); }
        private string _lohnMonatlichFormatted = "0,00 €";

        public string LohnJaehrlichFormatted { get => _lohnJaehrlichFormatted; private set => Set(ref _lohnJaehrlichFormatted, value); }
        private string _lohnJaehrlichFormatted = "0,00 €";

        // Selbstbucher (+20% auf JA)
        public string SelbstbucherMonatlichFormatted { get => _selbstbucherMonatlichFormatted; private set => Set(ref _selbstbucherMonatlichFormatted, value); }
        private string _selbstbucherMonatlichFormatted = "0,00 €";

        public string SelbstbucherJaehrlichFormatted { get => _selbstbucherJaehrlichFormatted; private set => Set(ref _selbstbucherJaehrlichFormatted, value); }
        private string _selbstbucherJaehrlichFormatted = "0,00 €";


        // --- Commands ---
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }
        public ICommand NavigateToFibuCommand { get; }
        public ICommand NavigateToJaCommand { get; }
        public ICommand NavigateToLohnCommand { get; }


        // --- Logik ---
        private void Recalculate()
        {
            var daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;

            // 1. Gesamtsumme (Footer)
            var gesamt = _honorarService.BerechneAlles();
            _jahresHonorar = gesamt.JahresHonorar;

            // 2. Vorschau-Werte (Spalten)

            // --- FiBu ---
            decimal fibuVal = _honorarService.BerechneFibu(daten, werte);
            FiBuMonatlichFormatted = (fibuVal / 12m).ToString("C");
            FiBuJaehrlichFormatted = fibuVal.ToString("C");

            // --- JA Vorschau (FIX HIER) ---
            decimal jaVal = 0;

            // Wir prüfen strikt den Typ, anstatt zu raten.
            if (daten.JahresabschlussTyp == "EÜR")
            {
                jaVal = _honorarService.BerechneEuer(daten, werte);
            }
            else if (daten.JahresabschlussTyp == "Bilanz")
            {
                // Jetzt wird explizit die Bilanz berechnet, wenn Bilanz ausgewählt ist.
                jaVal = _honorarService.BerechneBilanz(daten, werte);
            }
            // Wenn "NIX" gewählt ist, bleibt es 0.

            JAMonatlichFormatted = (jaVal / 12m).ToString("C");
            JAJaehrlichFormatted = jaVal.ToString("C");

            // --- Lohn ---
            decimal lohnVal = _honorarService.BerechneLohn(daten.AnzahlMitarbeiter, werte);
            LohnMonatlichFormatted = (lohnVal / 12m).ToString("C");
            LohnJaehrlichFormatted = lohnVal.ToString("C");

            // --- Selbstbucher ---
            decimal selbstbucherVal = 0;
            if (jaVal > 0)
            {
                selbstbucherVal = jaVal * 0.20m;
            }
            SelbstbucherMonatlichFormatted = (selbstbucherVal / 12m).ToString("C");
            SelbstbucherJaehrlichFormatted = selbstbucherVal.ToString("C");

            // UI Refresh für Footer
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private bool Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}