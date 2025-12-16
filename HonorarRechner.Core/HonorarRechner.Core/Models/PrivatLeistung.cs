using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HonorarRechner.Core.Models
{
    public class PrivatLeistung : INotifyPropertyChanged
    {
        // Der Name der Leistung (aus deiner Liste)
        public string Titel { get; set; }

        // Der Gegenstandswert für DIESE spezifische Leistung (z.B. Mieteinnahmen Objekt A)
        private decimal _gegenstandswert;
        public decimal Gegenstandswert
        {
            get => _gegenstandswert;
            set { _gegenstandswert = value; OnPropertyChanged(); }
        }

        // Das berechnete Honorar für diese Zeile
        private decimal _honorar;
        public decimal Honorar
        {
            get => _honorar;
            set { _honorar = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}