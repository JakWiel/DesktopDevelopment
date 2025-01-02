using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    class OrderDetailsViewModel : BaseManyViewModel<OrderDetailService, OrderDetailsDto, OrderDetail>
    {
        public OrderDetailsViewModel() : base("Order Details")
        {
        }
    }
}
