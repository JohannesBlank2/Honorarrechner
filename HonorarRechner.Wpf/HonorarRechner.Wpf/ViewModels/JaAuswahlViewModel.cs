using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;
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
            _daten = GlobalState.Instance.Daten;
            _honorarService = new HonorarService();

            InitializeFromState();

            // Commands
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenEuerCommand = new RelayCommand(_ => OpenEuerRequested?.Invoke());
            OpenBilanzCommand = new RelayCommand(_ => OpenBilanzRequested?.Invoke());

            // Dummy Commands für Excel (falls Buttons noch da sind)
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            Recalculate();
        }

        private void InitializeFromState()
        {
            // Initialisierung basierend auf GlobalState
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

            // Sub-Typ
            if (_daten.UnternehmensArt == "GESELLSCHAFT")
            {
                _isGesellschaft = true;
                _isEinzelunternehmen = false;
            }
            else
            {
                _isEinzelunternehmen = true;
                _isGesellschaft = false;
            }
        }

        // --- Shell ---
        public string ViewTitle => "Jahresabschluss (JA)";
        private string _jahresHonorarText = "Jahres Honorar: 0,00 €";
        public string JahresHonorarText { get => _jahresHonorarText; set => Set(ref _jahresHonorarText, value); }
        private string _monatsHonorarText = "Monats Honorar: 0,00 €";
        public string MonatsHonorarText { get => _monatsHonorarText; set => Set(ref _monatsHonorarText, value); }

        public ICommand ZurueckCommand { get; }
        public ICommand OpenEuerCommand { get; }
        public ICommand OpenBilanzCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Logik (BUG FIX HIER) ---

        private bool _isEuerSelected;
        public bool IsEuerSelected
        {
            get => _isEuerSelected;
            set
            {
                if (Set(ref _isEuerSelected, value))
                {
                    if (value)
                    {
                        // Nur wenn AKTIViert, ändern wir Daten
                        IsBilanzSelected = false;
                        UpdateJaData("EÜR");
                    }
                    // WICHTIG: Kein 'else' hier! 
                    // Wenn es 'false' wird (z.B. durch Navigation), löschen wir NICHT die Daten.

                    Recalculate();
                }
            }
        }

        private bool _isBilanzSelected;
        public bool IsBilanzSelected
        {
            get => _isBilanzSelected;
            set
            {
                if (Set(ref _isBilanzSelected, value))
                {
                    if (value)
                    {
                        IsEuerSelected = false;
                        UpdateJaData("Bilanz");
                    }
                    // WICHTIG: Kein 'else' hier!

                    Recalculate();
                }
            }
        }

        private void UpdateJaData(string typ)
        {
            _daten.JahresabschlussTyp = typ;
            // Wir setzen HatJahresabschluss IMMER auf true, wenn hier was ausgewählt wird.
            // Das Abwählen passiert nur in der LeistungenView (Checkbox).
            _daten.HatJahresabschluss = true;
        }

        // --- Sub-Typ ---

        private bool _isEinzelunternehmen = true;
        public bool IsEinzelunternehmen
        {
            get => _isEinzelunternehmen;
            set
            {
                if (Set(ref _isEinzelunternehmen, value))
                {
                    if (value)
                    {
                        IsGesellschaft = false;
                        _daten.UnternehmensArt = "EU";
                    }
                    Recalculate();
                }
            }
        }

        private bool _isGesellschaft;
        public bool IsGesellschaft
        {
            get => _isGesellschaft;
            set
            {
                if (Set(ref _isGesellschaft, value))
                {
                    if (value)
                    {
                        IsEinzelunternehmen = false;
                        _daten.UnternehmensArt = "GESELLSCHAFT";
                    }
                    else if (!IsEinzelunternehmen)
                    {
                        // Fallback: Einer muss an sein
                        IsEinzelunternehmen = true;
                    }
                    Recalculate();
                }
            }
        }

        private void Recalculate()
        {
            var ergebnis = _honorarService.BerechneAlles();
            JahresHonorarText = $"Jahres Honorar: {ergebnis.JahresHonorar:C}";
            MonatsHonorarText = $"Monats Honorar: {(ergebnis.JahresHonorar / 12m):C}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private bool Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return true;
        }
    }
}