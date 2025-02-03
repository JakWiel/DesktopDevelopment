using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class CustomerService : BaseService<CustomerDto, Customer>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Customer model)
        {
            if (model.CustomerId == default)
            {
                DatabaseContext.Customers.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }
        }


        public override void DeleteModel(CustomerDto model)
        {
            Customer entity = DatabaseContext.Customers.First(item => item.CustomerId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Customer GetModel(int id)
        {
            return DatabaseContext.Customers.First(item => item.CustomerId == id);
        }

        public override List<CustomerDto> GetModels()
        {
            IQueryable<Customer> entities = DatabaseContext.Customers.Where(item => item.IsActive).Include(item => item.Role);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.FullName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<CustomerDto> entitiesDto = entities.Select(item => new CustomerDto()
            {
                Id = item.CustomerId,
                FullName = item.FullName,
                RoleId = item.RoleId,
                RoleName = item.Role.RoleName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            }); ;
            return entitiesDto.ToList();
        }
        public override Customer CreateModel()
        {
            return new Customer()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Customer model)
        {
            DatabaseContext.Customers.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
