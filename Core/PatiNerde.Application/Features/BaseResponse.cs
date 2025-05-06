namespace PatiNerde.Application.Features;

public class BaseResponse<TResponseDto>
{
    public string? Code { get; set; }
    public string? Title { get; set; }
    public int TotalCount { get; set; } = 0;
    public int Count { get; set; } = 0;
}
