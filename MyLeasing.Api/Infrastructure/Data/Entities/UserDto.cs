namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class UserDto: IdentityUser
    {
        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(30, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Address { get; set; }
    }
}
