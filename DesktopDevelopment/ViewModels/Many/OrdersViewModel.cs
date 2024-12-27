using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    class OrdersViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<OrdersDto> orders;
        public ObservableCollection<OrdersDto> Orders
        {
            get { return orders; }
            set
            {
                if (orders != value)
                {
                    orders = value;
                    OnPropertyChanged(() => Orders);
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

        public OrdersViewModel()
        {
            DisplayName = "Orders";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Order> order = database.Orders.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(searchInput))
            {
                order = order.Where(item => ("" + item.OrderId).Contains(searchInput));
            }
            IQueryable<OrdersDto> orderDto = order.Select(item => new OrdersDto()
            {
                Id = item.OrderId,
                CustomerID = item.CustomerId,
                OrderDate = item.OrderDate,
                EmployeeID = item.EmployeeId,
                StatusID = item.StatusId,
                TotalAmount = item.TotalAmount
            });

            Orders = new ObservableCollection<OrdersDto>(orderDto.ToList());
        }
    }
}
