using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RapidD.Data
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "required!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool? IsActive { get; set; }

        public List<ContactModel> ContactCollection { get; set; }
    }
}
