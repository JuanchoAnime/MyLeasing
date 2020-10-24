namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "PropertyType")]
    public class PropertyTypeDto : BaseEntity
    {
        [Required(ErrorMessage = "The field {0} is Mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0}  can not have more than {1} characteres")]
        public string Name { get; set; }

        public ICollection<PropertyDto> Properties { get; set; }
    }
}
