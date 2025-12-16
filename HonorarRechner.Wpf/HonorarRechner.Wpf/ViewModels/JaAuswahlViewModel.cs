using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services; // Wichtig: Damit wir rechnen können
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class JaAuswahlViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? OpenEuerRequested;
        public event Action? OpenBilanzRequested;

        private readonly UnternehmensDaten _daten;
        private readonly HonorarService _honorarService;

        public JaAuswahlViewModel()
        {
            // 1. Zugriff auf GlobalState und Service
            _daten = GlobalState.Instance.Daten;
            _honorarService = new HonorarService();

            // 2. Den alten Zustand (Häkchen) wiederherstellen
            InitializeFromState();

            // Commands
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenEuerCommand = new RelayCommand(_ => OpenEuerRequested?.Invoke());
            OpenBilanzCommand = new RelayCommand(_ => OpenBilanzRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            // 3. SOFORT beim Start einmal rechnen, damit unten nicht 0 steht
            Recalculate();
        }

        private void InitializeFromState()
        {
            // JA Typ wiederherstellen
            if (_daten.JahresabschlussTyp == "EÜR")
            {
                _isEuerSelected = true;
                _isBilanzSelected = false;
            }
            else if (_daten.JahresabschlussTyp == "Bilanz")
            {
                _isBilanzSelected = true;
                _isEuerSelected = false;
            }

            // Unternehmensart wiederherstellen
            if (_daten.UnternehmensArt == "GESELLSCHAFT")
            {
                _isGesellschaft = true;
                _isEinzelunternehmen = false;
            }
            else
            {
                // Standard: Einzelunternehmen
                _isEinzelunternehmen = true;
                _isGesellschaft = false;
            }
        }

        // --- Shell Properties (Die Anzeige unten im Fenster) ---
        public string ViewTitle => "Jahresabschluss (JA)";

        private string _jahresHonorarText = "Jahres Honorar: 0,00 €";
        public string JahresHonorarText
        {
            get => _jahresHonorarText;
            set => SetProperty(ref _jahresHonorarText, value);
        }

        private string _monatsHonorarText = "Monats Honorar: 0,00 €";
        public string MonatsHonorarText
        {
            get => _monatsHonorarText;
            set => SetProperty(ref _monatsHonorarText, value);
        }

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenEuerCommand { get; }
        public ICommand OpenBilanzCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Logik & Properties ---

        private bool _isEuerSelected;
        public bool IsEuerSelected
        {
            get => _isEuerSelected;
            set
            {
                if (value == _isEuerSelected) return;
                _isEuerSelected = value;
                OnPropertyChanged();

                if (value)
                {
                    IsBilanzSelected = false;
                    UpdateJaData("EÜR");
                }
                else if (!IsBilanzSelected)
                {
                    UpdateJaData("NIX");
                }
                Recalculate();
            }
        }

        private bool _isBilanzSelected;
        public bool IsBilanzSelected
        {
            get => _isBilanzSelected;
            set
            {
                if (value == _isBilanzSelected) return;
                _isBilanzSelected = value;
                OnPropertyChanged();

                if (value)
                {
                    IsEuerSelected = false;
                    UpdateJaData("Bilanz");
                }
                else if (!IsEuerSelected)
                {
                    UpdateJaData("NIX");
                }
                Recalculate();
            }
        }

        private void UpdateJaData(string typ)
        {
            _daten.JahresabschlussTyp = typ;
            _daten.HatJahresabschluss = (typ != "NIX");
        }

        private bool _isEinzelunternehmen = true;
        public bool IsEinzelunternehmen
        {
            get => _isEinzelunternehmen;
            set
            {
                if (value == _isEinzelunternehmen) return;
                _isEinzelunternehmen = value;
                OnPropertyChanged();

                if (value)
                {
                    IsGesellschaft = false;
                    _daten.UnternehmensArt = "EU";
                }
                Recalculate();
            }
        }

        private bool _isGesellschaft;
        public bool IsGesellschaft
        {
            get => _isGesellschaft;
            set
            {
                if (value == _isGesellschaft) return;
                _isGesellschaft = value;
                OnPropertyChanged();

                if (value)
                {
                    IsEinzelunternehmen = false;
                    _daten.UnternehmensArt = "GESELLSCHAFT";
                }
                else if (!IsEinzelunternehmen)
                {
                    // Darf nicht beides aus sein -> Fallback auf EU
                    IsEinzelunternehmen = true;
                }
                Recalculate();
            }
        }

        // --- BERECHNUNG ---
        private void Recalculate()
        {
            // Hier nutzen wir jetzt den zentralen Service, der ALLES zusammenrechnet
            var ergebnis = _honorarService.BerechneAlles();

            // Texte updaten
            JahresHonorarText = $"Jahres Honorar: {ergebnis.JahresHonorar:C}";
            MonatsHonorarText = $"Monats Honorar: {(ergebnis.JahresHonorar / 12m):C}";
        }

        // --- Helper ---
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }
    }
}