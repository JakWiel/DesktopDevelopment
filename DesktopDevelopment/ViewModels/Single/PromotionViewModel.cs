using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using System;

namespace DesktopDevelopment.ViewModels.Single
{
    public class PromotionViewModel : BaseCreateViewModel<PromotionService, PromotionsDto, Promotion>
    {
        public string PromotionName
        {
            get => Model.PromotionName;
            set
            {
                if (Model.PromotionName != value)
                {
                    Model.PromotionName = value;
                    OnPropertyChanged(() => PromotionName);
                }
            }
        }

        public decimal DiscountPercentage
        {
            get => Model.DiscountPercentage;
            set
            {
                if (Model.DiscountPercentage != value)
                {
                    Model.DiscountPercentage = value;
                    OnPropertyChanged(() => DiscountPercentage);
                }
            }
        }

        public DateTime StartDate
        {
            get => Model.StartDate;
            set
            {
                if (Model.StartDate != value)
                {
                    Model.StartDate = value;
                    OnPropertyChanged(() => StartDate);
                }
                //}
            }
        }

        public DateTime EndDate
        {
            get => Model.EndDate;
            set
            {
                if (Model.EndDate != value)
                {
                    Model.EndDate = value;
                    OnPropertyChanged(() => EndDate);
                }
            }
        }

        public PromotionViewModel() : base("Promotion")
        {
        }
    }
}
