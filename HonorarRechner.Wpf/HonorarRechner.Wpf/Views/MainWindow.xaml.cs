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

        // --- Start ---
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
            if (typ == "Unternehmen") ShowUnternehmensView();
            else MessageBox.Show("Privat-Mandanten-Maske kommt später 😊");
        }

        // --- Unternehmensdaten ---
        private void ShowUnternehmensView()
        {
            var view = new UnternehmensView();
            var vm = new UnternehmensViewModel();
            vm.ZurueckRequested += ShowStartView;
            vm.WeiterRequested += ShowLeistungenView;
            view.DataContext = vm;
            MainContent.Content = view;
        }

        // --- Leistungen Übersicht ---
        private void ShowLeistungenView()
        {
            var view = new LeistungenView();
            var vm = new LeistungenViewModel();
            vm.ZurueckRequested += ShowUnternehmensView;

            vm.NavigateToFibuRequested += ShowFibuView;
            vm.NavigateToJaRequested += ShowJaAuswahlView;
            vm.NavigateToLohnRequested += ShowLohnView; // NEU

            view.DataContext = vm;
            MainContent.Content = view;
        }

        // --- Details Views ---
        private void ShowFibuView()
        {
            var view = new FibuView();
            var vm = new FibuViewModel();
            vm.ZurueckRequested += ShowLeistungenView;
            view.DataContext = vm;
            MainContent.Content = view;
        }

        private void ShowJaAuswahlView()
        {
            var view = new JaAuswahlView();
            var vm = new JaAuswahlViewModel();
            vm.ZurueckRequested += ShowLeistungenView;
            vm.OpenEuerRequested += ShowEuerView;
            vm.OpenBilanzRequested += ShowBilanzView;
            view.DataContext = vm;
            MainContent.Content = view;
        }

        private void ShowEuerView()
        {
            var view = new EuerView();
            var vm = new EuerViewModel();
            vm.ZurueckRequested += ShowJaAuswahlView;
            view.DataContext = vm;
            MainContent.Content = view;
        }

        private void ShowBilanzView()
        {
            var view = new BilanzView();
            var vm = new BilanzViewModel();
            vm.ZurueckRequested += ShowJaAuswahlView;
            view.DataContext = vm;
            MainContent.Content = view;
        }

        // NEU: Lohn View anzeigen
        private void ShowLohnView()
        {
            var view = new LohnView();
            var vm = new LohnViewModel();
            vm.ZurueckRequested += ShowLeistungenView;
            view.DataContext = vm;
            MainContent.Content = view;
        }
    }
}