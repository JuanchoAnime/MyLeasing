namespace MyLeasing.Api.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Owner")]
    public class OwnerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Document { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string FixedPhone { get; set; }

        [MaxLength(20)]
        public string CellPhone { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
