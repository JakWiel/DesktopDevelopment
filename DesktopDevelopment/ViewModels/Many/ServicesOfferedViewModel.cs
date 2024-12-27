using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class ServicesOfferedViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<ServicesOfferedDto> servicesOffered;
        public ObservableCollection<ServicesOfferedDto> ServicesOffered
        {
            get { return servicesOffered; }
            set
            {
                if (servicesOffered != value)
                {
                    servicesOffered = value;
                    OnPropertyChanged(() => ServicesOffered);
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

        public ServicesOfferedViewModel()
        {
            DisplayName = "Services Offered";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<ServicesOffered> serviceOffered = database.ServicesOffereds.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                serviceOffered = serviceOffered.Where(item => item.ServiceName.Contains(searchInput));
            }
            IQueryable<ServicesOfferedDto> serviceOfferedDto = serviceOffered.Select(item => new ServicesOfferedDto()
            {
                Id = item.ServiceId,
                ServiceName = item.ServiceName,
                Description = item.Description,
                Price = item.Price
            });

            ServicesOffered = new ObservableCollection<ServicesOfferedDto>(serviceOfferedDto.ToList());
        }
    }
}
