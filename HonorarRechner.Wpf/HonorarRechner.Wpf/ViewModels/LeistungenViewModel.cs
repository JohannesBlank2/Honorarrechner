using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LeistungenViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;
        public event Action? NavigateToFibuRequested;
        public event Action? NavigateToJaRequested; // NEU

        public LeistungenViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());
            NavigateToFibuCommand = new RelayCommand(_ => NavigateToFibuRequested?.Invoke());
            NavigateToJaCommand = new RelayCommand(_ => NavigateToJaRequested?.Invoke()); // NEU
        }

        // Leistungen-Auswahl
        public bool FiBu { get => _fiBu; set => Set(ref _fiBu, value); }
        private bool _fiBu;

        public bool JA { get => _ja; set => Set(ref _ja, value); }
        private bool _ja;

        public bool Lohn { get => _lohn; set => Set(ref _lohn, value); }
        private bool _lohn;

        public bool Selbstbucher { get => _selbstbucher; set => Set(ref _selbstbucher, value); }
        private bool _selbstbucher;

        // Beispielpreise
        public string FiBuMonatlichFormatted => "0,00 €";
        public string FiBuJaehrlichFormatted => "0,00 €";

        public string JAMonatlichFormatted => "0,00 €";
        public string JAJaehrlichFormatted => "0,00 €";

        public string LohnMonatlichFormatted => "0,00 €";
        public string LohnJaehrlichFormatted => "0,00 €";

        public string SelbstbucherMonatlichFormatted => "0,00 €";
        public string SelbstbucherJaehrlichFormatted => "0,00 €";

        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }
        public ICommand NavigateToFibuCommand { get; }
        public ICommand NavigateToJaCommand { get; } // NEU

        public event PropertyChangedEventHandler? PropertyChanged;
        private void Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}