using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class SupplierService : BaseService<SuppliersDto, Supplier>
    {
        public override void AddModel(Supplier model)
        {
            DatabaseContext.Suppliers.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(SuppliersDto model)
        {
            Supplier entity = DatabaseContext.Suppliers.First(item => item.SupplierId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Supplier GetModel(int id)
        {
            return DatabaseContext.Suppliers.First(item => item.SupplierId == id);
        }

        public override List<SuppliersDto> GetModels()
        {
            IQueryable<Supplier> entities = DatabaseContext.Suppliers.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.SupplierName.Contains(SearchInput));
            }
            IQueryable<SuppliersDto> entitiesDto = entities.Select(item => new SuppliersDto()
            {
                Id = item.SupplierId,
                SupplierName = item.SupplierName,
                ContactInfo = item.ContactInfo,
            });
            return entitiesDto.ToList();
        }
        public override Supplier CreateModel()
        {
            return new Supplier()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Supplier model)
        {
            DatabaseContext.Suppliers.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
