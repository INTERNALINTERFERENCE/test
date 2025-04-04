using System.Text.Json;
using RestService.Core.Dto;
using RestService.Infrastructure.Entities;

namespace RestService.Core.Converters;

public static class DataConverter
{
    public static DataDto ToDto(this DataEntity entity)
    {
        return new DataDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Value = entity.Value
        };
    }
    
    public static DataEntity ToEntity(this DataCreateDto data)
    {
        return new DataEntity
        {
            Code = data.Code,
            Value = data.Value,
            CreatedAt = DateTime.UtcNow,
        };
    }
    
    public static IEnumerable<DataCreateDto> ToEntities(string json)
    {
        var rawData = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json) ?? [];
        
        foreach (var item in rawData)
        {
            var (key, value) = item.First();
            
            if (int.TryParse(key, out var code))
            {
                yield return new DataCreateDto
                {
                    Code = code,
                    Value = value
                };
            } 
        }
    }
}