using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class BilanzViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public BilanzViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
        }

        // Dummy Properties
        public string AufstellungText => "0,00 €";
        public string AntragText => "0,00 €";
        public string SteuerbilanzText => "0,00 €";
        public string KoerperschaftText => "0,00 €";

        public string UstText => "0,00 €";
        public string GewerbeText => "0,00 €";
        public string BescheidText => "0,00 €";

        // WICHTIG: Auch hier "set" hinzufügen für die TextBox
        private string _bescheidAnzahl = "4";
        public string BescheidAnzahl
        {
            get => _bescheidAnzahl;
            set
            {
                if (_bescheidAnzahl != value)
                {
                    _bescheidAnzahl = value;
                    OnPropertyChanged();
                }
            }
        }

        public string EBilanzText => "160,00 €";
        public string OffenlegungText => "110,00 €";

        public string ZwischenSummeMonat => "0,00 €";
        public string ZwischenSummeJahr => "0,00 €";

        public ICommand ZurueckCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}