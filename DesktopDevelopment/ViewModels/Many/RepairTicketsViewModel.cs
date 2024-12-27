using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class RepairTicketsViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<RepairTicketDto> repairTickets;
        public ObservableCollection<RepairTicketDto> RepairTickets
        {
            get { return repairTickets; }
            set
            {
                if (repairTickets != value)
                {
                    repairTickets = value;
                    OnPropertyChanged(() => RepairTickets);
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

        public RepairTicketsViewModel()
        {
            DisplayName = "Repair Tickets";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<RepairTicket> category = database.RepairTickets.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                category = category.Include(item => item.Customer).Where(item => item.Customer.FullName.Contains(searchInput));
            }
            IQueryable<RepairTicketDto> repairTicketDto = category.Select(item => new RepairTicketDto()
            {
                Id = item.RepairTicketId,
                CustomerID = item.CustomerId,
                EmployeeID = item.EmployeeId,
                Description = item.Description
            });

            RepairTickets = new ObservableCollection<RepairTicketDto>(repairTicketDto.ToList());
        }
    }
}
