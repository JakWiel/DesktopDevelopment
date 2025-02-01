using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class CustomersReviewsViewModel : BaseManyViewModel<CustomerReviewService, CustomersReviewDto, CustomerReview>
    {
        public CustomersReviewsViewModel() : base("Customers Reviews")
        {
        }
        protected override void CreateNew()
        {
        }
    }
}
