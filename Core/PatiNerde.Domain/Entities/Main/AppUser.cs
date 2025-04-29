using System.ComponentModel.DataAnnotations;

namespace PatiNerde.Domain.Entities.Main
{
    public class AppUser : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public required string NickName { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public required string SurName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [MaxLength(50)]
        public required string Password { get; set; }
        public string PasswordSalt { get; set; }
        public required string Phone { get; set; }
        [MaxLength(50)]
        public required string Address { get; set; }
        [MaxLength(50)]
        public required string City { get; set; }
        public bool Active { get; set; }

    }
}
