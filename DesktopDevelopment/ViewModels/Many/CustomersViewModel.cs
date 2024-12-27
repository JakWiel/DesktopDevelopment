using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class CustomersViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<CustomerDto> customers;
        public ObservableCollection<CustomerDto> Customers
        {
            get { return customers; }
            set
            {
                if (customers != value)
                {
                    customers = value;
                    OnPropertyChanged(() => Customers);
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

        public CustomersViewModel()
        {
            DisplayName = "Customers";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Category> customers = database.Customers.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                customers = customers.Where(item => item.FullName.Contains(searchInput));
            }
            IQueryable<CustomerDto> customersDto = customers.Select(item => new CustomerDto()
            {
                Id = item.CustomerId,
                FullName = item.FullName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            });

            Customers = new ObservableCollection<CustomerDto>(customersDto.ToList());
        }

    }
}
