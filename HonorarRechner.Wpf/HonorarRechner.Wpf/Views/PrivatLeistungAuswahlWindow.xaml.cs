using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using HonorarRechner.Wpf.ViewModels;

namespace HonorarRechner.Wpf.Views
{
    public partial class PrivatLeistungAuswahlWindow : Window
    {
        public ObservableCollection<PrivatLeistungOption> Optionen { get; }
        private readonly ICollectionView _optionenView;
        public PrivatLeistungOption? SelectedOption { get; set; }
        public ObservableCollection<PrivatLeistungOption> SelectedOptions { get; } = new();

        public PrivatLeistungAuswahlWindow(ObservableCollection<PrivatLeistungOption> optionen,
            PrivatLeistungOption? selectedOption)
        {
            InitializeComponent();
            Optionen = optionen;
            SelectedOption = selectedOption;
            foreach (var option in Optionen)
            {
                option.AddCount = 1;
            }
            _optionenView = CollectionViewSource.GetDefaultView(Optionen);
            _optionenView.Filter = FilterOption;
            DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (OptionenList.SelectedItems.Count == 0)
            {
                return;
            }

            SelectedOptions.Clear();
            foreach (var item in OptionenList.SelectedItems.OfType<PrivatLeistungOption>())
            {
                var addCount = item.AddCount < 1 ? 1 : item.AddCount;
                for (var i = 0; i < addCount; i++)
                {
                    SelectedOptions.Add(item);
                }
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OptionenList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsFromInteractiveElement(e.OriginalSource as DependencyObject))
            {
                e.Handled = true;
                return;
            }

            if (OptionenList.SelectedItems.Count == 0)
            {
                return;
            }

            Add_Click(sender, e);
        }

        private void OptionenList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OptionenList.SelectedItems.Count == 1)
            {
                SelectedOption = OptionenList.SelectedItems[0] as PrivatLeistungOption;
            }
            else if (OptionenList.SelectedItems.Count == 0)
            {
                SelectedOption = null;
            }
        }

        private void OptionenListItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListViewItem item)
            {
                return;
            }

            if (IsFromInteractiveElement(e.OriginalSource as DependencyObject))
            {
                return;
            }

            item.IsSelected = !item.IsSelected;
            e.Handled = true;
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

        private static bool IsFromInteractiveElement(DependencyObject? source)
        {
            while (source != null)
            {
                if (source is ButtonBase || source is TextBoxBase)
                {
                    return true;
                }

                source = VisualTreeHelper.GetParent(source);
            }

            return false;
        }

        private void IncreaseItemCount_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is PrivatLeistungOption option)
            {
                option.AddCount++;
            }
        }

        private void DecreaseItemCount_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is PrivatLeistungOption option && option.AddCount > 1)
            {
                option.AddCount--;
            }
        }
    }
}
