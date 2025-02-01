using CommunityToolkit.Mvvm.Messaging;
using DesktopDevelopment.Helpers;
using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;
using DesktopDevelopment.ViewModels.Single;

namespace DesktopDevelopment.ViewModels.Many
{
    public class PromotionsViewModel : BaseManyViewModel<PromotionService, PromotionsDto, Promotion>
    {
        public PromotionsViewModel() : base("Promotions")
        {
        }
        protected override void CreateNew()
        {
            WeakReferenceMessenger.Default.Send<OpenViewMessage>(new OpenViewMessage()
            {
                Sender = this,
                ViewModelToBeOpened = new PromotionViewModel()
            });
        }
    }
}
