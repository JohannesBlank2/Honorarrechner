using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class EuerViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public EuerViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
        }

        // Dummy Properties für die Anzeige (ReadOnly ist hier ok für Textblöcke)
        public string BeaText => "0,00 €";
        public string BeaSatz => "15/10";

        public string GewerbeText => "0,00 €";
        public string GewerbeSatz => "3/10";

        public string UedbText => "0,00 €";
        public string UedbSatz => "7/10";

        public string UstText => "0,00 €";
        public string UstSatz => "3/10";

        public string PauschaleText => "0,00 €";

        // WICHTIG: Dies war der Fehlergrund. 
        // Weil dies an eine TextBox gebunden ist, braucht es einen "set"-Teil.
        private string _bescheidAnzahl = "3";
        public string BescheidAnzahl
        {
            get => _bescheidAnzahl;
            set
            {
                if (_bescheidAnzahl != value)
                {
                    _bescheidAnzahl = value;
                    OnPropertyChanged();
                    // Hier würde man später Recalculate() aufrufen
                }
            }
        }

        public string ZwischenSummeMonat => "0,00 €";
        public string ZwischenSummeJahr => "0,00 €";

        public ICommand ZurueckCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}