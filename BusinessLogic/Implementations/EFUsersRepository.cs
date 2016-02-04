using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EFUsersRepository : IUsersRepository
    {
        private EFDbContext context;
        public EFUsersRepository(EFDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByName(string userName)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public MembershipUser GetMembershipUserByName(string userName)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null)
            {
                return new MembershipUser(
                    "CustomMembershipProvider",
                    user.UserName,
                    user.Id,
                    user.Email,
                    "",
                    null,
                    true,
                    false,
                    user.CreatedDate,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now,
                    DateTime.Now
                    );
            }
            return null;
        }

        public string GetUserNameByEmail(string email)
        {
            User user = context.Users.FirstOrDefault(x => x.Email == email);
            return user != null ? user.UserName : "";
        }

        public void CreateUser(string userName, string password, string email, string firstName, string lastName, string middleName)
        {
            User user = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                CreatedDate = DateTime.Now,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            };
            SaveUser(user);
        }

        public bool ValidateUser(string userName, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null && user.Password == password)
                return true;
            return false;
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            else
                context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }


        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}