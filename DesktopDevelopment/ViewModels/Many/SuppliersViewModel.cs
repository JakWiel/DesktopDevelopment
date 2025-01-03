using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class SuppliersViewModel : BaseManyViewModel<RepairTicketService, RepairTicketDto, RepairTicket>
    {
        public SuppliersViewModel() : base("Suppliers")
        {
        }
    }
}
