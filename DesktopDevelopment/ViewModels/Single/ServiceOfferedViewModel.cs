using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class ServiceOfferedViewModel : BaseCreateViewModel<ServicesOfferedService, ServicesOfferedDto, ServicesOffered>
    {
        public string ServiceName
        {
            get => Model.ServiceName;
            set
            {
                if (Model.ServiceName != value)
                {
                    Model.ServiceName = value.Trim();
                    OnPropertyChanged(() => ServiceName);
                }
            }
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        public decimal Price
        {
            get => Model.Price;
            set
            {
                if (Model.Price != value)
                {
                    Model.Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }

        public ServiceOfferedViewModel() : base(" Service Offered")
        {
        }
        public ServiceOfferedViewModel(int id) : base(id, "Service Offered")
        {
        }
    }
}
