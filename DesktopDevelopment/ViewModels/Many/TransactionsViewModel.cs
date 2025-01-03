using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class TransactionsViewModel : BaseManyViewModel<TransactionService, TransactionsDto, Transaction>
    {
        public TransactionsViewModel() : base("Transactions")
        {
        }
    }
}
