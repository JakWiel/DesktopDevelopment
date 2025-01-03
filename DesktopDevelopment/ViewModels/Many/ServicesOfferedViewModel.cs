using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ServicesOfferedViewModel : BaseManyViewModel<ServicesOfferedService, ServicesOfferedDto, ServicesOffered>
    {
        public ServicesOfferedViewModel() : base("Services Offered")
        {
        }
    }
}
