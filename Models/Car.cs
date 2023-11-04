using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarManagementEntity
{
    internal class Car
    {
        public int Id { get; set; }

        //Конвертирует Enum в строковое значение, когда сохраняет в json, а не int формат.
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumCarsBrands Brand {  get; set; }

        public string Model { get; set; }
    }
}
