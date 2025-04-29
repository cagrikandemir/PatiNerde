namespace PatiNerde.Domain.Abtractions.Entities;

public interface IBaseEntity
{
    public DateTime? CreationTime { get; set; }
    public DateTime? ModifiyTime { get; set; }
}
