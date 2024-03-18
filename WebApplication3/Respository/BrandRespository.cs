using System.Security.AccessControl;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using Dapper;
using System.Data;
using System.Reflection.Metadata;
namespace WebApplication3.Respository
{
    public class BrandRespository : IBrandRespository
    {
        private readonly IBrandRespository brandRespository;

        private readonly DapperContext _dapperContext;
        public BrandRespository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddBrand(Brand brand)
        {
            
            using (var con = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BrandName", brand.BrandName);
                parameter.Add("@Description", brand.Description);

                await con.ExecuteAsync("AddBrand", parameter, commandType: CommandType.StoredProcedure);
                return brand.BrandId;
            }
        }


        public async Task<IEnumerable<Brand>> GetAllBrand()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<Brand>("GetAllBrand", commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<bool> UpdateBrand(Brand brand)
        {
            
            using (var con = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BrandName", brand.BrandName);
                parameter.Add("@Description", brand.Description);
                parameter.Add("@IsActive", brand.IsActive);
                parameter.Add("@BrandId", brand.BrandId);

                int rowsAffected = await con.ExecuteAsync("UpdateBrand", parameter, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteBrand(int brand)
        {
            
            using (var conn = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BrandId", brand);

                int rowsAffected = await conn.ExecuteAsync("DeleteBrand", parameter, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}
