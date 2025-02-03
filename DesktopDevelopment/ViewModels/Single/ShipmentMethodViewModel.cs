using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class ShipmentMethodViewModel : BaseCreateViewModel<ShippingMethodService, ShipmentMethodDto, ShippingMethod>
    {
        public string Name
        {
            get => Model.MethodName;
            set
            {
                if (Model.MethodName != value)
                {
                    Model.MethodName = value.Trim();
                    OnPropertyChanged(() => Name);
                }
            }
        }
        public ShipmentMethodViewModel() : base("Shipment Method")
        {
        }
        public ShipmentMethodViewModel(int id) : base(id, "Shipment Method")
        {
        }
    }
}
