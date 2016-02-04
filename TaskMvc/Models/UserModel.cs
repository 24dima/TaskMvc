using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace TaskMvc.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public bool UserIsMe { get; set; }
        
    }
}