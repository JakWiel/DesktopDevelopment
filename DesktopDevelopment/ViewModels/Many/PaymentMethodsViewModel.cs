using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class PaymentMethodsViewModel : BaseManyViewModel<PaymentMethodService, PaymentMethodDto, PaymentMethod>
    {
        public PaymentMethodsViewModel() : base("Payment Methods")
        {
        }
    }
}
