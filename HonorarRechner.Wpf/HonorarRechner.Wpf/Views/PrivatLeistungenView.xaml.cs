using System.Windows.Controls;
using System.Windows.Input;

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
    }
}
