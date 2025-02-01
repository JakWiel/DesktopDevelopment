using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class CustomerViewModel : BaseCreateViewModel<CustomerService, CustomerDto, Customer>
    {
        public string FullName
        {
            get => Model.FullName; set
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
            get => Model.Email; set
            {
                if (Model.Email != value)
                {
                    Model.Email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }
        public string? PhoneNumber
        {
            get => Model.PhoneNumber; set
            {
                if (Model.PhoneNumber != value)
                {
                    Model.PhoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }
        public CustomerViewModel() : base("New Customer")
        {
        }

    }
}
