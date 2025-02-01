using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class CategoryViewModel : BaseCreateViewModel<CategoryService, CategoriesDto, Category>
    {
        public int Id
        {
            get => Model.CategoryId;
            set
            {
                if (Model.CategoryId != value)
                {
                    Model.CategoryId = value;
                    OnPropertyChanged(() => Id);
                }
            }
        }

        public string CategoryName
        {
            get => Model.CategoryName;
            set
            {
                if (Model.CategoryName != value)
                {
                    Model.CategoryName = value;
                    OnPropertyChanged(() => CategoryName);
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

        public CategoryViewModel() : base("Category")
        {
        }

    }
}
