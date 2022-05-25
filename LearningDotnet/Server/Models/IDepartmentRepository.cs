using LearningDotnet.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDotnet.Server.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int departmentId);
        Task<Department> GetDepartmentByName(string departmentName);

        Task<Department> AddDepartment(Department department);
        Task DeleteDepartment(int departmentId);
    }
}
