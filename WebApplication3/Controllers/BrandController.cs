using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRespository brandRespository;
        public BrandController(IBrandRespository brandRespository)
        {
            this.brandRespository = brandRespository;
        }

        [HttpGet]
        public async Task<IEnumerable<Brand>> GetAllBrand()
        {
            var brands = await brandRespository.GetAllBrand();
            return brands;
        }

        [HttpPost]
        public async Task<int> AddBrand(Brand brand)
        {
            try
            {
                return await brandRespository.AddBrand(brand);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<bool> UpdateBrand(Brand brand)
        {
            try
            {
                return await brandRespository.UpdateBrand(brand);
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
                return await brandRespository.DeleteBrand(id);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }

        }
    }
}
