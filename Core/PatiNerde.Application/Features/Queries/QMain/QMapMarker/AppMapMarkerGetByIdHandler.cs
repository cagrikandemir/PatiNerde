using AutoMapper;
using MediatR;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Queries.QMain.QMapMarker;

public class AppMapMarkerGetByIdHandler : IRequestHandler<AppMapMarkerGetByIdRequest, BaseResponse<AppMapMarkerGetByIdResponse>>
{
    private readonly IAppMapMakerRead _tableRead;
    private readonly IMapper _mapper;

    public AppMapMarkerGetByIdHandler(IMapper mapper, IAppMapMakerRead tableRead)
    {
        _mapper = mapper;
        _tableRead = tableRead;
    }

    public async Task<BaseResponse<AppMapMarkerGetByIdResponse>> Handle(AppMapMarkerGetByIdRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerGetByIdResponse> response = new();
        response.Items = (await _tableRead.FindListByIdAsync(request.MapMakerId)).
            Select(x => _mapper.Map<AppMapMarker, AppMapMarkerGetByIdResponse>(x)).ToList();
        
        response.Count = response.Items.Count;
        response.TotalCount=_tableRead.GetAll().Count();

        return await Task.FromResult(response);
    }
}
