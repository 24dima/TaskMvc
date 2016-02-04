using System.Collections.Generic;
using Domain.Entities;

namespace Web.Models
{
    public class UserViewModel
    {
        //Користувач
        public User User { get; set; }

        //Визиваючий користувач - я сам!
        public bool UserIsMe { get; set; }
        
    }
}