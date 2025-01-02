using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class OrderDetailService : BaseService<OrderDetailsDto, OrderDetail>
    {
        public override void AddModel(OrderDetail model)
        {
            DatabaseContext.OrderDetails.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(OrderDetailsDto model)
        {
            OrderDetail entity = DatabaseContext.OrderDetails.First(item => item.OrderDetailId == model.OrderDetailID);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override OrderDetail GetModel(int id)
        {
            return DatabaseContext.OrderDetails.First(item => item.OrderDetailId == id);
        }

        public override List<OrderDetailsDto> GetModels()
        {
            IQueryable<OrderDetail> entities = DatabaseContext.OrderDetails.Include(item => item.Product.ProductName).Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.Product.ProductName.Contains(SearchInput));
            }
            IQueryable<OrderDetailsDto> entitiesDto = entities.Select(item => new OrderDetailsDto()
            {
                OrderDetailID = item.OrderDetailId,
                OrderID = item.OrderDetailId,
                Price = item.Price,
                ProductName = item.Product.ProductName,
                ProductID = item.ProductId,
                Quantity = item.Quantity,
            });
            return entitiesDto.ToList();
        }
        public override OrderDetail CreateModel()
        {
            return new OrderDetail()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(OrderDetail model)
        {
            DatabaseContext.OrderDetails.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
