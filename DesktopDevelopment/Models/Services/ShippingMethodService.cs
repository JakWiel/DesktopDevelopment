using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class ShippingMethodService : BaseService<ShipmentMethodDto, ShippingMethod>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(ShippingMethod model)
        {
            DatabaseContext.ShippingMethods.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ShipmentMethodDto model)
        {
            ShippingMethod entity = DatabaseContext.ShippingMethods.First(item => item.ShippingMethodId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override ShippingMethod GetModel(int id)
        {
            return DatabaseContext.ShippingMethods.First(item => item.ShippingMethodId == id);
        }

        public override List<ShipmentMethodDto> GetModels()
        {
            IQueryable<ShippingMethod> entities = DatabaseContext.ShippingMethods.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.MethodName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<ShipmentMethodDto> entitiesDto = entities.Select(item => new ShipmentMethodDto()
            {
                Id = item.ShippingMethodId,
                Name = item.MethodName,
            });
            return entitiesDto.ToList();
        }
        public override ShippingMethod CreateModel()
        {
            return new ShippingMethod()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(ShippingMethod model)
        {
            DatabaseContext.ShippingMethods.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
