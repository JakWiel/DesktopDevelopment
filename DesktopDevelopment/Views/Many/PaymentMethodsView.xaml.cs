using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopDevelopment.Views.Many
{
    /// <summary>
    /// Logika interakcji dla klasy PaymentMethodsView.xaml
    /// </summary>
    public partial class PaymentMethodsView : UserControl
    {
        public PaymentMethodsView()
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
