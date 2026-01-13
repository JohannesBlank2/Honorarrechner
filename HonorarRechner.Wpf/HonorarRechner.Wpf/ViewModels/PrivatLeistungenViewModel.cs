using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HonorarRechner.Core.Models;

namespace HonorarRechner.Wpf.ViewModels
{
    public class PrivatLeistungenViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;

        public PrivatLeistungenViewModel()
        {
            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());

            var werte = GlobalState.Instance.Werte;
            LeistungOptionen = new ObservableCollection<PrivatLeistungOption>
            {
                new PrivatLeistungOption("Prüfung eines Steuerbescheids", werte.PruefungSteuerbescheidPauschale)
            };
            SelectedLeistungOption = LeistungOptionen.FirstOrDefault();

            var privatDaten = GlobalState.Instance.PrivatDaten;
            Leistungen = new ObservableCollection<PrivatLeistung>(privatDaten.Leistungen);
            Leistungen.CollectionChanged += (_, __) => UpdateTotals();

            AddLeistungCommand = new RelayCommand(_ => AddLeistung(), _ => SelectedLeistungOption != null);
            RemoveLeistungCommand = new RelayCommand(RemoveLeistung);

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
        public decimal Preis { get; }
    }
}
