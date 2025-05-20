using AutoMapper;
using MediatR;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerHandler : IRequestHandler<AppMapMarkerRequest, BaseResponse<AppMapMarkerResponse>>
{
    private readonly IAppMapMakerWrite _tableWrite;
    private readonly IMapper _mapper;

    public AppMapMarkerHandler(IAppMapMakerWrite tableWrite, IMapper mapper)
    {
        _tableWrite = tableWrite;
        _mapper = mapper;
    }

    public async Task<BaseResponse<AppMapMarkerResponse>> Handle(AppMapMarkerRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerResponse> response = new();
        response.Items=new List<AppMapMarkerResponse>();

        try
        {

            //AppMapMaker makers = await request.Select(x => _mapper.Map<AppMapMarker, AppMapMarkerResponse>(x)).ToListA();
            AppMapMaker maker = _mapper.Map<AppMapMarkerRequest, AppMapMaker>(request);
            AppMapMaker? addData = await _tableWrite.AddAsync(maker);

            if (addData != null)
            {
                response.Items.Add(_mapper.Map<AppMapMaker, AppMapMarkerResponse>(addData));
                response.Count = response.Items.Count;
                response.TotalCount = response.Items.Count;
            }
            else
            {
                response.Code = "500";
                response.Title = "Hata";
            }
        }
        catch (Exception)
        {

            throw;
        }

        return response;
    }
}
