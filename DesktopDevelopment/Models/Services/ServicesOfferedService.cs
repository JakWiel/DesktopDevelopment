using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class ServicesOfferedService : BaseService<ServicesOfferedDto, ServicesOffered>
    {
        public override void AddModel(ServicesOffered model)
        {
            DatabaseContext.ServicesOffereds.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(ServicesOfferedDto model)
        {
            ServicesOffered entity = DatabaseContext.ServicesOffereds.First(item => item.ServiceId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override ServicesOffered GetModel(int id)
        {
            return DatabaseContext.ServicesOffereds.First(item => item.ServiceId == id);

        }

        public override List<ServicesOfferedDto> GetModels()
        {
            IQueryable<ServicesOffered> entities = DatabaseContext.ServicesOffereds.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.ServiceName.Contains(SearchInput));
            }
            IQueryable<ServicesOfferedDto> entitiesDto = entities.Select(item => new ServicesOfferedDto()
            {
                Id = item.ServiceId,
                ServiceName = item.ServiceName,
                Description = item.Description,
                Price = item.Price
            });
            return entitiesDto.ToList();
        }
        public override ServicesOffered CreateModel()
        {
            return new ServicesOffered()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(ServicesOffered model)
        {
            DatabaseContext.ServicesOffereds.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
