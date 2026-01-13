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
                new PrivatLeistungOption(EinkommensteuerName, BerechneEinkommensteuerGebuehr())
            };
            SelectedLeistungOption = LeistungOptionen.FirstOrDefault();

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
            var option = LeistungOptionen.FirstOrDefault(o => o.Name == EinkommensteuerName);
            if (option == null) return;

            option.Preis = BerechneEinkommensteuerGebuehr();

            foreach (var leistung in Leistungen.Where(l => l.Name == EinkommensteuerName))
            {
                leistung.Preis = option.Preis;
            }

            OnPropertyChanged(nameof(SelectedLeistungPreisText));
            UpdateTotals();
        }

        private decimal BerechneEinkommensteuerGebuehr()
        {
            var privat = GlobalState.Instance.PrivatDaten;
            decimal basis = privat.SummePositiveEinkuenfte - privat.Werbungskosten + privat.SummeBetriebseinnahmen;
            if (basis < 0m) basis = 0m;

            decimal gegenstandswert = Math.Max(basis, _werte.EinkommensteuerErklaerungMin);
            double volleGebuehr = _rechner.BerechneVolleGebuehrBeratung((double)gegenstandswert);
            return (decimal)volleGebuehr * _werte.EinkommensteuerErklaerungSatz;
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
