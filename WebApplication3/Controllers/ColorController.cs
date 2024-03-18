using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorRespository colorRespository;
        public ColorController(IColorRespository colorRespository)
        {
            this.colorRespository = colorRespository;
        }

        [HttpGet]
        public async Task<IEnumerable<Color>> GetAllColor()
        {
            var color = await colorRespository.GetAllColor();
            return color;
        }

        [HttpPost]
        public async Task<int> AddColor(Color color)
        {
            try
            {
                return await colorRespository.AddColor(color);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<bool> UpdateColor(Color color)
        {
            try
            {
                return await colorRespository.UpdateColor(color);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteColor (int id)
        {
            try
            {
                return await colorRespository.DeleteColor(id);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
