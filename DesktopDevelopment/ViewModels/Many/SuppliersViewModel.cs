using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    class SuppliersViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<SuppliersDto> suppliers;
        public ObservableCollection<SuppliersDto> Suppliers
        {
            get { return suppliers; }
            set
            {
                if (suppliers != value)
                {
                    suppliers = value;
                    OnPropertyChanged(() => Suppliers);
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

        public SuppliersViewModel()
        {
            DisplayName = "Suppliers";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Supplier> supplier = database.Suppliers.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                supplier = supplier.Where(item => item.SupplierName.Contains(searchInput));
            }
            IQueryable<SuppliersDto> categoryDto = supplier.Select(item => new SuppliersDto()
            {
                Id = item.SupplierId,
                SupplierName = item.SupplierName,
                ContactInfo = item.ContactInfo
            });

            Suppliers = new ObservableCollection<SuppliersDto>(categoryDto.ToList());
        }
    }
}
