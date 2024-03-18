using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanlityController : ControllerBase
    {
        private IQuanlityRespository quanlityRespository;
        public QuanlityController( IQuanlityRespository quanlityRespository)
        {
            this.quanlityRespository = quanlityRespository;
        }

        [HttpGet]
        public async Task<IEnumerable<Quanlity>> GetAllQuanlity()
        {
            var quanlity = await quanlityRespository.GetAllQuanlity();
            return quanlity;
        }

        [HttpPost]
        public async Task<int> AddQuanlity(Quanlity quanlity)
        {
            try
            {
                return await quanlityRespository.AddQuanlity(quanlity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        public async Task<bool> UpdateQuanlity(Quanlity quanlity)
        {
            try
            {
                return await quanlityRespository.UpdateQuanlity(quanlity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteQuanlity(int id)
        {
            try
            {
                return await quanlityRespository.DeleteQuanlity(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
