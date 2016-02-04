using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByName(string userName);

        string GetUserNameByEmail(string email);
        MembershipUser GetMembershipUserByName(string userName);

        //Метод для сторення користувача
        void CreateUser(string userName, string password, string email, string firstName, string lastName,
                        string middleName);
        //Провірка правельності введення логіна і пароля
        bool ValidateUser(string userName, string password);
        //Метод для збереження користувача
        void SaveUser(User user);

        void DeleteUser(User user);
    }
}
