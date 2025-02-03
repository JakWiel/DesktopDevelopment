using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using System;

namespace DesktopDevelopment.ViewModels.Single
{
    public class TransactionViewModel : BaseCreateViewModel<TransactionService, TransactionsDto, Transaction>
    {
        public int OrderId
        {
            get => Model.OrderId;
            set
            {
                if (Model.OrderId != value)
                {
                    Model.OrderId = value;
                    OnPropertyChanged(() => OrderId);
                }
            }
        }

        public PaymentMethod PaymentMethod
        {
            get => Model.PaymentMethod;
            set
            {
                if (Model.PaymentMethod != value)
                {
                    Model.PaymentMethod = value;
                    OnPropertyChanged(() => PaymentMethod);
                }
            }
        }

        public decimal Amount
        {
            get => Model.Amount;
            set
            {
                if (Model.Amount != value && Model.Amount > 0)
                {
                    Model.Amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }

        public DateTime TransactionDate
        {
            get => Model.TransactionDate;
            set
            {
                if (Model.TransactionDate != value)
                {
                    Model.TransactionDate = value;
                    OnPropertyChanged(() => TransactionDate);
                }
            }
        }

        public TransactionViewModel() : base("Transaction")
        {
        }
        public TransactionViewModel(int id) : base(id, "Transaction")
        {
        }
    }
}
