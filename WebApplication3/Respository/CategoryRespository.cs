using Dapper;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using System.Data;

namespace WebApplication3.Respository
{
    public class CategoryRespository : ICategoryRespository
    {
        private readonly ICategoryRespository categoryRespository;
        private readonly DapperContext _dapperContext;
        public CategoryRespository (DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
       
        public async Task<int> AddCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException();
            using (var connec = _dapperContext.CreateConnection())
            {
                
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryName", category.CategoryName);

                await  connec.ExecuteAsync("AddCategory",parameter,commandType:CommandType.StoredProcedure);
                return category.CategoryId;

            }
        }

        public async Task<bool> DeleteCategory(int category)
        {
            if(category == null) throw new ArgumentNullException();
            using (var conn = _dapperContext.CreateConnection())
            {
                
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryId", category);

                int roweffected = await conn.ExecuteAsync("DeleteBrand",parameter, commandType:CommandType.StoredProcedure); 
                return roweffected >0;
                
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            using(var con =  _dapperContext.CreateConnection())
            {
                return await con.QueryAsync<Category>("GetAllCategory", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateCategory(Category category)
        {
           if (category == null) throw new ArgumentNullException();
           using (var con = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@CategoryName", category.CategoryName);
                parameter.Add("@IsActive", category.IsActive);
                parameter.Add("@CategoryId", category.CategoryId);

                int row = await con.ExecuteAsync("UpdateCategory",parameter,commandType:CommandType.StoredProcedure);   
                return row >0;
            }
        }
    }
}
