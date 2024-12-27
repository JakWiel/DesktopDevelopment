using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class PromotionsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<PromotionsDto> promotions;
        public ObservableCollection<PromotionsDto> Promotions
        {
            get { return promotions; }
            set
            {
                if (promotions != value)
                {
                    promotions = value;
                    OnPropertyChanged(() => Promotions);
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

        public PromotionsViewModel()
        {
            DisplayName = "Promotions";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Promotion> promotion = database.Promotions.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                promotion = promotion.Where(item => item.PromotionName.Contains(searchInput));
            }
            IQueryable<PromotionsDto> promotionDto = promotion.Select(item => new PromotionsDto()
            {
                Id = item.PromotionId,
                PromotionName = item.PromotionName,
                DiscountPercentage = item.DiscountPercentage,
                StartDate = item.StartDate,
                EndDate = item.EndDate
            });

            Promotions = new ObservableCollection<PromotionsDto>(promotionDto.ToList());
        }
    }
}
