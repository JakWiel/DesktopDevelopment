using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class OrderStatusViewModel : BaseCreateViewModel<OrderStatusService, OrderStatusDto, OrderStatus>
    {
        public string StatusName
        {
            get => Model.StatusName;
            set
            {
                if (Model.StatusName != value)
                {
                    Model.StatusName = value;
                    OnPropertyChanged(() => StatusName);
                }
            }
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        public OrderStatusViewModel() : base("Order Status")
        {
        }
    }
}
