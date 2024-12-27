using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class CategoryService : BaseService<CategoriesDto, Category>
    {
        public override void AddModel(Category model)
        {
            DatabaseContext.Categories.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(CategoriesDto model)
        {
            Category category = DatabaseContext.Categories.First(item => item.CategoryId == model.Id);
            category.IsActive = false;
            category.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Category GetModel(int id)
        {
            return DatabaseContext.Categories.First(item => item.CategoryId == id);
        }

        public override List<CategoriesDto> GetModels()
        {
            IQueryable<Category> categories = DatabaseContext.Categories.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                categories = categories.Where(item => item.CategoryName.Contains(SearchInput));
            }
            IQueryable<CategoriesDto> categoriesDto = categories.Select(item => new CategoriesDto()
            {
                Id = item.CategoryId,
                CategoryName = item.CategoryName,
                Description = item.Description
            });
            return categoriesDto.ToList();
        }
        public override Category CreateModel()
        {
            return new Category()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Category model)
        {
            DatabaseContext.Categories.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
