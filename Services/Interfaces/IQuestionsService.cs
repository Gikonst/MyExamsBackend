using MyExamsBackend.DTOs.QuestionDTOs;
using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IQuestionsService
    {
        public List<Question> GetAll();
        public Question GetById(int id);
        public bool Create(QuestionRequestDTO newQuestion);
        public bool Update(Question question);
        public bool Delete(int id);
    }
}
