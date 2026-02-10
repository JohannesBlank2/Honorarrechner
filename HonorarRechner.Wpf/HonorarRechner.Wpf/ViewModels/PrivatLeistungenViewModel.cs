using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HonorarRechner.Core.Models;
using HonorarRechner.Core.Services;

namespace HonorarRechner.Wpf.ViewModels
{
    public class PrivatLeistungenViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WerteEingebenRequested;

        private const string EinkommensteuerName = "Einkommensteuererklärung";
        private const string UeberschussKapitalvermoegenName = "EÜE Kapitalvermögen";
        private const string UeberschussNichtselbstName = "EÜE Nichtselbst. Arbeit";
        private const string UeberschussGewerbeName = "EÜB Gewerbebetrieb Selbstst.";
        private const string UeberschussSonstigeName = "EÜE Sonstige Einkünfte";
        private const string UeberschussVermietungName = "EÜE Vermiet./Verpacht.";
        private const string UstErklaerungConsultingName = "USt-Erklärung Consulting";
        private const string PruefungSteuerbescheidName = "Prüfung eines Steuerbescheids";

        private readonly TabellenWerte _werte;
        private readonly GebuehrenRechner _rechner;

        public PrivatLeistungenViewModel()
        {
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            _werte = GlobalState.Instance.Werte;
            _rechner = new GebuehrenRechner();
            LeistungOptionen = new ObservableCollection<PrivatLeistungOption>
            {
                new PrivatLeistungOption(EinkommensteuerName, BerechneEinkommensteuerGebuehr()),
                new PrivatLeistungOption(UeberschussKapitalvermoegenName, BerechneUeberschussKapitalvermoegenGebuehr()),
                new PrivatLeistungOption(UeberschussNichtselbstName, BerechneUeberschussNichtselbstGebuehr()),
                new PrivatLeistungOption(UeberschussGewerbeName, BerechneUeberschussGewerbeGebuehr()),
                new PrivatLeistungOption(UeberschussSonstigeName, BerechneUeberschussSonstigeGebuehr()),
                new PrivatLeistungOption(UeberschussVermietungName, BerechneUeberschussVermietungGebuehr()),
                new PrivatLeistungOption(UstErklaerungConsultingName, BerechneUstConsultingGebuehr()),
                new PrivatLeistungOption(PruefungSteuerbescheidName, _werte.PruefungSteuerbescheidPauschale)
            };
            var privatDaten = GlobalState.Instance.PrivatDaten;

            Leistungen = new ObservableCollection<PrivatLeistung>(privatDaten.Leistungen);
            foreach (var leistung in Leistungen)
            {
                UpdateLeistungPreis(leistung);
            }
            UpdateEingabeStatus();
            WerteEingebenCommand = new RelayCommand(_ => WerteEingebenRequested?.Invoke(), _ => HasEingabeLeistungen);
            Leistungen.CollectionChanged += (_, __) =>
            {
                UpdateTotals();
                UpdateEingabeStatus();
                CommandManager.InvalidateRequerySuggested();
            };

            AddLeistungCommand = new RelayCommand(_ => AddLeistung(), _ => SelectedLeistungOption != null);
            RemoveLeistungCommand = new RelayCommand(RemoveLeistung);

            GlobalState.Instance.DataChanged += HandleGlobalDataChanged;

            UpdateTotals();
        }

        public string ViewTitle => "Private Leistungen";
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";
        public string GesamtPreisText => _jahresHonorar.ToString("C");

        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand? WeiterCommand => WerteEingebenCommand;
        public ICommand AddLeistungCommand { get; }
        public ICommand RemoveLeistungCommand { get; }
        public ICommand WerteEingebenCommand { get; }

        private bool _hasEingabeLeistungen;
        public bool HasEingabeLeistungen
        {
            get => _hasEingabeLeistungen;
            private set => SetField(ref _hasEingabeLeistungen, value);
        }

        public ObservableCollection<PrivatLeistungOption> LeistungOptionen { get; }

        private PrivatLeistungOption? _selectedLeistungOption;
        public PrivatLeistungOption? SelectedLeistungOption
        {
            get => _selectedLeistungOption;
            set
            {
                if (SetField(ref _selectedLeistungOption, value))
                {
                    OnPropertyChanged(nameof(SelectedLeistungPreisText));
                }
            }
        }

