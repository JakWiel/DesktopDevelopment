using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopDevelopment.Views.Many
{
    /// <summary>
    /// Logika interakcji dla klasy CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
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
