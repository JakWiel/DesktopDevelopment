using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using DesktopDevelopment.ViewModels.Single;

namespace DesktopDevelopment.ViewModels.Many
{
    class OrderDetailsViewModel : BaseManyViewModel<OrderDetailService, OrderDetailsDto, OrderDetail>
    {
        public OrderDetailsViewModel() : base("Order Details")
        {
        }
        protected override void CreateNew()
        {
            WeakReferenceMessenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                Sender = this,
                ViewModelToBeOpened = new OrderDetailViewModel()
            });
        }
    }
}
