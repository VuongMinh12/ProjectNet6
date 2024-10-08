﻿using System.Security.AccessControl;
using WebApplication3.Interfaces;
using WebApplication3.Models;
using Dapper;
using System.Data;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
            try
            {
                using (var con = _dapperContext.CreateConnection())
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@BrandName", brand.BrandName);
                    parameter.Add("@Description", brand.Description);
                    brand.BrandId = Convert.ToInt32(await con.ExecuteScalarAsync("AddBrand", parameter, commandType: CommandType.StoredProcedure));
                    return brand.BrandId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<Brand>> GetBrand( int PageNumber, int PageSize, string? BrandName, bool? IsActive)
        {
            try
            {
                
                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@PageNumber", PageNumber);
                    parameter.Add("@PageSize", PageSize);
                    parameter.Add("@BrandName", BrandName);
                    parameter.Add("@IsActive", IsActive);

                    var brands = await connection.QueryAsync<Brand>("GetBrand", parameter, commandType: CommandType.StoredProcedure);

                    return brands.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

         }

        public async Task<bool> UpdateBrand(Brand brand)
        {
            try
            {
                using (var con = _dapperContext.CreateConnection())
                {

                    var parameter = new DynamicParameters();
                    parameter.Add("@BrandName", brand.BrandName);
                    parameter.Add("@Description", brand.Description);
                    parameter.Add("@BrandId", brand.BrandId);

                    int rowsAffected = await con.ExecuteAsync("UpdateBrand", parameter, commandType: CommandType.StoredProcedure);
                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBrand(Brand brand)
        {
            using (var conn = _dapperContext.CreateConnection())
            {
                var parameter = new DynamicParameters();
                parameter.Add("@BrandId", brand.BrandId);

                int rowsAffected = await conn.ExecuteAsync("DeleteBrand", parameter, commandType: CommandType.StoredProcedure);
                return rowsAffected > 0;
            }
        }
    }
}
