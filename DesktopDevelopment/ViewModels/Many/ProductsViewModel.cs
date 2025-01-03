using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ProductsViewModel : BaseManyViewModel<ProductService, ProductDto, Product>
    {
        public ProductsViewModel() : base("Products")
        {
        }
    }
}
