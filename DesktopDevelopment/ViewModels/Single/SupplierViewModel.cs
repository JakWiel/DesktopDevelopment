using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class SupplierViewModel : BaseCreateViewModel<SupplierService, SuppliersDto, Supplier>
    {
        public string SupplierName
        {
            get => Model.SupplierName;
            set
            {
                if (Model.SupplierName != value)
                {
                    Model.SupplierName = value.Trim();
                    OnPropertyChanged(() => SupplierName);
                }
            }
        }

        public string ContactInfo
        {
            get => Model.ContactInfo;
            set
            {
                if (Model.ContactInfo != value)
                {
                    Model.ContactInfo = value;
                    OnPropertyChanged(() => ContactInfo);
                }
            }
        }

        public SupplierViewModel() : base("Supplier") { }
        public SupplierViewModel(int id) : base(id, "Supplier") { }
    }
}
