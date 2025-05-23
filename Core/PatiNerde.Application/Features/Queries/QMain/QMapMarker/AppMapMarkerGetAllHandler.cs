using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Queries.QMain.QMapMarker;

public class AppMapMarkerGetAllHandler : IRequestHandler<AppMapMarkerGetAllRequest, BaseResponse<AppMapMarkerGetAllResponse>>
{
    private readonly IAppMapMakerRead _tableRead;
    private readonly IMapper _mapper;
    public AppMapMarkerGetAllHandler(IAppMapMakerRead tableRead, IMapper mapper)
    {
        _tableRead = tableRead;
        _mapper = mapper;
    }

    public async Task<BaseResponse<AppMapMarkerGetAllResponse>> Handle(AppMapMarkerGetAllRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerGetAllResponse> response = new();
        response.Items = new List<AppMapMarkerGetAllResponse>();

        try
        {
            response.Items = await _tableRead.Table.Select(x => _mapper.Map<AppMapMarker, AppMapMarkerGetAllResponse>(x)).ToListAsync();
            response.Count = response.Items.Count;
            response.TotalCount = _tableRead.GetAll().Count();
        }
        catch (Exception ex)
        {
            response.Items=new List<AppMapMarkerGetAllResponse>();
            response.Code = "500";
            response.Title = ex.Message;
        }
       

        return response;
    }
}
