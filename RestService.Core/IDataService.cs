using RestService.Core.Dto;

namespace RestService.Core;

public interface IDataService
{
    Task<IEnumerable<DataDto>> GetData(
        DataFilterDto? filter,
        CancellationToken cancellationToken);
    
    Task CreateData(
        IEnumerable<DataCreateDto> dtos,
        CancellationToken cancellationToken);
}