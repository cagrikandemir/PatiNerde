using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerRemoveHandler : IRequestHandler<AppMapMarkerRemoveRequest, BaseResponse<AppMapMarkerRemoveResponse>>
{
    private readonly IAppMapMakerWrite _tableWrite;
    private readonly IMapper _mapper;
    public AppMapMarkerRemoveHandler(IAppMapMakerWrite tableWrite, IMapper mapper)
    {
        _tableWrite = tableWrite;
        _mapper = mapper;
    }

    public async Task<BaseResponse<AppMapMarkerRemoveResponse>> Handle(AppMapMarkerRemoveRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerRemoveResponse> response = new();
        response.Items = new List<AppMapMarkerRemoveResponse>();
        try
        {
            AppMapMarker appMapMarker= _mapper.Map<AppMapMarkerRemoveRequest,AppMapMarker>(request);
            await _tableWrite.RemoveAsync(appMapMarker);
            await _tableWrite.SaveAsync();
            response.Items.Add(_mapper.Map<AppMapMarker, AppMapMarkerRemoveResponse>(appMapMarker));

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
