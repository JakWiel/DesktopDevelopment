using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class UserRoleViewModel : BaseManyViewModel<UserRoleService, UserRoleDto, UserRole>
    {
        public UserRoleViewModel() : base("User Roles")
        {
        }
    }
}
