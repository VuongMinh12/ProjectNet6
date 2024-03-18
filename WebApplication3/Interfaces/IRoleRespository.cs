using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IRoleRespository
    {
        public Task<IEnumerable<Role>> GetAllRole();
        public Task<int> AddRole(Role role);
        public Task<bool> UpdateRole(Role role);
        public Task<bool> DeleteRole(int role);
    }
}
