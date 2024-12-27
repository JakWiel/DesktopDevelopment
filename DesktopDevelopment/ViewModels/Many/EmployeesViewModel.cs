using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Contexts;
using DesktopDevelopment.Models.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopDevelopment.ViewModels.Many
{
    public class EmployeesViewModel : WorkspaceViewModel
    {
        public DatabaseContext database { get; set; }
        private ObservableCollection<EmployeeDto> employee;
        public ObservableCollection<EmployeeDto> Employee
        {
            get { return employee; }
            set
            {
                if (employee != value)
                {
                    employee = value;
                    OnPropertyChanged(() => Employee);
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

        public EmployeesViewModel()
        {
            DisplayName = "Employees";
            Initialize();
        }
        public void Initialize()
        {
            database = new DatabaseContext();
            IQueryable<Employee> employee = database.Employees.Where(item => item.IsActive);

            if (!string.IsNullOrEmpty(searchInput))
            {
                employee = employee.Where(item => item.FullName.Contains(searchInput));
            }
            IQueryable<EmployeeDto> employeeDto = employee.Select(item => new EmployeeDto()
            {
                FullName = item.FullName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Role = item.RoleId
            });

            Employee = new ObservableCollection<EmployeeDto>(employeeDto.ToList());
        }
    }
}
