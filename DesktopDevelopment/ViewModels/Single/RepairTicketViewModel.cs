using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Single
{
    public class RepairTicketViewModel : BaseCreateViewModel<RepairTicketService, RepairTicketDto, RepairTicket>
    {
        public int CustomerID
        {
            get => Model.CustomerId;
            set
            {
                if (Model.CustomerId != value)
                {
                    Model.CustomerId = value;
                    OnPropertyChanged(() => CustomerID);
                }
            }
        }

        public int EmployeeID
        {
            get => Model.EmployeeId;
            set
            {
                if (Model.EmployeeId != value)
                {
                    Model.EmployeeId = value;
                    OnPropertyChanged(() => EmployeeID);
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
                    Model.Description = value.Trim();
                    OnPropertyChanged(() => Description);
                }
            }
        }

        public RepairTicketViewModel() : base("Repair Ticket")
        {
        }
        public RepairTicketViewModel(int id) : base(id, "Repair Ticket")
        {
        }
    }
}
