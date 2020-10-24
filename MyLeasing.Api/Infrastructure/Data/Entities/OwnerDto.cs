namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Owner")]
    public class OwnerDto: BaseEntity
    {
        public UserDto User { get; set; }

        public ICollection<PropertyDto> Properties { get; set; }

        public ICollection<ContractDto> Contracts { get; set; }
    }
}
