using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopDevelopment.Views.Many
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
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
