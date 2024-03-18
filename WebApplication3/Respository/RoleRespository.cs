using Dapper;
using System.Data;
using System.Drawing.Drawing2D;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Respository
{
    public class RoleRespository : IRoleRespository
    {
        private readonly IRoleRespository roleRespository;
        private readonly DapperContext _dapperContext;
        public RoleRespository (DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<int> AddRole(Role role)
        {
            
            using (var con = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@RoleName", role.RoleName);

                await con.ExecuteAsync("AddRole", parameter, commandType: CommandType.StoredProcedure);
  
                return role.RoleId;
            }
        }

        public async Task<bool> DeleteRole(int role)
        {
           
            using (var conn = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BrandId", role);

                int rowsAffected = await conn.ExecuteAsync("DeleteRole", parameter, commandType: CommandType.StoredProcedure); 
                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<Role>("GetAllRole", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateRole(Role role)
        {
            
            using (var con = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@RoleName", role.RoleName);
                parameter.Add("@IsActive", role.IsActive);
                parameter.Add("@RoleId", role.RoleId);

                int rowsAffected = await con.ExecuteAsync("UpdateBrand", parameter, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}
