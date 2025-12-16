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
        private readonly UnternehmensDaten _daten; // Datenfeld für direkten Zugriff

        public LeistungenViewModel()
        {
            _honorarService = new HonorarService();
            _daten = GlobalState.Instance.Daten;

            // Checkbox-Status initial laden
            _fiBu = _daten.HatFiBu;
            _ja = _daten.HatJahresabschluss;
            _lohn = _daten.HatLohn;
            _selbstbucher = _daten.IstSelbstbucher;

            // Commands
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());

            NavigateToFibuCommand = new RelayCommand(_ => NavigateToFibuRequested?.Invoke());
            NavigateToJaCommand = new RelayCommand(_ => NavigateToJaRequested?.Invoke());
            NavigateToLohnCommand = new RelayCommand(_ => NavigateToLohnRequested?.Invoke());

            Recalculate();
        }

        // --- Shell ---
        public string ViewTitle => "Leistungen";
        private decimal _jahresHonorar;
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        // --- Checkbox Logic (Gegenseitiger Ausschluss) ---

        private bool _fiBu;
        public bool FiBu
        {
            get => _fiBu;
            set
            {
                if (Set(ref _fiBu, value))
                {
                    _daten.HatFiBu = value;

                    // Wenn Fibu AN, muss Selbstbucher AUS
                    if (value)
                    {
                        Selbstbucher = false;
                    }
                    Recalculate();
                }
            }
        }

        private bool _selbstbucher;
        public bool Selbstbucher
        {
            get => _selbstbucher;
            set
            {
                if (Set(ref _selbstbucher, value))
                {
                    _daten.IstSelbstbucher = value;

                    // Wenn Selbstbucher AN, muss Fibu AUS
                    if (value)
                    {
                        FiBu = false;
                    }
                    Recalculate();
                }
            }
        }

        private bool _ja;
        public bool JA
        {
            get => _ja;
            set { if (Set(ref _ja, value)) { _daten.HatJahresabschluss = value; Recalculate(); } }
        }

        private bool _lohn;
        public bool Lohn
        {
            get => _lohn;
            set { if (Set(ref _lohn, value)) { _daten.HatLohn = value; Recalculate(); } }
        }

        // --- Anzeige-Werte ---
        public string FiBuMonatlichFormatted { get => _fiBuMonatlichFormatted; private set => Set(ref _fiBuMonatlichFormatted, value); }
        private string _fiBuMonatlichFormatted = "0,00 €";
        public string FiBuJaehrlichFormatted { get => _fiBuJaehrlichFormatted; private set => Set(ref _fiBuJaehrlichFormatted, value); }
        private string _fiBuJaehrlichFormatted = "0,00 €";

        public string JAMonatlichFormatted { get => _jaMonatlichFormatted; private set => Set(ref _jaMonatlichFormatted, value); }
        private string _jaMonatlichFormatted = "0,00 €";
        public string JAJaehrlichFormatted { get => _jaJaehrlichFormatted; private set => Set(ref _jaJaehrlichFormatted, value); }
        private string _jaJaehrlichFormatted = "0,00 €";

        public string LohnMonatlichFormatted { get => _lohnMonatlichFormatted; private set => Set(ref _lohnMonatlichFormatted, value); }
        private string _lohnMonatlichFormatted = "0,00 €";
        public string LohnJaehrlichFormatted { get => _lohnJaehrlichFormatted; private set => Set(ref _lohnJaehrlichFormatted, value); }
        private string _lohnJaehrlichFormatted = "0,00 €";

        // Selbstbucher Spalte
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


        // --- Recalculate Logic ---
        private void Recalculate()
        {
            var werte = GlobalState.Instance.Werte;

            // 1. Footer Gesamt
            var gesamt = _honorarService.BerechneAlles();
            _jahresHonorar = gesamt.JahresHonorar;

            // 2. Einzelwerte für Spalten

            // Fibu
            decimal fibuVal = _daten.HatFiBu ? _honorarService.BerechneFibu(_daten, werte) : 0;
            FiBuMonatlichFormatted = (fibuVal / 12m).ToString("C");
            FiBuJaehrlichFormatted = fibuVal.ToString("C");

            // JA
            decimal jaVal = 0;
            if (_daten.HatJahresabschluss)
            {
                if (_daten.JahresabschlussTyp == "EÜR") jaVal = _honorarService.BerechneEuer(_daten, werte);
                else if (_daten.JahresabschlussTyp == "Bilanz") jaVal = _honorarService.BerechneBilanz(_daten, werte);
            }
            JAMonatlichFormatted = (jaVal / 12m).ToString("C");
            JAJaehrlichFormatted = jaVal.ToString("C");

            // Lohn
            decimal lohnVal = _daten.HatLohn ? _honorarService.BerechneLohn(_daten.AnzahlMitarbeiter, werte) : 0;
            LohnMonatlichFormatted = (lohnVal / 12m).ToString("C");
            LohnJaehrlichFormatted = lohnVal.ToString("C");

            // Selbstbucher (20% auf JA + Lohn, wenn aktiv)
            decimal selbstbucherVal = 0;
            if (_daten.IstSelbstbucher)
            {
                // Hier auch für die Vorschau die gleiche Logik: (JA + Lohn) * 20%
                decimal basis = jaVal + lohnVal;
                selbstbucherVal = basis * 0.20m;
            }
            SelbstbucherMonatlichFormatted = (selbstbucherVal / 12m).ToString("C");
            SelbstbucherJaehrlichFormatted = selbstbucherVal.ToString("C");

            // UI Refresh
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