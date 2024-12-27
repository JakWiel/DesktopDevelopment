using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ProductsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<ProductDto> products;
        public ObservableCollection<ProductDto> Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    OnPropertyChanged(() => Products);
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

        public ProductsViewModel()
        {
            DisplayName = "Products";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Product> products = database.Products.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                products = products.Where(item => item.ProductName.Contains(searchInput));
            }
            IQueryable<ProductDto> productsDto = products.Select(item => new ProductDto()
            {
                Id = item.ProductId,
                ProductName = item.ProductName,
                Price = item.Price,
                Description = item.Description
            });

            Products = new ObservableCollection<ProductDto>(productsDto.ToList());
        }
    }
}
