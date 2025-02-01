using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class UserRolesViewModel : BaseManyViewModel<UserRoleService, UserRoleDto, UserRole>
    {
        public UserRolesViewModel() : base("User Roles")
        {
        }
        protected override void CreateNew()
        {

        }
    }
}
