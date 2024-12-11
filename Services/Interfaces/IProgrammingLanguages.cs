using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface IProgrammingLanguagesService
    {
        public List<ProgrammingLanguage> GetAll();
        public ProgrammingLanguage GetById(int id);
        public bool Create(ProgrammingLanguage programmingLanguage);
        public bool Update(ProgrammingLanguage programmingLanguage);
        public bool Delete(int id);
    }
}

