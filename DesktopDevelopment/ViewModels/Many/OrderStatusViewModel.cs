using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class OrderStatusViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<OrderStatusDto> orderStatuses;
        public ObservableCollection<OrderStatusDto> OrderStatuses
        {
            get { return orderStatuses; }
            set
            {
                if (orderStatuses != value)
                {
                    orderStatuses = value;
                    OnPropertyChanged(() => OrderStatuses);
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

        public OrderStatusViewModel()
        {
            DisplayName = "Order Status";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<OrderStatus> orderStatus = database.OrderStatuses.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                orderStatus = orderStatus.Where(item => item.StatusName.Contains(searchInput));
            }
            IQueryable<OrderStatusDto> orderStatusDto = orderStatus.Select(item => new OrderStatusDto()
            {
                Id = item.StatusId,
                StatusName = item.StatusName,
                Description = item.Description
            });

            OrderStatuses = new ObservableCollection<OrderStatusDto>(orderStatusDto.ToList());
        }
    }
}

