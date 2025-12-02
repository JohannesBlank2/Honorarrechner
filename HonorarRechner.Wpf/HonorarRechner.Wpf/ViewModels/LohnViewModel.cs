using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class LohnViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public LohnViewModel()
        {
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            // Startwert (Beispiel)
            AnzahlMitarbeiterText = "10";
        }

        #region Eingaben

        private int _anzahlMitarbeiter;
        public string AnzahlMitarbeiterText
        {
            get => _anzahlMitarbeiter.ToString();
            set
            {
                // Versuche Eingabe zu parsen, sonst 0
                if (int.TryParse(value, out int result))
                {
                    _anzahlMitarbeiter = result;
                }
                else
                {
                    _anzahlMitarbeiter = 0;
                }

                Recalculate();
                OnPropertyChanged();
                // Alle betroffenen Properties aktualisieren
                OnPropertyChanged(nameof(CountMa1));
                OnPropertyChanged(nameof(CountMa2_9));
                OnPropertyChanged(nameof(CountMa10_19));
                OnPropertyChanged(nameof(CountMa20_49));
                OnPropertyChanged(nameof(CountMa50_100));
                OnPropertyChanged(nameof(CountMa101Plus));

                OnPropertyChanged(nameof(SumMa1));
                OnPropertyChanged(nameof(SumMa2_9));
                OnPropertyChanged(nameof(SumMa10_19));
                OnPropertyChanged(nameof(SumMa20_49));
                OnPropertyChanged(nameof(SumMa50_100));
                OnPropertyChanged(nameof(SumMa101Plus));

                OnPropertyChanged(nameof(PreisMa101Plus)); // Dieser Preis ist dynamisch

                OnPropertyChanged(nameof(ZwischenSummeMonat));
                OnPropertyChanged(nameof(ZwischenSummeJahr));
            }
        }

        #endregion

        #region Preise & Konstanten (Platzhalter für Excel-Werte)
        // Diese Werte kommen später aus deiner Excel-Tabelle/Datenbank
        public decimal PreisMa1_Base => 42.00m;
        public decimal PreisMa2_9_Base => 30.00m;
        public decimal PreisMa10_19_Base => 24.00m;
        public decimal PreisMa20_49_Base => 22.00m;
        public decimal PreisMa50_100_Base => 20.00m;
        // Preis für 101+ wird dynamisch berechnet
        #endregion

        #region Berechnete Properties für die View

        // --- Anzahl pro Staffel ---
        public int CountMa1 { get; private set; }
        public int CountMa2_9 { get; private set; }
        public int CountMa10_19 { get; private set; }
        public int CountMa20_49 { get; private set; }
        public int CountMa50_100 { get; private set; }
        public int CountMa101Plus { get; private set; }

        // --- Summen pro Staffel (für die Anzeige formatiert) ---
        public string SumMa1 => $"{(CountMa1 * PreisMa1_Base):C}";
        public string SumMa2_9 => $"{(CountMa2_9 * PreisMa2_9_Base):C}";
        public string SumMa10_19 => $"{(CountMa10_19 * PreisMa10_19_Base):C}";
        public string SumMa20_49 => $"{(CountMa20_49 * PreisMa20_49_Base):C}";
        public string SumMa50_100 => $"{(CountMa50_100 * PreisMa50_100_Base):C}";

        private decimal _sumMa101PlusValue;
        public string SumMa101Plus => $"{_sumMa101PlusValue:C}";

        // Dynamischer Preisanzeige für 101+
        private decimal _preisMa101PlusDynamic;
        public string PreisMa101Plus => $"{_preisMa101PlusDynamic:C}";

        // --- Gesamtsummen ---
        private decimal _zwischenSummeMonat;
        public string ZwischenSummeMonat => $"{_zwischenSummeMonat:C}";
        public string ZwischenSummeJahr => $"{(_zwischenSummeMonat * 12):C}";

        #endregion

        #region Logik

        private void Recalculate()
        {
            int rest = _anzahlMitarbeiter;

            // 1. Mitarbeiter
            CountMa1 = rest > 0 ? 1 : 0;
            rest -= CountMa1;

            // 2. bis 9. (8 Stück)
            CountMa2_9 = Math.Min(rest, 8);
            rest -= CountMa2_9;

            // 10. bis 19. (10 Stück)
            CountMa10_19 = Math.Min(rest, 10);
            rest -= CountMa10_19;

            // 20. bis 49. (30 Stück)
            CountMa20_49 = Math.Min(rest, 30);
            rest -= CountMa20_49;

            // 50. bis 100. (51 Stück)
            CountMa50_100 = Math.Min(rest, 51);
            rest -= CountMa50_100;

            // Ab 101
            CountMa101Plus = Math.Max(0, rest);

            // --- Berechnung Summen ---
            decimal total = 0;
            total += CountMa1 * PreisMa1_Base;
            total += CountMa2_9 * PreisMa2_9_Base;
            total += CountMa10_19 * PreisMa10_19_Base;
            total += CountMa20_49 * PreisMa20_49_Base;
            total += CountMa50_100 * PreisMa50_100_Base;

            // Logik für 101+: "Beitrag sinkt je mehr Mitarbeiter, min 15€" (aus Form1.cs)
            // double satzProMitarbeiter = Math.Max(20 - (mitarbeiterAnzahl - 100) * 0.1, 15);
            if (CountMa101Plus > 0)
            {
                // Wir nehmen die Gesamtanzahl für die Rabatt-Logik
                decimal rabatt = (decimal)((_anzahlMitarbeiter - 100) * 0.1);
                _preisMa101PlusDynamic = Math.Max(20m - rabatt, 15m);

                _sumMa101PlusValue = CountMa101Plus * _preisMa101PlusDynamic;
                total += _sumMa101PlusValue;
            }
            else
            {
                _preisMa101PlusDynamic = 0m; // oder Basiswert anzeigen
                _sumMa101PlusValue = 0m;
            }

            _zwischenSummeMonat = total;
        }

        #endregion

        public ICommand ZurueckCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}