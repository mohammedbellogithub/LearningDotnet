using LearningDotnet.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDotnet.Server.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

        }

        public async Task<Department> GetDepartmentByName(string departmentName)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentName == departmentName );    
        }
        public async Task<Department> AddDepartment(Department department)
        {
            var result = await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var result = await appDbContext.Departments
               .FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
            if (result != null)
            {
                appDbContext.Departments.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
