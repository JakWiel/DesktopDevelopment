using DesktopDevelopment.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopDevelopment.Models.Services
{
    public class TransactionService : BaseService<TransactionsDto, Transaction>
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
        public override void AddModel(Transaction model)
        {
            DatabaseContext.Transactions.Add(model);
            DatabaseContext.SaveChanges();
        }

        public override void DeleteModel(TransactionsDto model)
        {
            Transaction entity = DatabaseContext.Transactions.First(item => item.TransactionId == model.Id);
            entity.IsActive = false;
            entity.DateDeleted = DateTime.Now;
            DatabaseContext.SaveChanges();
        }

        public override Transaction GetModel(int id)
        {
            return DatabaseContext.Transactions.First(item => item.TransactionId == id);
        }

        public override List<TransactionsDto> GetModels()
        {
            IQueryable<Transaction> entities = DatabaseContext.Transactions.Where(item => item.IsActive);
            if (!string.IsNullOrEmpty(SearchInput))
            {
                entities = entities.Where(item => (item.TransactionId + "").Contains(SearchInput));
            }
            if (CreatedFrom != null)
            {
                entities = entities.Where(item => item.DateCreated >= CreatedFrom);
            }
            if (CreatedTo != null)
            {
                entities = entities.Where(item => item.DateCreated <= CreatedTo);
            }
            IQueryable<TransactionsDto> entitiesDto = entities.Select(item => new TransactionsDto()
            {
                Id = item.TransactionId,
                Amount = item.Amount,
                OrderId = item.OrderId,
                PaymentMethod = item.PaymentMethod,
                TransactionDate = item.TransactionDate
            });
            return entitiesDto.ToList();
        }
        public override Transaction CreateModel()
        {
            return new Transaction()
            {
                IsActive = true,
                DateCreated = DateTime.Now,
            };
        }
        public override void UpdateModel(Transaction model)
        {
            DatabaseContext.Transactions.Update(model);
            DatabaseContext.SaveChanges();
        }
    }
}
