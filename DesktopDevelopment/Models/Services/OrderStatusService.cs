using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class OrderStatusService : BaseService<OrderStatusDto, OrderStatus>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(OrderStatus model)
        {
            DatabaseContext.OrderStatuses.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(OrderStatusDto model)
        {
            OrderStatus entity = DatabaseContext.OrderStatuses.First(item => item.StatusId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override OrderStatus GetModel(int id)
        {
            return DatabaseContext.OrderStatuses.First(item => item.StatusId == id);
        }

        public override List<OrderStatusDto> GetModels()
        {
            IQueryable<OrderStatus> entities = DatabaseContext.OrderStatuses.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.StatusName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<OrderStatusDto> entitiesDto = entities.Select(item => new OrderStatusDto()
            {
                Id = item.StatusId,
                Description = item.Description,
                StatusName = item.StatusName,
            });
            return entitiesDto.ToList();
        }
        public override OrderStatus CreateModel()
        {
            return new OrderStatus()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(OrderStatus model)
        {
            DatabaseContext.OrderStatuses.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
