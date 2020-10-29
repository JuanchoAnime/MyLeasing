namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Contract")]
    public class ContractDto: BaseEntity
    {
        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public LesseeDto Lessee { get; set; }

        public PropertyDto Property { get; set; }

        public OwnerDto Owner { get; set; }
    }
}
