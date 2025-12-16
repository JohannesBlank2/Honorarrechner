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
    public class EuerViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        private readonly CultureInfo _deCulture = CultureInfo.GetCultureInfo("de-DE");

        // Referenzen auf die globalen Daten und Services
        private readonly UnternehmensDaten _daten;
        private readonly TabellenWerte _werte;
        private readonly GebuehrenRechner _rechner;

        public EuerViewModel()
        {
            // 1. Zugriff auf GlobalState initialisieren
            // Hier holen wir uns die Instanz, die im vorherigen Schritt befüllt wurde.
            _daten = GlobalState.Instance.Daten;
            var werte = GlobalState.Instance.Werte;
            var globalState = GlobalState.Instance;
            _werte = globalState.Werte;
            _rechner = new GebuehrenRechner();

            // Commands
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Dummy Commands für Excel (können später implementiert werden)
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Funktion noch nicht implementiert"));
            UpdateExcelCommand = new RelayCommand(_ =>
            {
                // Beispiel: Neu laden und neu berechnen
                // new ExcelWerteService().LadeWerte(...);
                Recalculate();
            });

            // Initial einmal berechnen
            Recalculate();
        }

        // --- Shell Properties ---
        public string ViewTitle => "Einnahmen-Überschuss-Rechnung (EÜR)";

        // Commands
        public ICommand ZurueckCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }

        // Hilfsfunktion für Formatierung
        private string ToEuro(decimal value) => value.ToString("C", _deCulture);

        // -------------------------------------------------------------------------
        // Berechnete Eigenschaften für die View (Binding Sources)
        // -------------------------------------------------------------------------

        // 1. Betriebs-Einnahmen/Ausgaben (BEA)
        private decimal _beaGebuehr;
        public string BeaGebuehrText => ToEuro(_beaGebuehr);

        // Form1: tB_BEA zeigt den Gegenstandswert an (entweder Gewinn oder Min-Wert)
        private decimal _beaGegenstandswert;
        public string BeaGegenstandswertText => ToEuro(_beaGegenstandswert);

        public string BeaSatzText => $"{_werte.BeaSatz:0.00}"; // Anzeige des Satzes

        // 2. Gewerbesteuer
        private decimal _gewerbeGebuehr;
        public string GewerbeGebuehrText => ToEuro(_gewerbeGebuehr);

        private decimal _gewerbeGegenstandswert;
        public string GewerbeGegenstandswertText => ToEuro(_gewerbeGegenstandswert);

        public string GewerbeSatzText => $"{_werte.GewerbeSatz:0.00}";

        // 3. Überschuss der Betriebseinnahmen (UdB) -> Nur sichtbar/berechnet wenn HatUeberschussRechnung true
        private decimal _uedbGebuehr;
        public string UedbGebuehrText => ToEuro(_uedbGebuehr);

        private decimal _uedbGegenstandswert;
        public string UedbGegenstandswertText => ToEuro(_uedbGegenstandswert);

        // Property für die Sichtbarkeit in der View (kann man an Visibility binden via Converter)
        public bool ZeigeUedb => _daten.HatUeberschussRechnung;
        public string UedbSatzText => $"{_werte.UedbSatz:0.00}";

        // 4. Umsatzsteuererklärung
        private decimal _ustGebuehr;
        public string UstGebuehrText => ToEuro(_ustGebuehr);

        private decimal _ustGegenstandswert;
        public string UstGegenstandswertText => ToEuro(_ustGegenstandswert);

        public string UstSatzText => $"{_werte.UstSatz:0.00}";

        // 5. Pauschale für Abschlussarbeiten
        private decimal _pauschaleGebuehr;
        public string PauschaleGebuehrText => ToEuro(_pauschaleGebuehr);
        public string PauschaleAnzahlText => "3"; // Festwert aus Form1: "int AnzahlPauschalen = 3;"

        // --- Gesamtsummen ---
        private decimal _summeJahr;
        public string JahresGesamtText => ToEuro(_summeJahr); // Binding für l_EURWS / labelEURZWJA
        public string MonatsAnteilText => ToEuro(_summeJahr / 12); // Binding für l_EURWSMonatlich

        // Form1: l_EURMin -> "min. " + ...
        public string MinJahresGebuehrText => "min. " + ToEuro(_werte.EurMinMonat * 12);


        // -------------------------------------------------------------------------
        // Logik (Portierung aus Form1.cs)
        // -------------------------------------------------------------------------

        private void Recalculate()
        {
            // 1. BEA (Betriebs Einnahmen-Ausgaben)
            CalcBEA();

            // 2. Gewerbesteuer
            CalcGewerbesteuer();

            // 3. UdB (Überschuss der Betriebseinnahmen)
            // Form1 Logik: if (cB_UdB.Checked) ...
            if (_daten.HatUeberschussRechnung)
            {
                CalcUEdB();
            }
            else
            {
                _uedbGebuehr = 0;
                _uedbGegenstandswert = 0;
            }

            // 4. Umsatzsteuererklärung
            CalcUmsatzsteuererklaerung();

            // 5. Pauschale
            CalcPauschalefuerAbschlussarbeiten();

            // Gesamtsumme berechnen
            // Form1: CalcCompleteEUR
            decimal completeEur = _beaGebuehr + _gewerbeGebuehr + _uedbGebuehr + _ustGebuehr + _pauschaleGebuehr;

            // Minimum Prüfung
            decimal minJahr = _werte.EurMinMonat * 12; // CompleteEURminMonat * 12

            if (completeEur < minJahr)
            {
                _summeJahr = minJahr;
            }
            else
            {
                _summeJahr = completeEur;
            }

            // UI aktualisieren
            NotifyAllPropertiesChanged();
        }

        private void CalcBEA()
        {
            // Form1: double Gewinn = Jahresueberschuss;
            decimal gewinn = _daten.Jahresueberschuss;
            decimal minGewinn = _werte.BeaMin; // BEAminBeitrag aus Excel

            if (gewinn < minGewinn)
            {
                _beaGegenstandswert = minGewinn;
            }
            else
            {
                _beaGegenstandswert = gewinn;
            }

            // Rechner aufrufen (Cast auf double notwendig, da GebuehrenRechner alt ist)
            // Form1: BerechneVolleGebuehrAbschluss (Tabelle C)
            double volleGebuehr = _rechner.BerechneVolleGebuehrAbschluss((double)_beaGegenstandswert);

            // Form1: volleGebuehr * BetriebsEinnahmenAusgabenSatz
            _beaGebuehr = (decimal)volleGebuehr * _werte.BeaSatz;
        }

        private void CalcGewerbesteuer()
        {
            decimal gewinn = _daten.Jahresueberschuss;
            decimal minGewinn = _werte.GewerbeMin;

            if (gewinn < minGewinn)
            {
                _gewerbeGegenstandswert = minGewinn;
            }
            else
            {
                _gewerbeGegenstandswert = gewinn;
            }

            // Form1: BerechneVolleGebuehrBeratung (Tabelle A)
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)_gewerbeGegenstandswert);

            _gewerbeGebuehr = (decimal)volleGebuehr * _werte.GewerbeSatz;
        }

        private void CalcUEdB()
        {
            decimal gewinn = _daten.Jahresueberschuss;
            decimal minGewinn = _werte.UedbMin;

            if (gewinn < minGewinn)
            {
                _uedbGegenstandswert = minGewinn;
            }
            else
            {
                _uedbGegenstandswert = gewinn;
            }

            // Form1: BerechneVolleGebuehrAbschluss (Tabelle C)
            double volleGebuehr = _rechner.BerechneVolleGebuehrAbschluss((double)_uedbGegenstandswert);

            _uedbGebuehr = (decimal)volleGebuehr * _werte.UedbSatz;
        }

        private void CalcUmsatzsteuererklaerung()
        {
            decimal umsatz = _daten.UmsatzImJahr;
            decimal minUmsatz = _werte.UstMin; // UmsatzsteuererlaerungMinBeitrag

            if (umsatz < minUmsatz)
            {
                _ustGegenstandswert = minUmsatz;
            }
            else
            {
                _ustGegenstandswert = umsatz;
            }

            // Form1: BerechneVolleGebuehrBeratung (Tabelle A)
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)_ustGegenstandswert);

            _ustGebuehr = (decimal)volleGebuehr * _werte.UstSatz;
        }

        private void CalcPauschalefuerAbschlussarbeiten()
        {
            // Form1: int AnzahlPauschalen = 3;
            int anzahl = 3;
            _pauschaleGebuehr = anzahl * _werte.AbschlussPauschaleSatz;
        }

        private void NotifyAllPropertiesChanged()
        {
            OnPropertyChanged(nameof(BeaGebuehrText));
            OnPropertyChanged(nameof(BeaGegenstandswertText));

            OnPropertyChanged(nameof(GewerbeGebuehrText));
            OnPropertyChanged(nameof(GewerbeGegenstandswertText));

            OnPropertyChanged(nameof(UedbGebuehrText));
            OnPropertyChanged(nameof(UedbGegenstandswertText));
            OnPropertyChanged(nameof(ZeigeUedb));

            OnPropertyChanged(nameof(UstGebuehrText));
            OnPropertyChanged(nameof(UstGegenstandswertText));

            OnPropertyChanged(nameof(PauschaleGebuehrText));

            OnPropertyChanged(nameof(JahresGesamtText));
            OnPropertyChanged(nameof(MonatsAnteilText));
            OnPropertyChanged(nameof(MinJahresGebuehrText));
        }

        // --- INotifyPropertyChanged Implementation ---
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}