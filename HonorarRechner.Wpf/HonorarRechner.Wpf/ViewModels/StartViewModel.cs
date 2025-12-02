using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HonorarRechner.Wpf.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public event Action<string>? MandatSelected;

        public StartViewModel()
        {
            SelectMandatCommand = new RelayCommand(p => SelectMandat(p as string));
            OpenExcelCommand = new RelayCommand(_ => OpenExcel());
            UpdateExcelCommand = new RelayCommand(_ => UpdateExcel());

            JahresHonorar = 0m;
        }

        #region Properties

        private string _selectedMandatTyp = string.Empty;
        public string SelectedMandatTyp
        {
            get => _selectedMandatTyp;
            set => SetField(ref _selectedMandatTyp, value);
        }

        private decimal _jahresHonorar;
        public decimal JahresHonorar
        {
            get => _jahresHonorar;
            set
            {
                if (SetField(ref _jahresHonorar, value))
                {
                    OnPropertyChanged(nameof(JahresHonorarText));
                    OnPropertyChanged(nameof(MonatsHonorarText));
                }
            }
        }

        public string JahresHonorarText =>
            $"Jahres Honorar: {JahresHonorar:C}";

        public string MonatsHonorarText =>
            $"Monats Honorar: {(JahresHonorar / 12m):C}";

        #endregion

        #region Commands

        public ICommand SelectMandatCommand { get; }
        public ICommand OpenExcelCommand { get; }
        public ICommand UpdateExcelCommand { get; }

        private void SelectMandat(string? typ)
        {
            if (string.IsNullOrWhiteSpace(typ))
                return;

            SelectedMandatTyp = typ;
            MandatSelected?.Invoke(typ);
        }

        private void OpenExcel()
        {
            MessageBox.Show("Excel öffnen – wird später mit Service verdrahtet.",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdateExcel()
        {
            MessageBox.Show("Excel neu einlesen – wird später mit Service verdrahtet.",
                "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetField<T>(ref T field, T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }

    /// <summary>
    /// Einfacher RelayCommand für MVVM.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) =>
            _execute(parameter);

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
