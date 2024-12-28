using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class CustomerReviewService : BaseService<CustomersReviewDto, CustomerReview>
    {
        public override void AddModel(CustomerReview model)
        {
            DatabaseContext.CustomerReviews.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(CustomersReviewDto model)
        {
            CustomerReview entity = DatabaseContext.CustomerReviews.First(item => item.CustomerId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override CustomerReview GetModel(int id)
        {
            return DatabaseContext.CustomerReviews.First(item => item.CustomerId == id);
        }

        public override List<CustomersReviewDto> GetModels()
        {
            IQueryable<CustomerReview> entities = DatabaseContext.CustomerReviews.Include(item => item.Customer.FullName).Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => item.Customer.FullName.Contains(SearchInput));
            }
            IQueryable<CustomersReviewDto> entitiesDto = entities.Select(item => new CustomersReviewDto()
            {
                Id = item.ReviewId,
                CustomerID = item.CustomerId,
                Comment = item.Comment,
                ProductID = item.ProductId,
                Rating = item.Rating,
                ServiceID = item.Service.ServiceId,
            });
            return entitiesDto.ToList();
        }
        public override CustomerReview CreateModel()
        {
            return new CustomerReview()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(CustomerReview model)
        {
            DatabaseContext.CustomerReviews.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
