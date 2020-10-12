using CheckerApp.Application.Documents.Queries;
using CheckerApp.Domain.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CheckerApp.Server.Common.JsonConverters
{
    public class CheckStatusConverter : JsonConverter<HardwareCheckStatusDto>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(HardwareCheckStatusDto).IsAssignableFrom(typeToConvert);

        public override HardwareCheckStatusDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                if (!jsonDocument.RootElement.TryGetProperty("HardwareType", out var typeProperty))
                {
                    throw new JsonException();
                }
                var type = (HardwareType)typeProperty.GetInt32();

                var jsonObject = jsonDocument.RootElement.GetRawText();

                return type switch
                {
                    HardwareType.Cabinet => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.FlowComputer => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.Flowmeter => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.Network => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.PLC => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.Pressure => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.Temperature => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    HardwareType.Valve => JsonSerializer.Deserialize<CabinetCheckStatusDto>(jsonObject),
                    _ => throw new NotSupportedException(),
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, HardwareCheckStatusDto value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value);
        }
    }
}
