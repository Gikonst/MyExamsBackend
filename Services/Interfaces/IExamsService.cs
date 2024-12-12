using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IExamsService
    {
        public List<Exam> GetAll();
        public Exam GetById(int id);
        public bool Create(Exam exam);
        public bool Update(Exam exam);
        public bool Delete(int id);
    }
}
