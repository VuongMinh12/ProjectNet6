using WebApplication3.Models;

namespace WebApplication3.Interfaces
{
    public interface IQuanlityRespository
    {
        public Task<IEnumerable<Quanlity>> GetAllQuanlity();
        public Task<int> AddQuanlity(Quanlity quanlity);
        public Task<bool> UpdateQuanlity(Quanlity quanlity);
        public Task<bool> DeleteQuanlity(int Id);

    }
}
