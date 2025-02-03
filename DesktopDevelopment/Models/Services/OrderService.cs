using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class OrderService : BaseService<OrdersDto, Order>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Order model)
        {
            if (model.OrderId == default)
            {
                DatabaseContext.Orders.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }

        }

        public override void DeleteModel(OrdersDto model)
        {
            Order entity = DatabaseContext.Orders.First(item => item.OrderId == model.OrderId);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Order GetModel(int id)
        {
            return DatabaseContext.Orders.First(item => item.OrderId == id);
        }

        public override List<OrdersDto> GetModels()
        {
            IQueryable<Order> entities = DatabaseContext.Orders.Include(item => item.Customer).Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.Customer.FullName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<OrdersDto> entitiesDto = entities.Select(item => new OrdersDto()
            {
                OrderId = item.OrderId,
                CustomerID = item.CustomerId,
                EmployeeID = item.EmployeeId,
                OrderDate = item.OrderDate,
                StatusID = item.StatusId,
                TotalAmount = item.TotalAmount,
                CustomerFullName = item.Customer.FullName,
            });
            return entitiesDto.ToList();
        }
        public override Order CreateModel()
        {
            return new Order()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Order model)
        {
            DatabaseContext.Orders.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
