using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf.ViewModels
{
    public class UnternehmensViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;

        private readonly HonorarService _honorarService;

        public UnternehmensViewModel()
        {
            _honorarService = new HonorarService();

            // 1. Daten laden (wichtig beim Zurückkommen)
            LoadFromGlobalState();

            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());

            // 2. Einmal initial rechnen
            Recalculate();
        }

        // --- Shell ---
        public string ViewTitle => "Unternehmensdaten";
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        // --- Commands ---
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        // --- Data ---
        private decimal _jahresHonorar;

        private string _umsatzImJahr = "";
        public string UmsatzImJahr
        {
            get => _umsatzImJahr;
            set
            {
                if (SetField(ref _umsatzImJahr, value))
                {
                    GlobalState.Instance.Daten.UmsatzImJahr = ParseDecimal(value);
                    Recalculate();
                }
            }
        }

        private string _bilanzsumme = "";
        public string Bilanzsumme
        {
            get => _bilanzsumme;
            set
            {
                if (SetField(ref _bilanzsumme, value))
                {
                    GlobalState.Instance.Daten.Bilanzsumme = ParseDecimal(value);
                    Recalculate();
                }
            }
        }

        private string _jahresueberschuss = "";
        public string Jahresueberschuss
        {
            get => _jahresueberschuss;
            set
            {
                if (SetField(ref _jahresueberschuss, value))
                {
                    GlobalState.Instance.Daten.Jahresueberschuss = ParseDecimal(value);
                    Recalculate();
                }
            }
        }

        private string _anzahlMitarbeiter = "";
        public string AnzahlMitarbeiter
        {
            get => _anzahlMitarbeiter;
            set
            {
                if (SetField(ref _anzahlMitarbeiter, value))
                {
                    int.TryParse(value, out int result);
                    GlobalState.Instance.Daten.AnzahlMitarbeiter = result;
                    Recalculate();
                }
            }
        }

        private bool _istBargeldGewerbe;
        public bool IstBargeldGewerbe
        {
            get => _istBargeldGewerbe;
            set
            {
                if (SetField(ref _istBargeldGewerbe, value))
                {
                    GlobalState.Instance.Daten.IstBargeldGewerbe = value;
                    if (value) IstOnlineHaendler = false;
                    Recalculate();
                }
            }
        }

        private bool _istOnlineHaendler;
        public bool IstOnlineHaendler
        {
            get => _istOnlineHaendler;
            set
            {
                if (SetField(ref _istOnlineHaendler, value))
                {
                    GlobalState.Instance.Daten.IstOnlineHaendler = value;
                    if (value) IstBargeldGewerbe = false;
                    Recalculate();
                }
            }
        }

        private void Recalculate()
        {
            var ergebnis = _honorarService.BerechneAlles();
            _jahresHonorar = ergebnis.JahresHonorar;
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));
        }

        private void LoadFromGlobalState()
        {
            var d = GlobalState.Instance.Daten;
            // Nur laden, wenn Werte > 0 sind, sonst bleibt das Feld leer (besser für UX beim Start)
            _umsatzImJahr = d.UmsatzImJahr > 0 ? d.UmsatzImJahr.ToString("N0") : "";
            _bilanzsumme = d.Bilanzsumme > 0 ? d.Bilanzsumme.ToString("N0") : "";
            _jahresueberschuss = d.Jahresueberschuss > 0 ? d.Jahresueberschuss.ToString("N0") : "";
            _anzahlMitarbeiter = d.AnzahlMitarbeiter > 0 ? d.AnzahlMitarbeiter.ToString() : "";

            _istBargeldGewerbe = d.IstBargeldGewerbe;
            _istOnlineHaendler = d.IstOnlineHaendler;
        }

        private decimal ParseDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0m;
            // Robustes Parsing: Punkte und € entfernen, Komma als Dezimaltrenner akzeptieren
            string clean = input.Replace(".", "").Replace("€", "").Trim();
            if (decimal.TryParse(clean, out decimal res)) return res;
            return 0m;
        }

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