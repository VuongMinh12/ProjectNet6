using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IColorRespository
    {
        public Task<IEnumerable<Color>> GetAllColor();
        public Task<int> AddColor(Color color);
        public Task<bool> UpdateColor(Color color);
        public Task<bool> DeleteColor(int id);
    }
}
