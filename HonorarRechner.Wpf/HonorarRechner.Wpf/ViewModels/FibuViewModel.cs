using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf.ViewModels
{
    public class FibuViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly HonorarService _honorarService;

        public FibuViewModel()
        {
            _honorarService = new HonorarService();
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            LoadData();
        }

        // --- Shell ---
        public string ViewTitle => "FiBu - Finanzbuchhaltung";
        private decimal _jahresHonorar;
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Detail Data ---
        private decimal _umsatz;
        public string UmsatzText
        {
            get => _umsatz.ToString("N2");
            set
            {
                // --- CRASH FIX: Setter hinzugefügt ---
                string clean = value.Replace("€", "").Replace(".", "").Trim();
                if (decimal.TryParse(clean, out decimal result))
                {
                    _umsatz = result;
                    GlobalState.Instance.Daten.UmsatzImJahr = result;
                    LoadData();
                    OnPropertyChanged();
                }
            }
        }

        private string _satzText = "";
        public string SatzText { get => _satzText; set { _satzText = value; OnPropertyChanged(); } }

        // Diese Properties haben jetzt private Setter, damit wir sie in LoadData füllen können
        public string LaufendeFibuMonatlich { get; private set; } = "0,00 €";
        public string ItPauschaleText { get; private set; } = "0,00 €";
        public string AuslagenPauschaleProzentText { get; private set; } = "0 %";
        public string AuslagenPauschaleWert { get; private set; } = "0,00 €";
        public string ZwischenSummeMonat { get; private set; } = "0,00 €";
        public string ZwischenSummeJahr { get; private set; } = "0,00 €";

        private void LoadData()
        {
            var daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;

            _umsatz = daten.UmsatzImJahr;

            // Satz Text für UI (z.B. "7/10")
            decimal satz = werte.FibuNormalSatz;
            if (daten.IstBargeldGewerbe) satz = werte.BarGeldGewerbeSatz;
            if (daten.IstOnlineHaendler) satz = werte.OnlineHaendlerSatz;
            SatzText = $"{satz * 10:0.##}/10";

            // 1. Footer (nur wenn Checkbox gesetzt ist)
            var gesamtErg = _honorarService.BerechneAlles();
            _jahresHonorar = gesamtErg.JahresHonorar;

            // 2. Details anzeigen (IMMER berechnen, auch als Vorschau)
            var details = _honorarService.BerechneFibuDetails(daten, werte);

            LaufendeFibuMonatlich = details.LaufendeMonatlich.ToString("C");
            ItPauschaleText = details.ItMonatlich.ToString("C");
            AuslagenPauschaleProzentText = (werte.AuslagenPauschaleProzent * 100).ToString("0") + " %";
            AuslagenPauschaleWert = details.AuslagenMonatlich.ToString("C");

            ZwischenSummeMonat = details.EndsummeMonatlich.ToString("C");
            ZwischenSummeJahr = details.JahresGesamt.ToString("C");

            // UI aktualisieren
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));

            OnPropertyChanged(nameof(LaufendeFibuMonatlich));
            OnPropertyChanged(nameof(ItPauschaleText));
            OnPropertyChanged(nameof(AuslagenPauschaleProzentText));
            OnPropertyChanged(nameof(AuslagenPauschaleWert));
            OnPropertyChanged(nameof(ZwischenSummeMonat));
            OnPropertyChanged(nameof(ZwischenSummeJahr));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}