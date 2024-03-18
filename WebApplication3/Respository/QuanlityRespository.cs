using Dapper;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using System.Data;
namespace WebApplication3.Respository
{
    public class QuanlityRespository : IQuanlityRespository
    {
        private readonly IQuanlityRespository quanlityRespository;
        private readonly DapperContext dappercontext;
        public QuanlityRespository(IQuanlityRespository quanlityRespository, DapperContext dappercontext)
        {
            this.quanlityRespository = quanlityRespository;
            this.dappercontext = dappercontext;
        }

        public async Task<int> AddQuanlity(Quanlity quanlity)
        {
            using (var con = dappercontext.CreateConnection())
            {
                
                var parameter = new DynamicParameters();
                parameter.Add("@QuanlityName", quanlity.QuanlityName);

                return await con.ExecuteAsync("AddQuanlity", parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<bool> DeleteQuanlity(int id)
        {
            
            using (var con = dappercontext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@QuanlityId", id);

                var del = await con.ExecuteAsync("DeleteQuanlity",parameter, commandType: CommandType.StoredProcedure);
                return del > 0;
            }
        }

        public async Task<IEnumerable<Quanlity>> GetAllQuanlity()
        {
            using (var con = dappercontext.CreateConnection()) {
                return await con.QueryAsync<Quanlity>("GetAllQuanlity", commandType: CommandType.StoredProcedure);
            }
            
        }

        public async Task<bool> UpdateQuanlity(Quanlity quanlity)
        {
            
            using (var con = dappercontext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@QuanlityName",quanlity.QuanlityName);
                parameter.Add("@IsActive", quanlity.IsActive);
                parameter.Add("@QuanlityId", quanlity.QuanlityId);

                var update = await con.ExecuteAsync("UpdateQuanlity",parameter,commandType: CommandType.StoredProcedure);   
                return update > 0;
            }
        }
    }
}
