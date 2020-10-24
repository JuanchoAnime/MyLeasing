namespace MyLeasing.Api.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Manager")]
    public class ManagerDto: BaseEntity
    {
        public UserDto User { get; set; }
    }
}
