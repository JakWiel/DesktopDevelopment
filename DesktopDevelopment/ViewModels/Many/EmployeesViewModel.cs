using DesktopDevelopment.Models;
using DesktopDevelopment.Models.Dtos;
using DesktopDevelopment.Models.Services;

namespace DesktopDevelopment.ViewModels.Many
{
    public class EmployeesViewModel : BaseManyViewModel<EmployeeService, EmployeeDto, Employee>
    {
        public EmployeesViewModel() : base("Employees")
        {
        }
    }
}
