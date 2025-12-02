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
            OpenExcelCommand = new RelayCommand(_ => OpenExcel());
            UpdateExcelCommand = new RelayCommand(_ => UpdateExcel());
            ZurueckCommand = new RelayCommand(_ => Zurueck());
            WeiterCommand = new RelayCommand(_ => Weiter());

            JahresHonorar = 0m;
        }

        #region Eingaben

        private string _umsatzImJahr = string.Empty;
        public string UmsatzImJahr
        {
            get => _umsatzImJahr;
            set => SetField(ref _umsatzImJahr, value);
        }

        private string _bilanzsumme = string.Empty;
        public string Bilanzsumme
        {
            get => _bilanzsumme;
            set => SetField(ref _bilanzsumme, value);
        }

        private string _jahresueberschuss = string.Empty;
        public string Jahresueberschuss
        {
            get => _jahresueberschuss;
            set => SetField(ref _jahresueberschuss, value);
        }

        private string _anzahlMitarbeiter = string.Empty;
        public string AnzahlMitarbeiter
        {
            get => _anzahlMitarbeiter;
            set => SetField(ref _anzahlMitarbeiter, value);
        }

        private bool _istBargeldGewerbe;
        public bool IstBargeldGewerbe
        {
            get => _istBargeldGewerbe;
            set => SetField(ref _istBargeldGewerbe, value);
        }

        private bool _istOnlineHaendler;
        public bool IstOnlineHaendler
        {
            get => _istOnlineHaendler;
            set => SetField(ref _istOnlineHaendler, value);
        }

        #endregion

        #region Honorar

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

        public string JahresHonorarText => $"Jahres Honorar: {JahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(JahresHonorar / 12m):C}";

        #endregion

        #region Commands

        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        private void OpenExcel()
        {
            MessageBox.Show("Open Excel (Unternehmen) – wird noch angebunden.",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateExcel()
        {
            MessageBox.Show("Update Excel (Unternehmen) – wird noch angebunden.",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Zurueck()
        {
            ZurueckRequested?.Invoke();
        }

        private void Weiter()
        {
            WeiterRequested?.Invoke();
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetField<T>(ref T field, T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
