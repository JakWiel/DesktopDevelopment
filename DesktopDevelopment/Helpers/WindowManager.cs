using DesktopDevelopment.ViewModels;
using DesktopDevelopment.ViewModels.Many;
using DesktopDevelopment.Views.Many;
using System.Windows;

namespace DesktopDevelopment.Helpers
{
    public static class WindowManager
    {
        public static void OpenWindow(WorkspaceViewModel workspaceView)
        {
            Window window = new Window()
            {
                Owner = App.Current.MainWindow,
                Height = 400,
                Width = 600,
            };
            if (workspaceView.GetType() == typeof(RolesWithCallbackViewModel))
            {
                window.Content = new UserRolesView()
                {
                    DataContext = workspaceView
                };
            }
            workspaceView.RequestClose += (sender, e) =>
            {
                window.Close();
            };
            App.Current.MainWindow.Opacity = 0.5;

            window.Closing += (sender, e) =>
            {
                App.Current.MainWindow.Opacity = 1;
            };
            window.ShowDialog();
        }
    }
}
