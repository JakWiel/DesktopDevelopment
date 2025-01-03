using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class RepairTicketsViewModel : BaseManyViewModel<RepairTicketService, RepairTicketDto, RepairTicket>
    {
        public RepairTicketsViewModel() : base("Repair Tickets")
        {
        }
    }
}
