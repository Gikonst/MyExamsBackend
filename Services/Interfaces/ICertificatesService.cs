using MyExamsBackend.Models;

namespace MyExamsBackend.Services.Interfaces
{
    public interface ICertificatesService
    {
        public List<Certificate> GetAll();
        public Certificate GetById(int id);
        public bool Create(Certificate certificate);
        public bool Update(Certificate certificate);
        public bool Delete(int id);
    }
}
