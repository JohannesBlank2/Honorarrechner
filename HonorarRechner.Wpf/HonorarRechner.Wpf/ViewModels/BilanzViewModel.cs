using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

namespace HonorarRechner.Wpf.ViewModels
{
    public class BilanzViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        private readonly UnternehmensDaten _daten;
        private readonly TabellenWerte _werte;
        private readonly GebuehrenRechner _rechner;
        private readonly HonorarService _honorarService;

        public BilanzViewModel()
        {
            var globalState = GlobalState.Instance;
            _daten = globalState.Daten;
            _werte = globalState.Werte;
            _rechner = new GebuehrenRechner();
            _honorarService = new HonorarService();

            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));

            Recalculate();
        }

        // --- Shell ---
        public string ViewTitle => "Bilanz";
        private string _jahresHonorarText = "Jahres Honorar: 0,00 €";
        public string JahresHonorarText { get => _jahresHonorarText; set { _jahresHonorarText = value; OnPropertyChanged(); } }
        private string _monatsHonorarText = "Monats Honorar: 0,00 €";
        public string MonatsHonorarText { get => _monatsHonorarText; set { _monatsHonorarText = value; OnPropertyChanged(); } }

        // --- Commands ---
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand? WeiterCommand => null;

        // --- Properties ---
        private string ToEuro(decimal d) => d.ToString("C", _deCulture);

        // 1. AdJ
        private decimal _aufstellungWert;
        public string AufstellungInput => ToEuro(_aufstellungWert);
        public string AufstellungSatz => $"{_werte.AdJSatz * 10:0}/10";
        private decimal _aufstellungGebuehr;
        public string AufstellungText => ToEuro(_aufstellungGebuehr);

        // 2. Antrag
        private decimal _antragWert;
        public string AntragInput => ToEuro(_antragWert);
        public string AntragSatz => $"{_werte.AntragSatz * 10:0}/10";
        private decimal _antragGebuehr;
        public string AntragText => ToEuro(_antragGebuehr);

        // 3. Steuerbilanz
        private decimal _steuerbilanzWert;
        public string SteuerbilanzInput => ToEuro(_steuerbilanzWert);
        public string SteuerbilanzSatz => $"{_werte.SteuerbilanzSatz * 10:0}/10";
        private decimal _steuerbilanzGebuehr;
        public string SteuerbilanzText => ToEuro(_steuerbilanzGebuehr);

        // 4. Körperschaftsteuer (WICHTIG: 0 bei EU)
        private decimal _koerperschaftWert;
        public string KoerperschaftInput => ToEuro(_koerperschaftWert);
        public string KoerperschaftSatz => $"{_werte.KoerperschaftSatz * 10:0}/10";
        private decimal _koerperschaftGebuehr;
        public string KoerperschaftText => ToEuro(_koerperschaftGebuehr);

        // 5. Umsatzsteuer
        private decimal _ustWert;
        public string UstInput => ToEuro(_ustWert);
        public string UstSatz => $"{_werte.UstKjSatz * 10:0}/10";
        private decimal _ustGebuehr;
        public string UstText => ToEuro(_ustGebuehr);

        // 6. Gewerbesteuer
        private decimal _gewerbeWert;
        public string GewerbeInput => ToEuro(_gewerbeWert);
        public string GewerbeSatz => $"{_werte.GewStErklSatz * 10:0}/10";
        private decimal _gewerbeGebuehr;
        public string GewerbeText => ToEuro(_gewerbeGebuehr);

        // 7. Bescheide
        private int _bescheidAnzahlInt = 4;
        public string BescheidAnzahl
        {
            get => _bescheidAnzahlInt.ToString();
            set
            {
                if (int.TryParse(value, out int result))
                {
                    _bescheidAnzahlInt = result;
                    Recalculate();
                }
                OnPropertyChanged();
            }
        }
        private decimal _bescheidGebuehr;
        public string BescheidText => ToEuro(_bescheidGebuehr);

        // 8. Pauschalen
        public string EBilanzText => ToEuro(_werte.E_BilanzPauschale);
        public string OffenlegungText => ToEuro(_werte.OffenlegungPauschale);

        // Zwischensummen
        private decimal _zwischenSummeJahr;
        public string ZwischenSummeJahr => ToEuro(_zwischenSummeJahr);
        public string ZwischenSummeMonat => ToEuro(_zwischenSummeJahr / 12);


        // --- LOGIK ---
        private void Recalculate()
        {
            decimal umsatz = _daten.UmsatzImJahr;
            decimal bilanzSumme = _daten.Bilanzsumme;
            decimal gewinn = _daten.Jahresueberschuss;

            // Mittelwert für Bilanz
            decimal mittelwert = (umsatz + bilanzSumme) / 2m;

            // 1. Aufstellung
            _aufstellungWert = Math.Max(mittelwert, _werte.AdJMin);
            double v1 = _rechner.BerechneVolleGebuehrAbschluss((double)_aufstellungWert);
            _aufstellungGebuehr = (decimal)v1 * _werte.AdJSatz;

            // 2. Antrag
            _antragWert = Math.Max(mittelwert, _werte.AntragMin);
            double v2 = _rechner.BerechneVolleGebuehrAbschluss((double)_antragWert);
            _antragGebuehr = (decimal)v2 * _werte.AntragSatz;

            // 3. Steuerbilanz
            _steuerbilanzWert = Math.Max(mittelwert, _werte.SteuerbilanzMin);
            double v3 = _rechner.BerechneVolleGebuehrAbschluss((double)_steuerbilanzWert);
            _steuerbilanzGebuehr = (decimal)v3 * _werte.SteuerbilanzSatz;

            // 4. KSt -> NUR BEI GESELLSCHAFT
            if (_daten.UnternehmensArt == "GESELLSCHAFT")
            {
                _koerperschaftWert = Math.Max(gewinn, _werte.KoerperschaftMin);
                double v4 = _rechner.BerechneVolleGebuehrBeratung((double)_koerperschaftWert);
                _koerperschaftGebuehr = (decimal)v4 * _werte.KoerperschaftSatz;
            }
            else
            {
                _koerperschaftWert = 0;
                _koerperschaftGebuehr = 0;
            }

            // 5. USt
            _ustWert = Math.Max(umsatz * 0.1m, _werte.UstKjMin);
            double v5 = _rechner.BerechneVolleGebuehrBeratung((double)_ustWert);
            _ustGebuehr = (decimal)v5 * _werte.UstKjSatz;

            // 6. Gewerbesteuer
            _gewerbeWert = Math.Max(gewinn, _werte.GewStErklMin);
            double v6 = _rechner.BerechneVolleGebuehrBeratung((double)_gewerbeWert);
            _gewerbeGebuehr = (decimal)v6 * _werte.GewStErklSatz;

            // 7. Bescheide
            _bescheidGebuehr = _bescheidAnzahlInt * _werte.BilanzBescheidSatz;

            // Summe
            decimal calcTotal = _aufstellungGebuehr + _antragGebuehr + _steuerbilanzGebuehr +
                                _koerperschaftGebuehr + _ustGebuehr + _gewerbeGebuehr +
                                _bescheidGebuehr + _werte.E_BilanzPauschale + _werte.OffenlegungPauschale;

            // Minimum prüfen
            decimal min = (_daten.UnternehmensArt == "GESELLSCHAFT" ? _werte.BilanzMinGesMonat : _werte.BilanzMinEuMonat) * 12;
            _zwischenSummeJahr = Math.Max(calcTotal, min);

            // --- Footer ---
            var gesamt = _honorarService.BerechneAlles();
            JahresHonorarText = $"Jahres Honorar: {gesamt.JahresHonorar:C}";
            MonatsHonorarText = $"Monats Honorar: {(gesamt.JahresHonorar / 12m):C}";

            NotifyAllPropertiesChanged();
        }

        private void NotifyAllPropertiesChanged()
        {
            OnPropertyChanged(nameof(AufstellungInput)); OnPropertyChanged(nameof(AufstellungSatz)); OnPropertyChanged(nameof(AufstellungText));
            OnPropertyChanged(nameof(AntragInput)); OnPropertyChanged(nameof(AntragSatz)); OnPropertyChanged(nameof(AntragText));
            OnPropertyChanged(nameof(SteuerbilanzInput)); OnPropertyChanged(nameof(SteuerbilanzSatz)); OnPropertyChanged(nameof(SteuerbilanzText));
            OnPropertyChanged(nameof(KoerperschaftInput)); OnPropertyChanged(nameof(KoerperschaftSatz)); OnPropertyChanged(nameof(KoerperschaftText));
            OnPropertyChanged(nameof(UstInput)); OnPropertyChanged(nameof(UstSatz)); OnPropertyChanged(nameof(UstText));
            OnPropertyChanged(nameof(GewerbeInput)); OnPropertyChanged(nameof(GewerbeSatz)); OnPropertyChanged(nameof(GewerbeText));
            OnPropertyChanged(nameof(BescheidText)); OnPropertyChanged(nameof(EBilanzText)); OnPropertyChanged(nameof(OffenlegungText));
            OnPropertyChanged(nameof(ZwischenSummeJahr)); OnPropertyChanged(nameof(ZwischenSummeMonat));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}