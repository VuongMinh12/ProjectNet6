using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface ICategoryRespository
    {
        public Task<IEnumerable<Category>> GetAllCategory();
        public Task<int> AddCategory(Category category);
        public Task<bool> UpdateCategory(Category category);
        public Task<bool> DeleteCategory(int category);
    }
}
