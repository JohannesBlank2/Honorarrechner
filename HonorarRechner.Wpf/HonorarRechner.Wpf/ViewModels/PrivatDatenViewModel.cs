using System;
using System.ComponentModel;
using System.Linq;
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

        private decimal _jahresHonorar = 0m;

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
                    var parsed = ParseDecimal(value);
                    GlobalState.Instance.PrivatDaten.Werbungskosten = parsed;
                    GlobalState.Instance.PrivatDaten.NichtselbstWerbungskosten = parsed;
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _kapitalvermoegenEinnahmen = "";
        public string KapitalvermoegenEinnahmen
        {
            get => _kapitalvermoegenEinnahmen;
            set
            {
                if (SetField(ref _kapitalvermoegenEinnahmen, value))
                {
                    GlobalState.Instance.PrivatDaten.KapitalvermoegenEinnahmen = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _kapitalvermoegenWerbungskosten = "";
        public string KapitalvermoegenWerbungskosten
        {
            get => _kapitalvermoegenWerbungskosten;
            set
            {
                if (SetField(ref _kapitalvermoegenWerbungskosten, value))
                {
                    GlobalState.Instance.PrivatDaten.KapitalvermoegenWerbungskosten = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _nichtselbstEinnahmen = "";
        public string NichtselbstEinnahmen
        {
            get => _nichtselbstEinnahmen;
            set
            {
                if (SetField(ref _nichtselbstEinnahmen, value))
                {
                    GlobalState.Instance.PrivatDaten.NichtselbstEinnahmen = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _nichtselbstWerbungskosten = "";
        public string NichtselbstWerbungskosten
        {
            get => _nichtselbstWerbungskosten;
            set
            {
                if (SetField(ref _nichtselbstWerbungskosten, value))
                {
                    var parsed = ParseDecimal(value);
                    GlobalState.Instance.PrivatDaten.NichtselbstWerbungskosten = parsed;
                    GlobalState.Instance.PrivatDaten.Werbungskosten = parsed;
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _sonstigeEinnahmen = "";
        public string SonstigeEinnahmen
        {
            get => _sonstigeEinnahmen;
            set
            {
                if (SetField(ref _sonstigeEinnahmen, value))
                {
                    GlobalState.Instance.PrivatDaten.SonstigeEinnahmen = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _sonstigeWerbungskosten = "";
        public string SonstigeWerbungskosten
        {
            get => _sonstigeWerbungskosten;
            set
            {
                if (SetField(ref _sonstigeWerbungskosten, value))
                {
                    GlobalState.Instance.PrivatDaten.SonstigeWerbungskosten = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _vermietungEinnahmen = "";
        public string VermietungEinnahmen
        {
            get => _vermietungEinnahmen;
            set
            {
                if (SetField(ref _vermietungEinnahmen, value))
                {
                    GlobalState.Instance.PrivatDaten.VermietungEinnahmen = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _vermietungWerbungskosten = "";
        public string VermietungWerbungskosten
        {
            get => _vermietungWerbungskosten;
            set
            {
                if (SetField(ref _vermietungWerbungskosten, value))
                {
                    GlobalState.Instance.PrivatDaten.VermietungWerbungskosten = ParseDecimal(value);
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

        private string _summeBetriebsausgaben = "";
        public string SummeBetriebsausgaben
        {
            get => _summeBetriebsausgaben;
            set
            {
                if (SetField(ref _summeBetriebsausgaben, value))
                {
                    GlobalState.Instance.PrivatDaten.SummeBetriebsausgaben = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _ustConsultingGesamtbetragEntgelte = "";
        public string UstConsultingGesamtbetragEntgelte
        {
            get => _ustConsultingGesamtbetragEntgelte;
            set
            {
                if (SetField(ref _ustConsultingGesamtbetragEntgelte, value))
                {
                    GlobalState.Instance.PrivatDaten.UstConsultingGesamtbetragEntgelte = ParseDecimal(value);
                    GlobalState.Instance.NotifyDataChanged();
                }
            }
        }

        private string _ustConsultingEntgelteLeistungsempfaenger = "";
        public string UstConsultingEntgelteLeistungsempfaenger
        {
            get => _ustConsultingEntgelteLeistungsempfaenger;
            set
            {
                if (SetField(ref _ustConsultingEntgelteLeistungsempfaenger, value))
                {
                    GlobalState.Instance.PrivatDaten.UstConsultingEntgelteLeistungsempfaenger = ParseDecimal(value);
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
            _kapitalvermoegenEinnahmen = d.KapitalvermoegenEinnahmen > 0 ? d.KapitalvermoegenEinnahmen.ToString("N0") : "";
            _kapitalvermoegenWerbungskosten = d.KapitalvermoegenWerbungskosten > 0 ? d.KapitalvermoegenWerbungskosten.ToString("N0") : "";
            _nichtselbstEinnahmen = d.NichtselbstEinnahmen > 0 ? d.NichtselbstEinnahmen.ToString("N0") : "";

            decimal nichtselbstWerbungskosten = d.NichtselbstWerbungskosten > 0
                ? d.NichtselbstWerbungskosten
                : d.Werbungskosten;
            _nichtselbstWerbungskosten = nichtselbstWerbungskosten > 0 ? nichtselbstWerbungskosten.ToString("N0") : "";
            _werbungskosten = _nichtselbstWerbungskosten;

            _sonstigeEinnahmen = d.SonstigeEinnahmen > 0 ? d.SonstigeEinnahmen.ToString("N0") : "";
            _sonstigeWerbungskosten = d.SonstigeWerbungskosten > 0 ? d.SonstigeWerbungskosten.ToString("N0") : "";
            _vermietungEinnahmen = d.VermietungEinnahmen > 0 ? d.VermietungEinnahmen.ToString("N0") : "";
            _vermietungWerbungskosten = d.VermietungWerbungskosten > 0 ? d.VermietungWerbungskosten.ToString("N0") : "";
            _summeBetriebseinnahmen = d.SummeBetriebseinnahmen > 0 ? d.SummeBetriebseinnahmen.ToString("N0") : "";
            _summeBetriebsausgaben = d.SummeBetriebsausgaben > 0 ? d.SummeBetriebsausgaben.ToString("N0") : "";
            _ustConsultingGesamtbetragEntgelte = d.UstConsultingGesamtbetragEntgelte > 0 ? d.UstConsultingGesamtbetragEntgelte.ToString("N0") : "";
            _ustConsultingEntgelteLeistungsempfaenger = d.UstConsultingEntgelteLeistungsempfaenger > 0 ? d.UstConsultingEntgelteLeistungsempfaenger.ToString("N0") : "";

            UpdateLeistungVisibility();
        }

        private bool _showEinkommensteuer;
        public bool ShowEinkommensteuer
        {
            get => _showEinkommensteuer;
            private set => SetField(ref _showEinkommensteuer, value);
        }

        private bool _showKapitalvermoegen;
        public bool ShowKapitalvermoegen
        {
            get => _showKapitalvermoegen;
            private set => SetField(ref _showKapitalvermoegen, value);
        }

        private bool _showNichtselbst;
        public bool ShowNichtselbst
        {
            get => _showNichtselbst;
            private set => SetField(ref _showNichtselbst, value);
        }

        private bool _showSonstige;
        public bool ShowSonstige
        {
            get => _showSonstige;
            private set => SetField(ref _showSonstige, value);
        }

        private bool _showVermietung;
        public bool ShowVermietung
        {
            get => _showVermietung;
            private set => SetField(ref _showVermietung, value);
        }

        private bool _showGewerbe;
        public bool ShowGewerbe
        {
            get => _showGewerbe;
            private set => SetField(ref _showGewerbe, value);
        }

        private bool _showUstConsulting;
        public bool ShowUstConsulting
        {
            get => _showUstConsulting;
            private set => SetField(ref _showUstConsulting, value);
        }

        private void UpdateLeistungVisibility()
        {
            var leistungen = GlobalState.Instance.PrivatDaten.Leistungen.Select(l => l.Name).ToList();

            ShowEinkommensteuer = leistungen.Any(n => n.StartsWith("Einkommensteuer", StringComparison.OrdinalIgnoreCase));
            ShowKapitalvermoegen = leistungen.Any(n => n.Contains("Kapitalverm", StringComparison.OrdinalIgnoreCase));
            ShowNichtselbst = leistungen.Any(n => n.Contains("nichtselbst", StringComparison.OrdinalIgnoreCase));
            ShowSonstige = leistungen.Any(n => n.Contains("sonst", StringComparison.OrdinalIgnoreCase));
            ShowVermietung = leistungen.Any(n => n.Contains("Vermiet", StringComparison.OrdinalIgnoreCase));
            ShowGewerbe = leistungen.Any(n => n.Contains("Gewerbe", StringComparison.OrdinalIgnoreCase));
            ShowUstConsulting = leistungen.Any(n => n.Contains("USt", StringComparison.OrdinalIgnoreCase));
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
