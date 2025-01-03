using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ShipmentMethodsViewModel : BaseManyViewModel<ShippingMethodService, ShipmentMethodDto, ShippingMethod>
    {
        public ShipmentMethodsViewModel() : base("Shipment Methods")
        {
        }
    }
}

