using System.Windows;
using HonorarRechner.Wpf.ViewModels;
using HonorarRechner.Wpf.Views;

namespace HonorarRechner.Wpf
{
    public partial class MainWindow : Window
    {
        // WICHTIG: Hier speichern wir die Referenz, damit wir sie später benutzen können
        private readonly StartViewModel _startViewModel;

        public MainWindow()
        {
            InitializeComponent();
            // 1. ViewModel erstellen und speichern
            _startViewModel = new StartViewModel();

            // 2. Events abonnieren (Navigation)
            _startViewModel.OpenPrivateRechnerRequested += ShowPrivateFlow;

            // 3. Start-View anzeigen
            ShowStartView();
        }

        private void ShowPrivateFlow()
        {
            var vm = new PrivateDatenViewModel();

            // Navigation zurück zum Start
            vm.ZurueckRequested += ShowStartView;

            // Navigation Weiter -> zur Leistungs-Auswahl (die wir als nächstes bauen)
            vm.WeiterRequested += () =>
            {
                // Platzhalter, bis wir die PrivateLeistungenView haben
                MessageBox.Show("Hier geht es gleich weiter zur Leistungsauswahl!");
                // Später: ShowPrivateLeistungenFlow();
            };

            var view = new PrivateDatenView { DataContext = vm };
            MainContent.Content = view;
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
            else ShowPrivateFlow();
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