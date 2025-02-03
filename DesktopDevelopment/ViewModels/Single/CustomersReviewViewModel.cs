using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using Microsoft.IdentityModel.Tokens;

namespace DesktopDevelopment.ViewModels.Single
{
    public class CustomersReviewViewModel : BaseCreateViewModel<CustomerReviewService, CustomersReviewDto, CustomerReview>
    {
        public int CustomerID
        {
            get => Model.CustomerId;
            set
            {
                if (Model.CustomerId != value)
                {
                    Model.CustomerId = value;
                    OnPropertyChanged(() => CustomerID);
                }
            }
        }

        public int ProductID
        {
            get => Model.ProductId;
            set
            {
                if (Model.ProductId != value)
                {
                    Model.ProductId = value;
                    OnPropertyChanged(() => ProductID);
                }
            }
        }

        public int ServiceID
        {
            get => Model.ServiceId;
            set
            {
                if (Model.ServiceId != value)
                {
                    Model.ServiceId = value;
                    OnPropertyChanged(() => ServiceID);
                }
            }
        }

        public int Rating
        {
            get => Model.Rating;
            set
            {
                if (Model.Rating != value)
                {
                    Model.Rating = value;
                    OnPropertyChanged(() => Rating);
                }
            }
        }

        public string Comment
        {
            get => Model.Comment;
            set
            {
                if (Model.Comment != value && !Model.Comment.IsNullOrEmpty())
                {
                    Model.Comment = value.Trim();
                    OnPropertyChanged(() => Comment);
                }
            }
        }

        public CustomersReviewViewModel() : base("New Customer Review")
        {
        }
        public CustomersReviewViewModel(int id) : base(id, "New Customer Review")
        {
        }
    }
}
