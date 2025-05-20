using PatiNerde.Domain.Abtractions.Entities;

namespace PatiNerde.Domain.Entities;

public class BaseEntity : IBaseEntity
{
    public DateTime? CreationTime { get; set; }
    public DateTime? ModifiyTime { get; set; }
}
