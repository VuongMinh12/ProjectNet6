using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using WebApplication3.Respository;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRespository roleRespository;

        public RoleController(IRoleRespository roleRespository)
        {
            this.roleRespository = roleRespository;
        }

        [HttpPost]
        public async Task<int> AddBrand(Role role)
        {
            try
            {
                return await roleRespository.AddRole(role);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Role>> GetAllRole()
        {
            var roles = await roleRespository.GetAllRole();
            return roles;
        }

        [HttpPut]
        public async Task<bool> UpdateBrand(Role role)
        {
            try
            {
                return await roleRespository.UpdateRole(role);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }


        }

        [HttpDelete]
        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                return await roleRespository.DeleteRole(id);
            }
            catch (Exception ex)
            {
              
                throw new Exception();
            }


        }
    }
}
