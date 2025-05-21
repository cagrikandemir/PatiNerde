using AutoMapper;
using MediatR;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerUpdateHandler : IRequestHandler<AppMapMarkerUpdateRequest, BaseResponse<AppMapMarkerUpdateResponse>>
{
    private readonly IAppMapMakerWrite _tableWrite;
    private readonly IMapper _mapper;
    public AppMapMarkerUpdateHandler(IAppMapMakerWrite tableWrite, IMapper mapper)
    {
        _tableWrite = tableWrite;
        _mapper = mapper;
    }
    public async Task<BaseResponse<AppMapMarkerUpdateResponse>> Handle(AppMapMarkerUpdateRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerUpdateResponse> response = new();
        response.Items=new List<AppMapMarkerUpdateResponse>();

        try
        {
            AppMapMarker appmapmarker = _mapper.Map<AppMapMarkerUpdateRequest, AppMapMarker>(request);
            await _tableWrite.UpdateAsync(appmapmarker);
            await _tableWrite.SaveAsync();

            if (appmapmarker != null)
                response.Items.Add(_mapper.Map<AppMapMarker, AppMapMarkerUpdateResponse>(appmapmarker));

        }
        catch (Exception ex )
        {
            
            response.Code = "500";
            response.Title = ex.Message;

        }
        response.Count = response.Items.Count;
        response.TotalCount = response.Items.Count;

        return await Task.FromResult(response);
    }
}
