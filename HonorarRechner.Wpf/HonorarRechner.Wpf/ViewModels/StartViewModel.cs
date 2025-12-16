using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public event Action<string>? MandatSelected;

        // NEU:
        public event Action? OpenPrivateRechnerRequested;
        public ICommand OpenPrivateRechnerCommand { get; }
        public StartViewModel()
        {
            SelectMandatCommand = new RelayCommand(p => SelectMandat(p as string));
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Excel öffnen"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Excel update"));
            OpenPrivateRechnerCommand = new RelayCommand(_ => OpenPrivateRechnerRequested?.Invoke());
            JahresHonorar = 0m;
        }

        // --- Shell Properties ---
        public string ViewTitle => "Mandatstyp";
        public string JahresHonorarText => $"Jahres Honorar: {JahresHonorar:C}";
        
        public string MonatsHonorarText => $"Monats Honorar: {(JahresHonorar / 12m):C}";

        // --- Commands ---
        public ICommand SelectMandatCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        // Startseite hat kein Zurück/Weiter im Footer (dafür Buttons in der Mitte)
        public ICommand? ZurueckCommand => null;
        public ICommand? WeiterCommand => null;

        // --- Logic ---
        private string _selectedMandatTyp = string.Empty;
        public string SelectedMandatTyp
        {
            get => _selectedMandatTyp;
            set => SetField(ref _selectedMandatTyp, value);
        }

        private decimal _jahresHonorar;
        public decimal JahresHonorar
        {
            get => _jahresHonorar;
            set
            {
                if (SetField(ref _jahresHonorar, value))
                {
                    OnPropertyChanged(nameof(JahresHonorarText));
                    OnPropertyChanged(nameof(MonatsHonorarText));
                }
            }
        }

        private void SelectMandat(string? typ)
        {
            if (string.IsNullOrWhiteSpace(typ)) return;
            SelectedMandatTyp = typ;
            MandatSelected?.Invoke(typ);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}