using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class PaymentMethodsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<PaymentMethodDto> paymentMethods;
        public ObservableCollection<PaymentMethodDto> PaymentMethods
        {
            get { return paymentMethods; }
            set
            {
                if (paymentMethods != value)
                {
                    paymentMethods = value;
                    OnPropertyChanged(() => PaymentMethods);
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

        public PaymentMethodsViewModel()
        {
            DisplayName = "Payment Methods";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<PaymentMethod> paymentMethod = database.PaymentMethods.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                paymentMethod = paymentMethod.Where(item => item.MethodName.Contains(searchInput));
            }
            IQueryable<PaymentMethodDto> paymentMethodDto = paymentMethod.Select(item => new PaymentMethodDto()
            {
                Id = item.PaymentMethodId,
                MethodName = item.MethodName
            });

            PaymentMethods = new ObservableCollection<PaymentMethodDto>(paymentMethodDto.ToList());
        }
    }
}
