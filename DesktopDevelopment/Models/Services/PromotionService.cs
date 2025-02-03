using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class PromotionService : BaseService<PromotionsDto, Promotion>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Promotion model)
        {
            if (model.PromotionId == default)
            {
                DatabaseContext.Promotions.Add(model);
                DatabaseContext.SaveChanges();
            }
            else
            {
                UpdateModel(model);
            }

        }

        public override void DeleteModel(PromotionsDto model)
        {
            Promotion entity = DatabaseContext.Promotions.First(item => item.PromotionId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Promotion GetModel(int id)
        {
            return DatabaseContext.Promotions.First(item => item.PromotionId == id);
        }

        public override List<PromotionsDto> GetModels()
        {
            IQueryable<Promotion> entities = DatabaseContext.Promotions.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.PromotionName.Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<PromotionsDto> entitiesDto = entities.Select(item => new PromotionsDto()
            {
                Id = item.PromotionId,
                PromotionName = item.PromotionName,
                DiscountPercentage = item.DiscountPercentage,
                EndDate = item.EndDate,
                StartDate = item.StartDate
            });
            return entitiesDto.ToList();
        }
        public override Promotion CreateModel()
        {
            return new Promotion()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Promotion model)
        {
            DatabaseContext.Promotions.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
