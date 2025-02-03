using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Employee model)
        {
            if (model.EmployeeId == default)
            {
                DatabaseContext.Employees.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }

        }

        public override void DeleteModel(EmployeeDto model)
        {
            Employee entity = DatabaseContext.Employees.First(item => item.EmployeeId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Employee GetModel(int id)
        {
            return DatabaseContext.Employees.First(item => item.EmployeeId == id);
        }

        public override List<EmployeeDto> GetModels()
        {
            IQueryable<Employee> entities = DatabaseContext.Employees.Where(item => item.IsActive);
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
            IQueryable<EmployeeDto> entitiesDto = entities.Select(item => new EmployeeDto()
            {
                Id = item.EmployeeId,
                FullName = item.FullName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Role = item.Role.RoleName
            });
            return entitiesDto.ToList();
        }
        public override Employee CreateModel()
        {
            return new Employee()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Employee model)
        {
            DatabaseContext.Employees.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
