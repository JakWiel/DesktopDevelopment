using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class CustomersReviewsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<CustomersReviewDto> customerReviews;
        public ObservableCollection<CustomersReviewDto> CustomerReviews
        {
            get { return customerReviews; }
            set
            {
                if (customerReviews != value)
                {
                    customerReviews = value;
                    OnPropertyChanged(() => CustomerReviews);
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

        public CustomersReviewsViewModel()
        {
            DisplayName = "Customers Reviews";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<CustomerReview> customerReview = database.CustomerReviews.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                customerReview = customerReview.Where(item => (item.CustomerId + "").Contains(searchInput));
            }
            IQueryable<CustomersReviewDto> customerReviewDto = customerReview.Select(item => new CustomersReviewDto()
            {
                Id = item.ReviewId,
                CustomerID = item.CustomerId,
                ProductID = item.ProductId,
                ServiceID = item.ServiceId,
                Rating = item.Rating,
                Comment = item.Comment
            });

            CustomerReviews = new ObservableCollection<CustomersReviewDto>(customerReviewDto.ToList());
        }
    }
}
