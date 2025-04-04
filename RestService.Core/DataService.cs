using Microsoft.EntityFrameworkCore;
using RestService.Core.Converters;
using RestService.Core.Dto;
using RestService.Infrastructure;
using RestService.Infrastructure.Entities;

namespace RestService.Core;

public class DataService : IDataService
{
    private readonly RestDbContext _restDbContext;

    public DataService(RestDbContext restDbContext)
    {
        _restDbContext = restDbContext;
    }
    
    public async Task<IEnumerable<DataDto>> GetData(
        DataFilterDto? filter, 
        CancellationToken cancellationToken)
    {
        var query = _restDbContext.Set<DataEntity>().AsQueryable();
        
        if (filter?.CodeFrom != null)
            query = query.Where(entity => entity.Code >= filter.CodeFrom.Value);
        if (filter?.CodeTo != null)
            query = query.Where(entity => entity.Code <= filter.CodeTo.Value);
        if (!string.IsNullOrEmpty(filter?.Value))
            query = query.Where(entity => entity.Value != null && entity.Value.Contains(filter.Value));
        
        var entities = await query.ToListAsync(cancellationToken);
        return entities.Select(entity => entity.ToDto());
    }

    public async Task CreateData(IEnumerable<DataCreateDto> dtos, CancellationToken cancellationToken)
    { 
        var entities = dtos.Select(dto => dto.ToEntity());

        await _restDbContext.Set<DataEntity>().ExecuteDeleteAsync(cancellationToken);
        
        await _restDbContext.AddRangeAsync(entities, cancellationToken);
        await _restDbContext.SaveChangesAsync(cancellationToken);
    }
}