using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    class OrderDetailsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<OrderDetailsDto> orderDetails;
        public ObservableCollection<OrderDetailsDto> OrderDetails
        {
            get { return orderDetails; }
            set
            {
                if (orderDetails != value)
                {
                    orderDetails = value;
                    OnPropertyChanged(() => OrderDetails);
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

        public OrderDetailsViewModel()
        {
            DisplayName = "Order Details";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<OrderDetail> orderDetail = database.OrderDetails.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                orderDetail = orderDetail.Include(item => item.Product).Where(item => item.Product.ProductName.Contains(searchInput));
            }
            IQueryable<OrderDetailsDto> categoryDto = orderDetail.Select(item => new OrderDetailsDto()
            {
                OrderDetailID = item.OrderDetailId,
                OrderID = item.OrderDetailId,
                Price = item.Price,
                ProductID = item.ProductId,
                Quantity = item.Quantity
            });

            OrderDetails = new ObservableCollection<OrderDetailsDto>(categoryDto.ToList());
        }
    }
}
