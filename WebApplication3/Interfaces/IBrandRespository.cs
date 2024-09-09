using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IBrandRespository
    {
        public Task<IEnumerable<Brand>> GetBrand(int PageNumber, int PageSize , string? BrandName, bool? IsActive);
        public Task<int> AddBrand(Brand brand); 
        public Task<bool> UpdateBrand(Brand brand);
        public Task<bool> DeleteBrand(Brand brand);

    }
}
