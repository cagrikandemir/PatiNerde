using System.ComponentModel.DataAnnotations;

namespace PatiNerde.Domain.Entities.Main
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        public required string NickName { get; set; }
        public required string Name { get; set; }
        public required string SurName { get; set; }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public string PasswordSalt { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string City { get; set; }
        public bool Active { get; set; }

    }
}
