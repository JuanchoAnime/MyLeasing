namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Property")]
    public class PropertyDto: BaseEntity
    {
        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(100, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public int SquareMeters { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public int Stratum { get; set; }

        public bool HasParkingLot { get; set; }

        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public PropertyTypeDto PropertyType { get; set; }

        public OwnerDto Owner { get; set; }

        public ICollection<PropertyImageDto> PropertiesImages { get; set; }

        public ICollection<ContractDto> Contracts { get; set; }
    }
}
