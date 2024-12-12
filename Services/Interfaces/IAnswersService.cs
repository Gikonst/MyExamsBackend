using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IAnswersService
    {
        public List<Answer> GetAll();
        public Answer GetById(int id);
        public bool Create(Answer answer);
        public bool Update(Answer answer);
        public bool Delete(int id);

    }
}
