using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class PromotionsViewModel : BaseManyViewModel<PromotionService, PromotionsDto, Promotion>
    {
        public PromotionsViewModel() : base("Promotions")
        {
        }
    }
}
