using System.Windows.Controls;
using System.Windows.Input;
namespace DesktopDevelopment.Views.Many
{
    /// <summary>
    /// Logika interakcji dla klasy ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
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
