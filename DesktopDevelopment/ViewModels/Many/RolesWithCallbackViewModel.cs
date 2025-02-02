using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models.Dtos;

namespace DesktopDevelopment.ViewModels.Many
{
    public class RolesWithCallbackViewModel : UserRolesViewModel
    {
        public object WhoRequsetedToSelect { get; set; }
        public RolesWithCallbackViewModel(object whoRequsetedToSelect)
        {
            WhoRequsetedToSelect = whoRequsetedToSelect;
        }
        protected override void HandleSelect()
        {
            WeakReferenceMessenger.Default.Send<SelectedObjectMessage<UserRoleDto>>(new SelectedObjectMessage<UserRoleDto>(WhoRequsetedToSelect, SelectedModel!));
            OnRequestClose();
        }
    }
}
