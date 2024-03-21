using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IBrandRespository
    {
        public Task<IEnumerable<Brand>> GetBrand(BrandSearch brand);
        public Task<int> AddBrand(Brand brand);
        public Task<bool> UpdateBrand(Brand brand);
        public Task<bool> DeleteBrand(Brand brand);

    }
}
