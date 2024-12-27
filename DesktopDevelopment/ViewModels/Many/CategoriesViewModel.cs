using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class CategoriesViewModel : BaseManyViewModel<CategoryService, CategoriesDto, Category>
    {
        public CategoriesViewModel() : base("Categories")
        {
        }
    }
}
