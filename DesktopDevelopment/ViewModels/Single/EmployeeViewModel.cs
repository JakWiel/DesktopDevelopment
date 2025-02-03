using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using DesktopDevelopment.ViewModels.Many;
using System.Windows.Input;

namespace DesktopDevelopment.ViewModels.Single
{
    public class EmployeeViewModel : BaseCreateViewModel<EmployeeService, EmployeeDto, Employee>
    {
        public ICommand SelectRoleCommand { get; set; }
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

        private int _RoleId;
        public int RoleId
        {
            get => _RoleId;
            set
            {
                if (value != _RoleId)
                {
                    Model.RoleId = value;
                    OnPropertyChanged(() => RoleId);
                }
            }
        }
        private string _RoleName;
        public string RoleName
        {
            get => _RoleName;
            set
            {
                if (value != _RoleName)
                {
                    _RoleName = value;
                    OnPropertyChanged(() => RoleName);
                }
            }
        }

        public EmployeeViewModel() : base("New Employee")
        {
            SelectRoleCommand = new BaseCommand(() => SelectRole());
            RoleName = "Select Role";
            WeakReferenceMessenger.Default.Register<SelectedObjectMessage<UserRoleDto>>(this, (recipient, message) => GetSelectedRole(message));
        }
        public EmployeeViewModel(int id) : base(id, "New Employee")
        {
            SelectRoleCommand = new BaseCommand(() => SelectRole());
            RoleName = "Select Role";
            WeakReferenceMessenger.Default.Register<SelectedObjectMessage<UserRoleDto>>(this, (recipient, message) => GetSelectedRole(message));
        }
        private void SelectRole()
        {
            WindowManager.OpenWindow(new RolesWithCallbackViewModel(this));
        }
        private void GetSelectedRole(SelectedObjectMessage<UserRoleDto> message)
        {
            if (message.WhoRequestedToSelect == this)
            {
                RoleId = message.SelectedObject.Id;
                RoleName = message.SelectedObject.Name;
            }
        }
    }
}
