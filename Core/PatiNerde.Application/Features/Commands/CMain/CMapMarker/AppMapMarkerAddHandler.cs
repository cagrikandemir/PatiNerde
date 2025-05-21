using AutoMapper;
using MediatR;
using PatiNerde.Application.Abtractions.IEntities.IMain;
using PatiNerde.Domain.Entities.Main;

namespace PatiNerde.Application.Features.Commands.CMain.CMapMarker;

public class AppMapMarkerAddHandler : IRequestHandler<AppMapMarkerAddRequest, BaseResponse<AppMapMarkerAddResponse>>
{
    private readonly IAppMapMakerWrite _tableWrite;
    private readonly IMapper _mapper;

    public AppMapMarkerAddHandler(IAppMapMakerWrite tableWrite, IMapper mapper)
    {
        _tableWrite = tableWrite;
        _mapper = mapper;
    }

    public async Task<BaseResponse<AppMapMarkerAddResponse>> Handle(AppMapMarkerAddRequest request, CancellationToken cancellationToken)
    {
        BaseResponse<AppMapMarkerAddResponse> response = new();
        response.Items=new List<AppMapMarkerAddResponse>();

        try
        {

            //AppMapMaker makers = await request.Select(x => _mapper.Map<AppMapMarker, AppMapMarkerResponse>(x)).ToListA();
            AppMapMarker maker = _mapper.Map<AppMapMarkerAddRequest, AppMapMarker>(request);
            AppMapMarker? addData = await _tableWrite.AddAsync(maker);

            if (addData != null)
            {
                response.Items.Add(_mapper.Map<AppMapMarker, AppMapMarkerAddResponse>(addData));
               await _tableWrite.SaveAsync();
                
            } 
        }
        catch (Exception ex)
        {

            response.Code = "500";
            response.Title = ex.Message;
        }
        response.Count = response.Items.Count;
        response.TotalCount = response.Items.Count;

        return response;


    }
}
