using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class PaymentMethodViewModel : BaseCreateViewModel<PaymentMethodService, PaymentMethodDto, PaymentMethod>
    {
        public string MethodName
        {
            get => Model.MethodName;
            set
            {
                if (Model.MethodName != value)
                {
                    Model.MethodName = value.Trim();
                    OnPropertyChanged(() => MethodName);
                }
            }
        }
        public PaymentMethodViewModel() : base("Payment Method")
        {
        }
        public PaymentMethodViewModel(int id) : base(id, "Payment Method")
        {
        }
    }
}
