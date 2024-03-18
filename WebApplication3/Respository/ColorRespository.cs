using Dapper;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using System.Data;

namespace WebApplication3.Respository
{
    public class ColorRespository : IColorRespository
    {
        private readonly DapperContext dapperContext;
        private readonly IColorRespository colorRespository;
        public ColorRespository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
            
        }

        public async Task<int> AddColor(Color color)
        {
            using (var con = dapperContext.CreateConnection())
            {
                var para = new DynamicParameters();
                para.Add("@ColorName",color.ColorName);

                await con.ExecuteAsync("AddColor",para,commandType:CommandType.StoredProcedure);
                return color.ColorId;
            }
        }

        public async Task<bool> DeleteColor(int id)
        {
            using (var conn = dapperContext.CreateConnection())
            {
                var para = new DynamicParameters();
                para.Add("@ColorId", id);

                var rowchange = await conn.ExecuteAsync("DeleteColor", para, commandType: CommandType.StoredProcedure);
                return rowchange > 0;
            }
        }

        public async Task<IEnumerable<Color>> GetAllColor()
        {
            using (var con = dapperContext.CreateConnection())
            {
                return await con.QueryAsync<Color>("GetAllColor",commandType:CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateColor(Color color)
        {
            using (var conn = dapperContext.CreateConnection())
            {
                var para = new DynamicParameters();
                para.Add("@ColorName", color.ColorName);
                para.Add("@IsActive", color.IsActive);
                para.Add("@ColorId", color.ColorId);

                var rowchange = await conn.ExecuteAsync("UpdateColor", para, commandType: CommandType.StoredProcedure);
                return rowchange > 0;
            }
        }
    }
}
