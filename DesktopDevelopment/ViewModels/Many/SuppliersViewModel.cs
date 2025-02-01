using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using DesktopDevelopment.ViewModels.Single;

namespace DesktopDevelopment.ViewModels.Many
{
    public class SuppliersViewModel : BaseManyViewModel<SupplierService, SuppliersDto, Supplier>
    {
        public SuppliersViewModel() : base("Suppliers")
        {
        }
        protected override void CreateNew()
        {
            WeakReferenceMessenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                Sender = this,
                ViewModelToBeOpened = new SupplierViewModel()
            });
        }
    }
}
