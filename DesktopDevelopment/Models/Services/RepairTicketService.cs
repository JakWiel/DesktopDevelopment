using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class RepairTicketService : BaseService<RepairTicketDto, RepairTicket>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(RepairTicket model)
        {
            DatabaseContext.RepairTickets.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(RepairTicketDto model)
        {
            RepairTicket entity = DatabaseContext.RepairTickets.First(item => item.RepairTicketId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override RepairTicket GetModel(int id)
        {
            return DatabaseContext.RepairTickets.First(item => item.RepairTicketId == id);
        }

        public override List<RepairTicketDto> GetModels()
        {
            IQueryable<RepairTicket> entities = DatabaseContext.RepairTickets.Where(item => item.IsActive);
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
            IQueryable<RepairTicketDto> entitiesDto = entities.Select(item => new RepairTicketDto()
            {
                Id = item.RepairTicketId,
                CustomerID = item.CustomerId,
                Description = item.Description,
                EmployeeID = item.EmployeeId,
            });
            return entitiesDto.ToList();
        }
        public override RepairTicket CreateModel()
        {
            return new RepairTicket()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(RepairTicket model)
        {
            DatabaseContext.RepairTickets.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
