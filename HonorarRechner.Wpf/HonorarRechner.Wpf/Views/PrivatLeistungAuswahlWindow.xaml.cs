using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using HonorarRechner.Wpf.ViewModels;

namespace HonorarRechner.Wpf.Views
{
    public partial class PrivatLeistungAuswahlWindow : Window
    {
        public ObservableCollection<PrivatLeistungOption> Optionen { get; }
        public PrivatLeistungOption? SelectedOption { get; set; }

        public PrivatLeistungAuswahlWindow(ObservableCollection<PrivatLeistungOption> optionen,
            PrivatLeistungOption? selectedOption)
        {
            InitializeComponent();
            Optionen = optionen;
            SelectedOption = selectedOption;
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
    }
}
