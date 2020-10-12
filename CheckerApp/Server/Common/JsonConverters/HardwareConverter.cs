﻿using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CheckerApp.Server.Common.JsonConverters
{
    public class HardwareConverter : JsonConverter<HardwareVm>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(HardwareVm).IsAssignableFrom(typeToConvert);

        public override HardwareVm Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                if(!jsonDocument.RootElement.TryGetProperty("HardwareType", out var typeProperty))
                {
                    throw new JsonException();
                }
                var type = (HardwareType)typeProperty.GetInt32();

                var jsonObject = jsonDocument.RootElement.GetRawText();

                return type switch
                {
                    HardwareType.Cabinet => JsonSerializer.Deserialize<CabinetVm>(jsonObject),
                    HardwareType.FlowComputer => JsonSerializer.Deserialize<FlowComputerVm>(jsonObject),
                    HardwareType.Flowmeter => JsonSerializer.Deserialize<FlowmeterVm>(jsonObject),
                    HardwareType.Network => JsonSerializer.Deserialize<NetworkHardwareVm>(jsonObject),
                    HardwareType.PLC => JsonSerializer.Deserialize<PLCVm>(jsonObject),
                    HardwareType.Pressure => JsonSerializer.Deserialize<PressureVm>(jsonObject),
                    HardwareType.Temperature => JsonSerializer.Deserialize<TemperatureVm>(jsonObject),
                    HardwareType.Valve => JsonSerializer.Deserialize<ValveVm>(jsonObject),
                    _ => throw new NotSupportedException(),
                };
            }
        }

        public override void Write(Utf8JsonWriter writer, HardwareVm value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value);
        }
    }
}