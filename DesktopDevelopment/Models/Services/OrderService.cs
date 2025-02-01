﻿using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class OrderService : BaseService<OrdersDto, Order>
    {
        public override void AddModel(Order model)
        {
            DatabaseContext.Orders.Add(model);
            DatabaseContext.SaveChanges();
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
