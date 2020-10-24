namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "PropertyImage")]
    public class PropertyImageDto: BaseEntity
    {
        [Required(ErrorMessage = "The field {0} is Mandatory")]
        public string ImageUrl { get; set; }

        public PropertyDto Property { get; set; }
    }
}
