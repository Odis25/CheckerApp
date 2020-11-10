using CheckerApp.Shared.Enums;
using CheckerApp.Shared.Models.Software;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CheckerApp.Shared.Common.JsonConverters
{
    public class SoftwareConverter : JsonConverter<SoftwareVm>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(SoftwareVm).IsAssignableFrom(typeToConvert);

        public override SoftwareVm Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                if (!jsonDocument.RootElement.TryGetProperty("SoftwareType", out var typeProperty))
                {
                    throw new JsonException();
                }

                var type = (SoftwareType)typeProperty.GetInt32();

                var jsonObject = jsonDocument.RootElement.GetRawText();

                return type switch
                {
                    SoftwareType.SCADA => JsonSerializer.Deserialize<ScadaVm>(jsonObject),
                    SoftwareType.Other => JsonSerializer.Deserialize<SoftwareVm>(jsonObject),
                    _ => throw new NotSupportedException()
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, SoftwareVm value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value);
        }
    }

}
