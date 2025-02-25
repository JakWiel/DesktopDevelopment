﻿using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class CategoryService : BaseService<CategoriesDto, Category>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Category model)
        {

            if (model.CategoryId == default)
            {
                DatabaseContext.Categories.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }
        }

        public override void DeleteModel(CategoriesDto model)
        {
            Category entity = DatabaseContext.Categories.First(item => item.CategoryId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Category GetModel(int id)
        {
            return DatabaseContext.Categories.First(item => item.CategoryId == id);
        }

        public override List<CategoriesDto> GetModels()
        {
            IQueryable<Category> entities = DatabaseContext.Categories.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.CategoryName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<CategoriesDto> entitiesDto = entities.Select(item => new CategoriesDto()
            {
                Id = item.CategoryId,
                CategoryName = item.CategoryName,
                Description = item.Description
            });
            return entitiesDto.ToList();
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
