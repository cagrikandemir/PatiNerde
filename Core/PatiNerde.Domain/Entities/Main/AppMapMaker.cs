using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatiNerde.Domain.Entities.Main;

public class AppMapMaker : BaseEntity
{
    [Key]
    public int MapMakerId { get; set; }
    [ForeignKey(nameof(AppUser))]
    public required int CreateByUserId { get; set; }
    [MaxLength(50)]
    public required string Title { get; set; }
    [MaxLength(512)]
    public string? Description { get; set; }
    public required float Enlem { get; set; }
    public required float Boylam { get; set; }
    public bool IsActive { get; set; }
    public ICollection<AppUser>? AppUser { get; set; }

}
