using System.Windows;
using HonorarRechner.Wpf.ViewModels;
using HonorarRechner.Wpf.Views;

namespace HonorarRechner.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowStartView();
        }

        // ----------------- Startseite -----------------

        private void ShowStartView()
        {
            var view = new StartView();
            var vm = new StartViewModel();

            vm.MandatSelected += OnMandatSelected;

            view.DataContext = vm;
            MainContent.Content = view;
        }

        private void OnMandatSelected(string typ)
        {
            if (typ == "Unternehmen")
            {
                ShowUnternehmensView();
            }
            else if (typ == "Privat")
            {
                MessageBox.Show("Privat-Mandanten-Maske kommt später 😊",
                    "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // ----------------- Unternehmensdaten -----------------

        private void ShowUnternehmensView()
        {
            var view = new UnternehmensView();
            var vm = new UnternehmensViewModel();

            vm.ZurueckRequested += ShowStartView;
            vm.WeiterRequested += ShowLeistungenView;

            view.DataContext = vm;
            MainContent.Content = view;
        }

        // ----------------- Leistungen -----------------

        private void ShowLeistungenView()
        {
            var view = new LeistungenView();
            var vm = new LeistungenViewModel();

            vm.ZurueckRequested += ShowUnternehmensView;
            // später: vm.WeiterRequested += ShowZusammenfassungView;

            view.DataContext = vm;
            MainContent.Content = view;
        }
    }
}
