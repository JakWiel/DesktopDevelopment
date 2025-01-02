using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class OrderStatusViewModel : BaseManyViewModel<OrderStatusService, OrderStatusDto, OrderStatus>
    {
        public OrderStatusViewModel() : base("Order Status")
        {
        }
    }
}

