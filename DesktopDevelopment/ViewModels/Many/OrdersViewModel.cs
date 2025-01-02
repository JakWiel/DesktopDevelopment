using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    class OrdersViewModel : BaseManyViewModel<OrderService, OrdersDto, Order>
    {
        public OrdersViewModel() : base("Orders")
        {
        }

    }
}
