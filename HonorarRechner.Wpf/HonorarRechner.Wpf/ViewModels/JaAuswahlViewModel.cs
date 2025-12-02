using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class JaAuswahlViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? OpenEuerRequested;
        public event Action? OpenBilanzRequested;

        public JaAuswahlViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Direkte Commands für die "zum..." Links
            OpenEuerCommand = new RelayCommand(_ => OpenEuerRequested?.Invoke());
            OpenBilanzCommand = new RelayCommand(_ => OpenBilanzRequested?.Invoke());
        }

        // --- Auswahl Status (Standardmäßig alles FALSE) ---
        private bool _isEuerSelected;
        public bool IsEuerSelected
        {
            get => _isEuerSelected;
            set
            {
                if (Set(ref _isEuerSelected, value))
                {
                    if (value) IsBilanzSelected = false;
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
                    if (value) IsEuerSelected = false;
                    // Wenn Bilanz abgewählt wird, nichts tun, 
                    // wenn gewählt, könnte man hier einen Standard für Sub-Typ setzen, lassen wir aber offen.
                }
            }
        }

        // --- Unterauswahl Bilanz ---
        private bool _isEinzelunternehmen = true; // Standard innerhalb der Bilanz-Gruppe ist okay, oder auch false setzen
        public bool IsEinzelunternehmen
        {
            get => _isEinzelunternehmen;
            set { if (Set(ref _isEinzelunternehmen, value)) { if (value) IsGesellschaft = false; } }
        }

        private bool _isGesellschaft;
        public bool IsGesellschaft
        {
            get => _isGesellschaft;
            set { if (Set(ref _isGesellschaft, value)) { if (value) IsEinzelunternehmen = false; } }
        }

        // --- Navigation ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenEuerCommand { get; }
        public ICommand OpenBilanzCommand { get; }

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