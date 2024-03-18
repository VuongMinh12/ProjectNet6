using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.AccessControl;
using WebApplication3.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRespository categoryRespository;
        public CategoryController (ICategoryRespository respository)
        {
            categoryRespository = respository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            var category = await categoryRespository.GetAllCategory();
            return category;
        }

        [HttpPost]
        public async Task<int> AddCategory(Category category)
        {
            try
            {
                return await categoryRespository.AddCategory(category);
            }catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                return await categoryRespository.UpdateCategory(category);
            }catch(Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteCategory(int category)
        {
            try
            {
                return await categoryRespository.DeleteCategory(category);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
