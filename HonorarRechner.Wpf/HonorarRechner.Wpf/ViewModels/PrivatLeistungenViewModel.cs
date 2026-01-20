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
        private const string EinkommensteuerName = "Einkommensteuererklärung ohne Ermittlung der einzelnen Einkünfte";
        private const string UeberschussGewerbeName =
            "Ermittlung des Ueberschusses der Betriebseinnahmen ueber die -ausgaben aus Gewerbebetrieb Paragraf 25 StBVV 2022";
        private const string UeberschussNichtselbstName =
            "Ermittlung des Ueberschusses der Einnahmen ueber die Werbungsk. aus nichtselbst. Arbeit § 27 Abs. 1 StBVV 2022";

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
                new PrivatLeistungOption("Prüfung eines Steuerbescheids", _werte.PruefungSteuerbescheidPauschale),
                new PrivatLeistungOption(EinkommensteuerName, BerechneEinkommensteuerGebuehr()),
                new PrivatLeistungOption(UeberschussNichtselbstName, BerechneUeberschussNichtselbstGebuehr()),
                new PrivatLeistungOption(UeberschussGewerbeName, BerechneUeberschussGewerbeGebuehr())
            };
            var privatDaten = GlobalState.Instance.PrivatDaten;

            Leistungen = new ObservableCollection<PrivatLeistung>(privatDaten.Leistungen);
            Leistungen.CollectionChanged += (_, __) => UpdateTotals();

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
        public ICommand? WeiterCommand => null;
        public ICommand AddLeistungCommand { get; }
        public ICommand RemoveLeistungCommand { get; }

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

        private void HandleGlobalDataChanged()
        {
            UpdateLeistungPreis(EinkommensteuerName, BerechneEinkommensteuerGebuehr());
            UpdateLeistungPreis(UeberschussNichtselbstName, BerechneUeberschussNichtselbstGebuehr());
            UpdateLeistungPreis(UeberschussGewerbeName, BerechneUeberschussGewerbeGebuehr());

            OnPropertyChanged(nameof(SelectedLeistungPreisText));
            UpdateTotals();
        }

        private void UpdateLeistungPreis(string name, decimal preis)
        {
            var option = LeistungOptionen.FirstOrDefault(o => o.Name == name);
            if (option == null) return;

            option.Preis = preis;

            foreach (var leistung in Leistungen.Where(l => l.Name == name))
            {
                leistung.Preis = option.Preis;
            }
        }

        private decimal BerechneEinkommensteuerGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            decimal basis = privat.SummePositiveEinkuenfte;
            if (basis < 0m) basis = 0m;

            decimal gegenstandswert = Math.Max(basis, _werte.EinkommensteuerErklaerungMin);
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)gegenstandswert);
            return (decimal)volleGebuehr * _werte.EinkommensteuerErklaerungSatz;
        }

        private decimal BerechneUeberschussNichtselbstGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            decimal basis = privat.Werbungskosten;
            if (basis < 0m) basis = 0m;

            decimal gegenstandswert = Math.Max(basis, _werte.UeberschussNichtselbstMin);
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)gegenstandswert);
            return (decimal)volleGebuehr * _werte.UeberschussNichtselbstSatz;
        }

        private decimal BerechneUeberschussGewerbeGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            decimal basis = Math.Max(privat.SummeBetriebseinnahmen, privat.SummeBetriebsausgaben);
            if (basis < 0m) basis = 0m;

            decimal gegenstandswert = Math.Max(basis, 17500m);
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)gegenstandswert);
            return (decimal)volleGebuehr * _werte.UeberschussGewerbeSatz;
        }

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
