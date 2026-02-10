using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            GlobalState.Instance.DataChanged += UpdateTotals;
            UpdateTotals();
        }

        public string ViewTitle => "Privatdaten";
        public string JahresHonorarText => $"Jahres Honorar: {_jahresHonorar:C}";
        public string MonatsHonorarText => $"Monats Honorar: {(_jahresHonorar / 12m):C}";

        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }
        public ICommand ZurueckCommand { get; }
        public ICommand WeiterCommand { get; }

        public ObservableCollection<PrivatLeistungEingabeRow> EingabeZeilen { get; } = new();

        private decimal _jahresHonorar = 0m;

        private string _globalEinnahmen = "";
        public string GlobalEinnahmen
        {
            get => _globalEinnahmen;
            set
            {
                if (SetField(ref _globalEinnahmen, value))
                {
                    if (string.IsNullOrWhiteSpace(value)) return;
                    var parsed = ParseDecimal(value);
                    ApplyGlobalEinnahmen(parsed);
                }
            }
        }

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
            BuildEingabeZeilen();
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            var leistungen = GlobalState.Instance.PrivatDaten.Leistungen;
            _jahresHonorar = leistungen.Sum(l => l.Preis);
            OnPropertyChanged(nameof(JahresHonorarText));
            OnPropertyChanged(nameof(MonatsHonorarText));
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

        private void BuildEingabeZeilen()
        {
            EingabeZeilen.Clear();

            var defaultsUsed = new HashSet<LeistungArt>();
            var leistungen = GlobalState.Instance.PrivatDaten.Leistungen;
            int index = 0;

            foreach (var leistung in leistungen)
            {
                index++;
                var art = GetLeistungArt(leistung.Name);
                if (art == LeistungArt.None)
                {
                    continue;
                }

                ApplyDefaultsIfMissing(leistung, art, defaultsUsed);
                EingabeZeilen.Add(new PrivatLeistungEingabeRow(leistung, art, index));
            }
        }

        private void ApplyGlobalEinnahmen(decimal value)
        {
            foreach (var row in EingabeZeilen)
            {
                row.ApplyGlobalEinnahmen(value);
            }
        }

        private void ApplyDefaultsIfMissing(PrivatLeistung leistung, LeistungArt art, HashSet<LeistungArt> defaultsUsed)
        {
            if (defaultsUsed.Contains(art))
            {
                return;
            }

            if (leistung.EingabeWert1 != 0m || leistung.EingabeWert2 != 0m)
            {
                defaultsUsed.Add(art);
                return;
            }

            var d = GlobalState.Instance.PrivatDaten;
            switch (art)
            {
                case LeistungArt.Einkommensteuer:
                    leistung.EingabeWert1 = d.SummePositiveEinkuenfte;
                    break;
                case LeistungArt.Kapitalvermoegen:
                    leistung.EingabeWert1 = d.KapitalvermoegenEinnahmen;
                    break;
                case LeistungArt.Nichtselbst:
                    leistung.EingabeWert1 = d.NichtselbstEinnahmen;
                    break;
                case LeistungArt.Sonstige:
                    leistung.EingabeWert1 = d.SonstigeEinnahmen;
                    break;
                case LeistungArt.Vermietung:
                    leistung.EingabeWert1 = d.VermietungEinnahmen;
                    break;
                case LeistungArt.Gewerbe:
                    leistung.EingabeWert1 = d.SummeBetriebseinnahmen;
                    leistung.EingabeWert2 = d.SummeBetriebsausgaben;
                    break;
                case LeistungArt.UstConsulting:
                    leistung.EingabeWert1 = d.UstConsultingGesamtbetragEntgelte;
                    leistung.EingabeWert2 = d.UstConsultingEntgelteLeistungsempfaenger;
                    break;
            }

            defaultsUsed.Add(art);
        }

        private static LeistungArt GetLeistungArt(string name)
        {
            if (name.StartsWith("Einkommensteuer", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Einkommensteuer;
            }

            if (name.Contains("Kapitalverm", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Kapitalvermoegen;
            }

            if (name.Contains("nichtselbst", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Nichtselbst;
            }

            if (name.Contains("sonst", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Sonstige;
            }

            if (name.Contains("Vermiet", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Vermietung;
            }

            if (name.Contains("Gewerbe", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.Gewerbe;
            }

            if (name.Contains("USt", StringComparison.OrdinalIgnoreCase))
            {
                return LeistungArt.UstConsulting;
            }

            return LeistungArt.None;
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

    public enum LeistungArt
    {
        None,
        Einkommensteuer,
        Kapitalvermoegen,
        Nichtselbst,
        Sonstige,
        Vermietung,
        Gewerbe,
        UstConsulting
    }

    public class PrivatLeistungEingabeRow : INotifyPropertyChanged
    {
        private readonly PrivatLeistung _leistung;
        private readonly LeistungArt _art;
        private readonly int _index;

        private string _wert1;
        private string _wert2;

        public PrivatLeistungEingabeRow(PrivatLeistung leistung, LeistungArt art, int index)
        {
            _leistung = leistung;
            _art = art;
            _index = index;

            _wert1 = leistung.EingabeWert1 > 0m ? leistung.EingabeWert1.ToString("N0") : "";
            _wert2 = leistung.EingabeWert2 > 0m ? leistung.EingabeWert2.ToString("N0") : "";
        }

        public string LeistungName => BuildLeistungLabel();
        public string Nummerierung => $"{_index})";
        public int Index => _index - 1;
        public bool HasWert2 => _art == LeistungArt.Gewerbe || _art == LeistungArt.UstConsulting;
        public string Wert1Hint => GetWert1Hint();
        public string Wert2Hint => GetWert2Hint();

        public string Wert1
        {
            get => _wert1;
            set
            {
                if (SetField(ref _wert1, value))
                {
                    SetWert1Internal(ParseDecimalInput(value), true);
                }
            }
        }

        public string Wert2
        {
            get => _wert2;
            set
            {
                if (SetField(ref _wert2, value))
                {
                    _leistung.EingabeWert2 = ParseDecimalInput(value);
                    SyncGlobalWerte();
                }
            }
        }

        private void SyncGlobalWerte()
        {
            var d = GlobalState.Instance.PrivatDaten;
            switch (_art)
            {
                case LeistungArt.Einkommensteuer:
                    d.SummePositiveEinkuenfte = _leistung.EingabeWert1;
                    break;
                case LeistungArt.Kapitalvermoegen:
                    d.KapitalvermoegenEinnahmen = _leistung.EingabeWert1;
                    d.KapitalvermoegenWerbungskosten = 0m;
                    break;
                case LeistungArt.Nichtselbst:
                    d.NichtselbstEinnahmen = _leistung.EingabeWert1;
                    d.NichtselbstWerbungskosten = 0m;
                    d.Werbungskosten = 0m;
                    break;
                case LeistungArt.Sonstige:
                    d.SonstigeEinnahmen = _leistung.EingabeWert1;
                    d.SonstigeWerbungskosten = 0m;
                    break;
                case LeistungArt.Vermietung:
                    d.VermietungEinnahmen = _leistung.EingabeWert1;
                    d.VermietungWerbungskosten = 0m;
                    break;
                case LeistungArt.Gewerbe:
                    d.SummeBetriebseinnahmen = _leistung.EingabeWert1;
                    d.SummeBetriebsausgaben = _leistung.EingabeWert2;
                    break;
                case LeistungArt.UstConsulting:
                    d.UstConsultingGesamtbetragEntgelte = _leistung.EingabeWert1;
                    d.UstConsultingEntgelteLeistungsempfaenger = _leistung.EingabeWert2;
                    break;
            }

            GlobalState.Instance.NotifyDataChanged();
        }

        public void ApplyGlobalEinnahmen(decimal value)
        {
            SetWert1Internal(value, true);
        }

        private void SetWert1Internal(decimal value, bool syncGlobal)
        {
            _leistung.EingabeWert1 = value;
            _wert1 = value > 0m ? value.ToString("N0") : "";
            OnPropertyChanged(nameof(Wert1));
            if (syncGlobal)
            {
                SyncGlobalWerte();
            }
        }

        private static decimal ParseDecimalInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0m;
            string clean = input.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(clean, out decimal res)) return res;
            return 0m;
        }

        private string BuildLeistungLabel()
        {
            return _leistung.Name;
        }

        private string GetWert1Hint()
        {
            return _art switch
            {
                LeistungArt.Gewerbe => "Betriebseinnahmen",
                LeistungArt.UstConsulting => "Gesamtbetrag Entgelte",
                _ => "Einnahmen"
            };
        }

        private string GetWert2Hint()
        {
            return _art switch
            {
                LeistungArt.Gewerbe => "Betriebsausgaben",
                LeistungArt.UstConsulting => "Entgelte Leistungsempfaenger",
                _ => ""
            };
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
