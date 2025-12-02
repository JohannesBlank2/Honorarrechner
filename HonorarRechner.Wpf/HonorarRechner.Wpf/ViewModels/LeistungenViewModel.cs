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

            // Lade den aktuellen Status aus dem GlobalState
            var d = GlobalState.Instance.Daten;
            _fiBu = d.HatFiBu;
            _ja = d.HatJahresabschluss;
            _lohn = d.HatLohn;
            _selbstbucher = d.IstSelbstbucher;

            // Commands
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());

            NavigateToFibuCommand = new RelayCommand(_ => NavigateToFibuRequested?.Invoke());
            NavigateToJaCommand = new RelayCommand(_ => NavigateToJaRequested?.Invoke());
            NavigateToLohnCommand = new RelayCommand(_ => NavigateToLohnRequested?.Invoke());

            // Sofort rechnen, damit die Anzeige stimmt
            Recalculate();
        }

        // --- Shell ---
        public string ViewTitle => "Leistungen";
        private decimal _jahresHonorar;
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        // --- Commands ---
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }
        public ICommand NavigateToFibuCommand { get; }
        public ICommand NavigateToJaCommand { get; }
        public ICommand NavigateToLohnCommand { get; }

        // --- Properties mit Logik ---
        private bool _fiBu;
        public bool FiBu
        {
            get => _fiBu;
            set
            {
                if (Set(ref _fiBu, value))
                {
                    GlobalState.Instance.Daten.HatFiBu = value;
                    Recalculate();
                }
            }
        }

        private bool _ja;
        public bool JA
        {
            get => _ja;
            set
            {
                if (Set(ref _ja, value))
                {
                    GlobalState.Instance.Daten.HatJahresabschluss = value;
                    Recalculate();
                }
            }
        }

        private bool _lohn;
        public bool Lohn
        {
            get => _lohn;
            set
            {
                if (Set(ref _lohn, value))
                {
                    GlobalState.Instance.Daten.HatLohn = value;
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
                    GlobalState.Instance.Daten.IstSelbstbucher = value;
                    Recalculate();
                }
            }
        }

        // --- Anzeige-Werte (Detailbeträge) ---
        private string _fiBuMonatlichFormatted = "0,00 €";
        public string FiBuMonatlichFormatted { get => _fiBuMonatlichFormatted; private set => Set(ref _fiBuMonatlichFormatted, value); }

        private string _fiBuJaehrlichFormatted = "0,00 €";
        public string FiBuJaehrlichFormatted { get => _fiBuJaehrlichFormatted; private set => Set(ref _fiBuJaehrlichFormatted, value); }

        // (Hier analog für JA und Lohn Properties hinzufügen, falls du sie einzeln anzeigen willst)
        // Ich lasse die anderen der Kürze halber weg, das Prinzip ist gleich: Property anlegen -> im Recalculate setzen.

        private void Recalculate()
        {
            var erg = _honorarService.BerechneAlles();

            _jahresHonorar = erg.JahresHonorar;

            // Einzelwerte aktualisieren
            FiBuMonatlichFormatted = (erg.FiBuBeitrag / 12m).ToString("C");
            FiBuJaehrlichFormatted = erg.FiBuBeitrag.ToString("C");

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