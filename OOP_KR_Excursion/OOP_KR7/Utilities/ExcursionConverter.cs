namespace OOP_KR
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ExcursionConverter : JsonConverter<IExcursion>
    {
        public override IExcursion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader);
            var excursion = JsonSerializer.Deserialize<Excursion>(jsonObject.RootElement.GetRawText(), options);
            return excursion;
        }

        public override void Write(Utf8JsonWriter writer, IExcursion value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (Excursion)value, options);
        }
    }
}