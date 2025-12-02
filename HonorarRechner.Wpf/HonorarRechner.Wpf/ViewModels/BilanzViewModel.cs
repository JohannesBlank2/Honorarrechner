using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class BilanzViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public BilanzViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
        }

        // --- Shell Properties ---
        public string ViewTitle => "Bilanz";
        public string JahresHonorarText => "Jahres Honorar: 0,00 €";
        public string MonatsHonorarText => "Monats Honorar: 0,00 €";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Data ---
        public string AufstellungText => "0,00 €";
        public string AntragText => "0,00 €";
        public string SteuerbilanzText => "0,00 €";
        public string KoerperschaftText => "0,00 €";
        public string UstText => "0,00 €";
        public string GewerbeText => "0,00 €";
        public string BescheidText => "0,00 €";

        private string _bescheidAnzahl = "4";
        public string BescheidAnzahl { get => _bescheidAnzahl; set { if (_bescheidAnzahl != value) { _bescheidAnzahl = value; OnPropertyChanged(); } } }

        public string EBilanzText => "160,00 €";
        public string OffenlegungText => "110,00 €";
        public string ZwischenSummeMonat => "0,00 €";
        public string ZwischenSummeJahr => "0,00 €";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}