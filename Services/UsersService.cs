﻿using Microsoft.EntityFrameworkCore;
using MyExamsBackend.Domain;
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
        public bool Create(User user)
        {
            _context.Users.Add(user);
            var changed = _context.SaveChanges();

            return changed > 0;
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

        public User GetById(int id)
        {
            var dbResult = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            return dbResult;
        }

        public bool Update(User user)
        {
            var dbObject = _context.Users.AsNoTracking().Where(x => x.Id == user.Id).FirstOrDefault();
            if (dbObject != null)
            {
                _context.Users.Update(user);
                var SaveResults = _context.SaveChanges();
                return SaveResults > 0;
            }
            return false;

        }
    }
}