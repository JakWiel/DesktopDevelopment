using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class EmployeeViewModel : BaseCreateViewModel<EmployeeService, EmployeeDto, Employee>
    {
        public string FullName
        {
            get => Model.FullName;
            set
            {
                if (Model.FullName != value)
                {
                    Model.FullName = value;
                    OnPropertyChanged(() => FullName);
                }
            }
        }

        public string Email
        {
            get => Model.Email;
            set
            {
                if (Model.Email != value)
                {
                    Model.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        public string PhoneNumber
        {
            get => Model.PhoneNumber;
            set
            {
                if (Model.PhoneNumber != value)
                {
                    Model.PhoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }

        public string Role
        {
            get => Model.Role.RoleName;
            set
            {
                if (Model.Role.RoleName != value)
                {
                    Model.Role.RoleName = value;
                    OnPropertyChanged(() => Role);
                }
            }
        }

        public EmployeeViewModel() : base("New Employee")
        {
        }
    }
}
