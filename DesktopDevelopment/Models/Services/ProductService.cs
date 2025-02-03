using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class ProductService : BaseService<ProductDto, Product>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Product model)
        {
            DatabaseContext.Products.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ProductDto model)
        {
            Product entity = DatabaseContext.Products.First(item => item.ProductId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Product GetModel(int id)
        {
            return DatabaseContext.Products.First(item => item.ProductId == id);
        }

        public override List<ProductDto> GetModels()
        {
            IQueryable<Product> entities = DatabaseContext.Products.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.ProductName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<ProductDto> entitiesDto = entities.Select(item => new ProductDto()
            {
                Id = item.ProductId,
                ProductName = item.ProductName,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = item.DateCreated.Date,
            });
            return entitiesDto.ToList();
        }
        public override Product CreateModel()
        {
            return new Product()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Product model)
        {
            DatabaseContext.Products.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
