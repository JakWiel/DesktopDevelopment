using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ShipmentMethodsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<ShipmentMethodDto> shipmentMethod;
        public ObservableCollection<ShipmentMethodDto> ShipmentMethod
        {
            get { return shipmentMethod; }
            set
            {
                if (shipmentMethod != value)
                {
                    shipmentMethod = value;
                    OnPropertyChanged(() => ShipmentMethod);
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

        public ShipmentMethodsViewModel()
        {
            DisplayName = "Shipment Methods";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<ShippingMethod> shipmentMethod = database.ShippingMethods.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                shipmentMethod = shipmentMethod.Where(item => item.MethodName.Contains(searchInput));
            }
            IQueryable<ShipmentMethodDto> shipmentMethodDto = shipmentMethod.Select(item => new ShipmentMethodDto()
            {
                Id = item.ShippingMethodId,
                Name = item.MethodName,
            });

            ShipmentMethod = new ObservableCollection<ShipmentMethodDto>(shipmentMethodDto.ToList());
        }
    }
}

