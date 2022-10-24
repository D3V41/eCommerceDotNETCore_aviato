using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace rest.Models
{
    internal sealed class JsonToByteArrayConverter : JsonConverter<byte[]?>
    {
        public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!reader.TryGetBytesFromBase64(out byte[]? result) || result == default)
            {
                throw new Exception("");
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, byte[]? value, JsonSerializerOptions options)
        {
            writer.WriteBase64StringValue(value);
        }
    }
}