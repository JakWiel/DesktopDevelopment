using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class PaymentMethodService : BaseService<PaymentMethodDto, PaymentMethod>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(PaymentMethod model)
        {
            if (model.PaymentMethodId == default)
            {
                DatabaseContext.PaymentMethods.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }

        }

        public override void DeleteModel(PaymentMethodDto model)
        {
            PaymentMethod entity = DatabaseContext.PaymentMethods.First(item => item.PaymentMethodId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override PaymentMethod GetModel(int id)
        {
            return DatabaseContext.PaymentMethods.First(item => item.PaymentMethodId == id);
        }

        public override List<PaymentMethodDto> GetModels()
        {
            IQueryable<PaymentMethod> entities = DatabaseContext.PaymentMethods.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.MethodName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<PaymentMethodDto> entitiesDto = entities.Select(item => new PaymentMethodDto()
            {
                Id = item.PaymentMethodId,
                MethodName = item.MethodName,
            });
            return entitiesDto.ToList();
        }
        public override PaymentMethod CreateModel()
        {
            return new PaymentMethod()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(PaymentMethod model)
        {
            DatabaseContext.PaymentMethods.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
