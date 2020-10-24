namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Lessee")]
    public class LesseeDto: BaseEntity
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

        [MaxLength(20, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string FixedPhone { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string CellPhone { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Address { get; set; }

        public ICollection<ContractDto> Contracts { get; set; }
    }
}
