using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HonorarRechner.Wpf.ViewModels;

namespace HonorarRechner.Wpf.Views
{
    public partial class PrivatLeistungenView : UserControl
    {
        public PrivatLeistungenView()
        {
            InitializeComponent();
        }

        private void LeistungenList_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (LeistungenScrollViewer == null)
            {
                return;
            }

            var newOffset = LeistungenScrollViewer.VerticalOffset - e.Delta;
            LeistungenScrollViewer.ScrollToVerticalOffset(newOffset);
            e.Handled = true;
        }

        private void OpenLeistungAuswahl_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not PrivatLeistungenViewModel vm)
            {
                return;
            }

            var dialog = new PrivatLeistungAuswahlWindow(vm.LeistungOptionen, vm.SelectedLeistungOption);
            dialog.Owner = Window.GetWindow(this);
            if (dialog.Owner != null)
            {
                dialog.Width = dialog.Owner.ActualWidth;
                dialog.Height = dialog.Owner.ActualHeight;
            }

            var result = dialog.ShowDialog();
            if (result == true && dialog.SelectedOptions.Count > 0)
            {
                foreach (var option in dialog.SelectedOptions)
                {
                    vm.SelectedLeistungOption = option;
                    if (vm.AddLeistungCommand.CanExecute(null))
                    {
                        vm.AddLeistungCommand.Execute(null);
                    }
                }
            }
        }
    }
}
