using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using HonorarRechner.Wpf.ViewModels;

namespace HonorarRechner.Wpf.Views
{
    public partial class PrivatLeistungAuswahlWindow : Window
    {
        public ObservableCollection<PrivatLeistungOption> Optionen { get; }
        private readonly ICollectionView _optionenView;
        public PrivatLeistungOption? SelectedOption { get; set; }

        public PrivatLeistungAuswahlWindow(ObservableCollection<PrivatLeistungOption> optionen,
            PrivatLeistungOption? selectedOption)
        {
            InitializeComponent();
            Optionen = optionen;
            SelectedOption = selectedOption;
            _optionenView = CollectionViewSource.GetDefaultView(Optionen);
            _optionenView.Filter = FilterOption;
            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOption == null)
            {
                return;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OptionenList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedOption == null)
            {
                return;
            }

            DialogResult = true;
        }

        private void SucheTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _optionenView.Refresh();

            if (SelectedOption != null && !_optionenView.Cast<object>().Contains(SelectedOption))
            {
                SelectedOption = null;
                OptionenList.SelectedItem = null;
            }
        }

        private bool FilterOption(object item)
        {
            if (item is not PrivatLeistungOption option)
            {
                return false;
            }

            var suche = SucheTextBox?.Text?.Trim();
            if (string.IsNullOrWhiteSpace(suche))
            {
                return true;
            }

            return option.Name.IndexOf(suche, System.StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
