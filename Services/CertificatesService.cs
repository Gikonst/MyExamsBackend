using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class CertificatesService : ICertificatesService
    {
        private ApplicationDbContext _context;
        public CertificatesService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public bool Create(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            var changed = _context.SaveChanges();

            return changed > 0;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.Id == id).FirstOrDefault();

            if (dbResult != null)
            {
                _context.Certificates.Remove(dbResult);
                var deleteResult = _context.SaveChanges();
                
                return deleteResult > 0;
            }
            return false;
        }

        public List<Certificate> GetAll()
        {
            var dbResults = _context.Certificates.ToList();

            return dbResults;
        }

        public Certificate GetById(int id)
        {
            var dbResult = _context.Certificates.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(Certificate certificate)
        {
            var dbObject = _context.Certificates.AsNoTracking().Where(x => x.Id == certificate.Id).FirstOrDefault();

            if (dbObject != null)
            {
                _context.Certificates.Update(certificate);
                var saveResults = _context.SaveChanges();

                return saveResults > 0;
            }
            return false;
        }
    }
}
