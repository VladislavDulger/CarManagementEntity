using Newtonsoft.Json;

namespace CarManagementEntity
{
    public static class JsonFileManager
    {
        internal static void SaveToJson(List<Car> cars, string fileName)
        {
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        internal static List<Car> LoadFromJson(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<Car>>(json);
            }
            return new List<Car>();
        }
    }
}

