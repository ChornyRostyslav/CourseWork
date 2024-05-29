namespace OOP_KR
{
    using System.Text.Json;

    public static class SerializationHelper
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Converters =
        {
            new ExcursionConverter()
        },
            WriteIndented = true
        };

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, options);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static List<IExcursion> DeserializeExcursions(string json)
        {
            var excursions = JsonSerializer.Deserialize<List<Excursion>>(json, options);
            return excursions.Cast<IExcursion>().ToList();
        }
    }
}