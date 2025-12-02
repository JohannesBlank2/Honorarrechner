using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class UnternehmensViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;

        public UnternehmensViewModel()
        {
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());
            JahresHonorar = 0m;
        }

        // --- Shell Properties ---
        public string ViewTitle => "Unternehmensdaten";
        public string JahresHonorarText => $"Jahres Honorar: {JahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(JahresHonorar / 12m):C}";

        // --- Commands ---
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        // --- Data ---
        private decimal _jahresHonorar;
        public decimal JahresHonorar
        {
            get => _jahresHonorar;
            set { if (SetField(ref _jahresHonorar, value)) { OnPropertyChanged(nameof(JahresHonorarText)); OnPropertyChanged(nameof(MonatsHonorarText)); } }
        }

        private string _umsatzImJahr = "";
        public string UmsatzImJahr { get => _umsatzImJahr; set => SetField(ref _umsatzImJahr, value); }

        private string _bilanzsumme = "";
        public string Bilanzsumme { get => _bilanzsumme; set => SetField(ref _bilanzsumme, value); }

        private string _jahresueberschuss = "";
        public string Jahresueberschuss { get => _jahresueberschuss; set => SetField(ref _jahresueberschuss, value); }

        private string _anzahlMitarbeiter = "";
        public string AnzahlMitarbeiter { get => _anzahlMitarbeiter; set => SetField(ref _anzahlMitarbeiter, value); }

        private bool _istBargeldGewerbe;
        public bool IstBargeldGewerbe { get => _istBargeldGewerbe; set => SetField(ref _istBargeldGewerbe, value); }

        private bool _istOnlineHaendler;
        public bool IstOnlineHaendler { get => _istOnlineHaendler; set => SetField(ref _istOnlineHaendler, value); }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}