using System;
using System.Windows.Input;

namespace DesktopDevelopment.ViewModels
{
    /// <summary>
    /// This is class for element of side bar
    /// </summary>
    public class CommandViewModel : BaseViewModel
    {
        #region FieldAndProperties

        /// <summary>
        /// This is name of the button in sidebar
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Every button contains Command, that opens tab
        /// </summary>
        public ICommand Command { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        #endregion

        #region Konstruktor

        public CommandViewModel(string displayName, ICommand command, string color, string icon)
        {
            if (command == null)
                throw new ArgumentNullException("Command");
            this.DisplayName = displayName;
            this.Command = command;
            Color = color;
            Icon = icon;
        }

        #endregion
    }
}