        public string SelectedLeistungPreisText => SelectedLeistungOption == null
            ? "-"
            : SelectedLeistungOption.Preis.ToString("C");

        public ObservableCollection<PrivatLeistung> Leistungen { get; }

        private decimal _jahresHonorar;

        private void AddLeistung()
        {
            if (SelectedLeistungOption == null) return;

            var item = new PrivatLeistung
            {
                Name = SelectedLeistungOption.Name,
                Preis = SelectedLeistungOption.Preis
            };

            Leistungen.Add(item);
            GlobalState.Instance.PrivatDaten.Leistungen.Add(item);
            UpdateTotals();
        }

        private void RemoveLeistung(object? parameter)
        {
            if (parameter is not PrivatLeistung item) return;

            Leistungen.Remove(item);
            GlobalState.Instance.PrivatDaten.Leistungen.Remove(item);
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            _jahresHonorar = Leistungen.Sum(l => l.Preis);
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));
            OnPropertyChanged(nameof(GesamtPreisText));
        }

        private void UpdateEingabeStatus()
        {
            HasEingabeLeistungen = Leistungen.Any(l =>
                !string.Equals(l.Name, PruefungSteuerbescheidName, StringComparison.OrdinalIgnoreCase));
        }

        private void HandleGlobalDataChanged()
        {
            UpdateOptionPreise();
            foreach (var leistung in Leistungen)
            {
                UpdateLeistungPreis(leistung);
            }

            OnPropertyChanged(nameof(SelectedLeistungPreisText));
            UpdateTotals();
        }

        private void UpdateOptionPreise()
        {
            UpdateOptionPreis(EinkommensteuerName, BerechneEinkommensteuerGebuehr());
            UpdateOptionPreis(UeberschussKapitalvermoegenName, BerechneUeberschussKapitalvermoegenGebuehr());
            UpdateOptionPreis(UeberschussNichtselbstName, BerechneUeberschussNichtselbstGebuehr());
            UpdateOptionPreis(UeberschussGewerbeName, BerechneUeberschussGewerbeGebuehr());
            UpdateOptionPreis(UeberschussSonstigeName, BerechneUeberschussSonstigeGebuehr());
            UpdateOptionPreis(UeberschussVermietungName, BerechneUeberschussVermietungGebuehr());
            UpdateOptionPreis(UstErklaerungConsultingName, BerechneUstConsultingGebuehr());
            UpdateOptionPreis(PruefungSteuerbescheidName, _werte.PruefungSteuerbescheidPauschale);
        }

        private void UpdateOptionPreis(string name, decimal preis)
        {
            var option = LeistungOptionen.FirstOrDefault(o => o.Name == name);
            if (option == null) return;

            option.Preis = preis;
        }

        private void UpdateLeistungPreis(PrivatLeistung leistung)
        {
            if (string.Equals(leistung.Name, EinkommensteuerName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneEinkommensteuerGebuehr(leistung.EingabeWert1);
                return;
            }

            if (string.Equals(leistung.Name, UeberschussKapitalvermoegenName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUeberschussKapitalvermoegenGebuehr(leistung.EingabeWert1);
                return;
            }

            if (string.Equals(leistung.Name, UeberschussNichtselbstName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUeberschussNichtselbstGebuehr(leistung.EingabeWert1);
                return;
            }

            if (string.Equals(leistung.Name, UeberschussGewerbeName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUeberschussGewerbeGebuehr(leistung.EingabeWert1, leistung.EingabeWert2);
                return;
            }

            if (string.Equals(leistung.Name, UeberschussSonstigeName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUeberschussSonstigeGebuehr(leistung.EingabeWert1);
                return;
            }

            if (string.Equals(leistung.Name, UeberschussVermietungName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUeberschussVermietungGebuehr(leistung.EingabeWert1);
                return;
            }

            if (string.Equals(leistung.Name, UstErklaerungConsultingName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = BerechneUstConsultingGebuehr(leistung.EingabeWert1, leistung.EingabeWert2);
                return;
            }

            if (string.Equals(leistung.Name, PruefungSteuerbescheidName, StringComparison.OrdinalIgnoreCase))
            {
                leistung.Preis = _werte.PruefungSteuerbescheidPauschale;
            }
        }

        private decimal BerechneEinkommensteuerGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneEinkommensteuerGebuehr(privat.SummePositiveEinkuenfte);
        }

        private decimal BerechneEinkommensteuerGebuehr(decimal summePositiveEinkuenfte)
        {
            return BerechneBeratungsLeistung(summePositiveEinkuenfte, _werte.EinkommensteuerErklaerungMin,
                _werte.EinkommensteuerErklaerungSatz);
        }

        private decimal BerechneUeberschussKapitalvermoegenGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUeberschussKapitalvermoegenGebuehr(privat.KapitalvermoegenEinnahmen);
        }

        private decimal BerechneUeberschussKapitalvermoegenGebuehr(decimal einnahmen)
        {
            decimal basis = Max0(einnahmen);
            return BerechneBeratungsLeistung(basis, _werte.UeberschussKapitalvermoegenMin,
                _werte.UeberschussKapitalvermoegenSatz);
        }

        private decimal BerechneUeberschussNichtselbstGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUeberschussNichtselbstGebuehr(privat.NichtselbstEinnahmen);
        }

        private decimal BerechneUeberschussNichtselbstGebuehr(decimal einnahmen)
        {
            decimal basis = Max0(einnahmen);
            return BerechneBeratungsLeistung(basis, _werte.UeberschussNichtselbstMin, _werte.UeberschussNichtselbstSatz);
        }

        private decimal BerechneUeberschussGewerbeGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUeberschussGewerbeGebuehr(privat.SummeBetriebseinnahmen, privat.SummeBetriebsausgaben);
        }

        private decimal BerechneUeberschussGewerbeGebuehr(decimal einnahmen, decimal ausgaben)
        {
            decimal basis = Max0(Math.Max(einnahmen, ausgaben));
            decimal gegenstandswert = Math.Max(Max0(basis), Max0(_werte.UeberschussGewerbeMin));
            double volleGebuehr = _rechner.BerechneVolleGebuehrAbschluss((double)gegenstandswert);
            return (decimal)volleGebuehr * _werte.UeberschussGewerbeSatz;
        }

        private decimal BerechneUeberschussSonstigeGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUeberschussSonstigeGebuehr(privat.SonstigeEinnahmen);
        }

        private decimal BerechneUeberschussSonstigeGebuehr(decimal einnahmen)
        {
            decimal basis = Max0(einnahmen);
            return BerechneBeratungsLeistung(basis, _werte.UeberschussSonstigeMin, _werte.UeberschussSonstigeSatz);
        }

        private decimal BerechneUeberschussVermietungGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUeberschussVermietungGebuehr(privat.VermietungEinnahmen);
        }

        private decimal BerechneUeberschussVermietungGebuehr(decimal einnahmen)
        {
            decimal basis = Max0(einnahmen);
            return BerechneBeratungsLeistung(basis, _werte.UeberschussVermietungMin, _werte.UeberschussVermietungSatz);
        }

        private decimal BerechneUstConsultingGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            return BerechneUstConsultingGebuehr(privat.UstConsultingGesamtbetragEntgelte, privat.UstConsultingEntgelteLeistungsempfaenger);
        }

        private decimal BerechneUstConsultingGebuehr(decimal gesamtbetragEntgelte, decimal entgelteLeistungsempfaenger)
        {
            decimal basis = Max0((gesamtbetragEntgelte + entgelteLeistungsempfaenger) * 0.1m);
            return BerechneBeratungsLeistung(basis, _werte.UstErklaerungConsultingMin, _werte.UstErklaerungConsultingSatz);
        }

        private decimal BerechneBeratungsLeistung(decimal basis, decimal minBetrag, decimal satz)
        {
            decimal gegenstandswert = Math.Max(Max0(basis), Max0(minBetrag));
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)gegenstandswert);
            return (decimal)volleGebuehr * satz;
        }

        private static decimal Max0(decimal wert) => wert < 0m ? 0m : wert;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class PrivatLeistungOption
    {
        public PrivatLeistungOption(string name, decimal preis)
        {
            Name = name;
            Preis = preis;
        }

        public string Name { get; }
        public decimal Preis { get; set; }
    }
}
