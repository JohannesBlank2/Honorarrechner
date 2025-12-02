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

        public JaAuswahlViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenEuerCommand = new RelayCommand(_ => OpenEuerRequested?.Invoke());
            OpenBilanzCommand = new RelayCommand(_ => OpenBilanzRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
        }

        // --- Shell Properties ---
        public string ViewTitle => "Jahresabschluss (JA)";
        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenEuerCommand { get; }
        public ICommand OpenBilanzCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Logic ---
        private bool _isEuerSelected;
        public bool IsEuerSelected
        {
            get => _isEuerSelected;
            set { if (Set(ref _isEuerSelected, value)) { if (value) IsBilanzSelected = false; } }
        }

        private bool _isBilanzSelected;
        public bool IsBilanzSelected
        {
            get => _isBilanzSelected;
            set { if (Set(ref _isBilanzSelected, value)) { if (value) IsEuerSelected = false; } }
        }

        private bool _isEinzelunternehmen = true;
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