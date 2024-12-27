using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopDevelopment.Views.Many
{
    /// <summary>
    /// Logika interakcji dla klasy OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((Control)sender)?.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}
