using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RapidD.Data
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }

        [Required(ErrorMessage ="required!")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        [Required(ErrorMessage = "required!")]
        public string Password { get; set; }
                
    }
}
