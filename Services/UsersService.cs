using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
using MyExamsBackend.DTOs.CertificateDTOs;
using MyExamsBackend.DTOs.ExamDTOs;
using MyExamsBackend.DTOs.UserDTOs;
using MyExamsBackend.Models;
using MyExamsBackend.Services.Interfaces;

namespace MyExamsBackend.Services
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext _context;
        public UsersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var dbResult = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            if (dbResult != null)
            {
                _context.Users.Remove(dbResult);
                var DeleteResult = _context.SaveChanges();

                return DeleteResult > 0;
            }
            return false;
        }

        public List<User> GetAll()
        {
            var dbResults = _context.Users.ToList();

            return dbResults;
        }

        public UserResponseDTO GetById(int id)
        {
            var dbResult = _context.Users
                .Where(x => x.Id == id)
                .Include(c => c.Certificates)
                .ThenInclude(c => c.Exam)
                .FirstOrDefault();

            if (dbResult == null)
            {
                return null;
            }

            var userResponse = new UserResponseDTO
            {
                FirstName = dbResult.FirstName,
                LastName = dbResult.LastName,
                PassedCertificates = dbResult.Certificates
                .Where(c => c.IssuedDate != null)
                .Select(cert => new CertificateResponseUserDTO
                {
                    Id = cert.Id,
                    ExamId = cert.ExamId,
                    UserId = cert.UserId,
                    Exam = cert.Exam == null ? null : new ExamResponseCertificateDTO
                    {
                        Name = cert.Exam.Name,
                        ImageSrc = cert.Exam.ImageSrc,
                        Description = cert.Exam.Description,
                    },
                    Status = cert.Status,
                    IssuedDate = cert.IssuedDate

                }).
                ToList()

            };
            return userResponse;
        }

        public bool Update(UpdateUserRequestDTO updateUser)
        {
            var dbObject = _context.Users.AsNoTracking().Where(x => x.Id == updateUser.Id).FirstOrDefault();
            if (dbObject != null)
            {
                var user = new User
                {
                    Id = dbObject.Id,
                    FirstName = updateUser.FirstName,
                    LastName = updateUser.LastName,
                    Email = dbObject.Email,
                    Password = dbObject.Password,
                    Role = dbObject.Role,
                    Exams = dbObject.Exams,
                    Certificates = dbObject.Certificates
                };
                _context.Users.Update(user);
                var SaveResults = _context.SaveChanges();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
