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

        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (dbResult != null)
            {
                _context.Users.Remove(dbResult);
                var DeleteResult = await _context.SaveChangesAsync();

                return DeleteResult > 0;
            }
            return false;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var dbResults = await _context.Users.ToListAsync();

            return dbResults;
        }

        public async Task<UserResponseDTO> GetByIdAsync(int id)
        {
            var dbResult = await _context.Users
                .Where(x => x.Id == id)
                .Include(c => c.Certificates)
                .ThenInclude(c => c.Exam)
                .FirstOrDefaultAsync();

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

        public async Task<bool> UpdateAsync(UpdateUserRequestDTO updateUser)
        {
            var dbObject = await _context.Users.AsNoTracking().Where(x => x.Id == updateUser.Id).FirstOrDefaultAsync();
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
                var SaveResults = await _context.SaveChangesAsync();
                return SaveResults > 0;
            }
            return false;

        }
    }
}
