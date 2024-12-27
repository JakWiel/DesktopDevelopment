using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    class UserRoleViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<UserRoleDto> userRoles;
        public ObservableCollection<UserRoleDto> UserRoles
        {
            get { return userRoles; }
            set
            {
                if (userRoles != value)
                {
                    userRoles = value;
                    OnPropertyChanged(() => UserRoles);
                }
            }
        }
        private string searchInput { get; set; }
        public string SearchInput
        {
            get { return searchInput; }
            set
            {
                if (searchInput != value)
                {
                    searchInput = value;
                    OnPropertyChanged(() => SearchInput);
                    Initialize();
                }
            }
        }

        public UserRoleViewModel()
        {
            DisplayName = "User Roles";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<UserRole> userRole = database.UserRoles.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                userRole = userRole.Where(item => item.RoleName.Contains(searchInput));
            }
            IQueryable<UserRoleDto> userRoleDto = userRole.Select(item => new UserRoleDto()
            {
                Id = item.RoleId,
                Name = item.RoleName,
            });

            UserRoles = new ObservableCollection<UserRoleDto>(userRoleDto.ToList());
        }
    }
}
