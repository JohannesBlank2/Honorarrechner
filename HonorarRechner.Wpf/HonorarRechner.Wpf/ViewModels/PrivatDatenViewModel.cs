using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using HonorarRechner.Core.Models;

namespace HonorarRechner.Wpf.ViewModels
{
    public class PrivatDatenViewModel : INotifyPropertyChanged
    {
        public event Action? ZurueckRequested;
        public event Action? WeiterRequested;

        public PrivatDatenViewModel()
        {
            LoadFromGlobalState();

            OpenExcelCommand = new RelayCommand(_ => MessageBox.Show("Open Excel"));
            UpdateExcelCommand = new RelayCommand(_ => MessageBox.Show("Update Excel"));
            ZurueckCommand = new RelayCommand(_ => ZurueckRequested?.Invoke());
            WeiterCommand = new RelayCommand(_ => WeiterRequested?.Invoke());
        }

        public string ViewTitle => "Privatdaten";
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        private decimal _jahresHonorar;

        private string _vorname = "";
        public string Vorname
        {
            get => _vorname;
            set
            {
                if (SetField(ref _vorname, value))
                {
                    GlobalState.Instance.PrivatDaten.Vorname = value;
                }
            }
        }

        private string _nachname = "";
        public string Nachname
        {
            get => _nachname;
            set
            {
                if (SetField(ref _nachname, value))
                {
                    GlobalState.Instance.PrivatDaten.Nachname = value;
                }
            }
        }

        private string _steuerId = "";
        public string SteuerId
        {
            get => _steuerId;
            set
            {
                if (SetField(ref _steuerId, value))
                {
                    GlobalState.Instance.PrivatDaten.SteuerId = value;
                }
            }
        }

        private string _geburtsdatum = "";
        public string Geburtsdatum
        {
            get => _geburtsdatum;
            set
            {
                if (SetField(ref _geburtsdatum, value))
                {
                    GlobalState.Instance.PrivatDaten.Geburtsdatum = value;
                }
            }
        }

        private string _einkommenImJahr = "";
        public string EinkommenImJahr
        {
            get => _einkommenImJahr;
            set
            {
                if (SetField(ref _einkommenImJahr, value))
                {
                    GlobalState.Instance.PrivatDaten.EinkommenImJahr = ParseDecimal(value);
                }
            }
        }

        private string _anzahlKinder = "";
        public string AnzahlKinder
        {
            get => _anzahlKinder;
            set
            {
                if (SetField(ref _anzahlKinder, value))
                {
                    GlobalState.Instance.PrivatDaten.AnzahlKinder = ParseInt(value);
                }
            }
        }

        private string _summePositiveEinkuenfte = "";
        public string SummePositiveEinkuenfte
        {
            get => _summePositiveEinkuenfte;
            set
            {
                if (SetField(ref _summePositiveEinkuenfte, value))
                {
                    GlobalState.Instance.PrivatDaten.SummePositiveEinkuenfte = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _werbungskosten = "";
        public string Werbungskosten
        {
            get => _werbungskosten;
            set
            {
                if (SetField(ref _werbungskosten, value))
                {
                    GlobalState.Instance.PrivatDaten.Werbungskosten = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _summeBetriebseinnahmen = "";
        public string SummeBetriebseinnahmen
        {
            get => _summeBetriebseinnahmen;
            set
            {
                if (SetField(ref _summeBetriebseinnahmen, value))
                {
                    GlobalState.Instance.PrivatDaten.SummeBetriebseinnahmen = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private bool _verheiratet;
        public bool Verheiratet
        {
            get => _verheiratet;
            set
            {
                if (SetField(ref _verheiratet, value))
                {
                    GlobalState.Instance.PrivatDaten.Verheiratet = value;
                }
            }
        }

        private void LoadFromGlobalState()
        {
            var d = GlobalState.Instance.PrivatDaten;
            _vorname = d.Vorname;
            _nachname = d.Nachname;
            _steuerId = d.SteuerId;
            _geburtsdatum = d.Geburtsdatum;
            _einkommenImJahr = d.EinkommenImJahr > 0 ? d.EinkommenImJahr.ToString("N0") : "";
            _anzahlKinder = d.AnzahlKinder > 0 ? d.AnzahlKinder.ToString() : "";
            _verheiratet = d.Verheiratet;
            _summePositiveEinkuenfte = d.SummePositiveEinkuenfte > 0 ? d.SummePositiveEinkuenfte.ToString("N0") : "";
            _werbungskosten = d.Werbungskosten > 0 ? d.Werbungskosten.ToString("N0") : "";
            _summeBetriebseinnahmen = d.SummeBetriebseinnahmen > 0 ? d.SummeBetriebseinnahmen.ToString("N0") : "";
        }

        private decimal ParseDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0m;
            string clean = input.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(clean, out decimal res)) return res;
            return 0m;
        }

        private int ParseInt(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;
            if (int.TryParse(input.Trim(), out int res)) return res;
            return 0;
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
