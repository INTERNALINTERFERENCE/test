using RestService.Core.Dto;

namespace RestService.Core;

public interface IDataService
{
    Task<DataDto> GetData();
    Task<DataDto> CreateData();
}