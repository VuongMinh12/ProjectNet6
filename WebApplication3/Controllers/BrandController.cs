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
        public async Task<IEnumerable<Brand>> GetBrand(BrandSearch brand)
        {
            var brands = await brandRespository.GetBrand(brand);
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

                throw new Exception(ex.Message);
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

                throw new Exception(ex.Message);
            }


        }

        [HttpDelete]
        public async Task<bool> DeleteBrand(Brand id)
        {
            try
            {
                return await brandRespository.DeleteBrand(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
