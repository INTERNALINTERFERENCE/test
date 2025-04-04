using System.Text.Json;
using System.Text.Json.Serialization;
using RestService.Core.Dto;

namespace RestService.Core.Converters;

public class DataCreateDtoConverter : JsonConverter<DataCreateDto>
{
    public override DataCreateDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (root.ValueKind != JsonValueKind.Object)
            throw new JsonException("Expected an object.");
            
        var property = root.EnumerateObject().First();
        return new DataCreateDto
        {
            Code = int.TryParse(property.Name, out var code) ? code : 0,
            Value = property.Value.GetString()
        };
    }

    public override void Write(Utf8JsonWriter writer, DataCreateDto value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(value.Code?.ToString() ?? "", value.Value);
        writer.WriteEndObject();
    }
}