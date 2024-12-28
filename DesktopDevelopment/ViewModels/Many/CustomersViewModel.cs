using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class CustomersViewModel : BaseManyViewModel<CustomerService, CustomerDto, Customer>
    {
        public CustomersViewModel() : base("Customers")
        {
        }
    }
}
