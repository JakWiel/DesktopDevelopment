using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class UserRoleViewModel : BaseCreateViewModel<UserRoleService, UserRoleDto, UserRole>
    {
        public string Name
        {
            get => Model.RoleName;
            set
            {
                if (Model.RoleName != value)
                {
                    Model.RoleName = value.Trim();
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public UserRoleViewModel() : base("New User Role")
        {
        }
        public UserRoleViewModel(int id) : base(id, "New User Role")
        {
        }
    }
}
