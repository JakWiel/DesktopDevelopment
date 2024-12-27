using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    class TransactionsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<TransactionsDto> transactions;
        public ObservableCollection<TransactionsDto> Transactions
        {
            get { return transactions; }
            set
            {
                if (transactions != value)
                {
                    transactions = value;
                    OnPropertyChanged(() => Transactions);
                }
            }
        }
        private string searchInput { get; set; }
        public string SearchInput
        {
            get { return searchInput; }
            set
            {
                if (searchInput != value)
                {
                    searchInput = value;
                    OnPropertyChanged(() => SearchInput);
                    Initialize();
                }
            }
        }

        public TransactionsViewModel()
        {
            DisplayName = "Transactions";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Transaction> transcation = database.Transactions.Include(item => item.Order).ThenInclude(item => item.Customer).Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                transcation = transcation.Include(item => item.Order).ThenInclude(item => item.Customer).Where(item => item.Order.Customer.FullName.Contains(searchInput));
            }
            IQueryable<TransactionsDto> transactionsDto = transcation.Include(item => item.PaymentMethod).Select(item => new TransactionsDto()
            {
                Id = item.TransactionId,
                OrderId = item.OrderId,
                PaymentMethod = item.PaymentMethod.MethodName,
                Amount = item.Amount,
                TransactionDate = item.TransactionDate,
            });

            Transactions = new ObservableCollection<TransactionsDto>(transactionsDto.ToList());
        }
    }
}
