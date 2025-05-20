namespace PatiNerde.Application.Features;

public class BaseResponse<TResponseDto>
{
    public string? Code { get; set; }= "200";
    public string? Title { get; set; } = "Başarılı";
    public int TotalCount { get; set; } = 0;
    public int Count { get; set; } = 0;
    public ICollection<TResponseDto>? Items { get; set; }
}
