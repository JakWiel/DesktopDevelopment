using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class CustomerService : BaseService<CustomerDto, Customer>
    {
        public override void AddModel(Customer model)
        {
            DatabaseContext.Customers.Add(model);
            DatabaseContext.SaveChanges();
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
            IQueryable<Customer> entities = DatabaseContext.Customers.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.FullName.Contains(SearchInput));
            }
            IQueryable<CustomerDto> entitiesDto = entities.Select(item => new CustomerDto()
            {
                Id = item.CustomerId,
                FullName = item.FullName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber
            });
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
