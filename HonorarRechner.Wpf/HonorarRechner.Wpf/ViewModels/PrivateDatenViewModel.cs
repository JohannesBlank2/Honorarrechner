using HonorarRechner.Core.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class PrivateDatenViewModel : INotifyPropertyChanged
    {
        // Events für MainWindow.xaml.cs
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;

        private readonly PrivateDaten _daten;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        public PrivateDatenViewModel()
        {
            _daten = GlobalState.Instance.PrivateDaten;

            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());
        }

        public string ViewTitle => "Private Steuern (Grunddaten)";

        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        // --- Bindings ---

        public string Vorname
        {
            get => _daten.Vorname;
            set { _daten.Vorname = value; OnPropertyChanged(); }
        }

        public string Nachname
        {
            get => _daten.Nachname;
            set { _daten.Nachname = value; OnPropertyChanged(); }
        }

        // Formatierung und Parsing für Währung
        public string SummeEinkuenfteInput
        {
            get => _daten.SummePositiveEinkuenfte.ToString("C", _deCulture);
            set
            {
                string clean = value.Replace("€", "").Trim();
                if (decimal.TryParse(clean, NumberStyles.Any, _deCulture, out decimal result))
                {
                    _daten.SummePositiveEinkuenfte = result;
                }
                OnPropertyChanged();
            }
        }

        public bool IstZusammenVeranlagung
        {
            get => _daten.IstZusammenVeranlagung;
            set { _daten.IstZusammenVeranlagung = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}