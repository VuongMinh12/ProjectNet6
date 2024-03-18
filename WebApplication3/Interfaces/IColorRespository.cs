using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IColorRespository
    {
        public Task<IEnumerable<Color>> GetAllColor();
    }
}
