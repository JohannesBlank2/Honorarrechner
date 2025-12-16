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

        // Daten aus GlobalState
        private readonly UnternehmensDaten _daten;
        private readonly TabellenWerte _werte;
        private readonly GebuehrenRechner _rechner;

        public EuerViewModel()
        {
            // Initialisierung
            var globalState = GlobalState.Instance;
            _daten = globalState.Daten;
            _werte = globalState.Werte;
            _rechner = new GebuehrenRechner();

            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Berechnung starten
            Recalculate();
        }

        public ICommand ZurueckCommand { get; }

        private string ToEuro(decimal value) => value.ToString("C", _deCulture);

        // --- PROPERTIES FÜR DIE VIEW (Exakt passend zu den XAML Bindings) ---

        // 1. BEA
        private decimal _beaGegenstandswert;
        public string BeaInput
        {
            get => ToEuro(_beaGegenstandswert);
            set { OnPropertyChanged(); } // Setter nötig für TwoWay-Binding, auch wenn wir den Wert berechnen
        }
        public string BeaSatz => $"{_werte.BeaSatz:0.##}"; // z.B. 20/10

        private decimal _beaGebuehr;
        public string BeaResultText => ToEuro(_beaGebuehr);

        // 2. Gewerbesteuer
        private decimal _gewerbeGegenstandswert;
        public string GewerbeInput
        {
            get => ToEuro(_gewerbeGegenstandswert);
            set { OnPropertyChanged(); }
        }
        public string GewerbeSatz => $"{_werte.GewerbeSatz:0.##}";

        private decimal _gewerbeGebuehr;
        public string GewerbeResultText => ToEuro(_gewerbeGebuehr);

        // 3. Überschuss (UdB) -> Checkbox steuert GlobalState
        public bool IsUeberschussSelected
        {
            get => _daten.HatUeberschussRechnung;
            set
            {
                if (_daten.HatUeberschussRechnung != value)
                {
                    _daten.HatUeberschussRechnung = value;
                    OnPropertyChanged();
                    Recalculate(); // Neu berechnen wenn Checkbox geklickt wird
                }
            }
        }

        private decimal _uedbGegenstandswert;
        public string UedbInput
        {
            get => ToEuro(_uedbGegenstandswert);
            set { OnPropertyChanged(); }
        }
        public string UedbSatz => $"{_werte.UedbSatz:0.##}";

        private decimal _uedbGebuehr;
        public string UedbResultText => ToEuro(_uedbGebuehr);

        // 4. Umsatzsteuer
        private decimal _ustGegenstandswert;
        public string UstInput
        {
            get => ToEuro(_ustGegenstandswert);
            set { OnPropertyChanged(); }
        }
        public string UstSatz => $"{_werte.UstSatz:0.##}";

        private decimal _ustGebuehr;
        public string UstResultText => ToEuro(_ustGebuehr);

        // 5. Pauschale
        // In Form1 war "int AnzahlPauschalen = 3;" fest codiert.
        private int _pauschaleAnzahl = 3;
        public string PauschaleInput
        {
            get => _pauschaleAnzahl.ToString();
            set
            {
                // Falls man es editierbar machen will, könnte man es hier parsen
                OnPropertyChanged();
            }
        }

        private decimal _pauschaleGebuehr;
        public string PauschaleResultText => ToEuro(_pauschaleGebuehr);


        // --- BERECHNUNGSLOGIK (aus Form1 übernommen) ---

        private void Recalculate()
        {
            // 1. BEA
            decimal gewinn = _daten.Jahresueberschuss;
            decimal minGewinnBea = _werte.BeaMin;
            _beaGegenstandswert = (gewinn < minGewinnBea) ? minGewinnBea : gewinn;

            double volleGebuehrBea = _rechner.BerechneVolleGebuehrAbschluss((double)_beaGegenstandswert);
            _beaGebuehr = (decimal)volleGebuehrBea * _werte.BeaSatz;

            // 2. Gewerbe
            decimal minGewinnGew = _werte.GewerbeMin;
            _gewerbeGegenstandswert = (gewinn < minGewinnGew) ? minGewinnGew : gewinn;

            double volleGebuehrGew = _rechner.BerechneVolleGebuehrBeratung((double)_gewerbeGegenstandswert);
            _gewerbeGebuehr = (decimal)volleGebuehrGew * _werte.GewerbeSatz;

            // 3. UdB
            if (_daten.HatUeberschussRechnung)
            {
                decimal minGewinnUedb = _werte.UedbMin;
                _uedbGegenstandswert = (gewinn < minGewinnUedb) ? minGewinnUedb : gewinn;

                double volleGebuehrUedb = _rechner.BerechneVolleGebuehrAbschluss((double)_uedbGegenstandswert);
                _uedbGebuehr = (decimal)volleGebuehrUedb * _werte.UedbSatz;
            }
            else
            {
                _uedbGegenstandswert = 0;
                _uedbGebuehr = 0;
            }

            // 4. Umsatzsteuer
            decimal umsatz = _daten.UmsatzImJahr;
            decimal minUmsatz = _werte.UstMin;
            _ustGegenstandswert = (umsatz < minUmsatz) ? minUmsatz : umsatz;

            double volleGebuehrUst = _rechner.BerechneVolleGebuehrBeratung((double)_ustGegenstandswert);
            _ustGebuehr = (decimal)volleGebuehrUst * _werte.UstSatz;

            // 5. Pauschale
            _pauschaleGebuehr = _pauschaleAnzahl * _werte.AbschlussPauschaleSatz;


            // UI Updates
            NotifyAllPropertiesChanged();
        }

        private void NotifyAllPropertiesChanged()
        {
            OnPropertyChanged(nameof(BeaInput));
            OnPropertyChanged(nameof(BeaSatz));
            OnPropertyChanged(nameof(BeaResultText));

            OnPropertyChanged(nameof(GewerbeInput));
            OnPropertyChanged(nameof(GewerbeSatz));
            OnPropertyChanged(nameof(GewerbeResultText));

            OnPropertyChanged(nameof(IsUeberschussSelected));
            OnPropertyChanged(nameof(UedbInput));
            OnPropertyChanged(nameof(UedbSatz));
            OnPropertyChanged(nameof(UedbResultText));

            OnPropertyChanged(nameof(UstInput));
            OnPropertyChanged(nameof(UstSatz));
            OnPropertyChanged(nameof(UstResultText));

            OnPropertyChanged(nameof(PauschaleInput));
            OnPropertyChanged(nameof(PauschaleResultText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}