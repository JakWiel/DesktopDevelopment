using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class UserRoleService : BaseService<UserRoleDto, UserRole>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(UserRole model)
        {
            DatabaseContext.UserRoles.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(UserRoleDto model)
        {
            UserRole entity = DatabaseContext.UserRoles.First(item => item.RoleId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override UserRole GetModel(int id)
        {
            return DatabaseContext.UserRoles.First(item => item.RoleId == id);
        }

        public override List<UserRoleDto> GetModels()
        {
            IQueryable<UserRole> entities = DatabaseContext.UserRoles.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.RoleName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<UserRoleDto> entitiesDto = entities.Select(item => new UserRoleDto()
            {
                Id = item.RoleId,
                Name = item.RoleName
            });
            return entitiesDto.ToList();
        }
        public override UserRole CreateModel()
        {
            return new UserRole()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(UserRole model)
        {
            DatabaseContext.UserRoles.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
