using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string CreatedDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароль підтвердженно невірно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}",
            ErrorMessage = "Невірний формат Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}",
            ErrorMessage = "Невірний формат Email")]
        [System.ComponentModel.DataAnnotations.Compare("Email",ErrorMessage = "Email підтвердженно невірно")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public string MiddleName { get; set; }


       
    }
}